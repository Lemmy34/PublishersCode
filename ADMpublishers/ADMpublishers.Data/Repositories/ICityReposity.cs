using ADMpublishers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.Repositories
{
    public interface ICityReposity
    {
        IQueryable<City> GetAll();
        Task<City> GetByID(int id);

        Task<City> Add(City city);
        Task<City> update(City city);
        Task<City> remove(int id);

        bool CityExists(int id);
    }
}
