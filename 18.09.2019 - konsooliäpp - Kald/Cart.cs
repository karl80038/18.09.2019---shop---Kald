using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._09._2019___konsooliäpp___Kald
{
   public class Cart
    {
        public List<Food> Items { get; set; }

        public List<int> Amount { get; set; }

        public double Total { get; set; }

        public Cart()
        {

            Items = new List<Food>();

            Amount = new List<int>();

            Total = 0;
        }

        public void AddToCart(Food food , int amount)
        {

            Items.Add(food);

            Amount.Add(amount);

        }

        public double CalculateTotal ()
        {
            for (int i = 0 ; i < Items.Count ; i++)
            {

                Total = Total + Items[i].Price * Amount[i];

            }

            return Total;

        }
    }
}
