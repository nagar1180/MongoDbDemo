using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
   public class DepartmentDto : EntityDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
