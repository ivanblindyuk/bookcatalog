using BookCatalog.View.Model;
using BookCatalog.View.Model.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.DM
{
    public interface IAuthorDM : IBaseDM
    {
        IEnumerable<GridAuthorVM> GetAuthors(RequestVM request, out int total);
        AuthorVM GetAuthor(int id);
        void Save(AuthorVM author);
        void Create(AuthorVM author);
        void Update(AuthorVM author);
        void Delete(int id);
    }
}
