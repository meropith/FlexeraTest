using API.Models;
using API.Repos;
using Microsoft.AspNetCore.Mvc;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TELA.API.Controllers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : BaseDBController<AppInstallEntry, AppRepository>
    {
        private readonly AppRepository _appRepository;
        public AppController(AppRepository repository) : base(repository)
        {
            this._appRepository = repository;
        }

        [HttpGet("GetLicenceCountForApp/{appid}")]
        public async Task<int> GetLicenceCountForApp(int appid)
        {
            var result = 0;
            var Entries = await _appRepository.GetByAppID(appid);
            var AppsInstalls = Entries.DistinctBy(x => x.ComputerID);

            var UsersInstalls = AppsInstalls.GroupBy(g => g.UserID);
            foreach (var userGroup in UsersInstalls)
            {
                var laptopInstalls = userGroup.Count(u => u.ComputerType.ToUpper() == "LAPTOP");
                var desctopInstalls = userGroup.Count(u => u.ComputerType.ToUpper() == "DESKTOP");

                if (desctopInstalls >= laptopInstalls)
                {
                    result += desctopInstalls;
                }
                else
                {
                    result += desctopInstalls + (int)Math.Ceiling((double)(laptopInstalls - desctopInstalls) / 2);
                }


            }


            return result;

        }

    }
}
