using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AI_Search_Path_Project
{
    class FSM_Default
    {
        public const int NORMAL = 0;
        public const int START = 1;
        public const int GOAL = 2;
        public const int CURRENT = 3;     
    }
    
    class FSM_node : FSM_shape
    {
        private TextBox content;
        private TextBox heuristic;

        private int id;
        private int state;
        private string curName;
        private Rectangle rec;
        private static TableLayoutPanel FSM_tbl_node;
        private static custom_Canvas canvas;

        private static List<string> names;
        private static Dictionary<string, int> content_node;

        private Rectangle infoRec = new Rectangle();
        private string info;
        private bool isWindows = false;

        public Point Location
        {
            get
            {
                return GetCenter();
            }

            set
            {
                rec.Location = value;
                rec.X -= this.Radius;
                rec.Y -= this.Radius;
            }
        }

        public int Radius
        {
            get
            {
                return rec.Width / 2;
            }

            set
            {
                rec.Width = rec.Height = value * 2;
                rec.X -= this.Radius;
                rec.Y -= this.Radius;
            }
        }

        public int State
        {
            get
            {
                return state;
            }

            set
            {
                switch (value)
                {
                    case FSM_Default.NORMAL:
                        MyPen = new Pen(Color.Black);
                        break;
                    case FSM_Default.START:
                        MyPen = new Pen(Color.Blue, 8f);
                        break;
                    case FSM_Default.GOAL:
                        MyPen = new Pen(Color.Red, 8f);
                        break;
                    case FSM_Default.CURRENT:
                        MyPen = new Pen(Color.Cyan, 8f);
                        break;
                    default:
                        return;
                }
                state = value;
            }
        }

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

        public FSM_node(int id = -1, Point location = new Point(), int radius  = 0, string content_name = "", double h = 0)
        {
            if (rec == null)
            {
                rec = new Rectangle();
            }
            
            this.Id = id;
            this.Location = location;
            this.Radius = radius;

            state = FSM_Default.NORMAL;

            AddUI(content_name, h);
        }

        public void OpenInfoWindow(string info)
        {
            isWindows = true;
            this.info = info;
            infoRec.X = rec.X - rec.Width;
            infoRec.Y = rec.Y - rec.Height;
            infoRec.Width = rec.Width * 2;
            infoRec.Height = rec.Height;
            ReDraw();
        }

        public void CloseInfoWindow()
        {
            isWindows = false;
            infoRec.Width = 0;
            ReDraw();
        }

        public static void SetCavas(custom_Canvas canvas)
        {
            FSM_node.canvas = canvas;
        }
        
        public static void SetControls(TableLayoutPanel FSM_tbl_node)
        {
            FSM_node.FSM_tbl_node = FSM_tbl_node;
        }

        public static void SetNames(List<string> names)
        {
            FSM_node.names = names;
        }

        public static void SetDictionary(ref Dictionary<string, int> content_node)
        {
            FSM_node.content_node = content_node;
        }

        private static string RandomName()
        {
            Random rand = new Random();
            return names[rand.Next() % names.Count];
        }

        private Label CreateNewLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            return label;
        }

        private TextBox CreateNewTextBox(string text)
        {
            TextBox tb = new TextBox();
            tb.Text = text;
            tb.Dock = System.Windows.Forms.DockStyle.Fill;
            tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tb.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            return tb;
        }
        
        public void AddUI(string content_name = "", double h = 0)
        {
            string name;
            if (content_name == "")
            {
                do
                {
                    name = RandomName();
                } while (content_node.ContainsKey(name));
            }
            else
            {
                name = content_name;
            }

            curName = name;
            content = CreateNewTextBox(name);
            content.LostFocus += ChangeContent;

            heuristic = CreateNewTextBox(h.ToString());

            int row = FSM_tbl_node.RowCount++;
            FSM_tbl_node.Controls.Add(content, 0, row);
            FSM_tbl_node.Controls.Add(heuristic, 1, row);
        }

        private void ReDraw()
        {
            canvas.Invalidate();
        }

        private void ChangeContent(object sender, EventArgs e)
        {
            string newContent = content.Text;

            if (newContent == curName)
                return;
            
            if (content_node.ContainsKey(newContent))
            {
                string temp;
                int count = 1;

                do
                {
                    temp = newContent + count.ToString();
                    ++count;
                } while (content_node.ContainsKey(temp));

                newContent = temp;

                ReDraw();
            }
            
            content_node.Remove(curName);

            content_node.Add(newContent, Id);

            content.Text = newContent;

            curName = newContent;

        }

        public void SetHeuristic(double heuristic)
        {
            this.heuristic.Text = heuristic.ToString();
        }

        public double GetHeuristic()
        {
            return System.Convert.ToDouble(heuristic.Text);
        }

        public static int GetNode(string slot)
        {
            return content_node[slot];
        }

        public string GetContent()
        {
            return content.Text;
        }

        public Point GetCenter()
        {
            return new Point(rec.X + Radius, rec.Y + Radius);
        }

        public override bool ContainPoint(Point m)
        {
            Point c = GetCenter();

            return (c.X - m.X) * (c.X - m.X) + (c.Y - m.Y) * (c.Y - m.Y) < Radius * Radius;
        }

        public Point ClosestPointOnCircle(Point p)
        {
            Point c = GetCenter();
            PointF d = new PointF(p.X - c.X, p.Y - c.Y);
            double scale = Math.Sqrt(d.X * d.X + d.Y * d.Y);
            return new Point(System.Convert.ToInt32(c.X + d.X * Radius / scale), System.Convert.ToInt32(c.Y + d.Y * Radius / scale));
        }

        public double Distance(FSM_node node)
        {
            double dx = this.Location.X - node.Location.X;
            double dy = this.Location.Y - node.Location.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override void Translate(int vx, int vy)
        {
            rec.Location = new Point(rec.X + vx, rec.Y + vy);
            infoRec.X = rec.X - rec.Width;
            infoRec.Y = rec.Y - rec.Height;
        }

        public override void Draw(Graphics graph)
        {
            graph.DrawEllipse(this.MyPen, rec);

            SolidBrush solidBrush = new SolidBrush(MyPen.Color);
            graph.DrawString(this.content.Text, Font, solidBrush, rec, Sf);

            if (isWindows)
                graph.DrawString(info, Font, solidBrush, infoRec, Sf);

            solidBrush.Dispose();
        }

        public bool Equals(ref FSM_node node)
        {
            if (this.Id != node.Id)
                return false;

            return true;
        }
    }
}
