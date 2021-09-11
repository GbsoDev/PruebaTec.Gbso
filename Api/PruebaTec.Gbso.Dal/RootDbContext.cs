using Microsoft.EntityFrameworkCore;
using PruebaTec.Gbso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTec.Gbso.Dal
{
	public class RootDbContext : DbContext
	{
		public DbSet<UsuarioModel> Usuarios { get; set; }
		
		public RootDbContext(DbContextOptions<RootDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var usuarioEntity = modelBuilder.Entity<UsuarioModel>();
			usuarioEntity.Property(p => p.Nombre).IsRequired();
			usuarioEntity.Property(p => p.Apellido).IsRequired();
			usuarioEntity.Property(p => p.CorreoElectronico).IsRequired();
			usuarioEntity.Property(p => p.TipoIdentificacionId).HasConversion<short>();
			usuarioEntity
				.HasOne(p => p.TipoIdentificacion)
				.WithMany(n=> n.Usuarios)
				.HasForeignKey(u=> u.TipoIdentificacionId);


			var tipoIdentificacionEntity = modelBuilder.Entity<TipoIdentificacionModel>();
			tipoIdentificacionEntity.Property(p=> p.Id).HasConversion<short>();
			tipoIdentificacionEntity.HasData(
				Enum.GetValues(typeof(TiposIdentificacionEnum))
				.Cast<TiposIdentificacionEnum>()
				.Select(@enum => new TipoIdentificacionModel()
				{
					Id = @enum,
					Name = @enum.ToString()
				})
			);
		}
	}
}
