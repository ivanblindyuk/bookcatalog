using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Data.Model.Grid
{
    public class RequestEM
    {
        public int Offset { get; set; }
        public int Length { get; set; }
        public int? OrderBy { get; set; }
        public bool? IsDescending { get; set; }
        public string SearchExpression { get; set; }
    }
}
