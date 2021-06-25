using Mvp24Hours.Business.Logic;
using Mvp24Hours.Core.Contract.Data;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Core.DTOs;
using Mvp24Hours.Core.Enums;
using Mvp24Hours.Core.ValueObjects.Logic;
using Mvp24Hours.Infrastructure.Extensions;
using Mvp24Hours.Infrastructure.Helpers;
using Mvp24Hours.Infrastructure.Validations;
using SimpleAPI.Core.Contract.Logic;
using SimpleAPI.Core.Entity;
using SimpleAPI.Core.Resources;
using SimpleAPI.Core.Specifications.ProductCategories;
using SimpleAPI.Core.Specifications.Products;
using SimpleAPI.Core.ValueObjects.Products;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleAPI.Application.Logic
{
    public class ProductService : RepositoryServiceAsync<Product, IUnitOfWorkAsync>, IProductService
    {
        public async Task<IPagingResult<GetByProductResponse>> GetBy(GetByProductRequest filter, IPagingCriteria criteria)
        {
            try
            {
                int limit = MaxQtyByQueryPage;
                int offset = 0;

                if (criteria != null)
                {
                    limit = criteria.Limit > 0 ? criteria.Limit : limit;
                    offset = criteria.Offset;
                }

                // apply filter
                Expression<Func<Product, bool>> clause =
                    x => (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name))
                        && (filter.ProductCategoryId == null || x.ProductCategoryId == filter.ProductCategoryId);

                // get items
                var items = await GetByAsync(clause, criteria);

                // summary results
                var totalCount = await GetByCountAsync(clause);
                var totalPages = (int)Math.Ceiling((double)totalCount / limit);

                var dtos = items.MapTo<IList<GetByProductResponse>>();

                var result = await dtos.ToBusinessPagingAsync(
                    new PageResult(limit, offset, items.Count),
                    new SummaryResult(totalCount, totalPages)
                );

                return result;
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
                throw ex;
            }
        }

        public async Task<IBusinessResult<GetByIdProductResponse>> GetById(int id)
        {
            try
            {
                var item = await GetByIdAsync(id);
                if (item == null)
                {
                    return BusinessResult<GetByIdProductResponse>.Create(
                        Messages.OPERATION_FAIL_ID_NOT_FOUND.ToMessageResult(nameof(Messages.OPERATION_FAIL_ID_NOT_FOUND), MessageType.Error)
                    );
                }

                return item
                    .MapTo<GetByIdProductResponse>()
                    .ToBusiness();
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
                throw ex;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
                throw ex;
            }
        }

        public async Task<IBusinessResult<CreateProductResponse>> Create(CreateProductRequest dto)
        {
            try
            {
                var entity = dto.MapTo<Product>();

                var validator = new ValidatorEntityNotify<Product>()
                    .AddSpecification(new SpecialCategoryAllowsOneProductSpec(entity));

                if (await AddAsync(entity) > 0)
                {
                    return entity
                        .MapTo<CreateProductResponse>()
                        .ToBusinessWithMessage(
                            Messages.OPERATION_SUCCESS.ToMessageResult(nameof(Messages.OPERATION_SUCCESS), MessageType.Success)
                        );
                }

                return BusinessResult<CreateProductResponse>.Create(
                    Messages.OPERATION_FAIL.ToMessageResult(nameof(Messages.OPERATION_FAIL), MessageType.Error)
                );
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
                throw ex;
            }
        }

        public async Task<IBusinessResult<VoidResult>> Update(int id, UpdateProductRequest dto)
        {
            try
            {
                var entity = await GetProductById(id);

                var validator = new ValidatorEntityNotify<Product>()
                    .AddSpecification(new SpecialCategoryAllowsOneProductSpec(entity));

                if (entity == null)
                {
                    return BusinessResult<VoidResult>.Create(
                        Messages.OPERATION_FAIL_ID_NOT_FOUND.ToMessageResult(nameof(Messages.OPERATION_FAIL_ID_NOT_FOUND), MessageType.Warning)
                    );
                }

                AutoMapperHelper.Map<Product>(entity, dto);

                if (await ModifyAsync(entity) > 0)
                {
                    return BusinessResult<VoidResult>.Create(
                        Messages.OPERATION_SUCCESS.ToMessageResult(nameof(Messages.OPERATION_SUCCESS), MessageType.Success)
                    );
                }

                return BusinessResult<VoidResult>.Create(
                    Messages.OPERATION_FAIL.ToMessageResult(nameof(Messages.OPERATION_FAIL), MessageType.Error)
                );
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
                throw ex;
            }
        }

        public async Task<IBusinessResult<VoidResult>> Delete(int id)
        {
            try
            {
                var entidade = await GetProductById(id);

                if (entidade == null)
                {
                    return BusinessResult<VoidResult>.Create(
                        Messages.OPERATION_FAIL_ID_NOT_FOUND.ToMessageResult(nameof(Messages.OPERATION_FAIL_ID_NOT_FOUND), MessageType.Warning)
                    );
                }

                if (await RemoveByIdAsync(id) > 0)
                {
                    return BusinessResult<VoidResult>.Create(
                        Messages.OPERATION_SUCCESS.ToMessageResult(nameof(Messages.OPERATION_SUCCESS), MessageType.Success)
                    );
                }

                return BusinessResult<VoidResult>.Create(
                    Messages.OPERATION_FAIL.ToMessageResult(nameof(Messages.OPERATION_FAIL), MessageType.Error)
                );
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
                throw ex;
            }
        }

    }
}
