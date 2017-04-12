using System.Linq;
using System.Windows;

namespace CharacterSheetManagement
{
	/// <summary>
	/// Interaction logic for Open.xaml
	/// </summary>
	public partial class Open : Window
	{
		public Open()
		{
			InitializeComponent();

			using (db db = new db())
			{
				var selectPerso = from personnage in db.persoes orderby personnage.id_perso select personnage.nom;

				foreach (var nom in selectPerso)
				{
					Combo.Items.Add(nom);
				}
			}
		}

		private void Valider_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}


		private void Annuler_Click(object sender, RoutedEventArgs e)
		{
			Combo.SelectedItem = Default;
			Close();
		}
		
	}
}
