using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;

namespace MyPortfolio
{
    public class MyPortfolioDbContext : DbContext
    {
       
        public MyPortfolioDbContext(DbContextOptions<MyPortfolioDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<About> AboutTables { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
    }



    }
