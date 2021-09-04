using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaPaware.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPaware.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MensagemUsuario> Mensagens { get; set; }
    }
}
