using ComputerRepairShop.Data.Models;
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
            IEnumerable<PartModel> GetMultipleById(params int[] id);
            IEnumerable<PartModel> GetAllParts();
            IEnumerable<PartModel> GetByCategory(string category);
            IEnumerable<PartModel> GetByManufacturer(string manufacturer);
            PartModel GetSingleById(int id);
        }

        public class PartsDataService : IPartsSql
        {
            ApplicationDbContext db;

            public PartsDataService(ApplicationDbContext db)
            {
                this.db = db;
            }

            public IEnumerable<PartModel> GetAllParts() => db.Parts.Select(p => p);

            public IEnumerable<PartModel> GetByCategory(string category) => db.Parts.Select(p => p)
                                                                                 .Where(c => c.Category.ToString() == category);

            public IEnumerable<PartModel> GetMultipleById(params int[] id) => db.Parts.Where(p => id
                                                                                   .Any(n => p.Id == n))
                                                                                   .ToList();

            public PartModel GetSingleById(int id) => db.Parts.Select(p => p)
                                                     .Where(c => c.Id == id)
                                                     .FirstOrDefault();

            public IEnumerable<PartModel> GetByManufacturer(string manufacturer) => db.Parts.Select(p => p)
                                                                                         .Where(m => m.Manufacturer == manufacturer);
        }
    }
}
