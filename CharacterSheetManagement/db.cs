namespace CharacterSheetManagement
{
	using System.Data.Entity;
	using SQLite.CodeFirst;

	public partial class db : DbContext
	{
		public db()
			: base("name=db")
		{
		}

		public virtual DbSet<perso> persoes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<db>(modelBuilder);
			Database.SetInitializer(sqliteConnectionInitializer);
		}
	}
}
