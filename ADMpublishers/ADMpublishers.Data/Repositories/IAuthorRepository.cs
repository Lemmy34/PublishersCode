using ADMpublishers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.Repositories
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAll();
        Task<Author> GetByID(string id);

        Task<Author> Add(Author author);
        Task<Author> update(Author author);
        Task<Author> remove(string id);

        bool AuthorExists(string id);



    }
}
