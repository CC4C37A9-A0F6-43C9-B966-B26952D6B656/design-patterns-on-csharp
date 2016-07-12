using FactoryCustomer;
using ICustomerInterface;
using System;
using System.Windows.Forms;

namespace WindowsCustomerUI
{
    public partial class guiCustomer : Form
    {
        ICustomer iCustomer = null;
        public guiCustomer()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region Step 6 :-PIC Pattern for decoupling(Simple Factory Pattern)
            //ICustomer icust = null;
            //if (ddlType.SelectedIndex == 0)
            //{
            //    #region Step 6 :-PIC Pattern for decoupling(Simple Factory Pattern)
            //    //Step 6 :-PIC Pattern for decoupling(Simple Factory Pattern)
            //    //Acronym of PIC is “Polymorphism + Interfaces + Centralizing object creation”
            //    //If you watch the code very closely you will get the core reason why still decoupling is not achieved.
            //    //Its all because of the “NEW” keyword. “NEW” keyword one of the prime reason why two systems are tightly coupled.
            //    //So the first step is to get rid of the “NEW” keyword from the consumer end.
            //    //So let’s start moving the “NEW” keyword to a central factory class.
            //    //icust = new Lead(); 
            //    #endregion
            //    icust = new Lead();
            //}
            //else
            //{
            //    icust = new Customer();
            //} 
            #endregion

            //So now the console application UI uses the “Factory” to create objects and because the “Create” function 
            //returns “ICustomer” type the UI does not have to worry about the concrete customer classes at the back end.
            
            /*In case you are wondering about why we named the class as “factory”. A factory in real world means an entity 
             * which creates(manufactures) things and our “factory” class is exactly doing that creating objects.
             * So the name goes hand to hand with the same.*/
            //Factory obj = new Factory();//Thought process 8:- “NEW” keyword is the main culprit for tight coupling . Factory IS NOW STATIC

            #region Step 7 :-RIP Pattern(Replace IF with Polymorphism
            //iCustomer = FactoryBeforeGeneric.Create(cmbCustomerType.SelectedIndex);//icust = obj.Create(cmbCustomerType.SelectedIndex);
            iCustomer = Factory<ICustomer>.Create("Customer");
            /*Step 7 :-RIP Pattern(Replace IF with Polymorphism)
            If you watch step 6 code we just passed the bucks. The “IF” condition 
            which was in the UI part is now the part of factory which is better but in reality the “IF” 
            condition still exists.It’s just that it has been moved from the UI to the factory.

            The advantage of centralization of object creation is that if we are consuming concrete classes in lot of places 
            and clients we do not need to change in other places.

            If there is polymorphism and if you see lots of IF conditions that means polymorphism benefit is not exploited”.
            */
            #endregion
            iCustomer.CustomerName = txtName.Text;
            iCustomer.Address = txtAddress.Text;
            iCustomer.PhoneNumber = txtPhone.Text;
            iCustomer.BillDate = dtpBillDate.Value;
            iCustomer.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                //create customer or lead type depending on the combox's value
                iCustomer = Factory<ICustomer>.Create(cmbCustomerType.Text);
                //set all values
                iCustomer.CustomerName = txtName.Text;
                iCustomer.Address = txtAddress.Text;
                iCustomer.BillDate = dtpBillDate.Value;
                iCustomer.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
                iCustomer.PhoneNumber = txtPhone.Text;
                //call validate method

                iCustomer.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guiCustomer_Load(object sender, EventArgs e)
        {
            cmbCustomerType.SelectedIndex = 0;
        }
    }
}
