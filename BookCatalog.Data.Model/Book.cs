using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace BookCatalog.Data.Model
{
    [Table("tblBooks")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Ranking { get; set; }
    }
}
