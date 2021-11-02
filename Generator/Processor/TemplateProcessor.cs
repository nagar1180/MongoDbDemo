using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Processor
{
    public class TemplateProcessor : ITemplateProcessor
    {
        private const string sourcePath = @"~\shared\Models";
        private const string destSourcePath = @"~\shared\Dtos";
        public TemplateProcessor()
        {
           
        }
        public async Task ReadSource(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
            foreach (var dir in directoryInfo.GetDirectories())
            {  
                FileInfo[] files = dir.GetFiles();
            }
        }

        public Task WriteToFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}
