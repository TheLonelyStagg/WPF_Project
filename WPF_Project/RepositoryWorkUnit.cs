using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;
using Repositories;

namespace WPF_Project
{
    class RepositoryWorkUnit
    {

        private readonly CollectionsDatabaseEntities _context;

        public RepositoryWorkUnit(CollectionsDatabaseEntities context)
        {
            _context = context;
            Albums = new AlbumRepository(_context);
            AlbumCollections = new AlbumCollectionRepository(_context);
            Authors = new AuthorRepository(_context);
            CollectionRecords = new CollectionRecordRepository(_context);
            Formats = new FormatRepository(_context);
            Genres = new GenreRepository(_context);

        }

        private static readonly object padlock = new object();
        private static RepositoryWorkUnit instance = null;
        public static RepositoryWorkUnit Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new RepositoryWorkUnit( new CollectionsDatabaseEntities());
                    }
                    return instance;
                }
            }
        }

        public IRepository<AlbumSet> Albums { get; private set; }
        public IRepository<AlbumCollectionSet> AlbumCollections { get; private set; }
        public IRepository<AuthorSet> Authors { get; private set; }
        public IRepository<CollectionRecordSet> CollectionRecords { get; private set; }
        public IRepository<FormatSet> Formats { get; private set; }
        public IRepository<GenreSet> Genres { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
