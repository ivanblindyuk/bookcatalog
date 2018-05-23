using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.View.Model.Grid
{
    public class BooksVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Ranking { get; set; }
        public int? PageCount { get; set; }
        public IEnumerable<AuthorVM> Authors { get; set; }
    }
}
