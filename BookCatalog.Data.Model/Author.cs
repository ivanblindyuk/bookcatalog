using Dapper.Contrib.Extensions;

namespace BookCatalog.Data.Model
{
    [Table("tblAuthors")]
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
