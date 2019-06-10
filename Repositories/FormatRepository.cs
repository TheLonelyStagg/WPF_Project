using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class FormatRepository : Repository<FormatSet>
    {
        public FormatRepository(CollectionsDatabaseEntities db) : base(db) { }
    }
}
