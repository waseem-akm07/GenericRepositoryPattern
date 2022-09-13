using BusinessAccessLayer.Repository;
using DataAcessLayer.Model;
using DataTransferObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenericRepositoryPattern.Content
{
    public class EmployeeController : ApiController
    {      
        public  IBusinessLayer<Employee> _IbusinessLayer;
        readonly IBusinessLayer<Employee> businessLayer = new BusinessLayer<Employee>();

        public EmployeeController()
        {
            _IbusinessLayer = businessLayer;
        }

        // GET: api/Employee
        [HttpGet]
        [Route("api/employee/getemployees")]
        public IEnumerable<Employee> Get()
        {
            return _IbusinessLayer.GetEmployees();
        }

        // GET: api/Employee/5
        [HttpGet]
        [Route("api/employee/getemployee/{id}")]
        public Employee Get(int id)
        {
            return _IbusinessLayer.GetEmployee(id);
        }

        // POST: api/Employee
        [HttpPost]
        [Route("api/employee/postemployee")]
        public void Post(EmployeeModel employee)
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

            _IbusinessLayer.CreateEmployee(_employee);
        }

        // PUT: api/Employee/5
        [HttpPut]
        [Route("api/employee/putemployee/{id}")]
        public void Put(int id, EmployeeModel employee)
        {
            Employee _employee = new Employee()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                CompanyId =employee.Company.CompanyId,
                DepartmentId = employee.Department.DepartmentId,
                DetailId = employee.EmployeeDetail.DetailId,
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
             
            //  _IbusinessLayer.UpdateEmployee(id, _employee);
            _IbusinessLayer.update(id, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        [Route("api/employee/delete/{id}")]
        public void Delete(int id)
        {
            _IbusinessLayer.Delete(id);
        }
    }
}
