namespace CarRentSystemManagement.Vehilces
{
    partial class frmFindVehicle
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
            this.ctrFindVehicle1 = new CarRentSystemManagement.Vehilces.VehicleControls.ctrFindVehicle();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrFindVehicle1
            // 
            this.ctrFindVehicle1.FilterEnable = true;
            this.ctrFindVehicle1.Location = new System.Drawing.Point(8, 49);
            this.ctrFindVehicle1.Name = "ctrFindVehicle1";
            this.ctrFindVehicle1.Size = new System.Drawing.Size(749, 390);
            this.ctrFindVehicle1.TabIndex = 2;
            this.ctrFindVehicle1.VehicleFound += new System.Action<int>(this.ctrFindVehicle1_VehicleFound);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(277, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = " Find Vehicle ";
            // 
            // frmFindVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 454);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrFindVehicle1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFindVehicle";
            this.Text = "frmFindVehicle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private VehicleControls.ctrFindVehicle ctrFindVehicle1;
        private System.Windows.Forms.Label label1;
    }
}