using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Data.Services.SqlCommands
{
    class PartsSql
    {
        public interface IPartsSql
        {
            IEnumerable<Part> GetMultipleById(params int[] id);
            IEnumerable<Part> GetAllParts();
            IEnumerable<Part> GetByCategory(string category);
            IEnumerable<Part> GetByManufacturer(string manufacturer);
            Part GetSingleById(int id);
        }

        public class PartsDataService : IPartsSql
        {
            ApplicationDbContext db;

            public PartsDataService(ApplicationDbContext db)
            {
                this.db = db;
            }

            public IEnumerable<Part> GetAllParts() => db.Parts.Select(p => p);

            public IEnumerable<Part> GetByCategory(string category) => db.Parts.Select(p => p)
                                                                                 .Where(c => c.Category.ToString() == category);

            public IEnumerable<Part> GetMultipleById(params int[] id) => db.Parts.Where(p => id
                                                                                   .Any(n => p.id == n))
                                                                                   .ToList();

            public Part GetSingleById(int id) => db.Parts.Select(p => p)
                                                     .Where(c => c.id == id)
                                                     .FirstOrDefault();

            public IEnumerable<Part> GetByManufacturer(string manufacturer) => db.Parts.Select(p => p)
                                                                                         .Where(m => m.manufacturer == manufacturer);
        }
    }
}
