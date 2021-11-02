using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Processor
{
   public interface ITemplateProcessor
    {
        Task ReadSource(string path);
        Task WriteToFile(string path);
    }
}
