using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_JoseOrtega.Models;

namespace Parcial1_AP1_JoseOrtega.Contexto;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base (options){}
    public DbSet<Metas> Metas { get; set; }
}
