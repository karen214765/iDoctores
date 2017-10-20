using System;
using System.Data.Entity;
using System.Data.Entity.DbContext;
using iDoctores.DataLayer.Models.Views.QA;

namespace iDoctores.Library.DataAccess.Entities.Context

{
	public class SeguridadDatabaseModel : DbContext
	{
		public SeguridadDatabaseModel() : base("name=DB_A0FD5F_idoctors")
		{

		}

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Perfil> Perfiles { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
          //  modelBuilder.Entity<UsuarioEntity>()
        //}
	}
}