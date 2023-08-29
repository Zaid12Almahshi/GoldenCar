using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class BaseEntity
    {
        public string CreateId { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public string EditId { get; set; } = string.Empty;
        public DateTime EditDate { get; set; }
        public bool isActive { get; set; }
        public bool isDelete { get; set; }
    }
}
