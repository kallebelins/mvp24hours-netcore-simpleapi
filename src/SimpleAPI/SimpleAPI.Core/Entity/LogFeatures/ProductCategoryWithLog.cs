using Mvp24Hours.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SimpleAPI.Core.Entity.LogFeatures
{
    [DataContract(IsReference = false)]
    public partial class ProductCategoryWithLog : EntityBaseLog<int, int>
    {
        #region [ Primitive members ]

        [DataMember]
        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }

        #endregion

        #region [ Object members ]

        #endregion

        #region [ Collections members ]
        /// <summary>
        /// Gets or sets collection of the Product entity
        /// </summary>
        [DataMember]
        public virtual ICollection<ProductWithLog> Products { get; set; }
        #endregion

    }

}
