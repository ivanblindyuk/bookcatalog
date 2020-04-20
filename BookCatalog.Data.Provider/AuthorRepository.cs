using BookCatalog.Skeleton.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Data.Model;
using BookCatalog.Skeleton.Core;
using BookCatalog.Data.Model.Grid;
using Dapper;

namespace BookCatalog.Data.Provider
{
    public class AuthorRepository : DapperRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(IDbContext context)
            : base(context)
        {
        }

        public void CreateAuthor(Author author)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@FirstName", author.FirstName);
            parameters.Add("@LastName", author.LastName);

            ExecuteSP("uspInsertAuthor", parameters);
        }

        public ResponseEM<Authors> GetAuthors(RequestEM request)
        {
            return GetGrid<Authors>(request, "uspSelectAuthors");
        }

        public IEnumerable<Author> SearchAuthors(string name)
        {
            string query = @"Select Top 5 Id, FirstName, LastName 
                            From tblAuthors
                            Where @Name is null Or FirstName like '%' + @Name + '%' 
                                    Or LastName like '%' + @Name + '%'";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", name);

            return ExecuteMultiQuery<Author>(query, param: parameters);
        }
    }
}
