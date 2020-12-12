using API.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AppInstallEntry : IEntity
    {
        public AppInstallEntry() 
        {
          
        }
        public int UserID { get; set; }
        public int ComputerID { get; set; }
        public int ApplicationID { get; set; }
        public string ComputerType { get; set; }
        public string Comment { get; set; }        
    }
}
