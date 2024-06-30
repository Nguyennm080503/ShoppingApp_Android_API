using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Product
{
    public class ProductParam
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
    }
}
