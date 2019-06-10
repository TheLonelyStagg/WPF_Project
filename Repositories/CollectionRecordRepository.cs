﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class CollectionRecordRepository : Repository<CollectionRecordSet>
    {
        public CollectionRecordRepository(CollectionsDatabaseEntities db) : base(db) { }
    }
}
