using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Cart
{
    public class NewCart
    {
        public int AccountID { get; set; }
        public double TotalBill { get; set; }
        public string Addresss { get; set; }
    }
}
