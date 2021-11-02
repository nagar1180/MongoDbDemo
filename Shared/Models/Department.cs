using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
   public class Department : Entity
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
