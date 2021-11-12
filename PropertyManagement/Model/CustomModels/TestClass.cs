using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Model.CustomModels
{
    public class TestClass
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<Subject> subjects { get; set; }
    }

    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
