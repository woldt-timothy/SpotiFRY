﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TWDP.PlayList.PL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class playlistEntities : DbContext
    {
        public playlistEntities()
            : base("name=playlistEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblSuggestedPlaylist> tblSuggestedPlaylists { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblUSP> tblUSPs { get; set; }
    
        public virtual ObjectResult<string> spSuggestedSongTitle()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spSuggestedSongTitle");
        }
    
        public virtual ObjectResult<string> spSuggestedPlaylist()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spSuggestedPlaylist");
        }
    }
}
