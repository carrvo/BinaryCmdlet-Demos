
namespace PowerShellFormCmdlet
{
    partial class SquareForm
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
            this.InteractiveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InteractiveButton
            // 
            this.InteractiveButton.Location = new System.Drawing.Point(315, 197);
            this.InteractiveButton.Name = "InteractiveButton";
            this.InteractiveButton.Size = new System.Drawing.Size(75, 23);
            this.InteractiveButton.TabIndex = 0;
            this.InteractiveButton.Text = "Click Me!";
            this.InteractiveButton.UseVisualStyleBackColor = true;
            this.InteractiveButton.LocationChanged += new System.EventHandler(this.InteractiveButton_LocationChanged);
            this.InteractiveButton.TextChanged += new System.EventHandler(this.InteractiveButton_TextChanged);
            // 
            // SquareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InteractiveButton);
            this.Name = "SquareForm";
            this.Text = "Form1";
            this.BackColorChanged += new System.EventHandler(this.Form1_BackColorChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InteractiveButton;
    }
}