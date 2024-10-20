namespace CarRentSystemManagement.RenatalTransaction.Control
{
    partial class ctrRentalTransactionWithFilter
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
            this.cmbFindBy = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.ctrRentalTransactionCard1 = new CarRentSystemManagement.RenatalTransaction.Control.ctrRentalTransactionCard();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find By:";
            // 
            // cmbFindBy
            // 
            this.cmbFindBy.Enabled = false;
            this.cmbFindBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFindBy.FormattingEnabled = true;
            this.cmbFindBy.Items.AddRange(new object[] {
            "Transaction Id"});
            this.cmbFindBy.Location = new System.Drawing.Point(156, 15);
            this.cmbFindBy.Name = "cmbFindBy";
            this.cmbFindBy.Size = new System.Drawing.Size(176, 25);
            this.cmbFindBy.TabIndex = 3;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(345, 14);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(176, 26);
            this.txtValue.TabIndex = 4;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            this.txtValue.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFind);
            this.gbFilter.Controls.Add(this.txtValue);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.cmbFindBy);
            this.gbFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(8, 0);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(592, 55);
            this.gbFilter.TabIndex = 5;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Blue;
            this.btnFind.Image = global::CarRentSystemManagement.Properties.Resources.Find_vehicle;
            this.btnFind.Location = new System.Drawing.Point(536, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(35, 35);
            this.btnFind.TabIndex = 6;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ctrRentalTransactionCard1
            // 
            this.ctrRentalTransactionCard1.Location = new System.Drawing.Point(8, 47);
            this.ctrRentalTransactionCard1.Name = "ctrRentalTransactionCard1";
            this.ctrRentalTransactionCard1.Size = new System.Drawing.Size(912, 150);
            this.ctrRentalTransactionCard1.TabIndex = 2;
            // 
            // ctrRentalTransactionWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrRentalTransactionCard1);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrRentalTransactionWithFilter";
            this.Size = new System.Drawing.Size(930, 201);
            this.Load += new System.EventHandler(this.ctrRentalTransactionWithFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrRentalTransactionCard ctrRentalTransactionCard1;
        private System.Windows.Forms.ComboBox cmbFindBy;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnFind;
    }
}
