using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public class BaseEntityCreate
    {
        public string CreateId { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
    }
}
