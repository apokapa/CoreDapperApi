using CoreDapperApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDapperApi.Models;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace CoreDapperApi.Data
{
    public class customersRepository : IcustomersRepository
    {
        private SqlConnection con;

        //Constructor
        public customersRepository(string constring)
        {
            con = new SqlConnection(constring);
        }

        public void DeleteCustomer(int id)
        {
            con.Execute("DELETE FROM coreDapperApi.Customers WHERE Id = @Id", new { id });
        }

        public List<customersModel> GetAllCustomers()
        {
            return con.Query<customersModel>("SELECT * FROM coreDapperApi.Customers").ToList();
        }

        public customersModel GetCustomer(int id)
        {
            return con.Query<customersModel>("SELECT * FROM coreDapperApi.Customers WHERE Id = @Id", new { id }).SingleOrDefault();
        }

        public customersModel GetFullCustomer(int id)
        {
            var sql =
            "SELECT * FROM coreDapperApi.Customers WHERE Id = @Id; " +
            "SELECT * FROM coreDapperApi.Orders WHERE CustomerId = @Id";
    
            using (var multipleResults = this.con.QueryMultiple(sql, new { Id = id }))
            {
                var customers = multipleResults.Read<customersModel>().SingleOrDefault();

                var orders = multipleResults.Read<ordersModel>().ToList();

                if (customers != null && orders != null)
                {
                    customers.Orders.AddRange(orders);
                }
                return customers;
            }
        }

    
        public customersModel InsertCustomer(customersModel Customers)
        {
            var sql =
               "INSERT INTO coreDapperApi.Customers (Vat,Email,FirstName,LastName,Phone) VALUES(@Vat, @Email, @FirstName, @LastName,@Phone); " +
               "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = con.Query<int>(sql, Customers).Single();
            Customers.Id = id;
            return Customers;
        }


        public customersModel UpdateCustomer(customersModel Customers)
        {
            var sql =
             "UPDATE coreDapperApi.Customers " +
             "SET Vat = @Vat, " +
             "    Email  = @Email, " +
             "    FirstName     = @FirstName, " +
             "    LastName   = @LastName, " +
             "    Phone   = @Phone " +
             "WHERE Id = @Id";
            con.Execute(sql, Customers);
            return Customers;
        }
    }
}
