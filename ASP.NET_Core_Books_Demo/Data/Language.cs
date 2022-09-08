using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_Books_Demo.Data
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public ICollection<Books> Books { get; set; }
    }
}
