namespace CarRentSystemManagement.Customers
{
    partial class frmFindCustomer
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
            this.ctrClientCarWithFilter1 = new CarRentSystemManagement.Customers.ctrCustomerCardWithFilter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(140, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find Customer Screen";
            // 
            // ctrClientCarWithFilter1
            // 
            this.ctrClientCarWithFilter1.Location = new System.Drawing.Point(12, 61);
            this.ctrClientCarWithFilter1.Name = "ctrClientCarWithFilter1";
            this.ctrClientCarWithFilter1.Size = new System.Drawing.Size(551, 332);
            this.ctrClientCarWithFilter1.TabIndex = 0;
            this.ctrClientCarWithFilter1.onCustomerSelected += new System.Action<int>(this.ctrClientCarWithFilter1_onCustomerSelected);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarRentSystemManagement.Properties.Resources.closeBlack32;
            this.pictureBox1.Location = new System.Drawing.Point(540, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmFindCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 405);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrClientCarWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFindCustomer";
            this.Text = "frmFindCustomer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrCustomerCardWithFilter ctrClientCarWithFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}