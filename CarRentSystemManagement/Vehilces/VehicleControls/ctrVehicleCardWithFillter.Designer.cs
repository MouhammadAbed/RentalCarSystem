namespace CarRentSystemManagement.Vehilces.VehicleControls
{
    partial class ctrFindVehicle
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFind = new System.Windows.Forms.ComboBox();
            this.txtSearchBy = new System.Windows.Forms.TextBox();
            this.ctrVehicleInfo1 = new CarRentSystemManagement.Vehilces.VehicleControls.ctrVehicleInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find By:";
            // 
            // cmbFind
            // 
            this.cmbFind.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFind.FormattingEnabled = true;
            this.cmbFind.Items.AddRange(new object[] {
            "Plate Number",
            "Vehicle ID"});
            this.cmbFind.Location = new System.Drawing.Point(95, 29);
            this.cmbFind.Name = "cmbFind";
            this.cmbFind.Size = new System.Drawing.Size(119, 25);
            this.cmbFind.TabIndex = 3;
            // 
            // txtSearchBy
            // 
            this.txtSearchBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBy.Location = new System.Drawing.Point(220, 29);
            this.txtSearchBy.Name = "txtSearchBy";
            this.txtSearchBy.Size = new System.Drawing.Size(152, 25);
            this.txtSearchBy.TabIndex = 4;
            this.txtSearchBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchBy_KeyPress);
            this.txtSearchBy.Validating += new System.ComponentModel.CancelEventHandler(this.txtSearchBy_Validating);
            // 
            // ctrVehicleInfo1
            // 
            this.ctrVehicleInfo1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ctrVehicleInfo1.Location = new System.Drawing.Point(11, 73);
            this.ctrVehicleInfo1.Name = "ctrVehicleInfo1";
            this.ctrVehicleInfo1.Size = new System.Drawing.Size(747, 336);
            this.ctrVehicleInfo1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 432);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle Card Info With Filter";
            // 
            // ctrFindVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrVehicleInfo1);
            this.Controls.Add(this.txtSearchBy);
            this.Controls.Add(this.cmbFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrFindVehicle";
            this.Size = new System.Drawing.Size(766, 432);
            this.Load += new System.EventHandler(this.ctrFindVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFind;
        private ctrVehicleInfo ctrVehicleInfo1;
        private System.Windows.Forms.TextBox txtSearchBy;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
