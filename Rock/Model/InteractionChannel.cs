﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Model
{

    /// <summary>
    /// Represents a Interation Channel.
    /// </summary>
    [RockDomain( "Core" )]
    [NotAudited]
    [Table( "InteractionChannel" )]
    [DataContract]
    public partial class InteractionChannel : Model<InteractionChannel>
    {

        #region Entity Properties

        /// <summary>
        /// Gets or sets the interaction channel name.
        /// </summary>
        /// <value>
        /// The interaction channel name.
        /// </value>
        [DataMember]
        [MaxLength( 250 )]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the channel data.
        /// </summary>
        /// <value>
        /// The channel data.
        /// </value>
        [DataMember]
        public string ChannelData { get; set; }

        /// <summary>
        /// Gets or sets the EntityTypeId for the <see cref="Rock.Model.EntityType"/> of entity that was modified.
        /// </summary>
        /// <value>
        /// A <see cref="System.Int32"/> representing the EntityTypeId for the <see cref="Rock.Model.EntityType"/> of the entity that was modified.
        /// </value>
        [DataMember]
        public int? ComponentEntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the EntityTypeId for the <see cref="Rock.Model.EntityType"/> of entity that was modified.
        /// </summary>
        /// <value>
        /// A <see cref="System.Int32"/> representing the EntityTypeId for the <see cref="Rock.Model.EntityType"/> of the entity that was modified.
        /// </value>
        [DataMember]
        public int? InteractionEntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the channel entity identifier.
        /// Note, the ChannelEntityType is inferred based on what the ChannelTypeMediumValue is 
        /// INTERACTIONCHANNELTYPE_WEBSITE = Rock.Model.Site
        /// INTERACTIONCHANNELTYPE_COMMUNICATION = Rock.Model.Communication
        /// INTERACTIONCHANNELTYPE_CONTENTCHANNEL = Rock.Model.ContentChannel
        /// </summary>
        /// <value>
        /// The channel entity identifier.
        /// </value>
        [DataMember]
        public int? ChannelEntityId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Channel Type <see cref="Rock.Model.DefinedValue" /> representing what type of Interaction Channel this is.
        /// </summary>
        /// <value>
        /// A <see cref="System.Int32"/> representing the Id of the <see cref="Rock.Model.DefinedValue"/> identifying the interaction channel type. If no value is selected this can be null.
        /// </value>
        [DataMember]
        [DefinedValue( SystemGuid.DefinedType.INTERACTION_CHANNEL_MEDIUM )]
        public int? ChannelTypeMediumValueId { get; set; }


        /// <summary>
        /// Gets or sets the retention days.
        /// </summary>
        /// <value>
        /// The retention days.
        /// </value>
        [DataMember]
        public int? RetentionDuration { get; set; }

        /// <summary>
        /// Gets or sets the length of time that components of this channel should be cached
        /// </summary>
        /// <value>
        /// The duration of the component cache.
        /// </value>
        [DataMember]
        public int? ComponentCacheDuration { get; set; }

        /// <summary>
        /// Gets or sets the list template.
        /// Used when rendering the interaction channel in a list using lava
        /// </summary>
        /// <value>
        /// The list template.
        /// </value>
        [DataMember]
        public string ListTemplate { get; set; }

        /// <summary>
        /// Gets or sets the detail template.
        /// Used when rendering the interaction channel's details using lava
        /// </summary>
        /// <value>
        /// The detail template.
        /// </value>
        [DataMember]
        public string DetailTemplate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [uses session].
        /// Set to true if interactions in this channel from a web browser session (for example: PageViews).
        /// Set to false if interactions in this channel are not associated with a web browser session (for example: communication clicks and opens from an email client or sms device).
        /// </summary>
        /// <value>
        ///   <c>true</c> if [uses session]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool UsesSession { get; set; }


        #endregion

        #region Virtual Properties

        /// <summary>
        /// Gets or sets the type of the Component Entity.
        /// </summary>
        /// <value>
        /// The type of the component entity.
        /// </value>
        [DataMember]
        public virtual Model.EntityType ComponentEntityType { get; set; }

        /// <summary>
        /// Gets or sets the type of the interaction Entity.
        /// </summary>
        /// <value>
        /// The type of the interaction entity.
        /// </value>
        [DataMember]
        public virtual Model.EntityType InteractionEntityType { get; set; }

        /// <summary>
        /// Gets or sets the channel medium value.
        /// </summary>
        /// <value>
        /// The channel medium value.
        /// </value>
        [DataMember]
        public virtual DefinedValue ChannelTypeMediumValue { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method that will be called on an entity immediately after the item is saved by context
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public override void PostSaveChanges( Data.DbContext dbContext )
        {
            Web.Cache.InteractionChannelCache.Flush( this.Id );

            base.PostSaveChanges( dbContext );
        }

        #endregion
    }

    #region Entity Configuration

    /// <summary>
    /// Configuration class.
    /// </summary>
    public partial class InteractionChannelConfiguration : EntityTypeConfiguration<InteractionChannel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionChannelConfiguration"/> class.
        /// </summary>
        public InteractionChannelConfiguration()
        {
            this.HasOptional( r => r.ComponentEntityType ).WithMany( ).HasForeignKey( r => r.ComponentEntityTypeId ).WillCascadeOnDelete( false );
            this.HasOptional( r => r.InteractionEntityType ).WithMany().HasForeignKey( r => r.InteractionEntityTypeId ).WillCascadeOnDelete( false );
            this.HasOptional( r => r.ChannelTypeMediumValue ).WithMany().HasForeignKey( r => r.ChannelTypeMediumValueId ).WillCascadeOnDelete( false );
        }
    }

    #endregion
}