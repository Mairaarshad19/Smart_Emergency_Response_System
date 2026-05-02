namespace Emergency_Response_System.UI
{
    partial class FilterEmergencies
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
            this.button2 = new System.Windows.Forms.Button();
            this.dgvEmergencies = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergencies)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.SteelBlue;
            this.button2.Location = new System.Drawing.Point(356, 634);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(471, 57);
            this.button2.TabIndex = 18;
            this.button2.Text = "Get Prioritized Emergencies by Severity";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvEmergencies
            // 
            this.dgvEmergencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmergencies.Location = new System.Drawing.Point(71, 106);
            this.dgvEmergencies.Name = "dgvEmergencies";
            this.dgvEmergencies.RowHeadersWidth = 51;
            this.dgvEmergencies.RowTemplate.Height = 24;
            this.dgvEmergencies.Size = new System.Drawing.Size(969, 487);
            this.dgvEmergencies.TabIndex = 20;
            this.dgvEmergencies.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmergencies_CellContentClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(356, 722);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(471, 57);
            this.button1.TabIndex = 21;
            this.button1.Text = "Back to Dashboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ShowPrioritizedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1126, 924);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvEmergencies);
            this.Controls.Add(this.button2);
            this.Name = "ShowPrioritizedData";
            this.Text = "ShowPrioritizedData";
            this.Load += new System.EventHandler(this.ShowPrioritizedData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergencies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvEmergencies;
        private System.Windows.Forms.Button button1;
    }
}