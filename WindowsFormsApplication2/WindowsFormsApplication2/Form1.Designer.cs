namespace WindowsFormsApplication2
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
            this.colorListView = new System.Windows.Forms.ListView();
            this.colorPickEditText = new DevExpress.XtraEditors.ColorPickEdit();
            this.addColorButton = new System.Windows.Forms.Button();
            this.currentColorBox = new System.Windows.Forms.PictureBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.screenResolution = new System.Windows.Forms.Label();
            this.yPosLabel = new System.Windows.Forms.Label();
            this.xPosLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.bottomEditText = new DevExpress.XtraEditors.TextEdit();
            this.topEditText = new DevExpress.XtraEditors.TextEdit();
            this.rightEditText = new DevExpress.XtraEditors.TextEdit();
            this.leftEdtText = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.left_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchColor = new DevExpress.XtraEditors.ColorPickEdit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentColorBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomEditText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topEditText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightEditText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftEdtText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colorListView
            // 
            this.colorListView.Location = new System.Drawing.Point(6, 6);
            this.colorListView.MultiSelect = false;
            this.colorListView.Name = "colorListView";
            this.colorListView.Size = new System.Drawing.Size(153, 296);
            this.colorListView.TabIndex = 0;
            this.colorListView.UseCompatibleStateImageBehavior = false;
            this.colorListView.SelectedIndexChanged += new System.EventHandler(this.colorListView_SelectedIndexChanged);
            // 
            // colorPickEditText
            // 
            this.colorPickEditText.EditValue = System.Drawing.Color.Empty;
            this.colorPickEditText.Location = new System.Drawing.Point(206, 231);
            this.colorPickEditText.Name = "colorPickEditText";
            this.colorPickEditText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEditText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEditText.Size = new System.Drawing.Size(153, 20);
            this.colorPickEditText.TabIndex = 1;
            // 
            // addColorButton
            // 
            this.addColorButton.Location = new System.Drawing.Point(206, 270);
            this.addColorButton.Name = "addColorButton";
            this.addColorButton.Size = new System.Drawing.Size(153, 30);
            this.addColorButton.TabIndex = 2;
            this.addColorButton.Text = "Add";
            this.addColorButton.UseVisualStyleBackColor = true;
            this.addColorButton.Click += new System.EventHandler(this.addColorButton_Click);
            // 
            // currentColorBox
            // 
            this.currentColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentColorBox.Location = new System.Drawing.Point(206, 6);
            this.currentColorBox.Name = "currentColorBox";
            this.currentColorBox.Size = new System.Drawing.Size(153, 137);
            this.currentColorBox.TabIndex = 4;
            this.currentColorBox.TabStop = false;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(247, 159);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 338);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.colorListView);
            this.tabPage1.Controls.Add(this.removeButton);
            this.tabPage1.Controls.Add(this.currentColorBox);
            this.tabPage1.Controls.Add(this.addColorButton);
            this.tabPage1.Controls.Add(this.colorPickEditText);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(365, 312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Exclude Colors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.screenResolution);
            this.tabPage2.Controls.Add(this.yPosLabel);
            this.tabPage2.Controls.Add(this.xPosLabel);
            this.tabPage2.Controls.Add(this.nextButton);
            this.tabPage2.Controls.Add(this.backButton);
            this.tabPage2.Controls.Add(this.bottomEditText);
            this.tabPage2.Controls.Add(this.topEditText);
            this.tabPage2.Controls.Add(this.rightEditText);
            this.tabPage2.Controls.Add(this.leftEdtText);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.left_label);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.searchColor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(365, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Color Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // screenResolution
            // 
            this.screenResolution.AutoSize = true;
            this.screenResolution.Location = new System.Drawing.Point(112, 14);
            this.screenResolution.Name = "screenResolution";
            this.screenResolution.Size = new System.Drawing.Size(0, 13);
            this.screenResolution.TabIndex = 15;
            this.screenResolution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yPosLabel
            // 
            this.yPosLabel.AutoSize = true;
            this.yPosLabel.Location = new System.Drawing.Point(176, 214);
            this.yPosLabel.Name = "yPosLabel";
            this.yPosLabel.Size = new System.Drawing.Size(0, 13);
            this.yPosLabel.TabIndex = 14;
            // 
            // xPosLabel
            // 
            this.xPosLabel.AutoSize = true;
            this.xPosLabel.Location = new System.Drawing.Point(95, 214);
            this.xPosLabel.Name = "xPosLabel";
            this.xPosLabel.Size = new System.Drawing.Size(0, 13);
            this.xPosLabel.TabIndex = 13;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(225, 238);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 12;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(74, 238);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // bottomEditText
            // 
            this.bottomEditText.Location = new System.Drawing.Point(176, 175);
            this.bottomEditText.Name = "bottomEditText";
            this.bottomEditText.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bottomEditText.Size = new System.Drawing.Size(100, 20);
            this.bottomEditText.TabIndex = 9;
            this.bottomEditText.EditValueChanged += new System.EventHandler(this.bottomEditText_EditValueChanged);
            // 
            // topEditText
            // 
            this.topEditText.Location = new System.Drawing.Point(176, 143);
            this.topEditText.Name = "topEditText";
            this.topEditText.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.topEditText.Size = new System.Drawing.Size(100, 20);
            this.topEditText.TabIndex = 8;
            this.topEditText.EditValueChanged += new System.EventHandler(this.topEditText_EditValueChanged);
            // 
            // rightEditText
            // 
            this.rightEditText.Location = new System.Drawing.Point(176, 111);
            this.rightEditText.Name = "rightEditText";
            this.rightEditText.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.rightEditText.Size = new System.Drawing.Size(100, 20);
            this.rightEditText.TabIndex = 7;
            this.rightEditText.EditValueChanged += new System.EventHandler(this.rightEditText_EditValueChanged);
            // 
            // leftEdtText
            // 
            this.leftEdtText.Location = new System.Drawing.Point(176, 79);
            this.leftEdtText.Name = "leftEdtText";
            this.leftEdtText.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.leftEdtText.Size = new System.Drawing.Size(100, 20);
            this.leftEdtText.TabIndex = 6;
            this.leftEdtText.EditValueChanged += new System.EventHandler(this.leftEdtText_EditValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Bottom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Top";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Right";
            // 
            // left_label
            // 
            this.left_label.AutoSize = true;
            this.left_label.Location = new System.Drawing.Point(92, 82);
            this.left_label.Name = "left_label";
            this.left_label.Size = new System.Drawing.Size(25, 13);
            this.left_label.TabIndex = 2;
            this.left_label.Text = "Left";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Color";
            // 
            // searchColor
            // 
            this.searchColor.EditValue = System.Drawing.Color.Empty;
            this.searchColor.Location = new System.Drawing.Point(176, 47);
            this.searchColor.Name = "searchColor";
            this.searchColor.Properties.AutoHeight = false;
            this.searchColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.searchColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchColor.Size = new System.Drawing.Size(100, 20);
            this.searchColor.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 343);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(398, 382);
            this.MinimumSize = new System.Drawing.Size(398, 382);
            this.Name = "Form1";
            this.Text = "Universal Color Picker";
            this.Load += new System.EventHandler(this.homeLoad);
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentColorBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bottomEditText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topEditText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightEditText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftEdtText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchColor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView colorListView;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEditText;
        private System.Windows.Forms.Button addColorButton;
        private System.Windows.Forms.PictureBox currentColorBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraEditors.ColorPickEdit searchColor;
        private DevExpress.XtraEditors.TextEdit leftEdtText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label left_label;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit bottomEditText;
        private DevExpress.XtraEditors.TextEdit topEditText;
        private DevExpress.XtraEditors.TextEdit rightEditText;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label yPosLabel;
        private System.Windows.Forms.Label xPosLabel;
        private System.Windows.Forms.Label screenResolution;

    }
}

