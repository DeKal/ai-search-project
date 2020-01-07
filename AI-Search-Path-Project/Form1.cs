using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using GMap.NET;
using GMap.NET.MapProviders;
using System.Diagnostics;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using AI_Search_Path_Project.Properties;
using IronPython.Runtime;
using System.IO;
using System.Timers;

namespace AI_Search_Path_Project
{
    public partial class Form1 : Form
    {

        private ScriptEngine m_engine = Python.CreateEngine();
        private GMapOverlay markersOverlay = new GMapOverlay("markers");
        private GMapOverlay polyOverlay = new GMapOverlay("polygons");
        private List<MPoint> location = new List<MPoint>();
        private List<GMapMarker> markers = new List<GMapMarker>();
        private List<Route> routes = new List<Route>();
        private ListPlace lPlace = new ListPlace();
        private List<Step> steps = new List<Step>();
        
        private int current_step = 0;
        private dynamic shortest_path;

        public Form1()
        {
            InitializeComponent();

            // init map
            gMapMain.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            gMapMain.SetPositionByKeywords("Việt Nam");
            gMapMain.ShowCenter = false;
            lPlace.AddMap(gMapMain);
            
        }
       

        
        //dynamically create new label
        private Label CreateNewLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            return label;
        }
        //dynamically create new textbox
        private TextBox CreateNewTextBox(string text)
        {
            TextBox tb = new TextBox();
            tb.Text = text;
            tb.Dock = System.Windows.Forms.DockStyle.Fill;
            tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            return tb;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tb_timer.Visible = false;
            LoadPythonAlgo();
            LoadTableRoute();
            LoadTablePlaces();
            LoadBoard();
            LoadFSM();
        }

        private void LoadPythonAlgo()
        {
            var scope = m_engine.Runtime.CreateScope();

            string code = System.Text.Encoding.UTF8.GetString(Resources._420);
            m_engine.Execute(code, scope);

            // get function and dynamically invoke


            shortest_path = scope.GetVariable("shortest_path");

        }

        private void LoadBoard()
        {
            Label think = CreateNewLabel("");
            think.Font = new Font("Arial", 11F);

            tableBoard.Controls.Add(CreateTitleLabel("Think"), 0, 0);
            tableBoard.Controls.Add(think, 1, 0);

            Label open = CreateNewLabel("");
            open.Font = new Font("Arial", 11F);
            tableBoard.Controls.Add(CreateTitleLabel("Open"), 0, 1);
            tableBoard.Controls.Add(open, 1, 1);

            Label close = CreateNewLabel("");
            close.Font = new Font("Arial", 11F);
            tableBoard.Controls.Add(CreateTitleLabel("Close"), 0, 2);
            tableBoard.Controls.Add(close, 1, 2);

            Label result = CreateNewLabel("");
            result.Font = new Font("Arial", 11F);
            tableBoard.Controls.Add(CreateTitleLabel("Result"), 0, 3);
            tableBoard.Controls.Add(result, 1, 3);

            Step.AddMap(gMapMain);
            Step.AddMarkersArray(markers);
            Step.AddDisplayControl(think, open, close, result);
        }

