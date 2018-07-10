using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Core
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }
}
