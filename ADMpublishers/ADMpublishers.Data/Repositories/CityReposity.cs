using ADMpublishers.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.Repositories
{
    public class CityReposity :IDisposable, ICityReposity
    {

        private ADMpublishersContext db = new ADMpublishersContext();

        public async Task<City> Add(City city)
        {
            db.Cities.Add(city);
            await db.SaveChangesAsync();

            return city;
        }

        public bool CityExists(int id)
        {
            return db.Cities.Count(e => e.Id == id) > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<City> GetAll()
        {
            return db.Cities;
        }

        public async Task<City> GetByID(int id)
        {
            return await db.Cities.FirstOrDefaultAsync(a => a.Id== id);
        }

        public async Task<City> remove(int id)
        {
            var dbcity = db.Cities.FirstOrDefault(c => c.Id == id);

            db.Cities.Remove(dbcity);

            await db.SaveChangesAsync();

            return dbcity;
        }

        public async Task<City> update(City city)
        {
            db.Cities.Add(city);
            db.Entry(city).State = System.Data.Entity.EntityState.Modified;
            await db.SaveChangesAsync();

            return city;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
    }
}
