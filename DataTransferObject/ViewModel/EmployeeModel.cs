using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.ViewModel
{

    public class EmployeeModel
    {
        public int  EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public CompanyModel Company { get; set; }
        public DepartmentModel Department { get; set; }
        public EmployeeDetailModel EmployeeDetail { get; set; }
    }
}
