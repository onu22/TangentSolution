using System;
using System.Collections.Generic;
using System.Text;

namespace Tangent.Core.Domain.Employees
{
    public class Review : BaseEntity
    {
        public string date { get; set; }
        public string salary { get; set; }
        public string type { get; set; }
        public string employee { get; set; }
        public string position { get; set; }

    }
}
