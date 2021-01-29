using Mvp24Hours.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SimpleAPI.Core.Entity.GuidFeatures
{
    [DataContract(IsReference = false)]
    public partial class ProductCategoryWithGuid : EntityBase<Guid>
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
        /// Gets or sets collection of the ProductGuid entity
        /// </summary>
        [DataMember]
        public virtual ICollection<ProductWithGuid> Products { get; set; }
        #endregion

    }

}
