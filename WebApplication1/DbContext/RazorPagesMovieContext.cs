using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DbContext
{

    public class RazorPagesMovieContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }
    }
}
