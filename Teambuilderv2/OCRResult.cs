using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teambuilderv2
{

   

        public class Rootobject
        {
            public Parsedresult[] ParsedResults { get; set; }
            public int OCRExitCode { get; set; }
            public bool IsErroredOnProcessing { get; set; }
            public string ErrorMessage { get; set; }
            public string ErrorDetails { get; set; }
        }

        public class Parsedresult
        {
            public object FileParseExitCode { get; set; }
            public string ParsedText { get; set; }
            public string ErrorMessage { get; set; }
            public string ErrorDetails { get; set; }
        }

    
}
