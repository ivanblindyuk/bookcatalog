using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.View.Model
{
    public class BookVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; }
        
        public DateTime? ReleaseDate { get; set; }

        [Range(1, 10, ErrorMessage = "Ranking value must be between 1 and 10")]
        public int? Ranking { get; set; }

        [Range(1, 9999, ErrorMessage = "Pages value must be between 1 and 9999")]
        public int? PageCount { get; set; }
        
        public IEnumerable<AuthorVM> Authors { get; set; }
    }
}
