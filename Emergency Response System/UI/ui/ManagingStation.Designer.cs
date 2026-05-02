namespace Emergency_Response_System.UI
{
    partial class ManagingStation
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtlat = new System.Windows.Forms.TextBox();
            this.txtlong = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gridStations = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.search_by_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.noofamb = new System.Windows.Forms.Button();
            this.gridCount = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(198, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(198, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "Latitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(198, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "Longitude";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(424, 53);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(485, 22);
            this.txtname.TabIndex = 22;
            // 
            // txtlat
            // 
            this.txtlat.Location = new System.Drawing.Point(424, 104);
            this.txtlat.Name = "txtlat";
            this.txtlat.Size = new System.Drawing.Size(485, 22);
            this.txtlat.TabIndex = 23;
            // 
            // txtlong
            // 
            this.txtlong.Location = new System.Drawing.Point(424, 156);
            this.txtlong.Name = "txtlong";
            this.txtlong.Size = new System.Drawing.Size(485, 22);
            this.txtlong.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(203, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 50);
            this.button1.TabIndex = 26;
            this.button1.Text = "Add Station";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.SteelBlue;
            this.button2.Location = new System.Drawing.Point(506, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(266, 50);
            this.button2.TabIndex = 27;
            this.button2.Text = "Update Station";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gridStations
            // 
            this.gridStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStations.Location = new System.Drawing.Point(139, 576);
            this.gridStations.Name = "gridStations";
            this.gridStations.RowHeadersWidth = 51;
            this.gridStations.RowTemplate.Height = 24;
            this.gridStations.Size = new System.Drawing.Size(993, 77);
            this.gridStations.TabIndex = 28;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.SteelBlue;
            this.button3.Location = new System.Drawing.Point(817, 201);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(266, 50);
            this.button3.TabIndex = 29;
            this.button3.Text = "Delete Station";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // search_by_id
            // 
            this.search_by_id.Location = new System.Drawing.Point(443, 456);
            this.search_by_id.Name = "search_by_id";
            this.search_by_id.Size = new System.Drawing.Size(485, 22);
            this.search_by_id.TabIndex = 30;
            this.search_by_id.TextChanged += new System.EventHandler(this.search_by_id_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(181, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Search Station by ID";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.SteelBlue;
            this.button4.Location = new System.Drawing.Point(530, 502);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(266, 50);
            this.button4.TabIndex = 32;
            this.button4.Text = "Search Station";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // noofamb
            // 
            this.noofamb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noofamb.ForeColor = System.Drawing.Color.SteelBlue;
            this.noofamb.Location = new System.Drawing.Point(443, 271);
            this.noofamb.Name = "noofamb";
            this.noofamb.Size = new System.Drawing.Size(405, 50);
            this.noofamb.TabIndex = 33;
            this.noofamb.Text = "Show no of ambulances in each station";
            this.noofamb.UseVisualStyleBackColor = true;
            this.noofamb.Click += new System.EventHandler(this.noofamb_Click);
            // 
            // gridCount
            // 
            this.gridCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCount.Location = new System.Drawing.Point(139, 327);
            this.gridCount.Name = "gridCount";
            this.gridCount.RowHeadersWidth = 51;
            this.gridCount.RowTemplate.Height = 24;
            this.gridCount.Size = new System.Drawing.Size(993, 92);
            this.gridCount.TabIndex = 34;
            // 
            // ManagingStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1196, 992);
            this.Controls.Add(this.gridCount);
            this.Controls.Add(this.noofamb);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.search_by_id);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.gridStations);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtlong);
            this.Controls.Add(this.txtlat);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManagingStation";
            this.Text = "ManagingStation";
            this.Load += new System.EventHandler(this.ManagingStation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridStations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtlat;
        private System.Windows.Forms.TextBox txtlong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView gridStations;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox search_by_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button noofamb;
        private System.Windows.Forms.DataGridView gridCount;
    }
}