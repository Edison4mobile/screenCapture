namespace WindowsFormsApplication2
{
    partial class FloatingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloatingWindow));
            this.colorText = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.position = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // colorText
            // 
            this.colorText.Location = new System.Drawing.Point(1, 21);
            this.colorText.Name = "colorText";
            this.colorText.Size = new System.Drawing.Size(143, 29);
            this.colorText.TabIndex = 0;
            this.colorText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(60, 80);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(1, 50);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(143, 29);
            this.position.TabIndex = 0;
            this.position.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FloatingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 101);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.position);
            this.Controls.Add(this.colorText);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(140, 140);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(140, 140);
            this.Name = "FloatingWindow";
            this.ShowInTaskbar = false;
            this.Text = "FloatingWindow";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.myDrawingPanel_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FloatingWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FloatingWindow_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label colorText;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label position;

    }
}