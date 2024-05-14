using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Infrastructure.Persistance
{
    public class MassaMasterDbContext : IdentityDbContext<User,IdentityRole<Guid>,Guid> ,IMassaMasterDbContext
    {
        public MassaMasterDbContext(DbContextOptions<MassaMasterDbContext> options) : base(options) 
        {
            Database.Migrate();
        }

        
    }
}
