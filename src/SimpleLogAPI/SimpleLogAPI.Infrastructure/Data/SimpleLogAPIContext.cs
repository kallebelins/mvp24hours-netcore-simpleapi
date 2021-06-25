using Microsoft.EntityFrameworkCore;
using Mvp24Hours.Infrastructure.Data;
using SimpleLogAPI.Core.Entity;

namespace SimpleLogAPI.Infrastructure.Data
{
    public class SimpleLogAPIContext : Mvp24HoursContext
    {
        #region [ Ctor ]

        public SimpleLogAPIContext()
            : base()
        {
        }

        public SimpleLogAPIContext(DbContextOptions options)
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
