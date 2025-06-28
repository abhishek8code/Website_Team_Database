using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GECPATAN_FACULTY_PORTAL.Models;

public partial class GecpatanFacultyPortalContext : DbContext
{
    public GecpatanFacultyPortalContext()
    {
    }

    public GecpatanFacultyPortalContext(DbContextOptions<GecpatanFacultyPortalContext> options)
        : base(options)
    {
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
