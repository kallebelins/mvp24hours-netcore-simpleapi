using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Core.Contract.Logic;
using Mvp24Hours.Core.Contract.Logic.DTO;
using Mvp24Hours.Core.DTO.Logic;
using Mvp24Hours.Infrastructure.Extensions;
using Mvp24Hours.WebAPI.Extensions;
using SimpleAPI.Application;
using SimpleAPI.Core.Entity.SimpleFeatures;

namespace SimpleAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithPagingController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="clause"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("", Name = "ProductPagingGet")]
        public IPagingResult<ProductSimple> Get(string nome, [FromQuery] PagingCriteria<ProductSimple> clause)
        {
            IPagingResult<ProductSimple> result;

            if (string.IsNullOrEmpty(nome))
            {
                result = FacadeService.ProductWithPagingService.PagingList(clause);
            }
            else
            {
                result = FacadeService.ProductWithPagingService.PagingGetBy(x => x.Name.Contains(nome), clause);
            }

            /* hateaos */
            result.AddLinkPaging("ProductPagingGet", clause)
                .AddLinkSelf("ProductPagingGet")
                .AddLinkItem("ProductPagingGetId", new { Id = 0 });
            /* hateaos */

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "ProductPagingGetId")]
        public IBusinessResult<ProductSimple> GetId(int id)
        {
            var result = FacadeService.ProductWithPagingService
                .GetById(id)
                .ToBusiness();

            /* hateaos */
            result.AddLinkSelf("ProductPagingGet")
                .AddLinkCollection("ProductPagingGet")
                .AddLinkItemCreate("ProductPagingPost")
                .AddLinkItemEdit("ProductPagingPut", new { Id = 0 })
                .AddLinkItemDelete("ProductPagingDelete", new { Id = 0 });
            /* hateaos */

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("", Name = "ProductPagingPost")]
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
        [Route("{id:int}", Name = "ProductPagingPut")]
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
        [Route("{id:int}", Name = "ProductPagingDelete")]
        public IActionResult Delete(int id)
        {
            FacadeService.ProductSimpleService.Remove(id);
            return NoContent();
        }

    }
}
