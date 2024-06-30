using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.CartDetail
{
    public class UpdateQuantity
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
