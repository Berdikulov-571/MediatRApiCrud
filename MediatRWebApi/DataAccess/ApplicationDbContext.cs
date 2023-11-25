﻿using MediatRWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatRWebApi.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        public DbSet<User> Users {  get; set; }
    }
}