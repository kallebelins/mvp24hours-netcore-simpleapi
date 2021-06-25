using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Application;
using SimpleAPI.Core.Entity.GuidFeatures;
using System;
using System.Collections.Generic;

namespace SimpleAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithGuidController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IList<ProductWithGuid> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return FacadeService.ProductWithGuidService.List();
            }
            else
            {
                return FacadeService.ProductWithGuidService.GetBy(x => x.Name.Contains(name));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public ProductWithGuid GetId(Guid id)
        {
            return FacadeService.ProductWithGuidService.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ProductWithGuid model)
        {
            FacadeService.ProductWithGuidService.Add(model);
            return CreatedAtAction(nameof(Post), new { Id = model.Id }, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody] ProductWithGuid model)
        {
            model.Id = id;
            FacadeService.ProductWithGuidService.Modify(model);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            FacadeService.ProductWithGuidService.Remove(id);
            return NoContent();
        }
    }
}
