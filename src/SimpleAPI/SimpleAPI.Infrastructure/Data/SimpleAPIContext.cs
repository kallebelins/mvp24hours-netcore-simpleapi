using Microsoft.EntityFrameworkCore;
using Mvp24Hours.Infrastructure.Data;
using SimpleAPI.Core.Entity.GuidFeatures;
using SimpleAPI.Core.Entity.LogFeatures;
using SimpleAPI.Core.Entity.SimpleFeatures;

namespace SimpleAPI.Infrastructure.Data
{
    public class SimpleAPIContext : Mvp24HoursContext
    {
        #region [ Ctor ]

        public SimpleAPIContext()
            : base()
        {
        }

        public SimpleAPIContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override bool CanApplyEntityLog => false;

        protected override object EntityLogBy => null;

        #endregion

        #region [ Sets ]

        #region [ Simple ]
        public virtual DbSet<ProductSimple> ProductSimple { get; set; }
        public virtual DbSet<ProductCategorySimple> ProductCategorySimple { get; set; }
        #endregion

        #region [ Guid ]
        public virtual DbSet<ProductWithGuid> ProductWithGuid { get; set; }
        public virtual DbSet<ProductCategoryWithGuid> ProductCategoryWithGuid { get; set; }
        #endregion

        #region [ Log ]
        public virtual DbSet<ProductWithLog> ProductWithLog { get; set; }
        public virtual DbSet<ProductCategoryWithLog> ProductCategoryWithLog { get; set; }
        #endregion

        #endregion
    }
}
