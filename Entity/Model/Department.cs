using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Department : Audit
    {
        [Key]
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
       
    }
}
