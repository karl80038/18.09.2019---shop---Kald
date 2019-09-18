using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._09._2019___konsooliäpp___Kald
{
   public class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Cart PersonalCart { get; set; }


        public Customer (string firstName , string lastName)
        {

            FirstName = firstName;

            LastName = lastName;

        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
