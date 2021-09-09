using ADMpublishers.Data.Dto;
using ADMpublishers.Data.MapperConfigurations;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Core.Services
{
    public class ExportService
    {
        public ExportService()
        {

        }

        public void ExportFile(List<AuthorDto> authors, string dirPath , string filename)
        {

            var OutputList = Mapping.Mapper.Map<List<AuthorDto>, List<AuthorFile>>(authors);

            var engine = new FileHelperEngine<AuthorFile>();

            engine.HeaderText = engine.GetFileHeader();
    
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string filePath = Path.Combine(dirPath, filename);
            engine.WriteFile(filePath, OutputList);
        }
    }
}
