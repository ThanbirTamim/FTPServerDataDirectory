
namespace FTPDataDirectory
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
        /// 
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPort = new System.Windows.Forms.ComboBox();
            this.txtHost = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.radioButtonSn = new System.Windows.Forms.RadioButton();
            this.radioButtonTr = new System.Windows.Forms.RadioButton();
            this.radioButtonEx = new System.Windows.Forms.RadioButton();
            this.radioButtonDB = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtPort);
            this.panel2.Controls.Add(this.txtHost);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCheck);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 193);
            this.panel2.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.FormattingEnabled = true;
            this.txtPort.Items.AddRange(new object[] {
            "101",
            "100",
            "102"});
            this.txtPort.Location = new System.Drawing.Point(7, 72);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(165, 21);
            this.txtPort.TabIndex = 18;
            this.txtPort.Text = "100";
            // 
            // txtHost
            // 
            this.txtHost.FormattingEnabled = true;
            this.txtHost.Items.AddRange(new object[] {
            "127.0.0.1",
            "172.16.255.8",
            "172.16.101.61"});
            this.txtHost.Location = new System.Drawing.Point(7, 18);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(165, 21);
            this.txtHost.TabIndex = 17;
            this.txtHost.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Host";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.Color.SkyBlue;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(7, 108);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(73, 28);
            this.btnCheck.TabIndex = 12;
            this.btnCheck.Text = "Check Server";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 196);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(223, 254);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Size = new System.Drawing.Size(573, 450);
            this.splitContainer2.SplitterDistance = 439;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(439, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.btnUpload);
            this.panel3.Controls.Add(this.radioButtonSn);
            this.panel3.Controls.Add(this.radioButtonTr);
            this.panel3.Controls.Add(this.radioButtonEx);
            this.panel3.Controls.Add(this.radioButtonDB);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(20);
            this.panel3.Size = new System.Drawing.Size(130, 450);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpload.Location = new System.Drawing.Point(20, 88);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 12, 3, 10);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(88, 34);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // radioButtonSn
            // 
            this.radioButtonSn.AutoSize = true;
            this.radioButtonSn.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButtonSn.Location = new System.Drawing.Point(20, 71);
            this.radioButtonSn.Name = "radioButtonSn";
            this.radioButtonSn.Size = new System.Drawing.Size(88, 17);
            this.radioButtonSn.TabIndex = 4;
            this.radioButtonSn.TabStop = true;
            this.radioButtonSn.Text = "Extra";
            this.radioButtonSn.UseVisualStyleBackColor = true;
            // 
            // radioButtonTr
            // 
            this.radioButtonTr.AutoSize = true;
            this.radioButtonTr.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButtonTr.Location = new System.Drawing.Point(20, 54);
            this.radioButtonTr.Name = "radioButtonTr";
            this.radioButtonTr.Size = new System.Drawing.Size(88, 17);
            this.radioButtonTr.TabIndex = 3;
            this.radioButtonTr.TabStop = true;
            this.radioButtonTr.Text = "Image";
            this.radioButtonTr.UseVisualStyleBackColor = true;
            // 
            // radioButtonEx
            // 
            this.radioButtonEx.AutoSize = true;
            this.radioButtonEx.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButtonEx.Location = new System.Drawing.Point(20, 37);
            this.radioButtonEx.Name = "radioButtonEx";
            this.radioButtonEx.Size = new System.Drawing.Size(88, 17);
            this.radioButtonEx.TabIndex = 2;
            this.radioButtonEx.TabStop = true;
            this.radioButtonEx.Text = "Video";
            this.radioButtonEx.UseVisualStyleBackColor = true;
            // 
            // radioButtonDB
            // 
            this.radioButtonDB.AutoSize = true;
            this.radioButtonDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButtonDB.Location = new System.Drawing.Point(20, 20);
            this.radioButtonDB.Name = "radioButtonDB";
            this.radioButtonDB.Size = new System.Drawing.Size(88, 17);
            this.radioButtonDB.TabIndex = 1;
            this.radioButtonDB.TabStop = true;
            this.radioButtonDB.Text = "Audio";
            this.radioButtonDB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.RadioButton radioButtonTr;
        private System.Windows.Forms.RadioButton radioButtonEx;
        private System.Windows.Forms.RadioButton radioButtonDB;
        private System.Windows.Forms.RadioButton radioButtonSn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox txtHost;
        private System.Windows.Forms.ComboBox txtPort;
    }
}

