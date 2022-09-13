using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Model
{
    public class EmployeeDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailId { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        //public virtual int? EmployeeId { get; set; }
        //[ForeignKey("EmployeeId")]
        //public virtual Employee Employee { get; set; }

    }
}
