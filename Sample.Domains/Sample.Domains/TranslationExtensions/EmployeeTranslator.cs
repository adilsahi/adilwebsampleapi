using Sample.Domains.Entities;
using Sample.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domains.TranslationExtensions
{
    public static class EmployeeTranslator
    {
        public static EmployeeEntity Translate(this EmployeeModel employeeModel)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();

            if(employeeModel.EmployeeId != null)
                employeeEntity.EmployeeId = employeeModel.EmployeeId.Value;

            employeeEntity.FirstName = employeeModel.FirstName;
            employeeEntity.LastName = employeeModel.LastName;
            employeeEntity.Gender = employeeModel.Gender;
            employeeEntity.Age = employeeModel.Age;

            return employeeEntity;
        }

        public static EmployeeModel Translate(this EmployeeEntity employeeEntity)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            
            employeeModel.EmployeeId = employeeEntity.EmployeeId;
            employeeModel.FirstName = employeeEntity.FirstName;
            employeeModel.LastName = employeeEntity.LastName;
            employeeModel.Gender = employeeEntity.Gender;
            employeeModel.Age = employeeEntity.Age;

            return employeeModel;
        }
    }
}
