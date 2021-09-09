using ADMpublishers.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.Repositories
{
    public class AuthorRepository : IDisposable,IAuthorRepository
    {
        private ADMpublishersContext db = new ADMpublishersContext();

        public async Task<Author> Add(Author author)
        {
            db.Authors.Add(author);
            await db.SaveChangesAsync();

            return author;
        }

        public bool AuthorExists(string id)
        {
            return db.Authors.Count(e => e.au_id == id) > 0;
        }

   

        public IQueryable<Author> GetAll()
        {
            return db.Authors.Include(c=>c.city).Include(s=>s.city.state);
        }

        public async Task<Author> GetByID(string id)
        {
            return await db.Authors.FirstOrDefaultAsync(a => a.au_id.Equals(id));
        }

        public async Task<Author> remove(string id)
        {
            var dbauthor = db.Authors.FirstOrDefault(a => a.au_id.Equals(id));

            db.Authors.Remove(dbauthor);

           await db.SaveChangesAsync();

            return dbauthor;
        }

        public async Task<Author> update(Author author)
        {
            db.Authors.Add(author);
            db.Entry(author).State = System.Data.Entity.EntityState.Modified;
            await db.SaveChangesAsync();

            return author;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
