using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAcessLayer.Model
{
    public class DataContext :  DbContext
    {
        public DataContext()
            : base("constr")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
    }
}
