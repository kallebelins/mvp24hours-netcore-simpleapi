using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Infrastructure.Contexts;
using SimpleAPI.Application;
using SimpleAPI.Core.Entity.GuidFeatures;
using System;
using System.Collections.Generic;
using Mvp24Hours.WebAPI.Extensions;
using Mvp24Hours.WebAPI.Controller;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using System.Threading.Tasks;
using Mvp24Hours.Core.DTOs;

namespace SimpleAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryWithGuidController : BaseMvpController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("", Name = "ProductCategoryWithGuidGetBy")]
        public IList<ProductCategoryWithGuid> Get(string name)
        {
            HATEOASContext.AddLinkSelf("ProductCategoryWithGuidGetBy");
            HATEOASContext.AddLinkItem("ProductCategoryWithGuidGetById", new { id = 0 });
            HATEOASContext.AddLinkItemCreate("ProductCategoryWithGuidCreate");
            HATEOASContext.AddLinkItemEdit("ProductCategoryWithGuidUpdate", new { id = 0 });
            HATEOASContext.AddLinkItemDelete("ProductCategoryWithGuidDelete", new { id = 0 });

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
        [Route("{id:guid}", Name = "ProductCategoryWithGuidGetBy")]
        public Task<IBusinessResult<GetByIdBeneficiarioResponse>> GetId(Guid id)
        {
            HATEOASContext.AddLinkSelf("ProductCategoryWithGuidGetById");
            HATEOASContext.AddLinkCollection("ProductCategoryWithGuidGetBy");
            HATEOASContext.AddLinkItemCreate("ProductCategoryWithGuidCreate");
            HATEOASContext.AddLinkItemEdit("ProductCategoryWithGuidUpdate", new { id = 0 });
            HATEOASContext.AddLinkItemDelete("ProductCategoryWithGuidDelete", new { id = 0 });
            return FacadeService.ProductCategoryWithGuidService.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("", Name = "ProductCategoryWithGuidGetBy")]
        public Task<IBusinessResult<CreateBeneficiarioResponse>> Post([FromBody] ProductCategoryWithGuid model)
        {
            HATEOASContext.AddLinkSelf("ProductCategoryWithGuidGetById");
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
        [Route("{id:guid}", Name = "ProductCategoryWithGuidGetBy")]
        public Task<IBusinessResult<VoidResult>> Update(Guid id, [FromBody] ProductCategoryWithGuid model)
        {
            HATEOASContext.AddLinkSelf("ProductCategoryWithGuidGetById");
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
        [Route("{id:guid}", Name = "ProductCategoryWithGuidDelete")]
        public Task<IBusinessResult<VoidResult>> Delete(Guid id)
        {
            HATEOASContext.AddLinkSelf("ProductCategoryWithGuidDelete");
            FacadeService.ProductCategoryWithGuidService.Remove(id);
            return NoContent();
        }
    }
}
