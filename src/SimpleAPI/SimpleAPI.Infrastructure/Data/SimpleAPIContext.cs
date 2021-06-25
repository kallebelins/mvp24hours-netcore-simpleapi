using Microsoft.EntityFrameworkCore;
using Mvp24Hours.Infrastructure.Data;
using SimpleAPI.Core.Entity;

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

        protected override bool CanApplyEntityLog => true;

        protected override object EntityLogBy => null;

        #endregion

        #region [ Sets ]

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }

        #endregion
    }
}
