using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_App.Model
{
    public class Module
    {
        public int Id { get; set; }
        public string? ModuleName { get; set; }
        public string? ModuleCode { get; set;}
        //public Lecturer? ModuleCoordinator { get; set; }

        public int Credits { get; set; }

       
    }
}
