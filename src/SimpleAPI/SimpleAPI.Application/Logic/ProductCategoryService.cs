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
using SimpleAPI.Core.ValueObjects.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SimpleAPI.Application.Logic
{
    public class ProductCategoryService : RepositoryServiceAsync<ProductCategory, IUnitOfWorkAsync>, IProductCategoryService
    {
        public async Task<IPagingResult<GetByProductCategoryResponse>> GetBy(GetByProductCategoryRequest filter, IPagingCriteria criteria)
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
                Expression<Func<ProductCategory, bool>> clause =
                    x => (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name));

                // get items
                var items = await GetByAsync(clause, criteria);

                // summary results
                var totalCount = await GetByCountAsync(clause);
                var totalPages = (int)Math.Ceiling((double)totalCount / limit);

                var dtos = items.MapTo<IList<GetByProductCategoryResponse>>();

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

        public async Task<IBusinessResult<GetByIdProductCategoryResponse>> GetById(int id)
        {
            try
            {
                var item = await GetByIdAsync(id);

                if (item == null)
                {
                    return BusinessResult<GetByIdProductCategoryResponse>.Create(
                        Messages.OPERATION_FAIL_ID_NOT_FOUND.ToMessageResult(nameof(Messages.OPERATION_FAIL_ID_NOT_FOUND), MessageType.Error)
                    );
                }

                return item
                    .MapTo<GetByIdProductCategoryResponse>()
                    .ToBusiness();
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
                throw ex;
            }
        }

        public async Task<ProductCategory> GetProductCategoryById(int id)
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

        public async Task<IBusinessResult<CreateProductCategoryResponse>> Create(CreateProductCategoryRequest dto)
        {
            try
            {
                var entity = dto.MapTo<ProductCategory>();

                if (await AddAsync(entity) > 0)
                {
                    return entity
                        .MapTo<CreateProductCategoryResponse>()
                        .ToBusinessWithMessage(
                            Messages.OPERATION_SUCCESS.ToMessageResult(nameof(Messages.OPERATION_SUCCESS), MessageType.Success)
                        );
                }

                return BusinessResult<CreateProductCategoryResponse>.Create(
                    Messages.OPERATION_FAIL.ToMessageResult(nameof(Messages.OPERATION_FAIL), MessageType.Error)
                );
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
                throw ex;
            }
        }

        public async Task<IBusinessResult<VoidResult>> Update(int id, UpdateProductCategoryRequest dto)
        {
            try
            {
                var entity = await GetProductCategoryById(id);

                if (entity == null)
                {
                    return BusinessResult<VoidResult>.Create(
                        Messages.OPERATION_FAIL_ID_NOT_FOUND.ToMessageResult(nameof(Messages.OPERATION_FAIL_ID_NOT_FOUND), MessageType.Warning)
                    );
                }

                AutoMapperHelper.Map<ProductCategory>(entity, dto);

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
                var entity = await GetProductCategoryById(id);

                if (entity == null)
                {
                    return BusinessResult<VoidResult>.Create(
                        Messages.OPERATION_FAIL_ID_NOT_FOUND.ToMessageResult(nameof(Messages.OPERATION_FAIL_ID_NOT_FOUND), MessageType.Warning)
                    );
                }

                var validator = new ValidatorEntityNotify<ProductCategory>()
                    .AddSpecification<IsNotSpecialCategorySpec>()
                    .AddSpecification<CategoryHasNotProductSpec>();

                if (!validator.Validate(entity) 
                    && await RemoveByIdAsync(id) > 0)
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
