﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Domain.Entity
{
    public class Book : IEntity<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }
}
