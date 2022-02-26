
namespace AnalogClock
{
    partial class Setting
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
            this.checkBoxs = new System.Windows.Forms.CheckBox();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonok = new System.Windows.Forms.Button();
            this.checkBoxtop = new System.Windows.Forms.CheckBox();
            this.textBoxEdge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxs
            // 
            this.checkBoxs.AutoSize = true;
            this.checkBoxs.Location = new System.Drawing.Point(31, 59);
            this.checkBoxs.Name = "checkBoxs";
            this.checkBoxs.Size = new System.Drawing.Size(120, 16);
            this.checkBoxs.TabIndex = 0;
            this.checkBoxs.Text = "Show Second Hand";
            this.checkBoxs.UseVisualStyleBackColor = true;
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(64, 6);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(100, 21);
            this.textBoxSize.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Size";
            // 
            // buttonok
            // 
            this.buttonok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonok.Location = new System.Drawing.Point(64, 103);
            this.buttonok.Name = "buttonok";
            this.buttonok.Size = new System.Drawing.Size(75, 23);
            this.buttonok.TabIndex = 3;
            this.buttonok.Text = "OK";
            this.buttonok.UseVisualStyleBackColor = true;
            this.buttonok.Click += new System.EventHandler(this.buttonok_Click);
            // 
            // checkBoxtop
            // 
            this.checkBoxtop.AutoSize = true;
            this.checkBoxtop.Location = new System.Drawing.Point(31, 81);
            this.checkBoxtop.Name = "checkBoxtop";
            this.checkBoxtop.Size = new System.Drawing.Size(66, 16);
            this.checkBoxtop.TabIndex = 4;
            this.checkBoxtop.Text = "Topmost";
            this.checkBoxtop.UseVisualStyleBackColor = true;
            // 
            // textBoxEdge
            // 
            this.textBoxEdge.Location = new System.Drawing.Point(64, 33);
            this.textBoxEdge.Name = "textBoxEdge";
            this.textBoxEdge.Size = new System.Drawing.Size(100, 21);
            this.textBoxEdge.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Edge";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 138);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxEdge);
            this.Controls.Add(this.checkBoxtop);
            this.Controls.Add(this.buttonok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.checkBoxs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.set_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxs;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonok;
        private System.Windows.Forms.CheckBox checkBoxtop;
        private System.Windows.Forms.TextBox textBoxEdge;
        private System.Windows.Forms.Label label2;
    }
}