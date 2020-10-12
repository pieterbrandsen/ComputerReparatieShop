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
    public interface ITechnicanSql
    {
        IEnumerable<Technican> GetAll();
        void Add(Technican order);
        Technican Get(string Id);
        void Delete(string id);
        void Update(Technican Technican);
    }
}
namespace ComputerRepairShop.Data.Services.SqlCommands
{
    public class TechnicanSql : ITechnicanSql
    {
        private readonly ApplicationDbContext db;
        public TechnicanSql(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Technican technican)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            var Technican = db.Technicians.Find(id);
            db.Users.Remove(Technican);
            db.SaveChanges();
        }

        public Technican Get(string id)
        {
            return db.Technicians.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Technican> GetAll()
        {
            return from r in db.Technicians
                   orderby r.RegisterDate
                   select r;
        }

        public void Update(Technican Technican)
        {
            /*var r = Get(Technican.Id);
            db.SaveChanges();*/
            var entry = db.Entry(Technican);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
