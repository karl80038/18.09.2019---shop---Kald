using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._09._2019___konsooliäpp___Kald
{
    public class Food
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Food (string name , double price) 
            {

            this.Name = name;
            this.Price = price;

            }
    }
}
