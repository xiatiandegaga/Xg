using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.EntityFrameworkCore;
using BenchmarkDotNet.Attributes;
using Xunit;

namespace IdentityApiApi.Utility.Test
{
    [MemoryDiagnoser]
    public class EfCoreTest
    {
        private DbContextOptions<BloggingContext> _options;
        private PooledDbContextFactory<BloggingContext> _poolingFactory;

        [Params(100)]
        public int NumBlogs { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<BloggingContext>()
                .UseNpgsql(@"PORT=5430;DATABASE=test-ef;HOST=xxxx;PASSWORD=xxxx;USER ID=postgres")
                .Options;

            using var context = new BloggingContext(_options);
/*            context.Database.EnsureDeleted();*/
            context.Database.EnsureCreated();
            context.SeedData(NumBlogs);

            _poolingFactory = new PooledDbContextFactory<BloggingContext>(_options);
        }

        [Benchmark]
        public List<Blog> WithoutContextPooling()
        {
            using var context = new BloggingContext(_options);

            return context.Blogs.ToList();
        }

        [Benchmark]
        public List<Blog> WithContextPooling()
        {
            using var context = _poolingFactory.CreateDbContext();

            return context.Blogs.ToList();
        }

        public class BloggingContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }

            public BloggingContext(DbContextOptions options) : base(options) { }

            public void SeedData(int numBlogs)
            {
                Blogs.AddRange(Enumerable.Range(0, numBlogs).Select(i => new Blog { Url = $"http://www.someblog{i}.com" }));
                SaveChanges();
            }
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string Url { get; set; }
            public int Rating { get; set; }
        }
    }
}
