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
    public class ProductCategoryWithPagingController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="clause"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("", Name = "ProductCategoryPagingGet")]
        public IPagingResult<ProductCategorySimple> Get(string nome, [FromQuery] PagingCriteria<ProductCategorySimple> clause)
        {
            IPagingResult<ProductCategorySimple> result;

            if (string.IsNullOrEmpty(nome))
            {
                result = FacadeService.ProductCategoryWithPagingService.PagingList(clause);
            }
            else
            {
                result = FacadeService.ProductCategoryWithPagingService.PagingGetBy(x => x.Name.Contains(nome), clause);
            }

            /* hateaos */
            result.AddLinkPaging("ProductCategoryPagingGet", clause)
                .AddLinkSelf("ProductCategoryPagingGet")
                .AddLinkItem("ProductCategoryPagingGetId", new { Id = 0 });
            /* hateaos */

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "ProductCategoryPagingGetId")]
        public IBusinessResult<ProductCategorySimple> GetId(int id)
        {
            var result = FacadeService.ProductCategoryWithPagingService
                .GetById(id)
                .ToBusiness();

            /* hateaos */
            result.AddLinkSelf("ProductCategoryPagingGet")
                .AddLinkCollection("ProductCategoryPagingGet")
                .AddLinkItemCreate("ProductCategoryPagingPost")
                .AddLinkItemEdit("ProductCategoryPagingPut", new { Id = 0 })
                .AddLinkItemDelete("ProductCategoryPagingDelete", new { Id = 0 });
            /* hateaos */

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("", Name = "ProductCategoryPagingPost")]
        public IActionResult Post([FromBody] ProductCategorySimple model)
        {
            FacadeService.ProductCategorySimpleService.Add(model);
            return CreatedAtAction(nameof(Post), new { id = model.Id }, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}", Name = "ProductCategoryPagingPut")]
        public IActionResult Put(int id, [FromBody] ProductCategorySimple model)
        {
            model.Id = id;
            FacadeService.ProductCategorySimpleService.Modify(model);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}", Name = "ProductCategoryPagingDelete")]
        public IActionResult Delete(int id)
        {
            FacadeService.ProductCategorySimpleService.Remove(id);
            return NoContent();
        }

    }
}
