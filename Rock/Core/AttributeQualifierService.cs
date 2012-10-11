//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Core
    
    /// <summary>
    /// AttributeQualifier Service class
    /// </summary>
    public partial class AttributeQualifierService : Service<AttributeQualifier, AttributeQualifierDto>
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeQualifierService"/> class
        /// </summary>
        public AttributeQualifierService()
            : base()
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeQualifierService"/> class
        /// </summary>
        public AttributeQualifierService(IRepository<AttributeQualifier> repository) : base(repository)
            
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override AttributeQualifier CreateNew()
            
            return new AttributeQualifier();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<AttributeQualifierDto> QueryableDto( )
            
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<AttributeQualifierDto> QueryableDto( IQueryable<AttributeQualifier> items )
            
            return items.Select( m => new AttributeQualifierDto()
                    
                    IsSystem = m.IsSystem,
                    AttributeId = m.AttributeId,
                    Key = m.Key,
                    Value = m.Value,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }
    }
}
