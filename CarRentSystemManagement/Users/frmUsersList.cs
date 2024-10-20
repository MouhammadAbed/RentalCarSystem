using CarRentalBusinessLayer;
using CarRentSystemManagement.GlobalClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement.Users
{
    public partial class frmUsersList : Form
    {
        public frmUsersList()
        {
            InitializeComponent();
        }
        private void _LoadUserList()
        {
            dgvUsers.DataSource = clsUser.getAllUser();
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 125;

                dgvUsers.Columns[1].HeaderText = "User Name";
                dgvUsers.Columns[1].Width = 125;

                dgvUsers.Columns[2].HeaderText = "Person ID";
                dgvUsers.Columns[2].Width = 125;

                dgvUsers.Columns[3].HeaderText = "First Name";
                dgvUsers.Columns[3].Width = 125;

                dgvUsers.Columns[4].HeaderText = "Second Name";
                dgvUsers.Columns[4].Width = 125;

                dgvUsers.Columns[5].HeaderText = "Last Name";
                dgvUsers.Columns[5].Width = 125;

                dgvUsers.Columns[6].HeaderText = "Phone Number";
                dgvUsers.Columns[6].Width = 135;


            }
        }
        private void frmUsersList_Load(object sender, EventArgs e)
        {
            _LoadUserList();
            lblRecord.Text = dgvUsers.RowCount.ToString();
        }
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
        }
        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void showUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(dgvUsers.CurrentRow.Cells[1].Value) == "admin")
            {
                MessageBox.Show("user 'admin' cannot be delete", "Delete not possible", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }
            if ((int)dgvUsers.CurrentRow.Cells[0].Value == clsGlobalUser.CurrentUser.UserID)
            {
                MessageBox.Show("You have logged in as this user. Delete current user is not possible.","Delete not possible",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this user?", "Delete users", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User delted successfully", "user deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User deleted failed.", "delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}