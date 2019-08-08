﻿//*********************************************************************************************************************
// Author: Fernando Martin - Last Modified Date: August, 7th 2019.  
// Defining the fields to be used in this class
//*********************************************************************************************************************
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanGuruApp.Models
{
    //class to define the fields and validate the data
    public class Customer
    {
        [Key]
        public int IdCustomer { get; set; }

        [Required(ErrorMessage = "Please enter a valid first name.")]
        public string FCustomerName { get; set; }
        public string MCustomerName { get; set; }

        [Required(ErrorMessage = "Please enter a valid last name.")]
        public string LCustomerName { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone.")]
        public string CtPhone1 { get; set; }
        public string CtPhone2 { get; set; }
        public string CtEmail
        {
            get
            {
                return UserName;
            }
        }

        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address.")]
        [Required(ErrorMessage = "Please enter your email.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [UIHint("password")]
        [Required(ErrorMessage = "Please enter your password.")] 
        public string Password { get; set; }

        [NotMapped]
        public string CustAddress { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<CustomerAddress> CustomerAddresss { get; set; }              

    }
}
