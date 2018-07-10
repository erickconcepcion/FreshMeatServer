using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Core
{
    interface IEntityEfectivity
    {
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
    }
}
