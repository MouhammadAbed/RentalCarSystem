namespace CarRentSystemManagement.Customers
{
    partial class ctrCustomerCardWithFilter
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
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.gbfilter = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrClientCard1 = new CarRentSystemManagement.Clients.ctrCustomerCard();
            this.gbfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find by:";
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "Driver License ID",
            "Customer ID"});
            this.cmbFilterBy.Location = new System.Drawing.Point(91, 19);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(152, 24);
            this.cmbFilterBy.TabIndex = 1;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(262, 19);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(142, 25);
            this.txtValue.TabIndex = 2;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            this.txtValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtValue_Validating);
            // 
            // gbfilter
            // 
            this.gbfilter.Controls.Add(this.txtValue);
            this.gbfilter.Controls.Add(this.btnSearch);
            this.gbfilter.Controls.Add(this.cmbFilterBy);
            this.gbfilter.Controls.Add(this.label1);
            this.gbfilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbfilter.Location = new System.Drawing.Point(15, 4);
            this.gbfilter.Name = "gbfilter";
            this.gbfilter.Size = new System.Drawing.Size(464, 52);
            this.gbfilter.TabIndex = 3;
            this.gbfilter.TabStop = false;
            this.gbfilter.Text = "Filter";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::CarRentSystemManagement.Properties.Resources.SearchPerson;
            this.btnSearch.Location = new System.Drawing.Point(415, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 35);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrClientCard1
            // 
            this.ctrClientCard1.Location = new System.Drawing.Point(3, 62);
            this.ctrClientCard1.Name = "ctrClientCard1";
            this.ctrClientCard1.Size = new System.Drawing.Size(545, 342);
            this.ctrClientCard1.TabIndex = 4;
            // 
            // ctrClientCarWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrClientCard1);
            this.Controls.Add(this.gbfilter);
            this.Name = "ctrClientCarWithFilter";
            this.Size = new System.Drawing.Size(551, 407);
            this.Load += new System.EventHandler(this.ctrClientCarWithFilter_Load);
            this.gbfilter.ResumeLayout(false);
            this.gbfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.GroupBox gbfilter;
        private Clients.ctrCustomerCard ctrClientCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSearch;
    }
}
