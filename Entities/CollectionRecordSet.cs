//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CollectionRecordSet
    {
        public int Id { get; set; }
        public int AlbumCollectionId { get; set; }
        public int FormatId { get; set; }
        public int AlbumId { get; set; }
    
        public virtual AlbumCollectionSet AlbumCollectionSet { get; set; }
        public virtual AlbumSet AlbumSet { get; set; }
        public virtual FormatSet FormatSet { get; set; }
    }
}
