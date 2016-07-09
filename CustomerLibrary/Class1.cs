﻿using System;

namespace CustomerLibrary
{
    public class CustomerBase
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        public virtual void Validate()
        {
            // Let this be define by the child classes 
        }
    }
    public class Customer: CustomerBase
    {
        public override void Validate()
        {
            if (CustomerName.Length == 0)
            {
                throw new Exception("Customer name is required");
            }
            if (PhoneNumber.Length == 0)
            {
                throw new Exception("Phone number is required");
            }
            if (BillAmount == 0)
            {
                throw new Exception("Bill amount is required");
            }
            if (BillDate >= DateTime.Now)
            {
                throw new Exception("Bill date is invalid");
            }
        }
    }
    public class Lead : CustomerBase
    {
        public override void Validate()
        {
            //base.Validate();
            if (CustomerName.Length == 0)
            {
                throw new Exception("Customer Name is required");
            }
            if (PhoneNumber.Length == 0)
            {
                throw new Exception("Phone number is required");
            }

        }
    }
}
