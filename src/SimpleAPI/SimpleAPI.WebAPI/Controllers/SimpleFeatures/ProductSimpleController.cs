using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Infrastructure.Extensions;
using SimpleAPI.Application;
using SimpleAPI.Core.Entity.SimpleFeatures;
using System.Collections.Generic;

namespace SimpleAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSimpleController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IList<ProductSimple>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IList<ProductSimple>> Get(string name)
        {
            IList<ProductSimple> result;

            if (string.IsNullOrEmpty(name))
            {
                result = FacadeService.ProductSimpleService.List();
            }
            else
            {
                result = FacadeService.ProductSimpleService.GetBy(x => x.Name.Contains(name));
            }

            if (result.AnyOrNotNull())
                return Ok(result);

            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProductSimple), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductSimple> GetId(int id)
        {
            var result = FacadeService.ProductSimpleService.GetById(id);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] ProductSimple model)
        {
            FacadeService.ProductSimpleService.Add(model);
            return CreatedAtAction(nameof(Post), new { id = model.Id }, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] ProductSimple model)
        {
            model.Id = id;
            FacadeService.ProductSimpleService.Modify(model);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            FacadeService.ProductSimpleService.Remove(id);
            return NoContent();
        }
    }
}
