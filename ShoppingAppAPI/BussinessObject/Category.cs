﻿

namespace BussinessObject
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
