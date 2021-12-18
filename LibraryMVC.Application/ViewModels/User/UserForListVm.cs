using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMVC.Application
{
    public class UserForListVm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Pesel { get; set; }
        public string Role { get; set; }
    }
}
