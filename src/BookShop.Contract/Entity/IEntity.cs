using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Contract.Entity
{
    public interface IEntity<IdentityType>
    {
        IdentityType Id { get; }
    }
}
