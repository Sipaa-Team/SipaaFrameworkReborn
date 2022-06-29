
namespace SipaaIconCreator
{
    partial class About
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
            this.title1 = new SipaaFrameworkReborn.Title();
            this.sButton1 = new SipaaFrameworkReborn.SButton();
            this.title2 = new SipaaFrameworkReborn.Title();
            this.title3 = new SipaaFrameworkReborn.Title();
            this.title4 = new SipaaFrameworkReborn.Title();
            this.title5 = new SipaaFrameworkReborn.Title();
            this.SuspendLayout();
            // 
            // title1
            // 
            this.title1.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title1.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.title1.Location = new System.Drawing.Point(15, 15);
            this.title1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(268, 29);
            this.title1.TabIndex = 2;
            this.title1.TitleText = "About";
            this.title1.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // sButton1
            // 
            this.sButton1.BackColor = System.Drawing.Color.White;
            this.sButton1.BorderRadius = 20;
            this.sButton1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.sButton1.ForeColor = System.Drawing.Color.Black;
            this.sButton1.Location = new System.Drawing.Point(349, 15);
            this.sButton1.Name = "sButton1";
            this.sButton1.Size = new System.Drawing.Size(30, 29);
            this.sButton1.TabIndex = 3;
            this.sButton1.Text = "X";
            this.sButton1.UseVisualStyleBackColor = false;
            // 
            // title2
            // 
            this.title2.Font = new System.Drawing.Font("Segoe UI", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title2.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.title2.Location = new System.Drawing.Point(15, 56);
            this.title2.Margin = new System.Windows.Forms.Padding(6);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(268, 25);
            this.title2.TabIndex = 4;
            this.title2.TitleText = "Sipaa Icon Maker (1.0.2, build 10)";
            this.title2.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // title3
            // 
            this.title3.Font = new System.Drawing.Font("Segoe UI", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title3.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.title3.Location = new System.Drawing.Point(15, 93);
            this.title3.Margin = new System.Windows.Forms.Padding(6);
            this.title3.Name = "title3";
            this.title3.Size = new System.Drawing.Size(364, 25);
            this.title3.TabIndex = 5;
            this.title3.TitleText = "With only 2 colors, an number and an image, you can";
            this.title3.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // title4
            // 
            this.title4.Font = new System.Drawing.Font("Segoe UI", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title4.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.title4.Location = new System.Drawing.Point(15, 120);
            this.title4.Margin = new System.Windows.Forms.Padding(6);
            this.title4.Name = "title4";
            this.title4.Size = new System.Drawing.Size(364, 25);
            this.title4.TabIndex = 6;
            this.title4.TitleText = "make your own icons like the SipaaOS Icons";
            this.title4.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // title5
            // 
            this.title5.Font = new System.Drawing.Font("Segoe UI", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title5.HorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.title5.Location = new System.Drawing.Point(15, 250);
            this.title5.Margin = new System.Windows.Forms.Padding(6);
            this.title5.Name = "title5";
            this.title5.Size = new System.Drawing.Size(364, 25);
            this.title5.TabIndex = 7;
            this.title5.TitleText = "Builded using new Sipaa Framework Reborn";
            this.title5.VerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 290);
            this.Controls.Add(this.title5);
            this.Controls.Add(this.title4);
            this.Controls.Add(this.title3);
            this.Controls.Add(this.title2);
            this.Controls.Add(this.sButton1);
            this.Controls.Add(this.title1);
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private SipaaFrameworkReborn.Title title1;
        private SipaaFrameworkReborn.SButton sButton1;
        private SipaaFrameworkReborn.Title title2;
        private SipaaFrameworkReborn.Title title3;
        private SipaaFrameworkReborn.Title title4;
        private SipaaFrameworkReborn.Title title5;
    }
}