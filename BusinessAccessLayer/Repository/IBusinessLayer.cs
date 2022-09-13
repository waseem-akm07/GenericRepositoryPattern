using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Model;
using DataTransferObject.ViewModel;

namespace BusinessAccessLayer.Repository
{
    public interface IBusinessLayer<T> where T: class
    {
        IEnumerable<T> GetEmployees();
        T GetEmployee(int id);
        void CreateEmployee(T employee);
        // void UpdateEmployee(int id, T employee);
        void UpdateEmployee(int id, T employee);
        void Delete(int id);
        void Save();
        void EmpModel(EmployeeModel employee);
        void update(int id, EmployeeModel employee);
    }
}
