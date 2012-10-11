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
    /// DefinedValue Service class
    /// </summary>
    public partial class DefinedValueService : Service<DefinedValue, DefinedValueDto>
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedValueService"/> class
        /// </summary>
        public DefinedValueService()
            : base()
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedValueService"/> class
        /// </summary>
        public DefinedValueService(IRepository<DefinedValue> repository) : base(repository)
            
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override DefinedValue CreateNew()
            
            return new DefinedValue();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<DefinedValueDto> QueryableDto( )
            
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<DefinedValueDto> QueryableDto( IQueryable<DefinedValue> items )
            
            return items.Select( m => new DefinedValueDto()
                    
                    IsSystem = m.IsSystem,
                    DefinedTypeId = m.DefinedTypeId,
                    Order = m.Order,
                    Name = m.Name,
                    Description = m.Description,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }
    }
}
