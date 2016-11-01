using CoreDapperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDapperApi.Repositories
{
    public interface IcustomersRepository
    {
        //Customers Table
        customersModel GetCustomer(int id);
        List<customersModel> GetAllCustomers();
        customersModel InsertCustomer(customersModel Customers);
        customersModel UpdateCustomer(customersModel Customers);
        void DeleteCustomer(int id);
        customersModel GetFullCustomer(int id); // Customer with orders

    }
}
