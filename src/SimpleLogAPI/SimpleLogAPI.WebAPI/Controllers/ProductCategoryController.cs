using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Core.DTOs;
using Mvp24Hours.Core.DTOs.Models;
using Mvp24Hours.Core.Extensions;
using Mvp24Hours.Infrastructure.Contexts;
using Mvp24Hours.WebAPI.Controller;
using Mvp24Hours.WebAPI.Extensions;
using SimpleLogAPI.Application;
using SimpleLogAPI.Core.ValueObjects.ProductCategories;
using SimpleLogAPI.Core.ValueObjects.Products;
using System.Threading.Tasks;

namespace SimpleLogAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : BaseMvpController
    {
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("", Name = "ProductCategoryGetBy")]
        public Task<IPagingResult<GetByProductCategoryResponse>> GetBy([FromQuery] GetByProductCategoryRequest filter, [FromQuery] PagingCriteriaRequest clause)
        {
            HATEOASContext.AddLinkSelf("ProductCategoryGetBy");
            HATEOASContext.AddLinkItem("ProductCategoryGetById", new { id = 0 });
            HATEOASContext.AddLinkItemCreate("ProductCategoryCreate");
            HATEOASContext.AddLinkItemEdit("ProductCategoryUpdate", new { id = 0 });
            HATEOASContext.AddLinkItemDelete("ProductCategoryDelete", new { id = 0 });
            return FacadeService.ProductCategoryService.GetBy(filter, clause.ToPagingService());
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("{id}", Name = "ProductCategoryGetById")]
        public Task<IBusinessResult<GetByIdProductCategoryResponse>> GetById(int id)
        {
            HATEOASContext.AddLinkItem("ProductCategoryGetBy");
            HATEOASContext.AddLinkSelf("ProductCategoryGetById");
            HATEOASContext.AddLinkItemCreate("ProductCategoryCreate");
            HATEOASContext.AddLinkItemEdit("ProductCategoryUpdate", new { id = 0 });
            HATEOASContext.AddLinkItemDelete("ProductCategoryDelete", new { id = 0 });
            return FacadeService.ProductCategoryService.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("", Name = "ProductCategoryCreate")]
        public Task<IBusinessResult<CreateProductCategoryResponse>> Create([FromBody] CreateProductCategoryRequest dto)
        {
            HATEOASContext.AddLinkSelf("ProductCategoryCreate");
            return FacadeService.ProductCategoryService.Create(dto);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPut]
        [Route("{id}", Name = "ProductCategoryUpdate")]
        public Task<IBusinessResult<VoidResult>> Update(int id, [FromBody] UpdateProductCategoryRequest dto)
        {
            HATEOASContext.AddLinkSelf("ProductCategoryUpdate");
            return FacadeService.ProductCategoryService.Update(id, dto);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpDelete]
        [Route("{id}", Name = "ProductCategoryDelete")]
        public Task<IBusinessResult<VoidResult>> Delete(int id)
        {
            HATEOASContext.AddLinkSelf("ProductCategoryDelete");
            return FacadeService.ProductCategoryService.Delete(id);
        }
    }
}
