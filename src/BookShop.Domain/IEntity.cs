using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Domain
{
    interface IEntity<IdentityType>
    {
        IdentityType Id { get; }
    }
}
