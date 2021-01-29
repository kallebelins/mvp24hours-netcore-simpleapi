using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Application;
using SimpleAPI.Core.Entity.LogFeatures;
using System.Collections.Generic;

namespace SimpleAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithLogController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IList<ProductWithLog> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return FacadeService.ProductWithLogService.List();
            }
            else
            {
                return FacadeService.ProductWithLogService.GetBy(x => x.Name.Contains(name));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public ProductWithLog GetId(int id)
        {
            return FacadeService.ProductWithLogService.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ProductWithLog model)
        {
            FacadeService.ProductWithLogService.Add(model);
            return CreatedAtAction(nameof(Post), new { Id = model.Id }, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put(int id, [FromBody] ProductWithLog model)
        {
            model.Id = id;
            FacadeService.ProductWithLogService.Modify(model);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            FacadeService.ProductWithLogService.Remove(id);
            return NoContent();
        }
    }
}
