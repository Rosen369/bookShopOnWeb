using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Domain.Entities
{
    public class Book : Entity
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }
}
