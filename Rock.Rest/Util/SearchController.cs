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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Rock.Data;

namespace Rock.Rest.Util
    
	/// <summary>
	/// Search REST API
	/// </summary>
	public partial class SearchController : ApiController
	    
        // GET api/<controller>
		public IQueryable<string> Get()
            
            string queryString = Request.RequestUri.Query;
            string type = System.Web.HttpUtility.ParseQueryString( queryString ).Get( "type" );
            string term = System.Web.HttpUtility.ParseQueryString( queryString ).Get( "term" );

            int key = int.MinValue;
            if (int.TryParse(type, out key))
                
                var searchComponents = Rock.Search.SearchContainer.Instance.Components;
                if (searchComponents.ContainsKey(key))
                    
                    var component = searchComponents[key];
                    return component.Value.Search( term );
                }
            }

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
    }
}
