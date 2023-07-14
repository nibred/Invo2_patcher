namespace Invo2_patcher
{
    partial class MainForm
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
            buttonChooseFile = new Button();
            labelSourceFile = new Label();
            tbSourceFileFullPath = new TextBox();
            labeOutputFile = new Label();
            tbOutputFilename = new TextBox();
            buttonPatch = new Button();
            SuspendLayout();
            // 
            // buttonChooseFile
            // 
            buttonChooseFile.Location = new Point(325, 36);
            buttonChooseFile.Name = "buttonChooseFile";
            buttonChooseFile.Size = new Size(120, 32);
            buttonChooseFile.TabIndex = 0;
            buttonChooseFile.Text = "Open";
            buttonChooseFile.UseVisualStyleBackColor = true;
            buttonChooseFile.Click += buttonChooseFile_Click;
            // 
            // labelSourceFile
            // 
            labelSourceFile.AutoSize = true;
            labelSourceFile.Location = new Point(13, 23);
            labelSourceFile.Name = "labelSourceFile";
            labelSourceFile.Size = new Size(124, 15);
            labelSourceFile.TabIndex = 2;
            labelSourceFile.Text = "Original INVO2.dll file:";
            // 
            // tbSourceFileFullPath
            // 
            tbSourceFileFullPath.Location = new Point(13, 41);
            tbSourceFileFullPath.Name = "tbSourceFileFullPath";
            tbSourceFileFullPath.ReadOnly = true;
            tbSourceFileFullPath.Size = new Size(304, 23);
            tbSourceFileFullPath.TabIndex = 3;
            // 
            // labeOutputFile
            // 
            labeOutputFile.AutoSize = true;
            labeOutputFile.Location = new Point(13, 93);
            labeOutputFile.Name = "labeOutputFile";
            labeOutputFile.Size = new Size(97, 15);
            labeOutputFile.TabIndex = 4;
            labeOutputFile.Text = "Output filename:";
            // 
            // tbOutputFilename
            // 
            tbOutputFilename.Location = new Point(116, 90);
            tbOutputFilename.MaxLength = 25;
            tbOutputFilename.Name = "tbOutputFilename";
            tbOutputFilename.Size = new Size(203, 23);
            tbOutputFilename.TabIndex = 5;
            // 
            // buttonPatch
            // 
            buttonPatch.Enabled = false;
            buttonPatch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPatch.Location = new Point(325, 84);
            buttonPatch.Name = "buttonPatch";
            buttonPatch.Size = new Size(120, 32);
            buttonPatch.TabIndex = 6;
            buttonPatch.Text = "Patch";
            buttonPatch.UseVisualStyleBackColor = true;
            buttonPatch.Click += buttonPatch_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 144);
            Controls.Add(buttonPatch);
            Controls.Add(tbOutputFilename);
            Controls.Add(labeOutputFile);
            Controls.Add(tbSourceFileFullPath);
            Controls.Add(labelSourceFile);
            Controls.Add(buttonChooseFile);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INVO2 Patcher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonChooseFile;
        private Label labelSourceFile;
        private TextBox tbSourceFileFullPath;
        private Label labeOutputFile;
        private TextBox tbOutputFilename;
        private Button buttonPatch;
    }
}