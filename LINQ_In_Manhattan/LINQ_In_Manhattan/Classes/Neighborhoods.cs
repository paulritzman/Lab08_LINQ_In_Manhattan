using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace LINQ_In_Manhattan.Classes
{
    public class Neighborhoods
    {
        public List<Features> Features { get; set; }
        public string Type { get; set; }
    }
}
