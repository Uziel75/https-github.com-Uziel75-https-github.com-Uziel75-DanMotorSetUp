namespace DanMotorGUIFORM
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
            label1 = new Label();
            listBoxParts = new ListBox();
            btnEditParts = new Button();
            btnDeleteParts = new Button();
            btnAddParts = new Button();
            radioButtonYamaha = new RadioButton();
            radioButtonHonda = new RadioButton();
            label2 = new Label();
            label3 = new Label();
            textBoxModel = new TextBox();
            label4 = new Label();
            textBoxConcept = new TextBox();
            textBoxPart = new TextBox();
            label5 = new Label();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Stencil", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(411, 61);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(640, 43);
            label1.TabIndex = 0;
            label1.Text = "WELCOME TO DAN MOTOR AND PARTS";
            label1.Click += label1_Click;
            // 
            // listBoxParts
            // 
            listBoxParts.ForeColor = SystemColors.MenuHighlight;
            listBoxParts.FormattingEnabled = true;
            listBoxParts.Location = new Point(166, 196);
            listBoxParts.Margin = new Padding(4, 3, 4, 3);
            listBoxParts.Name = "listBoxParts";
            listBoxParts.Size = new Size(389, 388);
            listBoxParts.TabIndex = 1;
            listBoxParts.SelectedIndexChanged += listBoxParts_SelectedIndexChanged;
            // 
            // btnEditParts
            // 
            btnEditParts.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditParts.Location = new Point(587, 196);
            btnEditParts.Margin = new Padding(4, 3, 4, 3);
            btnEditParts.Name = "btnEditParts";
            btnEditParts.Size = new Size(235, 49);
            btnEditParts.TabIndex = 2;
            btnEditParts.Text = "EDIT PARTS";
            btnEditParts.UseVisualStyleBackColor = true;
            btnEditParts.Click += btnEditParts_Click;
            // 
            // btnDeleteParts
            // 
            btnDeleteParts.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteParts.Location = new Point(587, 268);
            btnDeleteParts.Margin = new Padding(4, 3, 4, 3);
            btnDeleteParts.Name = "btnDeleteParts";
            btnDeleteParts.RightToLeft = RightToLeft.Yes;
            btnDeleteParts.Size = new Size(235, 49);
            btnDeleteParts.TabIndex = 3;
            btnDeleteParts.Text = "DELETE PARTS";
            btnDeleteParts.UseVisualStyleBackColor = true;
            btnDeleteParts.Click += btnDeleteParts_Click;
            // 
            // btnAddParts
            // 
            btnAddParts.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddParts.Location = new Point(894, 196);
            btnAddParts.Margin = new Padding(4, 3, 4, 3);
            btnAddParts.Name = "btnAddParts";
            btnAddParts.RightToLeft = RightToLeft.Yes;
            btnAddParts.Size = new Size(235, 49);
            btnAddParts.TabIndex = 4;
            btnAddParts.Text = "ADD PARTS";
            btnAddParts.UseVisualStyleBackColor = true;
            btnAddParts.Click += btnAddParts_Click;
            // 
            // radioButtonYamaha
            // 
            radioButtonYamaha.AutoSize = true;
            radioButtonYamaha.Location = new Point(894, 310);
            radioButtonYamaha.Name = "radioButtonYamaha";
            radioButtonYamaha.Size = new Size(114, 28);
            radioButtonYamaha.TabIndex = 5;
            radioButtonYamaha.TabStop = true;
            radioButtonYamaha.Text = "YAMAHA";
            radioButtonYamaha.UseVisualStyleBackColor = true;
            radioButtonYamaha.CheckedChanged += radioButtonYamaha_CheckedChanged;
            // 
            // radioButtonHonda
            // 
            radioButtonHonda.AutoSize = true;
            radioButtonHonda.Location = new Point(894, 344);
            radioButtonHonda.Name = "radioButtonHonda";
            radioButtonHonda.Size = new Size(101, 28);
            radioButtonHonda.TabIndex = 6;
            radioButtonHonda.TabStop = true;
            radioButtonHonda.Text = "HONDA";
            radioButtonHonda.UseVisualStyleBackColor = true;
            radioButtonHonda.CheckedChanged += radioButtonHonda_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(884, 278);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(181, 29);
            label2.TabIndex = 7;
            label2.Text = "SELECT BRAND";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(884, 375);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(161, 29);
            label3.TabIndex = 8;
            label3.Text = "TYPE MODEL:";
            label3.Click += label3_Click;
            // 
            // textBoxModel
            // 
            textBoxModel.Location = new Point(884, 407);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.Size = new Size(221, 31);
            textBoxModel.TabIndex = 9;
            textBoxModel.TextChanged += textBoxModel_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(884, 463);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(123, 29);
            label4.TabIndex = 10;
            label4.Text = "CONCEPT:";
            // 
            // textBoxConcept
            // 
            textBoxConcept.Location = new Point(884, 495);
            textBoxConcept.Name = "textBoxConcept";
            textBoxConcept.Size = new Size(221, 31);
            textBoxConcept.TabIndex = 11;
            textBoxConcept.TextChanged += textBoxConcept_TextChanged;
            // 
            // textBoxPart
            // 
            textBoxPart.Location = new Point(884, 577);
            textBoxPart.Name = "textBoxPart";
            textBoxPart.Size = new Size(221, 31);
            textBoxPart.TabIndex = 12;
            textBoxPart.TextChanged += textBoxPart_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.Highlight;
            label5.Location = new Point(884, 545);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(82, 29);
            label5.TabIndex = 13;
            label5.Text = "PART:";
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Stencil", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(1059, 55);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.RightToLeft = RightToLeft.Yes;
            btnExit.Size = new Size(235, 49);
            btnExit.TabIndex = 14;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightYellow;
            ClientSize = new Size(1642, 678);
            Controls.Add(btnExit);
            Controls.Add(label5);
            Controls.Add(textBoxPart);
            Controls.Add(textBoxConcept);
            Controls.Add(label4);
            Controls.Add(textBoxModel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(radioButtonHonda);
            Controls.Add(radioButtonYamaha);
            Controls.Add(btnAddParts);
            Controls.Add(btnDeleteParts);
            Controls.Add(btnEditParts);
            Controls.Add(listBoxParts);
            Controls.Add(label1);
            Font = new Font("Stencil", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.CornflowerBlue;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Dashboard";
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBoxParts;
        private Button btnEditParts;
        private Button btnDeleteParts;
        private Button btnAddParts;
        private RadioButton radioButtonYamaha;
        private RadioButton radioButtonHonda;
        private Label label2;
        private Label label3;
        private TextBox textBoxModel;
        private Label label4;
        private TextBox textBoxConcept;
        private TextBox textBoxPart;
        private Label label5;
        private Button btnExit;
    }
}