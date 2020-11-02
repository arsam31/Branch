using Branch.Data.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Branch.Data
{
	public class BranchContext : DbContext
	{
        

        public BranchContext(DbContextOptions<BranchContext> options) : base(options)
		{
			
		}
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Post> Posts { get; set; }
		public virtual DbSet<Category> Category { get; set; }
		public virtual DbSet<Comments> Comments { get; set; }
		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	//modelBuilder.HasDefaultSchema(schema:"BranchDb");	
		//	base.OnModelCreating(modelBuilder);
		//}
		

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Arsam",
                LastName = "Rahmaan",
                Email = "arsamrahmaan31@gmail.com",
                Mobile = "03367065720",
                IsActive = true,
                DOB = new DateTime(1979, 04, 25),
                Status = 1,
                ModifiedDate = new DateTime(1979, 04, 25),
                Modifiedby = 2,
                Remarks = "Awesome",
                Password = "1234",
                UserName = "admin",
                IsApproved = true,
                ApproveDate = new DateTime(1979, 04, 25),
                Role = "admin"

            }); 
        }
	}
     


}
