using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAL
{
    public interface IMockDB
    {
        IEnumerable<RepairOrder> GetAll();
    }
}
