namespace gR_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.GraphStyleCB = new System.Windows.Forms.ComboBox();
            this.TB_KillExcel = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.TB_Inp = new System.Windows.Forms.TextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.TB_Outp = new System.Windows.Forms.TextBox();
            this.Btn_Outp = new System.Windows.Forms.Button();
            this.Label18 = new System.Windows.Forms.Label();
            this.ProgressBar7 = new System.Windows.Forms.ProgressBar();
            this.Btn_Exec = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_WS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_WI = new System.Windows.Forms.TextBox();
            this.Btn_Inp = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.GraphStylePB = new System.Windows.Forms.PictureBox();
            this.TB_Help = new System.Windows.Forms.Button();
            this.TB_Info = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GraphStylePB)).BeginInit();
            this.SuspendLayout();
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.BackColor = System.Drawing.Color.Yellow;
            this.Label3.Name = "Label3";
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.BackColor = System.Drawing.Color.Yellow;
            this.Label2.Name = "Label2";
            // 
            // GraphStyleCB
            // 
            this.GraphStyleCB.BackColor = System.Drawing.Color.Black;
            this.GraphStyleCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.GraphStyleCB, "GraphStyleCB");
            this.GraphStyleCB.ForeColor = System.Drawing.Color.White;
            this.GraphStyleCB.FormattingEnabled = true;
            this.GraphStyleCB.Items.AddRange(new object[] {
            resources.GetString("GraphStyleCB.Items"),
            resources.GetString("GraphStyleCB.Items1"),
            resources.GetString("GraphStyleCB.Items2"),
            resources.GetString("GraphStyleCB.Items3")});
            this.GraphStyleCB.Name = "GraphStyleCB";
            this.GraphStyleCB.SelectedIndexChanged += new System.EventHandler(this.GraphStyleCB_SelectedIndexChanged);
            // 
            // TB_KillExcel
            // 
            this.TB_KillExcel.BackColor = System.Drawing.Color.Violet;
            resources.ApplyResources(this.TB_KillExcel, "TB_KillExcel");
            this.TB_KillExcel.ForeColor = System.Drawing.Color.Black;
            this.TB_KillExcel.Name = "TB_KillExcel";
            this.TB_KillExcel.UseVisualStyleBackColor = false;
            this.TB_KillExcel.Click += new System.EventHandler(this.TB_KillExcel_Click);
            // 
            // Label22
            // 
            resources.ApplyResources(this.Label22, "Label22");
            this.Label22.BackColor = System.Drawing.Color.Yellow;
            this.Label22.Name = "Label22";
            // 
            // TB_Inp
            // 
            this.TB_Inp.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.TB_Inp, "TB_Inp");
            this.TB_Inp.ForeColor = System.Drawing.Color.White;
            this.TB_Inp.Name = "TB_Inp";
            // 
            // Label21
            // 
            resources.ApplyResources(this.Label21, "Label21");
            this.Label21.BackColor = System.Drawing.Color.Yellow;
            this.Label21.Name = "Label21";
            // 
            // TB_Outp
            // 
            this.TB_Outp.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.TB_Outp, "TB_Outp");
            this.TB_Outp.ForeColor = System.Drawing.Color.White;
            this.TB_Outp.Name = "TB_Outp";
            // 
            // Btn_Outp
            // 
            this.Btn_Outp.BackColor = System.Drawing.Color.RoyalBlue;
            resources.ApplyResources(this.Btn_Outp, "Btn_Outp");
            this.Btn_Outp.ForeColor = System.Drawing.Color.White;
            this.Btn_Outp.Name = "Btn_Outp";
            this.Btn_Outp.UseVisualStyleBackColor = false;
            this.Btn_Outp.Click += new System.EventHandler(this.Btn_Outp_Click);
            // 
            // Label18
            // 
            resources.ApplyResources(this.Label18, "Label18");
            this.Label18.BackColor = System.Drawing.Color.Yellow;
            this.Label18.Name = "Label18";
            // 
            // ProgressBar7
            // 
            resources.ApplyResources(this.ProgressBar7, "ProgressBar7");
            this.ProgressBar7.Name = "ProgressBar7";
            // 
            // Btn_Exec
            // 
            this.Btn_Exec.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.Btn_Exec, "Btn_Exec");
            this.Btn_Exec.ForeColor = System.Drawing.Color.White;
            this.Btn_Exec.Name = "Btn_Exec";
            this.Btn_Exec.UseVisualStyleBackColor = false;
            this.Btn_Exec.Click += new System.EventHandler(this.Btn_Exec_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Name = "label1";
            // 
            // TB_WS
            // 
            this.TB_WS.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.TB_WS, "TB_WS");
            this.TB_WS.ForeColor = System.Drawing.Color.White;
            this.TB_WS.Name = "TB_WS";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Name = "label4";
            // 
            // TB_WI
            // 
            this.TB_WI.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.TB_WI, "TB_WI");
            this.TB_WI.ForeColor = System.Drawing.Color.White;
            this.TB_WI.Name = "TB_WI";
            // 
            // Btn_Inp
            // 
            this.Btn_Inp.BackColor = System.Drawing.Color.RoyalBlue;
            resources.ApplyResources(this.Btn_Inp, "Btn_Inp");
            this.Btn_Inp.ForeColor = System.Drawing.Color.White;
            this.Btn_Inp.Name = "Btn_Inp";
            this.Btn_Inp.UseVisualStyleBackColor = false;
            this.Btn_Inp.Click += new System.EventHandler(this.Btn_Inp_Click);
            // 
            // GraphStylePB
            // 
            this.GraphStylePB.BackColor = System.Drawing.Color.Transparent;
            this.GraphStylePB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.GraphStylePB, "GraphStylePB");
            this.GraphStylePB.Name = "GraphStylePB";
            this.GraphStylePB.TabStop = false;
            // 
            // TB_Help
            // 
            this.TB_Help.BackColor = System.Drawing.Color.LimeGreen;
            resources.ApplyResources(this.TB_Help, "TB_Help");
            this.TB_Help.Name = "TB_Help";
            this.TB_Help.UseVisualStyleBackColor = false;
            // 
            // TB_Info
            // 
            this.TB_Info.BackColor = System.Drawing.Color.LimeGreen;
            this.TB_Info.BackgroundImage = global::gR_window.Properties.Resources.InfoIcon;
            resources.ApplyResources(this.TB_Info, "TB_Info");
            this.TB_Info.Name = "TB_Info";
            this.TB_Info.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gR_window.Properties.Resources.BG3;
            this.Controls.Add(this.Btn_Inp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_WI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_WS);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.ProgressBar7);
            this.Controls.Add(this.Btn_Exec);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.TB_Outp);
            this.Controls.Add(this.Btn_Outp);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.TB_Inp);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.GraphStylePB);
            this.Controls.Add(this.GraphStyleCB);
            this.Controls.Add(this.TB_KillExcel);
            this.Controls.Add(this.TB_Help);
            this.Controls.Add(this.TB_Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GraphStylePB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.PictureBox GraphStylePB;
        internal System.Windows.Forms.ComboBox GraphStyleCB;
        internal System.Windows.Forms.Button TB_KillExcel;
        internal System.Windows.Forms.Button TB_Help;
        internal System.Windows.Forms.Button TB_Info;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.TextBox TB_Inp;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.TextBox TB_Outp;
        internal System.Windows.Forms.Button Btn_Outp;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.ProgressBar ProgressBar7;
        internal System.Windows.Forms.Button Btn_Exec;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox TB_WS;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox TB_WI;
        internal System.Windows.Forms.Button Btn_Inp;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

