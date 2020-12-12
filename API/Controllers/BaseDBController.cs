using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using API.Repos;

namespace TELA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseDBController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        protected BaseDBController(TRepository injectedRepository)
        {
            repository = injectedRepository;
        }


        // GET: api/[controller]
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {            
            try
            {
                return await repository.GetAll().ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {               
                throw;
            }

        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]        
        public async Task<ActionResult<IEnumerable<TEntity>>> Get(int id)
        {            
            try
            {
                var entities = await repository.GetByAppID(id).ConfigureAwait(false);
                if (entities.Count == 0)
                {
                    return NotFound();
                }
                return entities;
            }
            catch (System.Exception ex)
            {                
                throw;
            }
        }

      
      

        
    }
}

