namespace CharacterSheetManagement
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class db : DbContext
	{
		public db()
			: base("name=db")
		{
		}

		public virtual DbSet<perso> persoes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
