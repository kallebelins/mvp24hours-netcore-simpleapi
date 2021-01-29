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
    public class ProductCategoryWithGuidController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IList<ProductCategoryWithGuid> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return FacadeService.ProductCategoryWithGuidService.List();
            }
            else
            {
                return FacadeService.ProductCategoryWithGuidService.GetBy(x => x.Name.Contains(name));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public ProductCategoryWithGuid GetId(Guid id)
        {
            return FacadeService.ProductCategoryWithGuidService.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ProductCategoryWithGuid model)
        {
            FacadeService.ProductCategoryWithGuidService.Add(model);
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
        public IActionResult Put(Guid id, [FromBody] ProductCategoryWithGuid model)
        {
            model.Id = id;
            FacadeService.ProductCategoryWithGuidService.Modify(model);
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
            FacadeService.ProductCategoryWithGuidService.Remove(id);
            return NoContent();
        }
    }
}
