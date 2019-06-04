using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class AlbumRepository : Repository<AlbumSet>
    {
        public AlbumRepository(CollectionsDatabaseEntities db) : base(db) { }
    }
}
