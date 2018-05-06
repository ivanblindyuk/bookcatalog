using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.View.Model
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Ranking { get; set; }
        IEnumerable<AuthorVM> Authors { get; set; }
    }
}
