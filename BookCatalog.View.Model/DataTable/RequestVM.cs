using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.View.Model.DataTable
{
    public class RequestVM
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public Search search { get; set; }
        public Sorting[] order { get; set; }

        public class Search
        {
            public string value { get; set; }
            public bool regex { get; set; }
        }

        public class Sorting
        {
            public int column { get; set; }
            public string dir { get; set; }
        }
    }
}
