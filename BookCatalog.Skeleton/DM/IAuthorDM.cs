﻿using BookCatalog.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Skeleton.DM
{
    public interface IAuthorDM : IBaseDM
    {
        IEnumerable<AuthorVM> GetAuthors();
    }
}