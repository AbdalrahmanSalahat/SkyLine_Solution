using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLine_DAL.Models
{
    
    public  class Job
    {

        public int Id { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Key_Responsibilities { get; set; }
        public decimal Salary { get; set; }




    }
}
