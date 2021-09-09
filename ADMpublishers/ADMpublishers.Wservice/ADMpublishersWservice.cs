using ADMpublishers.Core.Services;
using ADMpublishers.Data.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ADMpublishers.Wservice
{
    public partial class ADMpublishersWservice : ServiceBase
    {
        Timer ProgramTimer = new Timer();

        public ADMpublishersWservice()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ProgramTimer.Elapsed += new ElapsedEventHandler(ProgramTimer_Elapsed); // adding Event
            ProgramTimer.Interval = 3600000;
            ProgramTimer.Enabled = true;
            ProgramTimer.Start();
        }

        private void ProgramTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            List<AuthorDto> authors = null;

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

                    authors = JsonConvert.DeserializeObject<List<AuthorDto>>(dataTask.Result);


                    var default_path = System.Configuration.ConfigurationManager.AppSettings["default_path"];
                    var fileName = $"{Guid.NewGuid()}_{DateTime.Now.ToString("yyMMddhhss")}.csv";

                    ExportService export = new ExportService();

                    export.ExportFile(authors, default_path, fileName);


                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
