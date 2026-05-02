namespace Emergency_Response_System.UI
{
    partial class Delete_Ambulance
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmbulanceId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ambulancesGrid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ambulancesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(189, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ambulance ID";
            // 
            // txtAmbulanceId
            // 
            this.txtAmbulanceId.Location = new System.Drawing.Point(400, 69);
            this.txtAmbulanceId.Name = "txtAmbulanceId";
            this.txtAmbulanceId.Size = new System.Drawing.Size(485, 22);
            this.txtAmbulanceId.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(521, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 50);
            this.button1.TabIndex = 15;
            this.button1.Text = "Delete Ambulance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ambulancesGrid
            // 
            this.ambulancesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ambulancesGrid.Location = new System.Drawing.Point(242, 197);
            this.ambulancesGrid.Name = "ambulancesGrid";
            this.ambulancesGrid.RowHeadersWidth = 5;
            this.ambulancesGrid.RowTemplate.Height = 24;
            this.ambulancesGrid.Size = new System.Drawing.Size(776, 248);
            this.ambulancesGrid.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.SteelBlue;
            this.button2.Location = new System.Drawing.Point(521, 469);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(266, 50);
            this.button2.TabIndex = 17;
            this.button2.Text = "Back to Dashboard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Delete_Ambulance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1124, 735);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ambulancesGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAmbulanceId);
            this.Controls.Add(this.label1);
            this.Name = "Delete_Ambulance";
            this.Text = "Delete_Ambulance";
            this.Load += new System.EventHandler(this.Delete_Ambulance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ambulancesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmbulanceId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView ambulancesGrid;
        private System.Windows.Forms.Button button2;
    }
}