﻿using System.Collections.Generic;

namespace LibraryMVC.Application
{
    public class AuthorListVm
    {
        public List<AuthorForListVm> Authors { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public string SearchString { get; set; }

    }
}
