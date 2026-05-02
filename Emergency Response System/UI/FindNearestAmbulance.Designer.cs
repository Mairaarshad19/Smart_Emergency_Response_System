namespace Emergency_Response_System.UI
{
    partial class FindNearestAmbulance
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
            this.txtlat = new System.Windows.Forms.TextBox();
            this.txtlong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCoverage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtlat
            // 
            this.txtlat.Location = new System.Drawing.Point(448, 82);
            this.txtlat.Name = "txtlat";
            this.txtlat.Size = new System.Drawing.Size(530, 22);
            this.txtlat.TabIndex = 40;
            // 
            // txtlong
            // 
            this.txtlong.Location = new System.Drawing.Point(448, 140);
            this.txtlong.Name = "txtlong";
            this.txtlong.Size = new System.Drawing.Size(530, 22);
            this.txtlong.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(207, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 42;
            this.label5.Text = "Latitude";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(207, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 25);
            this.label6.TabIndex = 43;
            this.label6.Text = "Longitude";
            // 
            // btnCoverage
            // 
            this.btnCoverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoverage.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCoverage.Location = new System.Drawing.Point(539, 189);
            this.btnCoverage.Name = "btnCoverage";
            this.btnCoverage.Size = new System.Drawing.Size(338, 50);
            this.btnCoverage.TabIndex = 44;
            this.btnCoverage.Text = "Find nearest Ambulance ";
            this.btnCoverage.UseVisualStyleBackColor = true;
            this.btnCoverage.Click += new System.EventHandler(this.btnCoverage_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(539, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(338, 50);
            this.button1.TabIndex = 45;
            this.button1.Text = "Back to Dashboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FindNearestAmbulance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1352, 889);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCoverage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtlong);
            this.Controls.Add(this.txtlat);
            this.Name = "FindNearestAmbulance";
            this.Text = "FindNearestAmbulance";
            this.Load += new System.EventHandler(this.FindNearestAmbulance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtlat;
        private System.Windows.Forms.TextBox txtlong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCoverage;
        private System.Windows.Forms.Button button1;
    }
}