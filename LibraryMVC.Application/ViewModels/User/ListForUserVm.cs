using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class ListOfUserForVm
    {
        public List<UserForListVm> ListForUserVm { get; set; }
        public string SearchString { get; set; }
        public string RoleId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
    }
}
