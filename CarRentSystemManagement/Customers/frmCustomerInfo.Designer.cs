namespace CarRentSystemManagement.Customers
{
    partial class frmCustomerInfo
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
            this.ctrClientCard1 = new CarRentSystemManagement.Clients.ctrCustomerCard();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrClientCard1
            // 
            this.ctrClientCard1.Location = new System.Drawing.Point(12, 67);
            this.ctrClientCard1.Name = "ctrClientCard1";
            this.ctrClientCard1.Size = new System.Drawing.Size(514, 329);
            this.ctrClientCard1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(122, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show Customer info";
            // 
            // frmCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 408);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrClientCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCustomerInfo";
            this.Text = "frmCustomerInfo";
            this.Load += new System.EventHandler(this.frmCustomerInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Clients.ctrCustomerCard ctrClientCard1;
        private System.Windows.Forms.Label label1;
    }
}