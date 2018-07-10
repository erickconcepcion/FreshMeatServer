using System;
using System.Collections.Generic;

namespace FreshMeatServer.Core
{
    public class EntityActionResult
    {
        public int ErrorCode { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public Guid Id { get; set; }
    }
}