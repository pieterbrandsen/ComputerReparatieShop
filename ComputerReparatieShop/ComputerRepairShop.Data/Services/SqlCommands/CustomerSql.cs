using ComputerRepairShop.ClassLibrary.Const;
using ComputerRepairShop.Data.Models;
using ComputerRepairShop.Data.Services.ISqlCommands;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Data.Services.ISqlCommands
{
    public interface ICustomerSql
    {
        IEnumerable<Customer> GetAll();
        void Add(Customer order);
        Customer Get(string Id);
        void Delete(string id);
        void Update(Customer Customer);
    }
}
namespace ComputerRepairShop.Data.Services.SqlCommands
{
    public class CustomerSql : ICustomerSql
    {
        private readonly ApplicationDbContext db;
        public CustomerSql(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            var Customer = db.Customers.Find(id);
            db.Users.Remove(Customer);
            db.SaveChanges();
        }

        public Customer Get(string id)
        {
            return db.Customers.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return from r in db.Customers
                   orderby r.RegisterDate
                   select r;
        }

        public void Update(Customer Customer)
        {
            /*var r = Get(Customer.Id);
            db.SaveChanges();*/
            var entry = db.Entry(Customer);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
