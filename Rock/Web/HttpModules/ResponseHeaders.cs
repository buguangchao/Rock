﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Rock.Attribute;

namespace Rock.Web.HttpModules
{
    /// <summary>
    /// A HTTP module to add headers to the response. This module is provided more as a pattern for future HTTP modules than as 
    /// useful module for the masses.
    /// </summary>
    /// <seealso cref="Rock.Web.HttpModules.HttpModuleComponent" />
    [Description( "A HTTP Module that adds response headers to the request. Header updates are immediate and do not need a Rock restart." )]
    [Export( typeof( HttpModuleComponent ) )]
    [ExportMetadata( "ComponentName", "Response Headers" )]
    [KeyValueListField("Headers", "List of header key/values to inject into the top of every page loaded in Rock.", false, "", "Header Key", "Header Value")]
    public class ResponseHeaders : HttpModuleComponent
    {
        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        protected static List<KeyValuePair<string, object>> Headers { get; set; }

        public ResponseHeaders()
        {
            if ( Headers == null )
            {
                Headers = new List<KeyValuePair<string, object>>();
                UpdateHeaders();
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public override void Dispose()
        {
        }

        /// <summary>
        /// Method that is called when attribute values are updated. Components can
        /// override this to perform any needed setup/validation based on current attribute
        /// values.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public override bool ValidateAttributeValues( out string errorMessage )
        {
            errorMessage = string.Empty;
            UpdateHeaders();
            return true;
        }

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Init( HttpApplication context )
        {
            context.BeginRequest +=
                ( new EventHandler( this.Application_BeginRequest ) );
        }

        /// <summary>
        /// Handles the BeginRequest event of the Application control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Application_BeginRequest( Object source, EventArgs e )
        {
            // Create HttpApplication and HttpContext objects to access
            // request and response properties.
            HttpApplication application = ( HttpApplication ) source;
            HttpContext context = application.Context;
            
            foreach(var header in Headers )
            {
                context.Response.Headers.Add( header.Key, header.Value.ToString() );
            }
        }

        /// <summary>
        /// Updates the headers.
        /// </summary>
        private void UpdateHeaders()
        {
            var headerValues = GetAttributeValue( "Headers" );

            if ( headerValues != null )
            {
                var headersAttribute = this.Attributes["Headers"];
                if ( headersAttribute != null )
                {
                    var field = headersAttribute.FieldType.Field;
                    if ( field is Rock.Field.Types.KeyValueListFieldType )
                    {
                        var keyValueField = ( Rock.Field.Types.KeyValueListFieldType ) field;

                        Headers = keyValueField.GetValuesFromString( null, headerValues, headersAttribute.QualifierValues, false );
                    }
                }
            }
        }
    }
}
