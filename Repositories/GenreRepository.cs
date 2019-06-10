using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class GenreRepository : Repository<GenreSet>
    {
        public GenreRepository(CollectionsDatabaseEntities db) : base(db) { }
    }
}
