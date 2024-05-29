namespace OS_Project
{
    partial class Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Tasks = new System.Windows.Forms.DataGridView();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Home = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clearList = new System.Windows.Forms.Button();
            this.deleteTask = new System.Windows.Forms.Button();
            this.completeTask = new System.Windows.Forms.Button();
            this.addTask = new System.Windows.Forms.Button();
            this.taskTB = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tasks)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Tasks);
            this.panel1.Location = new System.Drawing.Point(214, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1254, 610);
            this.panel1.TabIndex = 19;
            // 
            // Tasks
            // 
            this.Tasks.BackgroundColor = System.Drawing.Color.DimGray;
            this.Tasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Task});
            this.Tasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tasks.Location = new System.Drawing.Point(0, 0);
            this.Tasks.Name = "Tasks";
            this.Tasks.RowHeadersWidth = 62;
            this.Tasks.Size = new System.Drawing.Size(1254, 610);
            this.Tasks.TabIndex = 0;
            // 
            // Task
            // 
            this.Task.HeaderText = "Tasks";
            this.Task.MinimumWidth = 8;
            this.Task.Name = "Task";
            this.Task.Width = 150;
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.Color.Maroon;
            this.Home.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Home.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.ForeColor = System.Drawing.SystemColors.Control;
            this.Home.Location = new System.Drawing.Point(0, 444);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(200, 35);
            this.Home.TabIndex = 18;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = false;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Enter New Task Here";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.clearList);
            this.panel3.Controls.Add(this.deleteTask);
            this.panel3.Controls.Add(this.completeTask);
            this.panel3.Controls.Add(this.addTask);
            this.panel3.Controls.Add(this.taskTB);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.Home);
            this.panel3.Location = new System.Drawing.Point(8, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 479);
            this.panel3.TabIndex = 18;
            // 
            // clearList
            // 
            this.clearList.BackColor = System.Drawing.Color.DimGray;
            this.clearList.Dock = System.Windows.Forms.DockStyle.Top;
            this.clearList.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearList.ForeColor = System.Drawing.SystemColors.Control;
            this.clearList.Location = new System.Drawing.Point(0, 214);
            this.clearList.Name = "clearList";
            this.clearList.Size = new System.Drawing.Size(200, 43);
            this.clearList.TabIndex = 42;
            this.clearList.Text = "Clear List";
            this.clearList.UseVisualStyleBackColor = false;
            // 
            // deleteTask
            // 
            this.deleteTask.BackColor = System.Drawing.Color.Red;
            this.deleteTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteTask.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteTask.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteTask.Location = new System.Drawing.Point(0, 171);
            this.deleteTask.Name = "deleteTask";
            this.deleteTask.Size = new System.Drawing.Size(200, 43);
            this.deleteTask.TabIndex = 41;
            this.deleteTask.Text = "Delete Task";
            this.deleteTask.UseVisualStyleBackColor = false;
            this.deleteTask.Click += new System.EventHandler(this.deleteTask_Click);
            // 
            // completeTask
            // 
            this.completeTask.BackColor = System.Drawing.Color.SeaGreen;
            this.completeTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.completeTask.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeTask.ForeColor = System.Drawing.SystemColors.Control;
            this.completeTask.Location = new System.Drawing.Point(0, 128);
            this.completeTask.Name = "completeTask";
            this.completeTask.Size = new System.Drawing.Size(200, 43);
            this.completeTask.TabIndex = 40;
            this.completeTask.Text = "Mark as Completed";
            this.completeTask.UseVisualStyleBackColor = false;
            this.completeTask.Click += new System.EventHandler(this.completeTask_Click);
            // 
            // addTask
            // 
            this.addTask.BackColor = System.Drawing.Color.RoyalBlue;
            this.addTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.addTask.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTask.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addTask.Location = new System.Drawing.Point(0, 85);
            this.addTask.Name = "addTask";
            this.addTask.Size = new System.Drawing.Size(200, 43);
            this.addTask.TabIndex = 39;
            this.addTask.Text = "Add Task";
            this.addTask.UseVisualStyleBackColor = false;
            this.addTask.Click += new System.EventHandler(this.addTask_Click);
            // 
            // taskTB
            // 
            this.taskTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskTB.Location = new System.Drawing.Point(0, 13);
            this.taskTB.Name = "taskTB";
            this.taskTB.Size = new System.Drawing.Size(200, 72);
            this.taskTB.TabIndex = 32;
            this.taskTB.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08806F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.91194F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1194, 130);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.46154F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(195, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(996, 124);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Peru;
            this.label1.Location = new System.Drawing.Point(328, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 62);
            this.label1.TabIndex = 28;
            this.label1.Text = "NOTION 2.0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(210, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(575, 35);
            this.label2.TabIndex = 23;
            this.label2.Text = "All-in-one workspace: Write, plan, collaborate, and get organized";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::OS_Project.Properties.Resources.pexels_breakingpic_3299_removebg_preview;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 124);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1194, 618);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tasks)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button clearList;
        private System.Windows.Forms.Button deleteTask;
        private System.Windows.Forms.Button completeTask;
        private System.Windows.Forms.Button addTask;
        private System.Windows.Forms.RichTextBox taskTB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView Tasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
    }
}