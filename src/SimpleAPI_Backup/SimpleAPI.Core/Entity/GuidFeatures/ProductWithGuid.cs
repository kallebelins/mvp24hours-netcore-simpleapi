using Mvp24Hours.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SimpleAPI.Core.Entity.GuidFeatures
{
    [DataContract(IsReference = false)]
    public partial class ProductWithGuid : EntityBase<Guid>
    {
        #region [ Primitive members ]

        [DataMember]
        [Required]
        public Guid ProductCategoryOid { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }

        [DataMember]
        [StringLength(50)]
        public virtual string Description { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }

        #endregion

        #region [ Object members ]
        /// <summary>
        /// Gets or sets instance of the ProductCategoryGuid entity
        /// </summary>
        [DataMember]
        [ForeignKey(nameof(ProductCategoryOid))]
        public virtual ProductCategoryWithGuid Category { get; set; }
        #endregion

        #region [ Collections members ]

        #endregion
    }

}