        private Label CreateTitleLabel(string text)
        {
            Label lb = CreateNewLabel(text);
            lb.Font = new Font("Arial", 11F, FontStyle.Bold);
            return lb;
        }
        private void LoadTableRoute()
        {
            //style for header
            RowStyle style = new RowStyle(SizeType.Absolute, 50F);
            tableRoute.RowStyles.Clear();
            tableRoute.RowStyles.Add(style);

            tableRoute.Controls.Add(CreateNewLabel("Place 1"), 0 /* Column Index */, 0 /* Row index */);
            tableRoute.Controls.Add(CreateNewLabel("Place 2"), 1 /* Column Index */, 0 /* Row index */);
            tableRoute.Controls.Add(CreateNewLabel("Weight"), 2 /* Column Index */, 0 /* Row index */);

            //style for content
            style = new RowStyle(SizeType.Absolute, 35F);
            tableRoute.RowStyles.Clear();
            tableRoute.RowStyles.Add(style);
            tableRoute.Controls.Add(CreateDeleteButton(1), 3 /* Column Index */, 1 /* Row index */);

            Route.AddMap(location, polyOverlay, markersOverlay, gMapMain);
            gMapMain.Overlays.Add(polyOverlay);
            routes.Add(new Route(tableRoute, addNewRouteRow));
            
        }
        private void addNewRouteRow(object sender, EventArgs e)
        {
            tableRoute.Controls.Add(CreateDeleteButton(tableRoute.RowCount), 3 /* Column Index */, tableRoute.RowCount /* Row index */);
            routes[routes.Count - 1].RemoveEvent();
            routes.Add(new Route(tableRoute, addNewRouteRow));
        }

        private Button CreateDeleteButton(int index)
        {

            Button btn = new Button();
            btn.Dock = System.Windows.Forms.DockStyle.Top;
            btn.GotFocus += FocusNextRow;
            btn.Text = "X";
            btn.Click += removeRow;
            btn.Tag = index - 1;
            return btn;
        }

        private void FocusNextRow(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = (int)btn.Tag;
            tableRoute.GetControlFromPosition(0, index+1).Focus();
        }

        private void removeRow(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            routes[(int)btn.Tag].RemoveRoute();
            routes[(int)btn.Tag].RemoveEvent();
            routes.RemoveAt((int)btn.Tag);
            int row_index_to_remove = (int)btn.Tag + 1;
            

            // delete all controls of row that we want to delete
            for (int i = 0; i < tableRoute.ColumnCount; i++)
            {
                var control = tableRoute.GetControlFromPosition(i, row_index_to_remove);
                //we know control must be label or textbox
                control.Text = "";
                tableRoute.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            for (int i = row_index_to_remove + 1; i < tableRoute.RowCount; i++)
            {
                for (int j = 0; j < tableRoute.ColumnCount; j++)
                {
                    var control = tableRoute.GetControlFromPosition(j, i);
                    tableRoute.SetRow(control, i - 1);
                    if (j == tableRoute.ColumnCount - 1)
                        control.Tag = (int)control.Tag - 1;
                }
            }

            // remove last row
            tableRoute.RowCount--;

        }

        private void LoadTablePlaces()
        {
            //style for header
            RowStyle style = new RowStyle(SizeType.Absolute, 50F);
            tablePlaces.RowStyles.Clear();
            tablePlaces.RowStyles.Add(style);

            tablePlaces.Controls.Add(CreateNewLabel("Id"), 0 /* Column Index */, 0 /* Row index */);
            tablePlaces.Controls.Add(CreateNewLabel("Name"), 1 /* Column Index */, 0 /* Row index */);
            tablePlaces.Controls.Add(CreateNewLabel("h"), 2 /* Column Index */, 0 /* Row index */);
            //style for content
            style = new RowStyle(SizeType.Absolute, 35F);
            tablePlaces.RowStyles.Clear();
            tablePlaces.RowStyles.Add(style);
            gMapMain.Overlays.Add(markersOverlay);
            
            Place.SetMap(gMapMain);
        }

        private void gMapMain_Click(object sender, EventArgs e)
        {
            MouseEventArgs E = (MouseEventArgs)e;
            //If left click
            if (E.Button == MouseButtons.Left)
            {
                //location on map
                double lat = gMapMain.FromLocalToLatLng(E.X, E.Y).Lat;
                double lng = gMapMain.FromLocalToLatLng(E.X, E.Y).Lng;

                //keep the position of marker on map
                location.Add(new MPoint(lat,lng));

                
                PointLatLng point = gMapMain.FromLocalToLatLng(E.X, E.Y);

                Place p = new Place(tablePlaces.RowCount++, point);
                lPlace.Add(p);
                
                markersOverlay.Markers.Add(p.Marker);

                // add new place row
                AddPlaceRow(p);
                //add new marker to list
                markers.Add(p.Marker);
            }
        }

        private void AddPlaceRow(Place p)
        {
            int rowIndex = tablePlaces.RowCount;
            
            tablePlaces.SuspendLayout();
            tablePlaces.Controls.Add(p.Id, 0, rowIndex);
            tablePlaces.Controls.Add(p.Name, 1, rowIndex);
            tablePlaces.Controls.Add(p.H, 2, rowIndex);
            tablePlaces.ResumeLayout();
        }

        private void start_cb_Click(object sender, EventArgs e)
        {
            
            start_cb.DataSource = createNewPlaceNameSource();
        }

        private BindingSource createNewPlaceNameSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = lPlace.GetListOfPlaceName();
            return bs;
        }

