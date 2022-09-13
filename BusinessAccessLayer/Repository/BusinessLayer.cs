using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Model;
using DataTransferObject.ViewModel;

namespace BusinessAccessLayer.Repository
{
    public class BusinessLayer<T> : IBusinessLayer<T> where T : class
    {
        private DataContext _context;
        private DbSet<T> dbEntity;

        public BusinessLayer()
        {
           
            this._context = new DataContext();
            dbEntity = _context.Set<T>();
        }

       
        public IEnumerable<T> GetEmployees()
        {
            try
            {    
                return dbEntity.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public T GetEmployee(int id)
        {
            try
            {
                return dbEntity.Find(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
               
        public void CreateEmployee(T employee)
        {
            try
            {
                dbEntity.Add(employee);
                Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public virtual void UpdateEmployee(int id, T employee)
        {
            try
            {
              //  update(id,  employee);

                T data = dbEntity.Find(id);
               // dbEntity.Attach(employee);
                //_context.Entry(data).State = EntityState.Detached;
               // var emp = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
               // emp.EmployeeName = employee.EmployeeName;

               _context.Entry(employee).State = EntityState.Modified;

                // T foundEntity = _context.Set<T>().Find(id);
                // _context.Entry(foundEntity).CurrentValues.SetValues(employee);
                // _context.Entry(foundEntity).Collection(x => x.Seals).Load();
                // _context.Entry(foundEntity).Collection(x => x.Seals).CurrentValue = employee.Seals;
                // _context.SaveChanges();

                _context.Entry(data).CurrentValues.SetValues(employee);
                _context.Entry(data).State = EntityState.Modified;
                 
                Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void update(int id, EmployeeModel employee)
        {
             var emp = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            emp.EmployeeName = employee.EmployeeName;

            var com = _context.Companies.Where(x => x.CompanyId == emp.CompanyId).FirstOrDefault();
            com.CompanyName = employee.Company.CompanyName;

            var dep = _context.Departments.Where(x => x.DepartmentId == emp.DepartmentId).FirstOrDefault();
            dep.DepartmentName = employee.Department.DepartmentName;

            var dtl = _context.EmployeeDetails.Where(x => x.DetailId == emp.DetailId).FirstOrDefault();
            dtl.FatherName = employee.EmployeeDetail.FatherName;
            dtl.Address = employee.EmployeeDetail.Address;
            dtl.PhoneNo = employee.EmployeeDetail.PhoneNo;
                      
            Save();
        }

        public void Delete(int id)
        {
            try
            {
                T data = dbEntity.Find(id);
                dbEntity.Remove(data);
              //  _context.Entry(data).State = EntityState.Deleted;
                Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
               
        public void Save()
        {
            _context.SaveChanges();
        }
        
        public void EmpModel(EmployeeModel employee)
        {
            Employee _employee = new Employee()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Company = new Company
                {
                    CompanyId = employee.Company.CompanyId,
                    CompanyName = employee.Company.CompanyName,
                },
                Department = new Department
                {
                    DepartmentId = employee.Department.DepartmentId,
                    DepartmentName = employee.Department.DepartmentName,
                },
                EmployeeDetail = new EmployeeDetail
                {
                    DetailId = employee.EmployeeDetail.DetailId,
                    FatherName = employee.EmployeeDetail.FatherName,
                    Address = employee.EmployeeDetail.Address,
                    PhoneNo = employee.EmployeeDetail.PhoneNo
                }
            };
        }
    }
}
