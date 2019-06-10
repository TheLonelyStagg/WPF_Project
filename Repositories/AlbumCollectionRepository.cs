using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class AlbumCollectionRepository : Repository<AlbumCollectionSet>
    {
        public AlbumCollectionRepository(CollectionsDatabaseEntities db) : base(db) { }
    }
}
