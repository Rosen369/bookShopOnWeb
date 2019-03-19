using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Domain.Entity
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
