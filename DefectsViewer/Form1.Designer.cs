
namespace DefectsViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AddDefect = new System.Windows.Forms.Button();
            this.ToBitMap = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tableLayoutPanel1.Controls.Add(this.AddDefect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ToBitMap, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 640);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1340, 80);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // AddDefect
            // 
            this.AddDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddDefect.Location = new System.Drawing.Point(921, 5);
            this.AddDefect.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.AddDefect.Name = "AddDefect";
            this.AddDefect.Size = new System.Drawing.Size(206, 70);
            this.AddDefect.TabIndex = 0;
            this.AddDefect.Text = "Add Defect";
            this.AddDefect.UseVisualStyleBackColor = true;
            this.AddDefect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddDefect_MouseClick);
            // 
            // ToBitMap
            // 
            this.ToBitMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToBitMap.Location = new System.Drawing.Point(1137, 5);
            this.ToBitMap.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ToBitMap.Name = "ToBitMap";
            this.ToBitMap.Size = new System.Drawing.Size(198, 70);
            this.ToBitMap.TabIndex = 1;
            this.ToBitMap.Text = "ToBitMap";
            this.ToBitMap.UseVisualStyleBackColor = true;
            this.ToBitMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ToBitMap_MouseClick);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainPanel.ColumnCount = 1;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 1;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainPanel.Size = new System.Drawing.Size(1340, 640);
            this.MainPanel.TabIndex = 1;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            this.MainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            this.MainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Defects By Nativ Maatuk";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AddDefect;
        private System.Windows.Forms.Button ToBitMap;
        private System.Windows.Forms.TableLayoutPanel MainPanel;
    }
}

