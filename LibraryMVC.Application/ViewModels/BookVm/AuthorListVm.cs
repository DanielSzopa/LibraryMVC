﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class AuthorListVm
    {
        public List<AuthorForListVm> Authors { get; set; }
        public int Count { get; set; }
    }
}