        private void end_cb_Click(object sender, EventArgs e)
        {
            end_cb.DataSource = createNewPlaceNameSource();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            //Clear all previous step
            steps.Clear();
            //reset all lable result
            Step.Reset();
            //set back the step
            current_step = 0;
            //reset all marker text
            lPlace.Reset();

            if (Autos.Visible == false)
            {
                Autos.Visible = true;
                next_btn.Visible = true;
                prev_btn.Visible = true;
            }

            //create input file
            CreateInputFile("input.txt");

            int algo_index = algo_cb.SelectedIndex;
            var result = shortest_path("input.txt", algo_index); // returns 42 (Int32)

            foreach (var obj in result)
            {
                Step step = new Step(obj);
                steps.Add(step);
            }

            RunStep(0);
            panel2.Visible = true;
        }

        public void Swap(List<List<string>> list, int indexA, int indexB)
        {
            List<string> tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        private List<List<string>> GetDataFromInterface()
        {
            List<List<string>> listData = lPlace.GetPlaceData();
            foreach (Route item in routes)
            {
                List<string> info = item.GetInfo();
                if (info[0] != "")
                {
                    var index = Place.GetPlace(info[0]) - 1;
                    if (index >= 0)
                    {
                        listData[index].Add(info[1]);
                        listData[index].Add(info[2]);
                    }

                    index = Place.GetPlace(info[1]) - 1;
                    if (index >= 0)
                    {
                        listData[index].Add(info[0]);
                        listData[index].Add(info[2]);
                    }
                }
            }

            int start = start_cb.SelectedIndex;
            int end = end_cb.SelectedIndex;
            Swap(listData, start, 0);
            Swap(listData, end, 1);
            return listData;
        }
        private void CreateInputFile(string file_name)
        {
                        
            var listData = GetDataFromInterface();
            // Create a new file 
            using (StreamWriter outputFile = new StreamWriter("input.txt"))
            {
                foreach(var row in listData)
                {
                    foreach (var item in row)
                        outputFile.Write(item + " ");
                    outputFile.WriteLine("");
                }
    
            }            
           
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            RunStep(1);
            if (current_step >= steps.Count)
                next_btn.Enabled = false;
            prev_btn.Enabled = true;
        }

        

        private void RunStep(int amount)
        {
            current_step += amount;
            if (current_step >= steps.Count || current_step < 0)
                return;

            steps[current_step].Display();
        }

        private void UndoStep()
        {
            if (current_step >= steps.Count || current_step < 0)
                return;
            steps[current_step].Undo();
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            UndoStep();
            RunStep(-1);
            if (current_step < 0)
                prev_btn.Enabled = false;
            next_btn.Enabled = true;
        }
       
        private void Autos_Click(object sender, EventArgs e)
        {
            
            
            if (autoShowStep.Enabled)
                autoShowStep.Enabled = false;
            else
                autoShowStep.Enabled = true;

        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            RunStep(1);
        }

        private void autoShowStep_Tick(object sender, EventArgs e)
        {
            RunStep(1);
        }

        /// <summary>
        /// Tis my part, thou shall not pass
        /// </summary>
            
        // keep track of ID
        public static int curNodeId = 0, curEdgeId = 0;

        // container
        private static Dictionary<string, int> content_node = new Dictionary<string, int>();
        private static Dictionary<int, FSM_node> nodes = new Dictionary<int, FSM_node>();
        private static Dictionary<int, FSM_edge> edges = new Dictionary<int, FSM_edge>();
        private static Dictionary<int, Dictionary<int, int>> node_edge = new Dictionary<int, Dictionary<int, int>>();
        private static List<FSM_step> fsm_steps = new List<FSM_step>();
        private static List<string> names = new List<string>();

        private int current_fsm_step = 0;

        // start end
        private static int startNode = -1, endNode = -1;

        // load graphic for drawing
        private void LoadFSM()
        {
            string[] temp = AI_Search_Path_Project.Properties.Resources.places
         .Split(new[] { ' ', ',', '.', ':', '\t', '\n', '\r' }, StringSplitOptions.None);
            
            for(int i = 0;i<temp.Length; i++)
            {
                if (temp[i].Length > 0)
                {
                    names.Add(temp[i]);
                }
            }

            LoadFSMBoard();
            LoadFSMNode();
            LoadFSMRoute();
        }

        private void LoadFSMBoard()
        {
            Label think = CreateNewLabel("");
            think.Font = new Font("Arial", 11F);

            FSM_board.Controls.Add(CreateTitleLabel("Think"), 0, 0);
            FSM_board.Controls.Add(think, 1, 0);

            Label open = CreateNewLabel("");
            open.Font = new Font("Arial", 11F);
            FSM_board.Controls.Add(CreateTitleLabel("Open"), 0, 1);
            FSM_board.Controls.Add(open, 1, 1);

            Label close = CreateNewLabel("");
            close.Font = new Font("Arial", 11F);
            FSM_board.Controls.Add(CreateTitleLabel("Close"), 0, 2);
            FSM_board.Controls.Add(close, 1, 2);

            Label result = CreateNewLabel("");
            result.Font = new Font("Arial", 11F);
            FSM_board.Controls.Add(CreateTitleLabel("Result"), 0, 3);
            FSM_board.Controls.Add(result, 1, 3);

            FSM_step.AddDisplayControl(think, open, close, result);
            FSM_step.AddNodes(nodes);
            FSM_step.AddEdges(edges);
            FSM_step.AddNodeEdge(node_edge);
            FSM_step.AddContentNode(content_node);
        }

        private void LoadFSMRoute()
        {
            //style for header
            RowStyle style = new RowStyle(SizeType.Absolute, 50F);
            FSM_tbl_routes.RowStyles.Clear();
            FSM_tbl_routes.RowStyles.Add(style);

            FSM_tbl_routes.Controls.Add(CreateNewLabel("Place 1"), 0 /* Column Index */, 0 /* Row index */);
            FSM_tbl_routes.Controls.Add(CreateNewLabel("Place 2"), 1 /* Column Index */, 0 /* Row index */);
            FSM_tbl_routes.Controls.Add(CreateNewLabel("Weight"), 2 /* Column Index */, 0 /* Row index */);

            //style for content
            style = new RowStyle(SizeType.Absolute, 35F);
            tablePlaces.RowStyles.Clear();
            tablePlaces.RowStyles.Add(style);

            FSM_edge.SetCavas(this.FSM_canvas);
            FSM_edge.SetControl(this.FSM_tbl_routes);
            FSM_edge.SetDictionary(ref nodes);
            FSM_edge.SetContent(ref content_node);
        }

        private void LoadFSMNode()
        {
            //style for header
            RowStyle style = new RowStyle(SizeType.Absolute, 50F);
            FSM_tbl_nodes.RowStyles.Clear();
            FSM_tbl_nodes.RowStyles.Add(style);

            FSM_tbl_nodes.Controls.Add(CreateNewLabel("Node"), 0 /* Column Index */, 0 /* Row index */);
            FSM_tbl_nodes.Controls.Add(CreateNewLabel("Heuristic"), 1 /* Column Index */, 0 /* Row index */);

            //style for content
            style = new RowStyle(SizeType.Absolute, 35F);
            FSM_tbl_nodes.RowStyles.Clear();
            FSM_tbl_nodes.RowStyles.Add(style);

            FSM_node.SetCavas(this.FSM_canvas);
            FSM_node.SetControls(this.FSM_tbl_nodes);
            FSM_node.SetDictionary(ref content_node);
            FSM_node.SetNames(names);
        }

        // Even handler
        private enum MOUSE
        {
            NONE,
            DRAG,
            DRAG_ALL,
            LINK,
            RELINK
        }
        private FSM_edge tempEdge;
        private int mode;
        private Point prevM;
        private int selectedNode, selectedEdge;


        private void FSM_canvas_Paint(object sender, PaintEventArgs e)
        {
            if(nodes.Count > 0)
                foreach(var node in nodes)
                {
                    node.Value.Draw(e.Graphics); 
                }

            if (edges.Count > 0)
            {
                foreach (var edge in edges)
                {
                    edge.Value.Draw(e.Graphics);
                }
            }

            if (tempEdge != null)
                tempEdge.Draw(e.Graphics, prevM);
        }
        
        private void FSM_canvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                FSM_node temp = new FSM_node(curNodeId, e.Location, 30);

                nodes.Add(curNodeId, temp);
                content_node.Add(temp.GetContent(), curNodeId);

                ++curNodeId;

                FSM_canvas.Invalidate();
            }
        }

        int SelectNode(Point m)
        {
            foreach(var node in nodes)
            {
                if (node.Value.ContainPoint(m))
                    return node.Key;
            }

            return -1;
        }

        int SelectEdge(Point m)
        {
            foreach (var edge in edges)
            {
                if (edge.Value.ContainPoint(m))
                    return edge.Key;
            }

            return -1;
        }

        private void FSM_canvas_MouseDown(object sender, MouseEventArgs e)
        {
            prevM = e.Location;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    selectedNode = SelectNode(e.Location);

                    if (selectedNode == -1)
                    {
                        selectedEdge = SelectEdge(e.Location);

                        if (selectedEdge == -1)
                            mode = (int)MOUSE.NONE;
                        else
                            mode = (int)MOUSE.RELINK;
                    }
                    else
                    {
                            mode = (int)MOUSE.DRAG;
                    }

                    break;
                case MouseButtons.Right:
                    selectedNode = SelectNode(e.Location);

                    if (selectedNode == -1)
                    {
                        selectedEdge = SelectEdge(e.Location);

                        if (selectedEdge == -1)
                            mode = (int)MOUSE.NONE;
                        else
                            mode = (int)MOUSE.RELINK;
                    }
                    else
                    {
                        tempEdge = new FSM_edge(curEdgeId, selectedNode);
                        mode = (int)MOUSE.LINK;
                    }

                    break;
                case MouseButtons.Middle:
                    mode = (int) MOUSE.DRAG_ALL;
                    break;
            }
        }

        private void FSM_canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if(mode == (int)MOUSE.LINK)
            {
                selectedNode = SelectNode(e.Location);

                if (selectedNode != -1 && selectedNode != tempEdge.IdA)
                {                    
                    if(!node_edge.ContainsKey(tempEdge.IdA))
                        node_edge.Add(tempEdge.IdA, new Dictionary<int, int>());

                    if (!node_edge.ContainsKey(selectedNode))
                        node_edge.Add(selectedNode, new Dictionary<int, int>());

                    if (!node_edge[tempEdge.IdA].ContainsKey(selectedNode))
                    {
                        edges.Add(curEdgeId, new FSM_edge(curEdgeId, tempEdge.IdA, selectedNode));

                        node_edge[tempEdge.IdA].Add(selectedNode, curEdgeId);
                        node_edge[selectedNode].Add(tempEdge.IdA, curEdgeId);

                        ++curEdgeId;
                    }
                }
            }
            else if(mode == (int)MOUSE.RELINK)
            {

            }

            mode = (int)MOUSE.NONE;
            tempEdge = null;
            FSM_canvas.Invalidate();
        }

        private void DeleteEdge(int id)
        {
            //FSM_edge t = edges[id];
            //node_edge[t.IdA].Remove(t.IdB);
            //node_edge[t.IdB].Remove(t.IdA);
            //edges.Remove(id);
        }

        private void DeleteNode(int id)
        {

        }

        private BindingSource GetNodeList()
        {
            BindingSource bs = new BindingSource();

            List<string> temp = new List<string>();

            foreach(var node in nodes)
            {
                temp.Add(node.Value.GetContent());
            }

            bs.DataSource = temp.OrderBy(q => q).ToList();

            return bs;
        }

        private void start_cb_Click_1(object sender, EventArgs e)
        {
            start_cb1.DataSource = GetNodeList();
        }

        private void end_cb_Click_1(object sender, EventArgs e)
        {
            end_cb1.DataSource = GetNodeList();
        }

        private List<List<string>> GetData()
        {
            List<List<string>> listData = new List<List<string>>();
            foreach (var item in node_edge)
            {
                List<string> subList = new List<string>();

                // get content
                subList.Add(nodes[item.Key].GetContent());
                // get heuristic
                subList.Add(nodes[item.Key].GetHeuristic().ToString());
                // get edge
                foreach(var item1 in item.Value){
                    subList.Add(nodes[item1.Key].GetContent());
                    subList.Add(edges[item1.Value].GetCost().ToString());
                }

                if (item.Key == startNode)
                    listData.Insert(0, subList);
                else if (item.Key == endNode)
                    listData.Insert(1, subList);
                else
                    listData.Add(subList);
            }
            
            return listData;
        }

        private void CreateFSMInputFile()
        {
            string path = "input.txt";
            

            var listData = GetData();

            // Create a new file 
            using (StreamWriter outputFile = new StreamWriter("input.txt"))
            {
                foreach (var row in listData)
                {
                    foreach (var item in row)
                        outputFile.Write(item + " ");
                    outputFile.WriteLine("");
                }

            }

        }

        private void fsm_run_Click(object sender, EventArgs e)
        {
            if(fsm_steps.Count > 0)
            {
                fsm_steps.Clear();
                foreach(var node in nodes){
                    node.Value.CloseInfoWindow();
                }
                current_fsm_step = 0;
                FSM_step.Reset();
            }

            if (startNode != -1)
                nodes[startNode].State = FSM_Default.NORMAL;

            if (endNode != -1)
                nodes[endNode].State = FSM_Default.NORMAL;

            startNode = content_node[start_cb1.Text];
            endNode = content_node[end_cb1.Text];

            nodes[startNode].State = FSM_Default.START;
            nodes[endNode].State = FSM_Default.GOAL;

            FSM_canvas.Invalidate();

            if (fsm_auto.Visible == false)
            {
                tb_timer.Visible = true;
                fsm_auto.Visible = true;
                fsm_next.Visible = true;
                fsm_prev.Visible = true;
            }

            CreateFSMInputFile();

            int algo_index = algo_cb1.SelectedIndex;
            var result = shortest_path("input.txt", algo_index); // returns 42 (Int32)

            foreach (var obj in result)
            {
                FSM_step step = new FSM_step(obj);
                fsm_steps.Add(step);
            }

            RunFSMStep(0);
        }
        private void RunFSMStep(int amount)
        {
            current_fsm_step += amount;
            if (current_fsm_step >= fsm_steps.Count || current_fsm_step < 0)
                return;

            fsm_steps[current_fsm_step].Display();
        }

        private void UndoFSMStep()
        {
            if (current_fsm_step >= fsm_steps.Count || current_fsm_step < 0)
                return;
            fsm_steps[current_fsm_step].Undo();
        }

        private void fsm_prev_Click(object sender, EventArgs e)
        {
            UndoFSMStep();
            RunFSMStep(-1);
            if (current_fsm_step < 0)
                fsm_prev.Enabled = false;
            fsm_prev.Enabled = true;
        }

        private void fsm_next_Click(object sender, EventArgs e)
        {
            RunFSMStep(1);
            if (current_fsm_step >= steps.Count)
                fsm_next.Enabled = false;
            fsm_next.Enabled = true;
        }

        private void fsm_auto_Click(object sender, EventArgs e)
        {
            if (fsm_timer.Enabled)
                fsm_timer.Enabled = false;
            else
                fsm_timer.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RunFSMStep(1);
        }

        //private void fsm_cmd_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Enter)
        //    {
        //        Command(fsm_cmd.Text, false);
        //    }
        //}

        private void ReadFromFile(string filePath)
        {
            string content = File.ReadAllText(filePath);
            content = content.Replace("\r\n", "-");

            string[] lines = content.Split('-');

            foreach (var line in lines)
            {
                string[] args = line.Split('\t');

                if (args.Length == 3)
                {
                    if (args[2] != "")
                        AddEdge(args);
                    else
                        AddHeuristic(args);
                }
                else if (args.Length == 2)
                {
                    AddHeuristic(args);
                }
                else
                {
                    Console.Out.WriteLine("Read exception: dim = " + args.Length.ToString());
                    foreach(var arg in args)
                    {
                        Console.Out.Write(arg + " ");
                    }
                }
            }

            FSM_canvas.Invalidate();
        }

        private void AddHeuristic(string[] args)
        {
            string node = args[0].Replace(" ", "");
            string heuristic = args[1];

            if (content_node.ContainsKey(node))
            {
                UpdateHeuristic(node, System.Convert.ToDouble(heuristic));
            }
            else
            {
                AddNode(node, System.Convert.ToDouble(heuristic));
            }
        }

        private int AddEdge(int nodeA, int nodeB, double cost)
        {
            int id = curEdgeId++;

            FSM_edge temp = new FSM_edge(id, nodeA, nodeB);
            temp.SetCost(cost);

            edges.Add(id, temp);

            node_edge[nodeA].Add(nodeB, id);
            node_edge[nodeB].Add(nodeA, id);

            return id;
        }

        private int AddNode(string node, double v)
        {
            Random rand = new Random(curNodeId);

            int id = curNodeId++;
            
            Point loc = new Point(rand.Next() % FSM_canvas.Width, rand.Next() % FSM_canvas.Height);

            FSM_node temp = new FSM_node(id, loc, 30, node, v);

            content_node.Add(node, id);
            nodes.Add(id, temp);

            node_edge.Add(id, new Dictionary<int, int>());

            return id;
        }

        private void UpdateHeuristic(string node, double h)
        {
            int id = content_node[node];

            nodes[id].SetHeuristic(h);
        }

        private void AddEdge(string[] args)
        {
            string nodeA = args[0].Replace(" ", "");
            string nodeB = args[1].Replace(" ", "");
            double cost = System.Convert.ToDouble(args[2]);
            
            if(content_node.ContainsKey(nodeA) && content_node.ContainsKey(nodeB))
            {
                UpdateEdge(nodeA, nodeB, cost);
            }
            else if(content_node.ContainsKey(nodeA) || content_node.ContainsKey(nodeB))
            {
                AddEdgeAndNode(nodeA, nodeB, cost);
            }
            else
            {
                AdgeNewEdgeAndNodes(nodeA, nodeB, cost);
            }
        }

        private void AdgeNewEdgeAndNodes(string nodeA, string nodeB, double cost)
        {
            int idA = AddNode(nodeA, 0), idB = AddNode(nodeB, 0);

            AddEdge(idA, idB, cost);
        }

        private void AddEdgeAndNode(string nodeA, string nodeB, double cost)
        {
            int exist = content_node.ContainsKey(nodeA) ? content_node[nodeA] : content_node[nodeB];
            int newNode = AddNode(!content_node.ContainsKey(nodeA) ? nodeA : nodeB, 0);

            AddEdge(exist, newNode, cost);
        }

        private void UpdateEdge(string nodeA, string nodeB, double cost)
        {
            int idA = content_node[nodeA], idB = content_node[nodeB];

            if (node_edge[idA].ContainsKey(idB))
            {
                int idEdge = node_edge[idA][idB];

                FSM_edge temp = edges[idEdge];

                temp.SetCost(cost);
            }
            else
            {
                AddEdge(idA, idB, cost);
            }
        }

        private void Command(string command, bool isImport)
        {
            if (command == "")
            {
                OpenFileDialog fbd = new OpenFileDialog();
                fbd.Multiselect = true;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string[] files = fbd.FileNames;

                    foreach (var file in files)
                    {
                        ReadFromFile(file);
                    }

                }
            }
        }

        private void fsm_reset_Click(object sender, EventArgs e)
        {
            for(int i = FSM_tbl_nodes.RowCount - 1; i >= 0; i--)
            {
                for(int j = FSM_tbl_nodes.ColumnCount - 1; j >= 0; j--)
                {
                    var control = FSM_tbl_nodes.GetControlFromPosition(j, i);
                    FSM_tbl_nodes.Controls.Remove(control);
                }
                FSM_tbl_nodes.RowCount--;
            }

            for (int i = FSM_tbl_routes.RowCount - 1; i >= 0; i--)
            {
                for (int j = FSM_tbl_routes.ColumnCount - 1; j >= 0; j--)
                {
                    var control = FSM_tbl_routes.GetControlFromPosition(j, i);
                    FSM_tbl_routes.Controls.Remove(control);
                }
                FSM_tbl_routes.RowCount--;
            }

            edges.Clear();
            nodes.Clear();
            content_node.Clear();
            node_edge.Clear();
            fsm_steps.Clear();
            curNodeId = 0;
            curEdgeId = 0;
            current_fsm_step = 0;
            startNode = endNode = -1;

            FSM_canvas.Invalidate();
        }

        private void fsm_import_Click(object sender, EventArgs e)
        {
            Command("", true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fsm_timer.Interval = int.Parse(tb_timer.Text);
        }

        private void FSM_canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                selectedNode = SelectNode(e.Location);
                if (selectedNode == -1)
                {
                    selectedEdge = SelectEdge(e.Location);
                    if (selectedEdge != -1)
                        DeleteEdge(selectedEdge);

                    selectedEdge = -1;
                }
                else
                {
                    DeleteNode(selectedEdge);
                    selectedNode = -1;
                }
            }
        }

        private void FSM_canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point v = new Point(e.X - prevM.X, e.Y - prevM.Y);
            switch (mode)
            {
                case (int)MOUSE.DRAG:
                    nodes[selectedNode].Translate(v.X, v.Y);
                    FSM_canvas.Invalidate();
                    break;
                case (int)MOUSE.DRAG_ALL:
                    v = new Point(e.X - prevM.X, e.Y - prevM.Y);
                    foreach(var node in nodes)
                    {
                        node.Value.Translate(v.X, v.Y);
                    }
                    FSM_canvas.Invalidate();
                    break;
                case (int)MOUSE.LINK:
                    FSM_canvas.Invalidate();
                    break;
                case (int)MOUSE.RELINK:
                    break;
                case (int)MOUSE.NONE:
                    break;
                default:
                    break;
            }

            prevM = e.Location;
        }
    }


}

