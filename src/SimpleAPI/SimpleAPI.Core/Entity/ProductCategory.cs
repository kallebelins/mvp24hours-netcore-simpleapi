﻿using Mvp24Hours.Core.Contract.Domain.Validations;
using Mvp24Hours.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SimpleAPI.Core.Entity
{
    [DataContract(IsReference = false)]
    public partial class ProductCategory : EntityBase<int>
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
        public virtual ICollection<Product> Products { get; set; }
        #endregion
    }

}
