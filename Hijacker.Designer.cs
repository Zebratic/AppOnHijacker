
namespace AppOnHijacker
{
    partial class Hijacker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hijacker));
            this.btnHijackVPS = new System.Windows.Forms.Button();
            this.cbIncognito = new System.Windows.Forms.CheckBox();
            this.cbAdminHijack = new System.Windows.Forms.CheckBox();
            this.cbFullscreen = new System.Windows.Forms.CheckBox();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.btnKilldrivers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHijackVPS
            // 
            this.btnHijackVPS.Location = new System.Drawing.Point(149, 7);
            this.btnHijackVPS.Name = "btnHijackVPS";
            this.btnHijackVPS.Size = new System.Drawing.Size(92, 23);
            this.btnHijackVPS.TabIndex = 0;
            this.btnHijackVPS.Text = "Hijack VPS";
            this.btnHijackVPS.UseVisualStyleBackColor = true;
            this.btnHijackVPS.Click += new System.EventHandler(this.btnHijackVPS_Click);
            // 
            // cbIncognito
            // 
            this.cbIncognito.AutoSize = true;
            this.cbIncognito.Location = new System.Drawing.Point(12, 5);
            this.cbIncognito.Name = "cbIncognito";
            this.cbIncognito.Size = new System.Drawing.Size(70, 17);
            this.cbIncognito.TabIndex = 4;
            this.cbIncognito.Text = "Incognito";
            this.cbIncognito.UseVisualStyleBackColor = true;
            // 
            // cbAdminHijack
            // 
            this.cbAdminHijack.AutoSize = true;
            this.cbAdminHijack.Location = new System.Drawing.Point(12, 22);
            this.cbAdminHijack.Name = "cbAdminHijack";
            this.cbAdminHijack.Size = new System.Drawing.Size(88, 17);
            this.cbAdminHijack.TabIndex = 5;
            this.cbAdminHijack.Text = "Admin Hijack";
            this.cbAdminHijack.UseVisualStyleBackColor = true;
            // 
            // cbFullscreen
            // 
            this.cbFullscreen.AutoSize = true;
            this.cbFullscreen.Location = new System.Drawing.Point(12, 39);
            this.cbFullscreen.Name = "cbFullscreen";
            this.cbFullscreen.Size = new System.Drawing.Size(131, 17);
            this.cbFullscreen.TabIndex = 6;
            this.cbFullscreen.Text = "Fullscreen on connect";
            this.cbFullscreen.UseVisualStyleBackColor = true;
            // 
            // rtxtLog
            // 
            this.rtxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtLog.Location = new System.Drawing.Point(0, 62);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(254, 129);
            this.rtxtLog.TabIndex = 7;
            this.rtxtLog.Text = "";
            this.rtxtLog.TextChanged += new System.EventHandler(this.rtxtLog_TextChanged);
            // 
            // btnKilldrivers
            // 
            this.btnKilldrivers.Location = new System.Drawing.Point(149, 36);
            this.btnKilldrivers.Name = "btnKilldrivers";
            this.btnKilldrivers.Size = new System.Drawing.Size(92, 23);
            this.btnKilldrivers.TabIndex = 8;
            this.btnKilldrivers.Text = "Kill drivers";
            this.btnKilldrivers.UseVisualStyleBackColor = true;
            this.btnKilldrivers.Click += new System.EventHandler(this.btnKilldrivers_Click);
            // 
            // Hijacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 189);
            this.Controls.Add(this.btnKilldrivers);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.cbFullscreen);
            this.Controls.Add(this.cbAdminHijack);
            this.Controls.Add(this.cbIncognito);
            this.Controls.Add(this.btnHijackVPS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(269, 99);
            this.Name = "Hijacker";
            this.Text = "AppOnHijacker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHijackVPS;
        private System.Windows.Forms.CheckBox cbIncognito;
        private System.Windows.Forms.CheckBox cbAdminHijack;
        private System.Windows.Forms.CheckBox cbFullscreen;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.Button btnKilldrivers;
    }
}

