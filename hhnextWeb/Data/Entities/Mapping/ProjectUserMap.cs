using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace hhnextWeb.Data.Entities.Mapping
{
    public class ProjectUserMap : EntityTypeConfiguration<ProjectUser>
    {
        public ProjectUserMap()
        {
            ToTable("ProjectUser");
            HasKey(pt => pt.ProjectUserId);


            HasRequired(pt => pt.AppUser)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(pt => pt.AppUserId);


            HasRequired(pt => pt.Project)
                .WithMany(t => t.ProjectUsers)
                .HasForeignKey(pt => pt.ProjectId);
        }

    }
}