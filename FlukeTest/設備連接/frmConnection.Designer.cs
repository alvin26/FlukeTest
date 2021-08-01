
namespace FlukeTest
{
    partial class frmConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnection));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUsb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabConn = new System.Windows.Forms.TabControl();
            this.tabEth = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.NumericUpDown();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.tabRS232 = new System.Windows.Forms.TabPage();
            this.TxtRS232Msg = new System.Windows.Forms.TextBox();
            this.lbxComs = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabUSB = new System.Windows.Forms.TabPage();
            this.TxtUsbMsg = new System.Windows.Forms.TextBox();
            this.lbxUsb = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabConn.SuspendLayout();
            this.tabEth.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            this.tabRS232.SuspendLayout();
            this.tabUSB.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.btnUsb);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(566, 104);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 98);
            this.button1.TabIndex = 1;
            this.button1.Text = "乙太網";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(191, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 98);
            this.button2.TabIndex = 2;
            this.button2.Text = "RS232/RS485";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUsb
            // 
            this.btnUsb.Image = ((System.Drawing.Image)(resources.GetObject("btnUsb.Image")));
            this.btnUsb.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUsb.Location = new System.Drawing.Point(379, 3);
            this.btnUsb.Name = "btnUsb";
            this.btnUsb.Size = new System.Drawing.Size(182, 98);
            this.btnUsb.TabIndex = 3;
            this.btnUsb.Text = "USB";
            this.btnUsb.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsb.UseVisualStyleBackColor = true;
            this.btnUsb.Click += new System.EventHandler(this.btnUsb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "選擇連接類型:";
            // 
            // tabConn
            // 
            this.tabConn.Controls.Add(this.tabEth);
            this.tabConn.Controls.Add(this.tabRS232);
            this.tabConn.Controls.Add(this.tabUSB);
            this.tabConn.Location = new System.Drawing.Point(0, 116);
            this.tabConn.Name = "tabConn";
            this.tabConn.SelectedIndex = 0;
            this.tabConn.Size = new System.Drawing.Size(566, 359);
            this.tabConn.TabIndex = 5;
            this.tabConn.SelectedIndexChanged += new System.EventHandler(this.tabConn_SelectedIndexChanged);
            // 
            // tabEth
            // 
            this.tabEth.Controls.Add(this.tableLayoutPanel1);
            this.tabEth.Location = new System.Drawing.Point(4, 22);
            this.tabEth.Name = "tabEth";
            this.tabEth.Padding = new System.Windows.Forms.Padding(3);
            this.tabEth.Size = new System.Drawing.Size(558, 333);
            this.tabEth.TabIndex = 0;
            this.tabEth.Text = "乙太網";
            this.tabEth.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtIP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDeviceName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPort, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnTestConn, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(552, 327);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtIP
            // 
            this.txtIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIP.Location = new System.Drawing.Point(85, 49);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(344, 22);
            this.txtIP.TabIndex = 4;
            this.txtIP.Text = "192.168.42.132";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "設備名稱";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "IP";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Port";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDeviceName.Location = new System.Drawing.Point(85, 9);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.ReadOnly = true;
            this.txtDeviceName.Size = new System.Drawing.Size(344, 22);
            this.txtDeviceName.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPort.Location = new System.Drawing.Point(85, 89);
            this.txtPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(120, 22);
            this.txtPort.TabIndex = 5;
            this.txtPort.Value = new decimal(new int[] {
            6363,
            0,
            0,
            0});
            // 
            // btnTestConn
            // 
            this.btnTestConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTestConn.Location = new System.Drawing.Point(407, 123);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(142, 31);
            this.btnTestConn.TabIndex = 6;
            this.btnTestConn.Text = "Test Connection";
            this.btnTestConn.UseVisualStyleBackColor = false;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // tabRS232
            // 
            this.tabRS232.Controls.Add(this.TxtRS232Msg);
            this.tabRS232.Controls.Add(this.lbxComs);
            this.tabRS232.Controls.Add(this.button3);
            this.tabRS232.Location = new System.Drawing.Point(4, 22);
            this.tabRS232.Name = "tabRS232";
            this.tabRS232.Padding = new System.Windows.Forms.Padding(3);
            this.tabRS232.Size = new System.Drawing.Size(558, 333);
            this.tabRS232.TabIndex = 1;
            this.tabRS232.Text = "RS232/RS485";
            this.tabRS232.UseVisualStyleBackColor = true;
            // 
            // TxtRS232Msg
            // 
            this.TxtRS232Msg.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtRS232Msg.Location = new System.Drawing.Point(3, 120);
            this.TxtRS232Msg.Multiline = true;
            this.TxtRS232Msg.Name = "TxtRS232Msg";
            this.TxtRS232Msg.Size = new System.Drawing.Size(552, 127);
            this.TxtRS232Msg.TabIndex = 2;
            // 
            // lbxComs
            // 
            this.lbxComs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbxComs.FormattingEnabled = true;
            this.lbxComs.ItemHeight = 12;
            this.lbxComs.Location = new System.Drawing.Point(3, 32);
            this.lbxComs.Name = "lbxComs";
            this.lbxComs.Size = new System.Drawing.Size(552, 88);
            this.lbxComs.TabIndex = 0;
            this.lbxComs.SelectedIndexChanged += new System.EventHandler(this.lbxComs_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(552, 29);
            this.button3.TabIndex = 1;
            this.button3.Text = "重新搜尋序列埠 COM Port";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabUSB
            // 
            this.tabUSB.Controls.Add(this.TxtUsbMsg);
            this.tabUSB.Controls.Add(this.lbxUsb);
            this.tabUSB.Controls.Add(this.button5);
            this.tabUSB.Location = new System.Drawing.Point(4, 22);
            this.tabUSB.Name = "tabUSB";
            this.tabUSB.Padding = new System.Windows.Forms.Padding(3);
            this.tabUSB.Size = new System.Drawing.Size(558, 333);
            this.tabUSB.TabIndex = 2;
            this.tabUSB.Text = "USB";
            this.tabUSB.UseVisualStyleBackColor = true;
            // 
            // TxtUsbMsg
            // 
            this.TxtUsbMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtUsbMsg.Location = new System.Drawing.Point(3, 120);
            this.TxtUsbMsg.Multiline = true;
            this.TxtUsbMsg.Name = "TxtUsbMsg";
            this.TxtUsbMsg.Size = new System.Drawing.Size(552, 127);
            this.TxtUsbMsg.TabIndex = 5;
            // 
            // lbxUsb
            // 
            this.lbxUsb.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbxUsb.FormattingEnabled = true;
            this.lbxUsb.ItemHeight = 12;
            this.lbxUsb.Location = new System.Drawing.Point(3, 32);
            this.lbxUsb.Name = "lbxUsb";
            this.lbxUsb.Size = new System.Drawing.Size(552, 88);
            this.lbxUsb.TabIndex = 3;
            this.lbxUsb.SelectedIndexChanged += new System.EventHandler(this.lbxUsb_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(552, 29);
            this.button5.TabIndex = 4;
            this.button5.Text = "重新搜尋序列埠 COM Port";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(479, 481);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(398, 481);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 516);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabConn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "連接設置";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabConn.ResumeLayout(false);
            this.tabEth.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            this.tabRS232.ResumeLayout(false);
            this.tabRS232.PerformLayout();
            this.tabUSB.ResumeLayout(false);
            this.tabUSB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnUsb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabConn;
        private System.Windows.Forms.TabPage tabEth;
        private System.Windows.Forms.TabPage tabRS232;
        private System.Windows.Forms.TabPage tabUSB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.NumericUpDown txtPort;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.ListBox lbxComs;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox TxtRS232Msg;
        private System.Windows.Forms.TextBox TxtUsbMsg;
        private System.Windows.Forms.ListBox lbxUsb;
        private System.Windows.Forms.Button button5;
    }
}