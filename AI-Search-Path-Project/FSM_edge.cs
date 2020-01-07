using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AI_Search_Path_Project.Properties;
using System.Windows.Forms;

namespace AI_Search_Path_Project
{
    class FSM_edge : FSM_shape
    {
        private Label from;
        private Label to;
        private TextBox cost;
        private static TableLayoutPanel FSM_route;
        private static custom_Canvas canvas;

        private static Dictionary<string, int> content_node;
        private static Dictionary<int, FSM_node> nodes;

        private int id;
        private Point start, end;
        private int idA = -1, idB = -1;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int IdA
        {
            get
            {
                return idA;
            }

            set
            {
                if (value == idB)
                    return;

                idA = value;
                if (idA != -1 && from != null)
                    from.Text = nodes[idA].GetContent();
            }
        }

        public int IdB
        {
            get
            {
                return idB;
            }

            set
            {
                if (value == idA)
                    return;

                idB = value;
                if (idB != -1 && to != null)
                    to.Text = nodes[IdB].GetContent();
            }
        }

        public static void SetCavas(custom_Canvas canvas)
        {
            FSM_edge.canvas = canvas;
        }

        public static void SetDictionary(ref Dictionary<int, FSM_node> nodes)
        {
            FSM_edge.nodes = nodes;
        }

        public static void SetContent(ref Dictionary<string, int> content_node)
        {
            FSM_edge.content_node = content_node;
        }

        public static void SetControl(TableLayoutPanel FSM_route)
        {
            FSM_edge.FSM_route = FSM_route;
        }

        private TextBox CreateNewTextBox()
        {
            TextBox tb = new TextBox();
            tb.Dock = System.Windows.Forms.DockStyle.Fill;
            tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            return tb;
        }

        private Label CreateNewLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            return label;
        }

        public void AddUI()
        {

            from = CreateNewLabel(nodes[IdA].GetContent());

            if (IdB != -1)
                to = CreateNewLabel(nodes[IdB].GetContent());
            else
                to = CreateNewLabel("Not defined");

            cost = CreateNewTextBox();
            cost.LostFocus += ReDraw;

            int row = FSM_route.RowCount++;
            FSM_route.Controls.Add(from, 0, row);
            FSM_route.Controls.Add(to, 1, row);
            FSM_route.Controls.Add(cost, 2, row);
        }

        private void ReDraw(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }

        public double GetCost()
        {
            return System.Convert.ToDouble(cost.Text);
        }
        
        public void SetCost(double cost)
        {
            this.cost.Text = cost.ToString();
        }

        public void GetEndPoints(FSM_node nodeA, FSM_node nodeB)
        {
            Point mid = new Point((nodeA.Location.X + nodeB.Location.X) / 2, (nodeA.Location.Y + nodeB.Location.Y) / 2);
            start = nodeA.ClosestPointOnCircle(mid);
            end = nodeB.ClosestPointOnCircle(mid);
        }

        public FSM_edge(int id = -1, int idA = -1, int idB = -1)
        {
            this.Id = id;
            this.IdA = idA;
            this.IdB = idB;

            if(idA != -1 && idB != -1)
                AddUI();
        }
        
        private Rectangle getRectangle(Point start, Point end)
        {
            return new Rectangle(
                Math.Min(start.X, end.X),
                Math.Min(start.Y, end.Y) - 10,
                Math.Max(Math.Abs(start.X - end.X), 20),
                Math.Max(Math.Abs(start.Y - end.Y), 20)
                );
        }

        public override void Draw(Graphics graph)
        {
            FSM_node nodeA = nodes[IdA], nodeB = nodes[IdB];
            
            if (nodeA == null || nodeB == null)
                return;

            if (nodeA.Distance(nodeB) < nodeA.Radius * 2)
                return;

            from.Text = nodeA.GetContent();
            to.Text = nodeB.GetContent();

            GetEndPoints(nodeA, nodeB);

            graph.DrawLine(MyPen, start, end);

            SolidBrush solidBrush = new SolidBrush(MyPen.Color);
            graph.DrawString(this.cost.Text, Font, solidBrush, getRectangle(start, end), Sf);
            
            solidBrush.Dispose();
        }

        public void Draw(Graphics graph, Point m)
        {
            FSM_node nodeA = nodes[idA];

            if (nodeA == null)
                return;

            start = nodeA.ClosestPointOnCircle(m);
            end = m;

            graph.DrawLine(MyPen, start, end);

            SolidBrush solidBrush = new SolidBrush(MyPen.Color);
            graph.DrawString("", Font, solidBrush, getRectangle(start, end), Sf);


            solidBrush.Dispose();
        }

        public override bool ContainPoint(Point m)
        {
            var dx = end.X - start.X;
            var dy = end.Y - start.Y;
            var length = Math.Sqrt(dx * dx + dy * dy);

            var percent = (dx * (m.X - start.X) + dy * (m.Y - start.Y)) / (length * length);
            var distance = (dx * (m.Y - start.Y) - dy * (m.X - start.X)) / length;

            return (percent > 0 && percent < 1 && Math.Abs(distance) < 6);
        }
    }
}
