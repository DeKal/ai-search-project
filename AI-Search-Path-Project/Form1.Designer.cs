namespace AI_Search_Path_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gMapMain = new GMap.NET.WindowsForms.GMapControl();
            this.PlacesTab = new System.Windows.Forms.TabControl();
            this.placeTab = new System.Windows.Forms.TabPage();
            this.tablePlaces = new System.Windows.Forms.TableLayoutPanel();
            this.routeTab = new System.Windows.Forms.TabPage();
            this.tableRoute = new System.Windows.Forms.TableLayoutPanel();
            this.RunTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableBoard = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableRunControl = new System.Windows.Forms.TableLayoutPanel();
            this.Autos = new System.Windows.Forms.Button();
            this.prev_btn = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.end_cb = new System.Windows.Forms.ComboBox();
            this.start_cb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.algo_cb = new System.Windows.Forms.ComboBox();
            this.autoShowStep = new System.Windows.Forms.Timer(this.components);
            this.program_tab = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FSM_main_container = new System.Windows.Forms.SplitContainer();
            this.FSM_canvas = new AI_Search_Path_Project.custom_Canvas();
            this.fsm_option_container = new System.Windows.Forms.SplitContainer();
            this.FSM_tab = new System.Windows.Forms.TabControl();
            this.FSM_tab_node = new System.Windows.Forms.TabPage();
            this.FSM_tbl_nodes = new System.Windows.Forms.TableLayoutPanel();
            this.FSM_tab_route = new System.Windows.Forms.TabPage();
            this.FSM_tbl_routes = new System.Windows.Forms.TableLayoutPanel();
            this.FSM_tab_run = new System.Windows.Forms.TabPage();
            this.FSM_board = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.fsm_run = new System.Windows.Forms.Button();
            this.fsm_auto = new System.Windows.Forms.Button();
            this.tb_timer = new System.Windows.Forms.TextBox();
            this.fsm_prev = new System.Windows.Forms.Button();
            this.fsm_next = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.end_cb1 = new System.Windows.Forms.ComboBox();
            this.start_cb1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.algo_cb1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.fsm_import = new System.Windows.Forms.Button();
            this.fsm_reset = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fsm_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.PlacesTab.SuspendLayout();
            this.placeTab.SuspendLayout();
            this.routeTab.SuspendLayout();
            this.RunTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableRunControl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.program_tab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FSM_main_container)).BeginInit();
            this.FSM_main_container.Panel1.SuspendLayout();
            this.FSM_main_container.Panel2.SuspendLayout();
            this.FSM_main_container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsm_option_container)).BeginInit();
            this.fsm_option_container.Panel1.SuspendLayout();
            this.fsm_option_container.Panel2.SuspendLayout();
            this.fsm_option_container.SuspendLayout();
            this.FSM_tab.SuspendLayout();
            this.FSM_tab_node.SuspendLayout();
            this.FSM_tab_route.SuspendLayout();
            this.FSM_tab_run.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gMapMain);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.PlacesTab);
            this.splitContainer.Size = new System.Drawing.Size(946, 639);
            this.splitContainer.SplitterDistance = 645;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 4;
            // 
            // gMapMain
            // 
            this.gMapMain.Bearing = 0F;
            this.gMapMain.CanDragMap = true;
            this.gMapMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapMain.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapMain.GrayScaleMode = false;
            this.gMapMain.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapMain.LevelsKeepInMemmory = 5;
            this.gMapMain.Location = new System.Drawing.Point(0, 0);
            this.gMapMain.Margin = new System.Windows.Forms.Padding(2);
            this.gMapMain.MarkersEnabled = true;
            this.gMapMain.MaxZoom = 17;
            this.gMapMain.MinZoom = 3;
            this.gMapMain.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapMain.Name = "gMapMain";
            this.gMapMain.NegativeMode = false;
            this.gMapMain.PolygonsEnabled = true;
            this.gMapMain.RetryLoadTile = 0;
            this.gMapMain.RoutesEnabled = true;
            this.gMapMain.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapMain.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapMain.ShowTileGridLines = false;
            this.gMapMain.Size = new System.Drawing.Size(645, 639);
            this.gMapMain.TabIndex = 0;
            this.gMapMain.Zoom = 5D;
            this.gMapMain.Click += new System.EventHandler(this.gMapMain_Click);
            // 
            // PlacesTab
            // 
            this.PlacesTab.Controls.Add(this.placeTab);
            this.PlacesTab.Controls.Add(this.routeTab);
            this.PlacesTab.Controls.Add(this.RunTab);
            this.PlacesTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlacesTab.Location = new System.Drawing.Point(0, 0);
            this.PlacesTab.Margin = new System.Windows.Forms.Padding(2);
            this.PlacesTab.Name = "PlacesTab";
            this.PlacesTab.SelectedIndex = 0;
            this.PlacesTab.Size = new System.Drawing.Size(298, 639);
            this.PlacesTab.TabIndex = 0;
            // 
            // placeTab
            // 
            this.placeTab.Controls.Add(this.tablePlaces);
            this.placeTab.Location = new System.Drawing.Point(4, 22);
            this.placeTab.Margin = new System.Windows.Forms.Padding(2);
            this.placeTab.Name = "placeTab";
            this.placeTab.Padding = new System.Windows.Forms.Padding(2);
            this.placeTab.Size = new System.Drawing.Size(290, 613);
            this.placeTab.TabIndex = 0;
            this.placeTab.Text = "Places";
            this.placeTab.UseVisualStyleBackColor = true;
            // 
            // tablePlaces
            // 
            this.tablePlaces.AutoScroll = true;
            this.tablePlaces.ColumnCount = 3;
            this.tablePlaces.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablePlaces.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tablePlaces.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tablePlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePlaces.Location = new System.Drawing.Point(2, 2);
            this.tablePlaces.Margin = new System.Windows.Forms.Padding(2);
            this.tablePlaces.Name = "tablePlaces";
            this.tablePlaces.RowCount = 1;
            this.tablePlaces.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 609F));
            this.tablePlaces.Size = new System.Drawing.Size(286, 609);
            this.tablePlaces.TabIndex = 0;
            // 
            // routeTab
            // 
            this.routeTab.Controls.Add(this.tableRoute);
            this.routeTab.Location = new System.Drawing.Point(4, 22);
            this.routeTab.Margin = new System.Windows.Forms.Padding(2);
            this.routeTab.Name = "routeTab";
            this.routeTab.Padding = new System.Windows.Forms.Padding(2);
            this.routeTab.Size = new System.Drawing.Size(290, 613);
            this.routeTab.TabIndex = 1;
            this.routeTab.Text = "Routes";
            this.routeTab.UseVisualStyleBackColor = true;
            // 
            // tableRoute
            // 
            this.tableRoute.ColumnCount = 4;
            this.tableRoute.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableRoute.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableRoute.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableRoute.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRoute.Location = new System.Drawing.Point(2, 2);
            this.tableRoute.Margin = new System.Windows.Forms.Padding(2);
            this.tableRoute.Name = "tableRoute";
            this.tableRoute.RowCount = 1;
            this.tableRoute.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableRoute.Size = new System.Drawing.Size(286, 609);
            this.tableRoute.TabIndex = 0;
            // 
            // RunTab
            // 
            this.RunTab.Controls.Add(this.panel2);
            this.RunTab.Controls.Add(this.panel1);
            this.RunTab.Controls.Add(this.tableLayoutPanel1);
            this.RunTab.Location = new System.Drawing.Point(4, 22);
            this.RunTab.Margin = new System.Windows.Forms.Padding(2);
            this.RunTab.Name = "RunTab";
            this.RunTab.Padding = new System.Windows.Forms.Padding(2);
            this.RunTab.Size = new System.Drawing.Size(290, 613);
            this.RunTab.TabIndex = 2;
            this.RunTab.Text = "Run";
            this.RunTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableBoard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 189);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 422);
            this.panel2.TabIndex = 14;
            this.panel2.Visible = false;
            // 
            // tableBoard
            // 
            this.tableBoard.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableBoard.ColumnCount = 2;
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableBoard.Location = new System.Drawing.Point(0, 0);
            this.tableBoard.Margin = new System.Windows.Forms.Padding(2);
            this.tableBoard.Name = "tableBoard";
            this.tableBoard.RowCount = 4;
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableBoard.Size = new System.Drawing.Size(286, 422);
            this.tableBoard.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableRunControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 110);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 79);
            this.panel1.TabIndex = 12;
            // 
            // tableRunControl
            // 
            this.tableRunControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableRunControl.ColumnCount = 4;
            this.tableRunControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableRunControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableRunControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableRunControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableRunControl.Controls.Add(this.Autos, 0, 0);
            this.tableRunControl.Controls.Add(this.prev_btn, 1, 0);
            this.tableRunControl.Controls.Add(this.next_btn, 2, 0);
            this.tableRunControl.Controls.Add(this.Run, 0, 0);
            this.tableRunControl.Location = new System.Drawing.Point(2, 19);
            this.tableRunControl.Margin = new System.Windows.Forms.Padding(2, 61, 2, 2);
            this.tableRunControl.Name = "tableRunControl";
            this.tableRunControl.RowCount = 1;
            this.tableRunControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableRunControl.Size = new System.Drawing.Size(286, 42);
            this.tableRunControl.TabIndex = 10;
            // 
            // Autos
            // 
            this.Autos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Autos.Location = new System.Drawing.Point(73, 2);
            this.Autos.Margin = new System.Windows.Forms.Padding(2);
            this.Autos.Name = "Autos";
            this.Autos.Size = new System.Drawing.Size(67, 38);
            this.Autos.TabIndex = 10;
            this.Autos.Text = "Auto/Stop";
            this.Autos.UseVisualStyleBackColor = true;
            this.Autos.Visible = false;
            this.Autos.Click += new System.EventHandler(this.Autos_Click);
            // 
            // prev_btn
            // 
            this.prev_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prev_btn.Location = new System.Drawing.Point(144, 2);
            this.prev_btn.Margin = new System.Windows.Forms.Padding(2);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(67, 38);
            this.prev_btn.TabIndex = 8;
            this.prev_btn.Text = "Prev";
            this.prev_btn.UseVisualStyleBackColor = true;
            this.prev_btn.Visible = false;
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.next_btn.Location = new System.Drawing.Point(215, 2);
            this.next_btn.Margin = new System.Windows.Forms.Padding(2);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(69, 38);
            this.next_btn.TabIndex = 9;
            this.next_btn.Text = "Next";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Visible = false;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // Run
            // 
            this.Run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Run.Location = new System.Drawing.Point(2, 2);
            this.Run.Margin = new System.Windows.Forms.Padding(2);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(67, 38);
            this.Run.TabIndex = 7;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.end_cb, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.start_cb, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.algo_cb, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(286, 108);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Algorithm ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "End";
            // 
            // end_cb
            // 
            this.end_cb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.end_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.end_cb.FormattingEnabled = true;
            this.end_cb.Location = new System.Drawing.Point(87, 80);
            this.end_cb.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.end_cb.Name = "end_cb";
            this.end_cb.Size = new System.Drawing.Size(139, 21);
            this.end_cb.TabIndex = 5;
            this.end_cb.Click += new System.EventHandler(this.end_cb_Click);
            // 
            // start_cb
            // 
            this.start_cb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.start_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.start_cb.FormattingEnabled = true;
            this.start_cb.Location = new System.Drawing.Point(87, 44);
            this.start_cb.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.start_cb.Name = "start_cb";
            this.start_cb.Size = new System.Drawing.Size(139, 21);
            this.start_cb.TabIndex = 3;
            this.start_cb.Click += new System.EventHandler(this.start_cb_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start";
            // 
            // algo_cb
            // 
            this.algo_cb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algo_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algo_cb.FormattingEnabled = true;
            this.algo_cb.Items.AddRange(new object[] {
            "Best First Search",
            "A *",
            "Recursive Best First Search"});
            this.algo_cb.Location = new System.Drawing.Point(87, 8);
            this.algo_cb.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.algo_cb.Name = "algo_cb";
            this.algo_cb.Size = new System.Drawing.Size(139, 21);
            this.algo_cb.TabIndex = 1;
            // 
            // autoShowStep
            // 
            this.autoShowStep.Interval = 1000;
            this.autoShowStep.Tick += new System.EventHandler(this.autoShowStep_Tick);
            // 
            // program_tab
            // 
            this.program_tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.program_tab.Controls.Add(this.tabPage2);
            this.program_tab.Controls.Add(this.tabPage1);
            this.program_tab.Location = new System.Drawing.Point(0, 2);
            this.program_tab.Name = "program_tab";
            this.program_tab.SelectedIndex = 0;
            this.program_tab.Size = new System.Drawing.Size(960, 671);
            this.program_tab.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FSM_main_container);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(952, 645);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Graph";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FSM_main_container
            // 
            this.FSM_main_container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FSM_main_container.Location = new System.Drawing.Point(3, 3);
            this.FSM_main_container.Name = "FSM_main_container";
            // 
            // FSM_main_container.Panel1
            // 
            this.FSM_main_container.Panel1.BackColor = System.Drawing.Color.White;
            this.FSM_main_container.Panel1.Controls.Add(this.FSM_canvas);
            // 
            // FSM_main_container.Panel2
            // 
            this.FSM_main_container.Panel2.Controls.Add(this.fsm_option_container);
            this.FSM_main_container.Size = new System.Drawing.Size(946, 639);
            this.FSM_main_container.SplitterDistance = 645;
            this.FSM_main_container.TabIndex = 0;
            // 
            // FSM_canvas
            // 
            this.FSM_canvas.AutoSize = true;
            this.FSM_canvas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FSM_canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FSM_canvas.Location = new System.Drawing.Point(0, 0);
            this.FSM_canvas.Name = "FSM_canvas";
            this.FSM_canvas.Size = new System.Drawing.Size(645, 639);
            this.FSM_canvas.TabIndex = 0;
            this.FSM_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.FSM_canvas_Paint);
            this.FSM_canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FSM_canvas_MouseClick);
            this.FSM_canvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FSM_canvas_MouseDoubleClick);
            this.FSM_canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FSM_canvas_MouseDown);
            this.FSM_canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FSM_canvas_MouseMove);
            this.FSM_canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FSM_canvas_MouseUp);
            // 
            // fsm_option_container
            // 
            this.fsm_option_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsm_option_container.Location = new System.Drawing.Point(0, 0);
            this.fsm_option_container.Name = "fsm_option_container";
            this.fsm_option_container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // fsm_option_container.Panel1
            // 
            this.fsm_option_container.Panel1.Controls.Add(this.FSM_tab);
            // 
            // fsm_option_container.Panel2
            // 
            this.fsm_option_container.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.fsm_option_container.Size = new System.Drawing.Size(297, 639);
            this.fsm_option_container.SplitterDistance = 569;
            this.fsm_option_container.TabIndex = 0;
            // 
            // FSM_tab
            // 
            this.FSM_tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FSM_tab.Controls.Add(this.FSM_tab_node);
            this.FSM_tab.Controls.Add(this.FSM_tab_route);
            this.FSM_tab.Controls.Add(this.FSM_tab_run);
            this.FSM_tab.Location = new System.Drawing.Point(0, 0);
            this.FSM_tab.Name = "FSM_tab";
            this.FSM_tab.SelectedIndex = 0;
            this.FSM_tab.Size = new System.Drawing.Size(297, 566);
            this.FSM_tab.TabIndex = 0;
            // 
            // FSM_tab_node
            // 
            this.FSM_tab_node.Controls.Add(this.FSM_tbl_nodes);
            this.FSM_tab_node.Location = new System.Drawing.Point(4, 22);
            this.FSM_tab_node.Name = "FSM_tab_node";
            this.FSM_tab_node.Padding = new System.Windows.Forms.Padding(3);
            this.FSM_tab_node.Size = new System.Drawing.Size(289, 540);
            this.FSM_tab_node.TabIndex = 0;
            this.FSM_tab_node.Text = "Nodes";
            this.FSM_tab_node.UseVisualStyleBackColor = true;
            // 
            // FSM_tbl_nodes
            // 
            this.FSM_tbl_nodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FSM_tbl_nodes.AutoScroll = true;
            this.FSM_tbl_nodes.ColumnCount = 2;
            this.FSM_tbl_nodes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FSM_tbl_nodes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FSM_tbl_nodes.Location = new System.Drawing.Point(0, 0);
            this.FSM_tbl_nodes.Name = "FSM_tbl_nodes";
            this.FSM_tbl_nodes.RowCount = 1;
            this.FSM_tbl_nodes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FSM_tbl_nodes.Size = new System.Drawing.Size(289, 541);
            this.FSM_tbl_nodes.TabIndex = 0;
            // 
            // FSM_tab_route
            // 
            this.FSM_tab_route.Controls.Add(this.FSM_tbl_routes);
            this.FSM_tab_route.Location = new System.Drawing.Point(4, 22);
            this.FSM_tab_route.Name = "FSM_tab_route";
            this.FSM_tab_route.Padding = new System.Windows.Forms.Padding(3);
            this.FSM_tab_route.Size = new System.Drawing.Size(289, 540);
            this.FSM_tab_route.TabIndex = 1;
            this.FSM_tab_route.Text = "Routes";
            this.FSM_tab_route.UseVisualStyleBackColor = true;
            // 
            // FSM_tbl_routes
            // 
            this.FSM_tbl_routes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FSM_tbl_routes.AutoScroll = true;
            this.FSM_tbl_routes.ColumnCount = 3;
            this.FSM_tbl_routes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.FSM_tbl_routes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.FSM_tbl_routes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.FSM_tbl_routes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FSM_tbl_routes.Location = new System.Drawing.Point(0, 0);
            this.FSM_tbl_routes.Name = "FSM_tbl_routes";
            this.FSM_tbl_routes.RowCount = 1;
            this.FSM_tbl_routes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FSM_tbl_routes.Size = new System.Drawing.Size(289, 541);
            this.FSM_tbl_routes.TabIndex = 0;
            // 
            // FSM_tab_run
            // 
            this.FSM_tab_run.Controls.Add(this.FSM_board);
            this.FSM_tab_run.Controls.Add(this.panel3);
            this.FSM_tab_run.Controls.Add(this.tableLayoutPanel4);
            this.FSM_tab_run.Location = new System.Drawing.Point(4, 22);
            this.FSM_tab_run.Name = "FSM_tab_run";
            this.FSM_tab_run.Size = new System.Drawing.Size(289, 540);
            this.FSM_tab_run.TabIndex = 2;
            this.FSM_tab_run.Text = "Run";
            this.FSM_tab_run.UseVisualStyleBackColor = true;
            // 
            // FSM_board
            // 
            this.FSM_board.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.FSM_board.ColumnCount = 2;
            this.FSM_board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.FSM_board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.FSM_board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FSM_board.Location = new System.Drawing.Point(0, 187);
            this.FSM_board.Margin = new System.Windows.Forms.Padding(2);
            this.FSM_board.Name = "FSM_board";
            this.FSM_board.RowCount = 4;
            this.FSM_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.FSM_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.FSM_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.FSM_board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.FSM_board.Size = new System.Drawing.Size(289, 353);
            this.FSM_board.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 108);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 79);
            this.panel3.TabIndex = 15;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.fsm_run, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.fsm_auto, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tb_timer, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.fsm_prev, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.fsm_next, 4, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 19);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 61, 2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(289, 42);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // fsm_run
            // 
            this.fsm_run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsm_run.Location = new System.Drawing.Point(2, 2);
            this.fsm_run.Margin = new System.Windows.Forms.Padding(2);
            this.fsm_run.Name = "fsm_run";
            this.fsm_run.Size = new System.Drawing.Size(53, 38);
            this.fsm_run.TabIndex = 7;
            this.fsm_run.Text = "Run";
            this.fsm_run.UseVisualStyleBackColor = true;
            this.fsm_run.Click += new System.EventHandler(this.fsm_run_Click);
            // 
            // fsm_auto
            // 
            this.fsm_auto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsm_auto.Location = new System.Drawing.Point(59, 2);
            this.fsm_auto.Margin = new System.Windows.Forms.Padding(2);
            this.fsm_auto.Name = "fsm_auto";
            this.fsm_auto.Size = new System.Drawing.Size(53, 38);
            this.fsm_auto.TabIndex = 10;
            this.fsm_auto.Text = "Auto/Stop";
            this.fsm_auto.UseVisualStyleBackColor = true;
            this.fsm_auto.Visible = false;
            this.fsm_auto.Click += new System.EventHandler(this.fsm_auto_Click);
            // 
            // tb_timer
            // 
            this.tb_timer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_timer.Location = new System.Drawing.Point(117, 3);
            this.tb_timer.Name = "tb_timer";
            this.tb_timer.Size = new System.Drawing.Size(51, 20);
            this.tb_timer.TabIndex = 11;
            this.tb_timer.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // fsm_prev
            // 
            this.fsm_prev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsm_prev.Location = new System.Drawing.Point(173, 2);
            this.fsm_prev.Margin = new System.Windows.Forms.Padding(2);
            this.fsm_prev.Name = "fsm_prev";
            this.fsm_prev.Size = new System.Drawing.Size(53, 38);
            this.fsm_prev.TabIndex = 8;
            this.fsm_prev.Text = "Prev";
            this.fsm_prev.UseVisualStyleBackColor = true;
            this.fsm_prev.Visible = false;
            this.fsm_prev.Click += new System.EventHandler(this.fsm_prev_Click);
            // 
            // fsm_next
            // 
            this.fsm_next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsm_next.Location = new System.Drawing.Point(230, 2);
            this.fsm_next.Margin = new System.Windows.Forms.Padding(2);
            this.fsm_next.Name = "fsm_next";
            this.fsm_next.Size = new System.Drawing.Size(57, 38);
            this.fsm_next.TabIndex = 9;
            this.fsm_next.Text = "Next";
            this.fsm_next.UseVisualStyleBackColor = true;
            this.fsm_next.Visible = false;
            this.fsm_next.Click += new System.EventHandler(this.fsm_next_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.end_cb1, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.start_cb1, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.algo_cb1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(289, 108);
            this.tableLayoutPanel4.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Algorithm ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "End";
            // 
            // end_cb1
            // 
            this.end_cb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.end_cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.end_cb1.FormattingEnabled = true;
            this.end_cb1.Location = new System.Drawing.Point(88, 80);
            this.end_cb1.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.end_cb1.Name = "end_cb1";
            this.end_cb1.Size = new System.Drawing.Size(140, 21);
            this.end_cb1.TabIndex = 5;
            this.end_cb1.Click += new System.EventHandler(this.end_cb_Click_1);
            // 
            // start_cb1
            // 
            this.start_cb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.start_cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.start_cb1.FormattingEnabled = true;
            this.start_cb1.Location = new System.Drawing.Point(88, 44);
            this.start_cb1.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.start_cb1.Name = "start_cb1";
            this.start_cb1.Size = new System.Drawing.Size(140, 21);
            this.start_cb1.TabIndex = 3;
            this.start_cb1.Click += new System.EventHandler(this.start_cb_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Start";
            // 
            // algo_cb1
            // 
            this.algo_cb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.algo_cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algo_cb1.FormattingEnabled = true;
            this.algo_cb1.Items.AddRange(new object[] {
            "Best First Search",
            "A *",
            "Recursive Best First Search"});
            this.algo_cb1.Location = new System.Drawing.Point(88, 8);
            this.algo_cb1.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this.algo_cb1.Name = "algo_cb1";
            this.algo_cb1.Size = new System.Drawing.Size(140, 21);
            this.algo_cb1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.fsm_import, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.fsm_reset, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(297, 66);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // fsm_import
            // 
            this.fsm_import.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsm_import.Location = new System.Drawing.Point(3, 36);
            this.fsm_import.Name = "fsm_import";
            this.fsm_import.Size = new System.Drawing.Size(291, 27);
            this.fsm_import.TabIndex = 1;
            this.fsm_import.Text = "Import";
            this.fsm_import.UseVisualStyleBackColor = true;
            this.fsm_import.Click += new System.EventHandler(this.fsm_import_Click);
            // 
            // fsm_reset
            // 
            this.fsm_reset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsm_reset.Location = new System.Drawing.Point(3, 3);
            this.fsm_reset.Name = "fsm_reset";
            this.fsm_reset.Size = new System.Drawing.Size(291, 27);
            this.fsm_reset.TabIndex = 2;
            this.fsm_reset.Text = "Reset";
            this.fsm_reset.UseVisualStyleBackColor = true;
            this.fsm_reset.Click += new System.EventHandler(this.fsm_reset_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(952, 645);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fsm_timer
            // 
            this.fsm_timer.Interval = 1000;
            this.fsm_timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 672);
            this.Controls.Add(this.program_tab);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "AI Search Project";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.PlacesTab.ResumeLayout(false);
            this.placeTab.ResumeLayout(false);
            this.routeTab.ResumeLayout(false);
            this.RunTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableRunControl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.program_tab.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.FSM_main_container.Panel1.ResumeLayout(false);
            this.FSM_main_container.Panel1.PerformLayout();
            this.FSM_main_container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FSM_main_container)).EndInit();
            this.FSM_main_container.ResumeLayout(false);
            this.fsm_option_container.Panel1.ResumeLayout(false);
            this.fsm_option_container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fsm_option_container)).EndInit();
            this.fsm_option_container.ResumeLayout(false);
            this.FSM_tab.ResumeLayout(false);
            this.FSM_tab_node.ResumeLayout(false);
            this.FSM_tab_route.ResumeLayout(false);
            this.FSM_tab_run.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private GMap.NET.WindowsForms.GMapControl gMapMain;
        private System.Windows.Forms.TabControl PlacesTab;
        private System.Windows.Forms.TabPage placeTab;
        private System.Windows.Forms.TableLayoutPanel tablePlaces;
        private System.Windows.Forms.TabPage routeTab;
        private System.Windows.Forms.TableLayoutPanel tableRoute;
        private System.Windows.Forms.TabPage RunTab;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableBoard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableRunControl;
        private System.Windows.Forms.Button prev_btn;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox end_cb;
        private System.Windows.Forms.ComboBox start_cb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox algo_cb;
        private System.Windows.Forms.Button Autos;
        private System.Windows.Forms.Timer autoShowStep;
        private System.Windows.Forms.TabControl program_tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer FSM_main_container;
        private System.Windows.Forms.TabControl FSM_tab;
        private System.Windows.Forms.TabPage FSM_tab_node;
        private System.Windows.Forms.TabPage FSM_tab_route;
        private System.Windows.Forms.TableLayoutPanel FSM_tbl_nodes;
        private System.Windows.Forms.TabPage FSM_tab_run;
        private custom_Canvas FSM_canvas;
        private System.Windows.Forms.TableLayoutPanel FSM_tbl_routes;
        private System.Windows.Forms.TableLayoutPanel FSM_board;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button fsm_auto;
        private System.Windows.Forms.Button fsm_prev;
        private System.Windows.Forms.Button fsm_next;
        private System.Windows.Forms.Button fsm_run;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox end_cb1;
        private System.Windows.Forms.ComboBox start_cb1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox algo_cb1;
        private System.Windows.Forms.Timer fsm_timer;
        private System.Windows.Forms.TextBox tb_timer;
        private System.Windows.Forms.SplitContainer fsm_option_container;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button fsm_import;
        private System.Windows.Forms.Button fsm_reset;
    }
}

