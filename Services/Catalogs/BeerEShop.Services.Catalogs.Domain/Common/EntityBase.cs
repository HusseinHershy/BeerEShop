using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Domain.Common
{
    /// <summary>
    /// Base Entity Of Entity Class 
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public EntityBase()
        {
            this.CreatedDate = DateTime.Now;
        }
        /// <summary>
        /// Created By
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Create Date
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Last Modify By
        /// </summary>
        public string LastModifiedBy { get; set; }
        /// <summary>
        /// Modified Date
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
    }
}
