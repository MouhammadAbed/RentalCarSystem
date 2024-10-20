using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement.Users.Controls
{
    public partial class ctrUserCardWithFilter : UserControl
    {
        bool Enable = true;
        int PersonID;
        public bool EnableFilter
        {
            set
            {
                Enable = value;
                gbFilter.Enabled = Enable;
                cbFilter.SelectedText = "User Id";
            }
        }
        public ctrUserCardWithFilter()
        {
            InitializeComponent();
        }
        public void SetFocus()
        {
            txtValue.Focus();
        }
        private void _FindNow()
        {
            switch (cbFilter.Text)
            {
                case "User Id":
                    ctrUserCard1.LoadUserbyUserID(Convert.ToInt32(txtValue.Text));
                    break;
                case "Person Id":
                    ctrUserCard1.LoadUserByPersonID(Convert.ToInt32(txtValue.Text));
                    break;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            _FindNow();
        }
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtValue.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtValue, "this field is required. Please insert userId/;Password to search for");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtValue, null);
            }
        }
        public void LoadUser(int PersonID)
        {
            cbFilter.Text = "User Id";
            txtValue.Text = PersonID.ToString();
            _FindNow();   
        }
    }
}

