using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repos;
using Microsoft.Extensions.Configuration;

namespace API.Repos
{
    public class AppRepository : Repository<AppInstallEntry, IConfiguration>
    {
        public AppRepository(IConfiguration Configuration) : base(Configuration)
        {

        }
    }
}
