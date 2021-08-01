
namespace FlukeTest
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.窗口ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.設備ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加設備配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.窗口ToolStripMenuItem1,
            this.設備ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 窗口ToolStripMenuItem1
            // 
            this.窗口ToolStripMenuItem1.Name = "窗口ToolStripMenuItem1";
            this.窗口ToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.窗口ToolStripMenuItem1.Text = "窗口";
            // 
            // 設備ToolStripMenuItem1
            // 
            this.設備ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加設備配置ToolStripMenuItem});
            this.設備ToolStripMenuItem1.Name = "設備ToolStripMenuItem1";
            this.設備ToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.設備ToolStripMenuItem1.Text = "設備";
            // 
            // 添加設備配置ToolStripMenuItem
            // 
            this.添加設備配置ToolStripMenuItem.Name = "添加設備配置ToolStripMenuItem";
            this.添加設備配置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加設備配置ToolStripMenuItem.Text = "添加設備配置";
            this.添加設備配置ToolStripMenuItem.Click += new System.EventHandler(this.添加設備配置ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 窗口ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 設備ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加設備配置ToolStripMenuItem;
    }
}