using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FeuillePersonnage
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : NavigationWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Menu_ContentRendered(object sender, EventArgs e)
		{
			Menu.ShowsNavigationUI = false;
		}
	}
}
