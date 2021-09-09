using ADMpublishers.Data.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Core.Services
{
    public class AuthorService : IAuthorService
    {
        public string GetAllAuthors()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Authors");
                responseTask.Wait();

                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataTask = response.Content.ReadAsStringAsync();

                    dataTask.Wait();

                    return dataTask.Result;

                }
                else
                {

                    return string.Empty;
                }
            }
        }

        public string GetSingleAuthor(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44391/api/");
                //HTTP GET
                var responseTask = client.GetAsync($"Authors/id={id}");
                responseTask.Wait();

                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataTask = response.Content.ReadAsStringAsync();

                    dataTask.Wait();

                    return dataTask.Result;

                }
                else
                {

                    return string.Empty;
                }
            }
        }

        public void SaveAuthor(AuthorDto author)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthor()
        {
            throw new NotImplementedException();
        }
    }
}
