using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListBreeze.Areas.Identity.Data;

namespace TodoListBreeze.Areas.Identity.Data
{
    public class TodoListBreezeIdentityDbContext : IdentityDbContext<UserData>
    {
        public TodoListBreezeIdentityDbContext(DbContextOptions<TodoListBreezeIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
