using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iDoctores.Library.DataAccess.Entities;

namespace iDoctores.Library.DataAccess.Entities.Seguridad
{
    [Table("usuarios", Schema = "seguridad")]
    public class UsuarioEntity
    {
        [Key]
        [Column("usuarioid")]
        public int UsuarioId { get; set; }

		[Column("usuario")]
        public string Usuario { get; set; }

		[Column("email")]
		public string Email { get; set; }

		[Column("password")]
		public string Password { get; set; }

		[Column("fecha_registro")]
		public string FechaRegistro { get; set; }
    }
}