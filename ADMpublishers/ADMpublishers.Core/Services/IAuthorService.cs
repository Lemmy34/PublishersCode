using ADMpublishers.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Core.Services
{
    public interface IAuthorService
    {

        string GetAllAuthors();

        string GetSingleAuthor(string id);

        void SaveAuthor(AuthorDto author);

        void UpdateAuthor();

        
        
    }
}
