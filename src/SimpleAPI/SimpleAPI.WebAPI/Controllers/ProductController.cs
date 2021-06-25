using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Core.DTOs;
using Mvp24Hours.Core.DTOs.Models;
using Mvp24Hours.Core.Extensions;
using Mvp24Hours.Infrastructure.Contexts;
using Mvp24Hours.WebAPI.Controller;
using Mvp24Hours.WebAPI.Extensions;
using SimpleAPI.Application;
using SimpleAPI.Core.ValueObjects.Products;
using System.Threading.Tasks;

namespace SimpleAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseMvpController
    {
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("", Name = "ProductGetBy")]
        public Task<IPagingResult<GetByProductResponse>> GetBy([FromQuery] GetByProductRequest filter, [FromQuery] PagingCriteriaRequest clause)
        {
            HATEOASContext.AddLinkSelf("ProductGetBy");
            HATEOASContext.AddLinkItem("ProductGetById", new { id = 0 });
            HATEOASContext.AddLinkItemCreate("ProductCreate");
            HATEOASContext.AddLinkItemEdit("ProductUpdate", new { id = 0 });
            HATEOASContext.AddLinkItemDelete("ProductDelete", new { id = 0 });
            return FacadeService.ProductService.GetBy(filter, clause.ToPagingService());
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        [Route("{id}", Name = "ProductGetById")]
        public Task<IBusinessResult<GetByIdProductResponse>> GetById(int id)
        {
            HATEOASContext.AddLinkItem("ProductGetBy");
            HATEOASContext.AddLinkSelf("ProductGetById");
            HATEOASContext.AddLinkItemCreate("ProductCreate");
            HATEOASContext.AddLinkItemEdit("ProductUpdate", new { id = 0 });
            HATEOASContext.AddLinkItemDelete("ProductDelete", new { id = 0 });
            return FacadeService.ProductService.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [Route("", Name = "ProductCreate")]
        public Task<IBusinessResult<CreateProductResponse>> Create([FromBody] CreateProductRequest dto)
        {
            HATEOASContext.AddLinkSelf("ProductCreate");
            return FacadeService.ProductService.Create(dto);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPut]
        [Route("{id}", Name = "ProductUpdate")]
        public Task<IBusinessResult<VoidResult>> Update(int id, [FromBody] UpdateProductRequest dto)
        {
            HATEOASContext.AddLinkSelf("ProductUpdate");
            return FacadeService.ProductService.Update(id, dto);
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpDelete]
        [Route("{id}", Name = "ProductDelete")]
        public Task<IBusinessResult<VoidResult>> Delete(int id)
        {
            HATEOASContext.AddLinkSelf("ProductDelete");
            return FacadeService.ProductService.Delete(id);
        }
    }
}
