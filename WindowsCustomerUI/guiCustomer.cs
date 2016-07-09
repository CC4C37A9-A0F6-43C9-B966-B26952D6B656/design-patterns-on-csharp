using CustomerLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCustomerUI
{
    public partial class guiCustomer : Form
    {
        public guiCustomer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerBase custBase = null;
            if (ddlType.SelectedIndex == 0)
            {
                custBase = new Lead();
            }
            else
            {
                custBase = new Customer();
            }

            custBase.CustomerName = txtName.Text;
            custBase.Address = txtAddress.Text;
            custBase.PhoneNumber = txtPhone.Text;
            custBase.BillDate = dtpBillDate.Value;
            custBase.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
        }
    }
}
