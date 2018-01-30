namespace tradetool
{
    partial class frmMain
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
            this.btnPolo = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPolo
            // 
            this.btnPolo.Location = new System.Drawing.Point(29, 59);
            this.btnPolo.Name = "btnPolo";
            this.btnPolo.Size = new System.Drawing.Size(75, 23);
            this.btnPolo.TabIndex = 0;
            this.btnPolo.Text = "Polo";
            this.btnPolo.UseVisualStyleBackColor = true;
            this.btnPolo.Click += new System.EventHandler(this.btnPolo_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(138, 59);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 1;
            this.btnAuto.Text = "AutoBuy";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 152);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnPolo);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPolo;
        private System.Windows.Forms.Button btnAuto;
    }
}