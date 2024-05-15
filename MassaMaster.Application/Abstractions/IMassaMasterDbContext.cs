using MassaMaster.Domain.Entities.Auth;
using MassaMaster.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Application.Abstractions
{
    public interface IMassaMasterDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
