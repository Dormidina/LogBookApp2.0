using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Abschluss.Models
{
    public class CreateTaskModel
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public string? UserName { get; set; }
        public int? EstimatedTime { get; set; }
        public int? RealTime { get; set; }
        public int Priority { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int Status { get; set; }
        public int ProjectID { get; set; }
               
    }
}
