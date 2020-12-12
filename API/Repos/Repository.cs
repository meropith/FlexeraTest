
using API.Models;
using API.Repos;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repos
{
    public class Repository<TEntity, TConfig> : IRepository<TEntity>
        where TEntity : class, IEntity
         where TConfig : IConfiguration

    {

        private readonly TConfig _config;
        public Repository(TConfig config)
        {
            _config = config;
        }

        //What i also considered here is to use a tool like Ole provider and essentially do SQL queries to the CSV File. 
        //But in the interest of keeping it clean, as the provider requires a lot more code and readers, I used the more popular method of the CSVHelper
       
        public async Task<List<TEntity>> GetAll()
        {            
            try
            {
                
                var dataPath = _config.GetValue<string>("datapath");
                using var reader = new StreamReader(dataPath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<TEntity>();
                return records.ToList();
            }
            catch (Exception ex)
            {                
                throw;
            }
        }      

        public async Task<List<TEntity>> GetByAppID(int id)
        {
            try
            {
                var dataPath = _config.GetValue<string>("datapath");
                using var reader = new StreamReader(dataPath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<TEntity>().Where(en => en.ApplicationID == id);

                return records.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
