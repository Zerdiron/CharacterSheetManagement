﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharacterSheetManagement
{
	/// <summary>
	/// Interaction logic for Main.xaml
	/// </summary>
	public partial class Main : Page
	{
		/// ### ATTRIBUTS ### \\\
		// ### De Changement d'états XAML ### \\
		/// <summary>
		/// Indique si le ReadOnly doit être désactivé ou non.
		/// </summary>
		bool bool_SwitchReadOnly = true;

		/// <summary>
		/// Indique si le IsEnable doit être désactivé ou non.
		/// </summary>
		bool bool_SwitchEnable = true;

		/// <summary>
		/// Indique si le cursor doit être modifié ou non.
		/// </summary>
		bool bool_SwitchCursor = true;

		// ### Stats du personnage ### \\
		short _maitrise;
		long id = 1;

		/// ### CONSTRUCTEUR ### \\\
		public Main()
		{
			InitializeComponent();
			RefreshLinkLevel();
			
			using (var db = new db())
			{
				try
				{
					SaveCharacter();
				}
				catch
				{
					

						MessageBox.Show("Error");
					
					
				}
				
			}
		}

		/// ### FONCTIONS ### \\\
		// ### Les switchs déclenchés lorsqu'un des boutons de modification est activé ### \\
		/// <summary>
		/// Switch l'état d'activité des CheckBox. 
		/// </summary>
		private void SwitchEnable()
		{
			bool Switch;
			if (bool_SwitchEnable)
				Switch = true;
			else
				Switch = false;

			bool_SwitchEnable = !bool_SwitchEnable;

			// Alignement.
			Loyal.IsEnabled = Switch;
			FirstNeutre.IsEnabled = Switch;
			Chaotique.IsEnabled = Switch;
			Bon.IsEnabled = Switch;
			SecondNeutre.IsEnabled = Switch;
			Mauvais.IsEnabled = Switch;

			// JDS.
			MaitriseJDSFor.IsEnabled = Switch;
			MaitriseJDSDex.IsEnabled = Switch;
			MaitriseJDSCon.IsEnabled = Switch;
			MaitriseJDSInt.IsEnabled = Switch;
			MaitriseJDSSag.IsEnabled = Switch;
			MaitriseJDSCha.IsEnabled = Switch;

			// Compétences.
			MaitriseAcro.IsEnabled = Switch;
			MaitriseArca.IsEnabled = Switch;
			MaitriseAthl.IsEnabled = Switch;
			MaitriseDisc.IsEnabled = Switch;
			MaitriseDres.IsEnabled = Switch;
			MaitriseEsca.IsEnabled = Switch;
			MaitriseHist.IsEnabled = Switch;
			MaitriseInti.IsEnabled = Switch;
			MaitriseIntu.IsEnabled = Switch;
			MaitriseInve.IsEnabled = Switch;
			MaitriseMede.IsEnabled = Switch;
			MaitriseNatu.IsEnabled = Switch;
			MaitrisePerc.IsEnabled = Switch;
			MaitrisePers.IsEnabled = Switch;
			MaitriseReli.IsEnabled = Switch;
			MaitriseRepr.IsEnabled = Switch;
			MaitriseSurv.IsEnabled = Switch;
			MaitriseTrom.IsEnabled = Switch;

			// CA.
			Bouclier.IsEnabled = Switch;
			Intermediaire.IsEnabled = Switch;
			Lourde.IsEnabled = Switch;

			// Sorts.
			SortINT.IsEnabled = Switch;
			SortSAG.IsEnabled = Switch;
			SortCHA.IsEnabled = Switch;
		}

		/// <summary>
		/// Switch l'état d'activité des TextBox. 
		/// </summary>
		private void SwitchReadOnly()
		{
			bool Switch;
			if (bool_SwitchReadOnly) { Switch = false; Edition.Header = "Mode Edition"; Creation.Visibility = Visibility.Visible; }
			else { Switch = true; Edition.Header = "Mode Lecture"; Creation.Visibility = Visibility.Hidden; }

			bool_SwitchReadOnly = !bool_SwitchReadOnly;

			/// ### INFORMATIONS PERSONNAGE ###
			Nom.IsReadOnly = Switch;
			Race.IsReadOnly = Switch;
			Classe.IsReadOnly = Switch;
			Level.IsReadOnly = Switch;

			/// ### HP ###
			HP.IsReadOnly = Switch;

			/// ### DES DE VIE ###
			DVNow.IsReadOnly = Switch;
			DVType.IsReadOnly = Switch;

			/// ### STATS ###
			// Force.
			BaseFor.IsReadOnly = Switch;
			LevelFor.IsReadOnly = Switch;
			MagicFor.IsReadOnly = Switch;
			TempFor.IsReadOnly = Switch;
			// Dex.
			BaseDex.IsReadOnly = Switch;
			LevelDex.IsReadOnly = Switch;
			MagicDex.IsReadOnly = Switch;
			TempDex.IsReadOnly = Switch;
			// Con.
			BaseCon.IsReadOnly = Switch;
			LevelCon.IsReadOnly = Switch;
			MagicCon.IsReadOnly = Switch;
			TempCon.IsReadOnly = Switch;
			// Int.
			BaseInt.IsReadOnly = Switch;
			LevelInt.IsReadOnly = Switch;
			MagicInt.IsReadOnly = Switch;
			TempInt.IsReadOnly = Switch;
			// Sag.
			BaseSag.IsReadOnly = Switch;
			LevelSag.IsReadOnly = Switch;
			MagicSag.IsReadOnly = Switch;
			TempSag.IsReadOnly = Switch;
			// Cha.
			BaseCha.IsReadOnly = Switch;
			LevelCha.IsReadOnly = Switch;
			MagicCha.IsReadOnly = Switch;
			TempCha.IsReadOnly = Switch;

			/// ### JDS ###
			// For.
			MagieJDSFor.IsReadOnly = Switch;
			TempJDSFor.IsReadOnly = Switch;
			// Dex.
			MagieJDSDex.IsReadOnly = Switch;
			TempJDSDex.IsReadOnly = Switch;
			// Con.
			MagieJDSCon.IsReadOnly = Switch;
			TempJDSCon.IsReadOnly = Switch;
			// Int.
			MagieJDSInt.IsReadOnly = Switch;
			TempJDSInt.IsReadOnly = Switch;
			// Sag.
			MagieJDSSag.IsReadOnly = Switch;
			TempJDSSag.IsReadOnly = Switch;
			// Cha.
			MagieJDSCha.IsReadOnly = Switch;
			TempJDSCha.IsReadOnly = Switch;

			/// ### COMPETENCES ###
			// BonusMagique.
			MagieAcro.IsReadOnly = Switch;
			MagieArca.IsReadOnly = Switch;
			MagieAthl.IsReadOnly = Switch;
			MagieDisc.IsReadOnly = Switch;
			MagieDres.IsReadOnly = Switch;
			MagieEsca.IsReadOnly = Switch;
			MagieHist.IsReadOnly = Switch;
			MagieInti.IsReadOnly = Switch;
			MagieIntu.IsReadOnly = Switch;
			MagieInve.IsReadOnly = Switch;
			MagieMede.IsReadOnly = Switch;
			MagieNatu.IsReadOnly = Switch;
			MagiePerc.IsReadOnly = Switch;
			MagiePers.IsReadOnly = Switch;
			MagieReli.IsReadOnly = Switch;
			MagieRepr.IsReadOnly = Switch;
			MagieSurv.IsReadOnly = Switch;
			MagieTrom.IsReadOnly = Switch;

			/// ### INITIATIVE ###
			BonusInit.IsReadOnly = Switch;

			/// ### VITESSE ###
			Feet.IsReadOnly = Switch;

			/// ### CLASSE D'ARMURE (CA) ###
			Armure.IsReadOnly = Switch;
			MagieCA.IsReadOnly = Switch;
			TempCA.IsReadOnly = Switch;

			/// ### BONUS AUX TOUCHERS ###
			MagieMelee.IsReadOnly = Switch;
			MagieDistance.IsReadOnly = Switch;
			MagieSort.IsReadOnly = Switch;
		}

		/// <summary>
		/// Switch l'apparence du cursor lors du survol des champs modifiables.
		/// </summary>
		private void SwitchCursor()
		{
			var Switch = Cursors.Pen;

			if (bool_SwitchCursor)
				Switch = Cursors.Pen;
			else
				Switch = Cursors.Arrow;

			bool_SwitchCursor = !bool_SwitchCursor;

			/// ### INFORMATIONS PERSONNAGE ###
			Nom.Cursor = Switch;
			Race.Cursor = Switch;
			Classe.Cursor = Switch;
			Level.Cursor = Switch;

			/// ### HP ###
			HP.Cursor = Switch;

			/// ### DES DE VIE ###
			DVNow.Cursor = Switch;
			DVType.Cursor = Switch;

			/// ### STATS ###
			// Force.
			BaseFor.Cursor = Switch;
			LevelFor.Cursor = Switch;
			MagicFor.Cursor = Switch;
			TempFor.Cursor = Switch;
			// Dex.
			BaseDex.Cursor = Switch;
			LevelDex.Cursor = Switch;
			MagicDex.Cursor = Switch;
			TempDex.Cursor = Switch;
			// Con.
			BaseCon.Cursor = Switch;
			LevelCon.Cursor = Switch;
			MagicCon.Cursor = Switch;
			TempCon.Cursor = Switch;
			// Int.
			BaseInt.Cursor = Switch;
			LevelInt.Cursor = Switch;
			MagicInt.Cursor = Switch;
			TempInt.Cursor = Switch;
			// Sag.
			BaseSag.Cursor = Switch;
			LevelSag.Cursor = Switch;
			MagicSag.Cursor = Switch;
			TempSag.Cursor = Switch;
			// Cha.
			BaseCha.Cursor = Switch;
			LevelCha.Cursor = Switch;
			MagicCha.Cursor = Switch;
			TempCha.Cursor = Switch;

			/// ### JDS ###
			// For.
			MagieJDSFor.Cursor = Switch;
			TempJDSFor.Cursor = Switch;
			// Dex.
			MagieJDSDex.Cursor = Switch;
			TempJDSDex.Cursor = Switch;
			// Con.
			MagieJDSCon.Cursor = Switch;
			TempJDSCon.Cursor = Switch;
			// Int.
			MagieJDSInt.Cursor = Switch;
			TempJDSInt.Cursor = Switch;
			// Sag.
			MagieJDSSag.Cursor = Switch;
			TempJDSSag.Cursor = Switch;
			// Cha.
			MagieJDSCha.Cursor = Switch;
			TempJDSCha.Cursor = Switch;

			/// ### COMPETENCES ###
			// BonusMagique.
			MagieAcro.Cursor = Switch;
			MagieArca.Cursor = Switch;
			MagieAthl.Cursor = Switch;
			MagieDisc.Cursor = Switch;
			MagieDres.Cursor = Switch;
			MagieEsca.Cursor = Switch;
			MagieHist.Cursor = Switch;
			MagieInti.Cursor = Switch;
			MagieIntu.Cursor = Switch;
			MagieInve.Cursor = Switch;
			MagieMede.Cursor = Switch;
			MagieNatu.Cursor = Switch;
			MagiePerc.Cursor = Switch;
			MagiePers.Cursor = Switch;
			MagieReli.Cursor = Switch;
			MagieRepr.Cursor = Switch;
			MagieSurv.Cursor = Switch;
			MagieTrom.Cursor = Switch;

			/// ### INITIATIVE ###
			BonusInit.Cursor = Switch;

			/// ### VITESSE ###
			Feet.Cursor = Switch;

			/// ### CLASSE D'ARMURE (CA) ###
			Armure.Cursor = Switch;
			MagieCA.Cursor = Switch;
			TempCA.Cursor = Switch;

			/// ### BONUS AUX TOUCHERS ###
			MagieMelee.Cursor = Switch;
			MagieDistance.Cursor = Switch;
			MagieSort.Cursor = Switch;
		}

		// ### Vérification des entrées de l'utilisateur ### \\
		/// <summary>
		/// Vérifie que ce ne sont que des nombres qui sont renseignés.
		/// </summary>
		/// <param name="sender">L'object envoyé à la fonction.</param>
		/// <param name="max">Le maximum de longueur du champs.</param>
		private void CheckNumberOnly(object sender, short max = 2)
		{
			string input = (sender as TextBox).Text;
			string newInput = "";
			for (int i = 0; i < input.Length; i++)
				if (Regex.IsMatch(input[i].ToString(), @"\d"))
					newInput += input[i];
			if (newInput.Length >= max)
				newInput = newInput.Substring(0, max);

			(sender as TextBox).Text = newInput;
		}

		// ### Les Refresh ### \\
		/// <summary>
		/// Lorsque le niveau du personnage est modifié déclenche tous les autres refresh en plus d'actualiser la maîtrise.
		/// </summary>
		private void RefreshLinkLevel()
		{
			short niveau = short.Parse(Level.Text);

			// On assigne le bonus de Maîtrise en fonction du niveau.
			if (niveau > 16) { Maitrise.Text = "+6"; _maitrise = 6; }
			else if (niveau > 12) { Maitrise.Text = "+5"; _maitrise = 5; }
			else if (niveau > 8) { Maitrise.Text = "+4"; _maitrise = 4; }
			else if (niveau > 4) { Maitrise.Text = "+3"; _maitrise = 3; }
			else if (niveau > 0) { Maitrise.Text = "+2"; _maitrise = 2; }

			DVMax.Text = Level.Text;

			RefreshStatistique();
			RefreshVitesse();
		}

		/// <summary>
		/// Rafraîchit les statistiques du personnage.
		/// </summary>
		private void RefreshStatistique()
		{
			// Calcul du total.
			Force.Text = (int.Parse(BaseFor.Text) + int.Parse(LevelFor.Text) + int.Parse(MagicFor.Text) + int.Parse(TempFor.Text)).ToString();
			Dexterite.Text = (int.Parse(BaseDex.Text) + int.Parse(LevelDex.Text) + int.Parse(MagicDex.Text) + int.Parse(TempDex.Text)).ToString();
			Constitution.Text = (int.Parse(BaseCon.Text) + int.Parse(LevelCon.Text) + int.Parse(MagicCon.Text) + int.Parse(TempCon.Text)).ToString();
			Intelligence.Text = (int.Parse(BaseInt.Text) + int.Parse(LevelInt.Text) + int.Parse(MagicInt.Text) + int.Parse(TempInt.Text)).ToString();
			Sagesse.Text = (int.Parse(BaseSag.Text) + int.Parse(LevelSag.Text) + int.Parse(MagicSag.Text) + int.Parse(TempSag.Text)).ToString();
			Charisme.Text = (int.Parse(BaseCha.Text) + int.Parse(LevelCha.Text) + int.Parse(MagicCha.Text) + int.Parse(TempCha.Text)).ToString();

			// Calcul des modificateurs.
			ModForce.Text = CalculModif(Force.Text).ToString();
			ModDexterite.Text = CalculModif(Dexterite.Text).ToString();
			ModConstitution.Text = CalculModif(Constitution.Text).ToString();
			ModIntelligence.Text = CalculModif(Intelligence.Text).ToString();
			ModSagesse.Text = CalculModif(Sagesse.Text).ToString();
			ModCharisme.Text = CalculModif(Charisme.Text).ToString();

			RefreshBase();
			RefreshHP();
			RefreshCompetence();
			RefreshToucher();
			RefreshJDS();
			RefreshInitiative();
			RefreshArmure();
		}

		/// <summary>
		/// Rafraîchit les "Base" des autres blocs du personnage.
		/// </summary>
		private void RefreshBase()
		{
			// Des jets de sauvegardes.
			BaseJDSFor.Text = ModForce.Text;
			BaseJDSDex.Text = ModDexterite.Text;
			BaseJDSCon.Text = ModConstitution.Text;
			BaseJDSInt.Text = ModIntelligence.Text;
			BaseJDSSag.Text = ModSagesse.Text;
			BaseJDSCha.Text = ModCharisme.Text;

			// Initiative.
			BaseInit.Text = ModDexterite.Text;

			// Compétences.
			BaseAcro.Text = ModDexterite.Text;
			BaseArca.Text = ModIntelligence.Text;
			BaseAthl.Text = ModForce.Text;
			BaseDisc.Text = ModDexterite.Text;
			BaseDres.Text = ModSagesse.Text;
			BaseEsca.Text = ModDexterite.Text;
			BaseHist.Text = ModIntelligence.Text;
			BaseInti.Text = ModCharisme.Text;
			BaseIntu.Text = ModSagesse.Text;
			BaseInve.Text = ModIntelligence.Text;
			BaseMede.Text = ModSagesse.Text;
			BaseNatu.Text = ModIntelligence.Text;
			BasePerc.Text = ModSagesse.Text;
			BasePers.Text = ModCharisme.Text;
			BaseReli.Text = ModIntelligence.Text;
			BaseRepr.Text = ModCharisme.Text;
			BaseSurv.Text = ModSagesse.Text;
			BaseTrom.Text = ModCharisme.Text;

			// Bonus aux Touchers.
			BaseMelee.Text = ModForce.Text;
			BaseDistance.Text = ModDexterite.Text;
		}

		/// <summary>
		/// Rafraîchit le bloc des compétences du personnage.
		/// </summary>
		private void RefreshCompetence()
		{
			Acrobatie.Text = (int.Parse(BaseAcro.Text) + int.Parse(MagieAcro.Text)).ToString();
			if (MaitriseAcro.IsChecked == true) Acrobatie.Text = (int.Parse(Acrobatie.Text) + _maitrise).ToString();

			Arcanes.Text = (int.Parse(BaseArca.Text) + int.Parse(MagieArca.Text)).ToString();
			if (MaitriseArca.IsChecked == true) Arcanes.Text = (int.Parse(Arcanes.Text) + _maitrise).ToString();

			Athletisme.Text = (int.Parse(BaseAthl.Text) + int.Parse(MagieAthl.Text)).ToString();
			if (MaitriseAthl.IsChecked == true) Athletisme.Text = (int.Parse(Athletisme.Text) + _maitrise).ToString();

			Discretion.Text = (int.Parse(BaseDisc.Text) + int.Parse(MagieDisc.Text)).ToString();
			if (MaitriseDisc.IsChecked == true) Discretion.Text = (int.Parse(Discretion.Text) + _maitrise).ToString();

			Dressage.Text = (int.Parse(BaseDres.Text) + int.Parse(MagieDres.Text)).ToString();
			if (MaitriseDres.IsChecked == true) Dressage.Text = (int.Parse(Dressage.Text) + _maitrise).ToString();

			Escamotage.Text = (int.Parse(BaseEsca.Text) + int.Parse(MagieEsca.Text)).ToString();
			if (MaitriseEsca.IsChecked == true) Escamotage.Text = (int.Parse(Escamotage.Text) + _maitrise).ToString();

			Histoire.Text = (int.Parse(BaseHist.Text) + int.Parse(MagieHist.Text)).ToString();
			if (MaitriseHist.IsChecked == true) Histoire.Text = (int.Parse(Histoire.Text) + _maitrise).ToString();

			Intimidation.Text = (int.Parse(BaseInti.Text) + int.Parse(MagieInti.Text)).ToString();
			if (MaitriseInti.IsChecked == true) Intimidation.Text = (int.Parse(Intimidation.Text) + _maitrise).ToString();

			Intuition.Text = (int.Parse(BaseIntu.Text) + int.Parse(MagieIntu.Text)).ToString();
			if (MaitriseIntu.IsChecked == true) Intuition.Text = (int.Parse(Intuition.Text) + _maitrise).ToString();

			Investigation.Text = (int.Parse(BaseInve.Text) + int.Parse(MagieInve.Text)).ToString();
			if (MaitriseInve.IsChecked == true) Investigation.Text = (int.Parse(Investigation.Text) + _maitrise).ToString();

			Medecine.Text = (int.Parse(BaseMede.Text) + int.Parse(MagieMede.Text)).ToString();
			if (MaitriseMede.IsChecked == true) Medecine.Text = (int.Parse(Medecine.Text) + _maitrise).ToString();

			Nature.Text = (int.Parse(BaseNatu.Text) + int.Parse(MagieNatu.Text)).ToString();
			if (MaitriseNatu.IsChecked == true) Nature.Text = (int.Parse(Nature.Text) + _maitrise).ToString();

			Perception.Text = (int.Parse(BasePerc.Text) + int.Parse(MagiePerc.Text)).ToString();
			if (MaitrisePerc.IsChecked == true) Perception.Text = (int.Parse(Perception.Text) + _maitrise).ToString();

			Persuasion.Text = (int.Parse(BasePers.Text) + int.Parse(MagiePers.Text)).ToString();
			if (MaitrisePers.IsChecked == true) Persuasion.Text = (int.Parse(Persuasion.Text) + _maitrise).ToString();

			Religion.Text = (int.Parse(BaseReli.Text) + int.Parse(MagieReli.Text)).ToString();
			if (MaitriseReli.IsChecked == true) Religion.Text = (int.Parse(Religion.Text) + _maitrise).ToString();

			Representation.Text = (int.Parse(BaseRepr.Text) + int.Parse(MagieRepr.Text)).ToString();
			if (MaitriseRepr.IsChecked == true) Representation.Text = (int.Parse(Representation.Text) + _maitrise).ToString();

			Survie.Text = (int.Parse(BaseSurv.Text) + int.Parse(MagieSurv.Text)).ToString();
			if (MaitriseSurv.IsChecked == true) Survie.Text = (int.Parse(Survie.Text) + _maitrise).ToString();

			Tromperie.Text = (int.Parse(BaseTrom.Text) + int.Parse(MagieTrom.Text)).ToString();
			if (MaitriseTrom.IsChecked == true) Tromperie.Text = (int.Parse(Tromperie.Text) + _maitrise).ToString();
		}

		/// <summary>
		/// Rafraîchit le bloc du bonus aux touchers du personnage.
		/// </summary>
		private void RefreshToucher()
		{
			Melee.Text = (int.Parse(BaseMelee.Text) + int.Parse(MagieMelee.Text) + _maitrise).ToString();
			Distance.Text = (int.Parse(BaseDistance.Text) + int.Parse(MagieDistance.Text) + _maitrise).ToString();

			if (SortINT.IsChecked == true) BaseSort.Text = (int.Parse(ModIntelligence.Text)).ToString();
			else if (SortSAG.IsChecked == true) BaseSort.Text = (int.Parse(ModSagesse.Text)).ToString();
			else if (SortCHA.IsChecked == true) BaseSort.Text = (int.Parse(ModCharisme.Text)).ToString();
			else BaseSort.Text = "0";

			Sort.Text = (int.Parse(BaseSort.Text) + int.Parse(MagieSort.Text) + _maitrise).ToString();
		}

		/// <summary>
		/// Rafraîchit le bloc des Jets de Sauvegarde du personnage.
		/// </summary>
		private void RefreshJDS()
		{
			JDSFor.Text = (int.Parse(BaseJDSFor.Text) + int.Parse(MagieJDSFor.Text) + int.Parse(TempJDSFor.Text)).ToString();
			if (MaitriseJDSFor.IsChecked == true) JDSFor.Text = (int.Parse(JDSFor.Text) + _maitrise).ToString();

			JDSDex.Text = (int.Parse(BaseJDSDex.Text) + int.Parse(MagieJDSDex.Text) + int.Parse(TempJDSDex.Text)).ToString();
			if (MaitriseJDSDex.IsChecked == true) JDSDex.Text = (int.Parse(JDSDex.Text) + _maitrise).ToString();

			JDSCon.Text = (int.Parse(BaseJDSCon.Text) + int.Parse(MagieJDSCon.Text) + int.Parse(TempJDSCon.Text)).ToString();
			if (MaitriseJDSCon.IsChecked == true) JDSCon.Text = (int.Parse(JDSCon.Text) + _maitrise).ToString();

			JDSInt.Text = (int.Parse(BaseJDSInt.Text) + int.Parse(MagieJDSInt.Text) + int.Parse(TempJDSInt.Text)).ToString();
			if (MaitriseJDSInt.IsChecked == true) JDSInt.Text = (int.Parse(JDSInt.Text) + _maitrise).ToString();

			JDSSag.Text = (int.Parse(BaseJDSSag.Text) + int.Parse(MagieJDSSag.Text) + int.Parse(TempJDSSag.Text)).ToString();
			if (MaitriseJDSSag.IsChecked == true) JDSSag.Text = (int.Parse(JDSSag.Text) + _maitrise).ToString();

			JDSCha.Text = (int.Parse(BaseJDSCha.Text) + int.Parse(MagieJDSCha.Text) + int.Parse(TempJDSCha.Text)).ToString();
			if (MaitriseJDSCha.IsChecked == true) JDSCha.Text = (int.Parse(JDSCha.Text) + _maitrise).ToString();

		}

		/// <summary>
		/// Rafraîchit la vitesse du personnage.
		/// </summary>
		private void RefreshVitesse()
		{
			Cases.Text = (int.Parse(Feet.Text) / 5).ToString();
			Metres.Text = (double.Parse(Cases.Text) * 1.5).ToString();
		}

		/// <summary>
		/// Rafraîchit l'initiative du personnage.
		/// </summary>
		private void RefreshInitiative()
		{
			Initiative.Text = (int.Parse(BaseInit.Text) + int.Parse(BonusInit.Text)).ToString();
		}

		/// <summary>
		/// Rafraîchit le bloc de l'armure du personnage.
		/// </summary>
		private void RefreshArmure()
		{
			if (Intermediaire.IsChecked == true && int.Parse(ModDexterite.Text) <= 2) BonusDexCa.Text = ModDexterite.Text;
			else if (Intermediaire.IsChecked == true && int.Parse(ModDexterite.Text) > 2) BonusDexCa.Text = "2";
			else if (Lourde.IsChecked == true) BonusDexCa.Text = "0";
			else BonusDexCa.Text = ModDexterite.Text;

			int bouclier = 0;

			if (Bouclier.IsChecked == true)
				bouclier = 2;

			CA.Text = (int.Parse(Armure.Text) + int.Parse(BonusDexCa.Text) + int.Parse(MagieCA.Text) + int.Parse(TempCA.Text) + bouclier).ToString();

		}

		/// <summary>
		/// Rafraîchit le bloc de hp du personnage.
		/// </summary>
		private void RefreshHP()
		{
			int CalculHP = 0;
			int moyen = int.Parse(DVType.Text);

			CalculHP += moyen + int.Parse(ModConstitution.Text);

			if (moyen == 4) moyen = 3;
			else if (moyen == 6) moyen = 4;
			else if (moyen == 8) moyen = 5;
			else if (moyen == 10) moyen = 6;
			else if (moyen == 12) moyen = 7;
			else if (moyen == 20) moyen = 11;

			for (int i = 0; i < int.Parse(Level.Text) - 1; i++)
				CalculHP += moyen + int.Parse(ModConstitution.Text);

			HPMax.Text = CalculHP.ToString();
		}

		// ### Actions des menus ### \\
		private void EditionMode()
		{
			SwitchReadOnly();
			SwitchEnable();
			SwitchCursor();
		}
		
		private void CreateCharacter()
		{
			using (db db = new db())
			{
				bool alreadyExist = false;
				do
				{
					alreadyExist = false;
					var checkIdentity = from check in db.persoes select check.nom;

					foreach (var item in checkIdentity)
					{
						if (Nom.Text == item)
						{
							alreadyExist = true;
							NewName nomNouveau = new NewName();
							nomNouveau.ShowDialog();
							Nom.Text = nomNouveau.LeNouveauNom.Text;
						}
					}
				} while (alreadyExist);
			}

			string loyal = "";

			if (Loyal.IsChecked == true) loyal = "L";
			else if (FirstNeutre.IsChecked == true) loyal = "N";
			else if (Chaotique.IsChecked == true) loyal = "C";

			string bon = "";

			if (Bon.IsChecked == true) bon = "B";
			else if (SecondNeutre.IsChecked == true) bon = "N";
			else if (Mauvais.IsChecked == true) bon = "M";

			long lourde = 0;
			long intermediaire = 0;
			long bouclier = 0;

			if (Lourde.IsChecked == true) lourde = 1;
			else if (Intermediaire.IsChecked == true) intermediaire = 1;
			else if (Bouclier.IsChecked == true) bouclier = 1;

			long sortint = 0;
			long sortsag = 0;
			long sortcha = 0;

			if (SortINT.IsChecked == true) sortint = 1;
			else if (SortSAG.IsChecked == true) sortsag = 1;
			else if (SortCHA.IsChecked == true) sortcha = 1;

			using (db db = new db())
			{
				var ajoutPerso = new perso()
				{
					nom = Nom.Text,
					classe = Classe.Text,
					level = long.Parse(Level.Text),
					race = Race.Text,
					loyaute = loyal,
					bonte = bon,
					HP = long.Parse(HP.Text),
					DV = long.Parse(DVNow.Text),
					DVType = long.Parse(DVType.Text),
					baseFor = long.Parse(BaseFor.Text),
					baseDex = long.Parse(BaseDex.Text),
					baseCon = long.Parse(BaseCon.Text),
					baseInt = long.Parse(BaseInt.Text),
					baseSag = long.Parse(BaseSag.Text),
					baseCha = long.Parse(BaseCha.Text),
					levelFor = long.Parse(LevelFor.Text),
					levelDex = long.Parse(LevelDex.Text),
					levelCon = long.Parse(LevelCon.Text),
					levelInt = long.Parse(LevelInt.Text),
					levelSag = long.Parse(LevelSag.Text),
					levelCha = long.Parse(LevelCha.Text),
					magicFor = long.Parse(MagicFor.Text),
					magicDex = long.Parse(MagicDex.Text),
					magicCon = long.Parse(MagicCon.Text),
					magicInt = long.Parse(MagicInt.Text),
					magicSag = long.Parse(MagicSag.Text),
					magicCha = long.Parse(MagicCha.Text),
					tempFor = long.Parse(TempFor.Text),
					tempDex = long.Parse(TempDex.Text),
					tempCon = long.Parse(TempCon.Text),
					tempInt = long.Parse(TempInt.Text),
					tempSag = long.Parse(TempSag.Text),
					tempCha = long.Parse(TempCha.Text),
					magieJDSFor = long.Parse(MagieJDSFor.Text),
					magieJDSDex = long.Parse(MagieJDSDex.Text),
					magieJDSCon = long.Parse(MagieJDSCon.Text),
					magieJDSInt = long.Parse(MagieJDSInt.Text),
					magieJDSSag = long.Parse(MagieJDSSag.Text),
					magieJDSCha = long.Parse(MagieJDSCha.Text),
					tempJDSFor = long.Parse(TempJDSFor.Text),
					tempJDSDex = long.Parse(TempJDSDex.Text),
					tempJDSCon = long.Parse(TempJDSCon.Text),
					tempJDSInt = long.Parse(TempJDSInt.Text),
					tempJDSSag = long.Parse(TempJDSSag.Text),
					tempJDSCha = long.Parse(TempJDSCha.Text),
					bonusInit = long.Parse(BonusInit.Text),
					feet = long.Parse(Feet.Text),
					armure = long.Parse(Armure.Text),
					lourde = lourde,
					intermediaire = intermediaire,
					bouclier = bouclier,
					magieCA = long.Parse(MagieCA.Text),
					tempCA = long.Parse(TempCA.Text),
					magieAcro = long.Parse(MagieAcro.Text),
					magieArca = long.Parse(MagieArca.Text),
					magieAthl = long.Parse(MagieAthl.Text),
					magieDisc = long.Parse(MagieDisc.Text),
					magieDres = long.Parse(MagieDres.Text),
					magieEsca = long.Parse(MagieEsca.Text),
					magieHist = long.Parse(MagieHist.Text),
					magieInti = long.Parse(MagieInti.Text),
					magieIntu = long.Parse(MagieIntu.Text),
					magieInve = long.Parse(MagieInve.Text),
					magieMede = long.Parse(MagieMede.Text),
					magieNatu = long.Parse(MagieNatu.Text),
					magiePerc = long.Parse(MagiePerc.Text),
					magiePers = long.Parse(MagiePers.Text),
					magieReli = long.Parse(MagieReli.Text),
					magieRepr = long.Parse(MagieRepr.Text),
					magieSurv = long.Parse(MagieSurv.Text),
					magieTrom = long.Parse(MagieTrom.Text),
					sortINT = sortint,
					sortSAG = sortsag,
					sortCHA = sortcha,
					magieMelee = long.Parse(MagieMelee.Text),
					magieDistance = long.Parse(MagieDistance.Text),
					magieSort = long.Parse(MagieSort.Text),
				};
				db.persoes.Add(ajoutPerso);
				db.SaveChanges();

				MessageBox.Show("Saved");
			}
		}

		private void ChooseCharacter()
		{
			Open open = new Open();
			open.ShowDialog();

			string nom_perso = open.Combo.SelectedItem.ToString();

			using (db db = new db())
			{
				try
				{
					var retrieve = from personnage in db.persoes where personnage.nom == nom_perso select personnage;

					retrieve.Single();

					foreach (var item in retrieve)
					{
						/// ### INFO PERSONNAGE ###
						id = item.id_perso;
						Nom.Text = item.nom;
						Classe.Text = item.classe;
						Level.Text = item.level.ToString();
						Race.Text = item.race;
						if (item.loyaute == "L") Loyal.IsChecked = true;
						else if (item.loyaute == "N") FirstNeutre.IsChecked = true;
						else if (item.loyaute == "C") Chaotique.IsChecked = true;
						if (item.bonte == "B") Bon.IsChecked = true;
						else if (item.bonte == "N") SecondNeutre.IsChecked = true;
						else if (item.bonte == "M") Mauvais.IsChecked = true;

						/// ### STATS ###
						// Base
						BaseFor.Text = item.baseFor.ToString();
						BaseDex.Text = item.baseDex.ToString();
						BaseCon.Text = item.baseCon.ToString();
						BaseInt.Text = item.baseInt.ToString();
						BaseSag.Text = item.baseSag.ToString();
						BaseCha.Text = item.baseCha.ToString();
						// Level
						LevelFor.Text = item.levelFor.ToString();
						LevelDex.Text = item.levelDex.ToString();
						LevelCon.Text = item.levelCon.ToString();
						LevelInt.Text = item.levelInt.ToString();
						LevelSag.Text = item.levelSag.ToString();
						LevelCha.Text = item.levelCha.ToString();
						// Magie
						MagicFor.Text = item.magicFor.ToString();
						MagicDex.Text = item.magicDex.ToString();
						MagicCon.Text = item.magicCon.ToString();
						MagicInt.Text = item.magicInt.ToString();
						MagicSag.Text = item.magicSag.ToString();
						MagicCha.Text = item.magicCha.ToString();
						// Temp
						TempFor.Text = item.tempFor.ToString();
						TempDex.Text = item.tempDex.ToString();
						TempCon.Text = item.tempCon.ToString();
						TempInt.Text = item.tempInt.ToString();
						TempSag.Text = item.tempSag.ToString();
						TempCha.Text = item.tempCha.ToString();

						/// ### JDS ###
						// Magie
						MagieJDSFor.Text = item.magieJDSFor.ToString();
						MagieJDSDex.Text = item.magieJDSDex.ToString();
						MagieJDSCon.Text = item.magieJDSCon.ToString();
						MagieJDSInt.Text = item.magieJDSInt.ToString();
						MagieJDSSag.Text = item.magieJDSSag.ToString();
						MagieJDSCha.Text = item.magieJDSCha.ToString();
						// Temp
						TempJDSFor.Text = item.tempJDSFor.ToString();
						TempJDSDex.Text = item.tempJDSDex.ToString();
						TempJDSCon.Text = item.tempJDSCon.ToString();
						TempJDSInt.Text = item.tempJDSInt.ToString();
						TempJDSSag.Text = item.tempJDSSag.ToString();
						TempJDSCha.Text = item.tempJDSCha.ToString();

						/// ### DV ###
						DVNow.Text = item.DV.ToString();
						DVType.Text = item.DVType.ToString();

						/// ### HP ###
						HP.Text = item.HP.ToString();

						/// ### INIT ###
						BonusInit.Text = item.bonusInit.ToString();

						/// ### VITESSE ###
						Feet.Text = item.feet.ToString();

						/// ### CA ###
						Armure.Text = item.armure.ToString();
						if (item.bouclier == 1) Bouclier.IsChecked = true;
						else Bouclier.IsChecked = false;
						if (item.lourde == 1) Lourde.IsChecked = true;
						else Lourde.IsChecked = false;
						if (item.intermediaire == 1) Intermediaire.IsChecked = true;
						else Intermediaire.IsChecked = false;
						MagieCA.Text = item.magieCA.ToString();
						TempCA.Text = item.tempCA.ToString();

						/// ### COMPETENCES ###
						MagieAcro.Text = item.magieAcro.ToString();
						MagieArca.Text = item.magieArca.ToString();
						MagieAthl.Text = item.magieAthl.ToString();
						MagieDisc.Text = item.magieDisc.ToString();
						MagieDres.Text = item.magieDres.ToString();
						MagieEsca.Text = item.magieEsca.ToString();
						MagieHist.Text = item.magieHist.ToString();
						MagieInti.Text = item.magieInti.ToString();
						MagieIntu.Text = item.magieIntu.ToString();
						MagieInve.Text = item.magieInve.ToString();
						MagieMede.Text = item.magieMede.ToString();
						MagieNatu.Text = item.magieNatu.ToString();
						MagiePerc.Text = item.magiePerc.ToString();
						MagiePers.Text = item.magiePers.ToString();
						MagieReli.Text = item.magieReli.ToString();
						MagieRepr.Text = item.magieRepr.ToString();
						MagieSurv.Text = item.magieSurv.ToString();
						MagieTrom.Text = item.magieTrom.ToString();

						/// ### SORTS ###
						if (item.sortINT == 1) SortINT.IsChecked = true;
						else SortINT.IsChecked = false;
						if (item.sortSAG == 1) SortSAG.IsChecked = true;
						else SortSAG.IsChecked = false;
						if (item.sortCHA == 1) SortCHA.IsChecked = true;
						else SortCHA.IsChecked = false;

						/// ### TOUCHERS ###
						MagieMelee.Text = item.magieMelee.ToString();
						MagieDistance.Text = item.magieDistance.ToString();
					}
				}
				catch
				{
					MessageBox.Show("Erreur de chargement.");
				}
			}
		}

		private void SaveCharacter()
		{
			using (db db = new db())
			{
				try
				{
					var checkIdentity = from check in db.persoes select check.nom;
					MessageBox.Show("Base Trouvée.");
				}
				catch (Exception)
				{
					MessageBox.Show("Pas de Base.");
					try
					{
						SQLiteConnection.CreateFile("db.db");
						var maConnexion = new SQLiteConnection("Data Source=db.db");
						maConnexion.Open();
						SQLiteCommand commande = new SQLiteCommand("CREATE TABLE `perso` (	`id_perso`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,	`nom`	TEXT NOT NULL,	`classe`	TEXT NOT NULL,	`level`	INTEGER NOT NULL,	`race`	TEXT NOT NULL,	`loyaute`	TEXT NOT NULL,	`bonte`	TEXT NOT NULL,	`HP`	INTEGER NOT NULL,	`DV`	INTEGER NOT NULL,	`DVType`	INTEGER NOT NULL,	`baseFor`	INTEGER NOT NULL,	`baseDex`	INTEGER NOT NULL,	`baseCon`	INTEGER NOT NULL,	`baseInt`	INTEGER NOT NULL,	`baseSag`	NUMERIC NOT NULL,	`baseCha`	INTEGER NOT NULL,	`levelFor`	INTEGER NOT NULL,	`levelDex`	INTEGER NOT NULL,	`levelCon`	INTEGER NOT NULL,	`levelInt`	INTEGER NOT NULL,	`levelSag`	INTEGER NOT NULL,	`levelCha`	INTEGER NOT NULL,	`magicFor`	INTEGER NOT NULL,	`magicDex`	INTEGER NOT NULL,	`magicCon`	INTEGER NOT NULL,	`magicInt`	INTEGER NOT NULL,	`magicSag`	INTEGER NOT NULL,	`magicCha`	INTEGER NOT NULL,	`tempFor`	INTEGER NOT NULL,	`tempDex`	INTEGER NOT NULL,	`tempCon`	INTEGER NOT NULL,	`tempInt`	INTEGER NOT NULL,	`tempSag`	INTEGER NOT NULL,	`tempCha`	INTEGER NOT NULL,	`magieJDSFor`	INTEGER NOT NULL,	`magieJDSDex`	INTEGER NOT NULL,	`magieJDSCon`	INTEGER NOT NULL,	`magieJDSInt`	INTEGER NOT NULL,	`magieJDSSag`	INTEGER NOT NULL,	`magieJDSCha`	INTEGER NOT NULL,	`tempJDSFor`	INTEGER NOT NULL,	`tempJDSDex`	INTEGER NOT NULL,	`tempJDSCon`	INTEGER NOT NULL,	`tempJDSInt`	INTEGER NOT NULL,	`tempJDSSag`	INTEGER NOT NULL,	`tempJDSCha`	INTEGER NOT NULL,	`bonusInit`	INTEGER NOT NULL,	`feet`	INTEGER NOT NULL,	`armure`	INTEGER NOT NULL,	`intermediaire`	INTEGER NOT NULL,	`lourde`	INTEGER NOT NULL,	`bouclier`	INTEGER NOT NULL,	`magieCA`	INTEGER NOT NULL,	`tempCA`	INTEGER NOT NULL,	`magieAcro`	INTEGER NOT NULL,	`magieArca`	INTEGER NOT NULL,	`magieAthl`	INTEGER NOT NULL,	`magieDisc`	INTEGER NOT NULL,	`magieDres`	INTEGER NOT NULL,	`magieEsca`	INTEGER NOT NULL,	`magieHist`	INTEGER NOT NULL,	`magieInti`	INTEGER NOT NULL,	`magieIntu`	INTEGER NOT NULL,	`magieInve`	INTEGER NOT NULL,	`magieMede`	INTEGER NOT NULL,	`magieNatu`	INTEGER NOT NULL,	`magiePerc`	INTEGER NOT NULL,	`magiePers`	INTEGER NOT NULL,	`magieReli`	INTEGER NOT NULL,	`magieRepr`	INTEGER NOT NULL,	`magieSurv`	INTEGER NOT NULL,	`magieTrom`	INTEGER NOT NULL,	`sortINT`	INTEGER NOT NULL,	`sortSAG`	INTEGER NOT NULL,	`sortCHA`	INTEGER NOT NULL,	`magieMelee`	INTEGER NOT NULL,	`magieDistance`	INTEGER NOT NULL,	`magieSort`	INTEGER NOT NULL)", maConnexion);
						// db.Database.ExecuteSqlCommand("CREATE TABLE `perso` (	`id_perso`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,	`nom`	TEXT NOT NULL,	`classe`	TEXT NOT NULL,	`level`	INTEGER NOT NULL,	`race`	TEXT NOT NULL,	`loyaute`	TEXT NOT NULL,	`bonte`	TEXT NOT NULL,	`HP`	INTEGER NOT NULL,	`DV`	INTEGER NOT NULL,	`DVType`	INTEGER NOT NULL,	`baseFor`	INTEGER NOT NULL,	`baseDex`	INTEGER NOT NULL,	`baseCon`	INTEGER NOT NULL,	`baseInt`	INTEGER NOT NULL,	`baseSag`	NUMERIC NOT NULL,	`baseCha`	INTEGER NOT NULL,	`levelFor`	INTEGER NOT NULL,	`levelDex`	INTEGER NOT NULL,	`levelCon`	INTEGER NOT NULL,	`levelInt`	INTEGER NOT NULL,	`levelSag`	INTEGER NOT NULL,	`levelCha`	INTEGER NOT NULL,	`magicFor`	INTEGER NOT NULL,	`magicDex`	INTEGER NOT NULL,	`magicCon`	INTEGER NOT NULL,	`magicInt`	INTEGER NOT NULL,	`magicSag`	INTEGER NOT NULL,	`magicCha`	INTEGER NOT NULL,	`tempFor`	INTEGER NOT NULL,	`tempDex`	INTEGER NOT NULL,	`tempCon`	INTEGER NOT NULL,	`tempInt`	INTEGER NOT NULL,	`tempSag`	INTEGER NOT NULL,	`tempCha`	INTEGER NOT NULL,	`magieJDSFor`	INTEGER NOT NULL,	`magieJDSDex`	INTEGER NOT NULL,	`magieJDSCon`	INTEGER NOT NULL,	`magieJDSInt`	INTEGER NOT NULL,	`magieJDSSag`	INTEGER NOT NULL,	`magieJDSCha`	INTEGER NOT NULL,	`tempJDSFor`	INTEGER NOT NULL,	`tempJDSDex`	INTEGER NOT NULL,	`tempJDSCon`	INTEGER NOT NULL,	`tempJDSInt`	INTEGER NOT NULL,	`tempJDSSag`	INTEGER NOT NULL,	`tempJDSCha`	INTEGER NOT NULL,	`bonusInit`	INTEGER NOT NULL,	`feet`	INTEGER NOT NULL,	`armure`	INTEGER NOT NULL,	`intermediaire`	INTEGER NOT NULL,	`lourde`	INTEGER NOT NULL,	`bouclier`	INTEGER NOT NULL,	`magieCA`	INTEGER NOT NULL,	`tempCA`	INTEGER NOT NULL,	`magieAcro`	INTEGER NOT NULL,	`magieArca`	INTEGER NOT NULL,	`magieAthl`	INTEGER NOT NULL,	`magieDisc`	INTEGER NOT NULL,	`magieDres`	INTEGER NOT NULL,	`magieEsca`	INTEGER NOT NULL,	`magieHist`	INTEGER NOT NULL,	`magieInti`	INTEGER NOT NULL,	`magieIntu`	INTEGER NOT NULL,	`magieInve`	INTEGER NOT NULL,	`magieMede`	INTEGER NOT NULL,	`magieNatu`	INTEGER NOT NULL,	`magiePerc`	INTEGER NOT NULL,	`magiePers`	INTEGER NOT NULL,	`magieReli`	INTEGER NOT NULL,	`magieRepr`	INTEGER NOT NULL,	`magieSurv`	INTEGER NOT NULL,	`magieTrom`	INTEGER NOT NULL,	`sortINT`	INTEGER NOT NULL,	`sortSAG`	INTEGER NOT NULL,	`sortCHA`	INTEGER NOT NULL,	`magieMelee`	INTEGER NOT NULL,	`magieDistance`	INTEGER NOT NULL,	`magieSort`	INTEGER NOT NULL)");
						maConnexion.Close();
						MessageBox.Show("Base Créée");
						try
						{
							
						}
						catch 
						{
							
						}
					}
					catch
					{
						MessageBox.Show("Création ratée.");
					}
				}
				
				
			}

			
		}

		private void ImportCharacter()
		{
			MessageBox.Show("Fonction non implémentée");
		}

		private void ExportCharacter()
		{
			MessageBox.Show("Fonction non implémentée");
		}

		// ### Fonctions de calculs ### \\
		/// <summary>
		/// Calcul les modificateurs de la caractéristique entrée en paramètre.
		/// </summary>
		/// <param name="value">La caractéristique à transformer en modificateur.</param>
		/// <returns>Renvoue le modificateur.</returns>
		private int CalculModif(string value)
		{
			int modif = int.Parse(value);

			if (modif == 9) modif = -1;
			else if (modif == 7) modif = -2;
			else if (modif == 5) modif = -3;
			else if (modif == 3) modif = -4;
			else modif = (modif - 10) / 2;

			return modif;
		}

		/// <summary>
		/// Vérifie les points de créations de toutes les caractéristiques.
		/// </summary>
		private void CheckCreation()
		{
			int somme = 0;

			somme += CalculCreation(int.Parse(BaseFor.Text));
			somme += CalculCreation(int.Parse(BaseDex.Text));
			somme += CalculCreation(int.Parse(BaseCon.Text));
			somme += CalculCreation(int.Parse(BaseInt.Text));
			somme += CalculCreation(int.Parse(BaseSag.Text));
			somme += CalculCreation(int.Parse(BaseCha.Text));

			Creation.Text = (27 - somme).ToString();
		}

		/// <summary>
		/// Calcul la valeur en point(s) de création de la caractéristique passée en argument.
		/// </summary>
		/// <param name="carac">La caractéristique à calculer.</param>
		/// <returns>Renvoie la quantité de points de créations consommés.</returns>
		private int CalculCreation(int carac)
		{
			int value = 0;

			if (carac == 9) value = 1;
			else if (carac == 10) value = 2;
			else if (carac == 11) value = 3;
			else if (carac == 12) value = 4;
			else if (carac == 13) value = 5;
			else if (carac == 14) value = 7;
			else if (carac >= 15) value = 9;

			return value;
		}


		/// ### EVENEMENTS ### \\\
		// ### Clicks ### \\
		/// <summary>
		/// Lors d'un click sur le bouton d'édition.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Edition_Click(object sender, RoutedEventArgs e)
		{
			EditionMode();
		}

		private void New_Click(object sender, RoutedEventArgs e)
		{
			CreateCharacter();
		}

		private void Open_Click(object sender, RoutedEventArgs e)
		{
			ChooseCharacter();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			SaveCharacter();
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Fonction non implémentée");
		}

		private void Import_Click(object sender, RoutedEventArgs e)
		{
			ImportCharacter();
		}

		private void Export_Click(object sender, RoutedEventArgs e)
		{
			ExportCharacter();
		}

		// ### Checks ### \\
		/// <summary>
		/// Quand une des checkbox de l'armure est check.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Armure_Checked(object sender, RoutedEventArgs e)
		{
			if (sender.Equals(Intermediaire))
				Lourde.IsChecked = false;
			else if (sender.Equals(Lourde))
				Intermediaire.IsChecked = false;

			RefreshArmure();
		}

		/// <summary>
		/// Quand une des checkbox de l'armure est uncheck.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Armure_Unchecked(object sender, RoutedEventArgs e)
		{
			RefreshArmure();
		}

		/// <summary>
		/// Quand une des checkbox de SpellCaster est check.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Sort_Checked(object sender, RoutedEventArgs e)
		{
			if (sender.Equals(SortINT))
			{
				SortSAG.IsChecked = false; SortCHA.IsChecked = false;
			}
			else if (sender.Equals(SortSAG))
			{
				SortINT.IsChecked = false; SortCHA.IsChecked = false;
			}
			else if (sender.Equals(SortCHA))
			{
				SortINT.IsChecked = false; SortSAG.IsChecked = false;
			}

			RefreshToucher();
		}

		/// <summary>
		/// Quand une des checkbox de SpellCaster est uncheck.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Sort_Unchecked(object sender, RoutedEventArgs e)
		{
			RefreshToucher();
		}

		/// <summary>
		/// Quand une des checkbox du bloc jet de sauvegarde est check.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void MaitriseJDS_Checked(object sender, RoutedEventArgs e)
		{
			RefreshJDS();
		}

		/// <summary>
		/// Quand une des checkbox du bloc jet de sauvegarde est uncheck.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void MaitriseJDS_Unchecked(object sender, RoutedEventArgs e)
		{
			RefreshJDS();
		}

		/// <summary>
		/// Quand une des checkbox de compétence est check.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void MaitriseCompetence_Checked(object sender, RoutedEventArgs e)
		{
			RefreshCompetence();
		}

		/// <summary>
		/// Quand une des checkbox de compétence est uncheck.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void MaitriseCompetence_Unchecked(object sender, RoutedEventArgs e)
		{
			RefreshCompetence();
		}

		// ### Lost Focus ### \\
		/// <summary>
		/// Quand une des TextBox perd le focus.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Global_LostFocus(object sender, RoutedEventArgs e)
		{
			// Ici on vérifie qu l'utilisateur a bien entré des chiffres
			if (sender.Equals(HP) || sender.Equals(Feet)) CheckNumberOnly(sender, 3);
			else CheckNumberOnly(sender);

			// En fonction de la TextBox qui a appellé l'évènement on refresh le bloc associé.
			if (sender.Equals(DVMax)) RefreshHP();
			else if (sender.Equals(Level)) RefreshLinkLevel();
			else if (sender.Equals(Feet)) RefreshVitesse();
			else if (sender.Equals(BonusInit)) RefreshInitiative();
			else if (sender.Equals(MagieCA) || sender.Equals(TempCA) || sender.Equals(Armure)) RefreshArmure();
			else if (sender.Equals(MagieJDSFor) || sender.Equals(MagieJDSDex) || sender.Equals(MagieJDSCon) || sender.Equals(MagieJDSInt) || sender.Equals(MagieJDSSag) || sender.Equals(MagieJDSCha)
				|| sender.Equals(TempJDSFor) || sender.Equals(TempJDSDex) || sender.Equals(TempJDSCon) || sender.Equals(TempJDSInt) || sender.Equals(TempJDSSag) || sender.Equals(TempJDSCha)
				)
				RefreshJDS();
			else if (sender.Equals(BaseFor) || sender.Equals(BaseDex) || sender.Equals(BaseCon) || sender.Equals(BaseInt) || sender.Equals(BaseSag) || sender.Equals(BaseCha)
				|| sender.Equals(LevelFor) || sender.Equals(LevelDex) || sender.Equals(LevelCon) || sender.Equals(LevelInt) || sender.Equals(LevelSag) || sender.Equals(LevelCha)
				|| sender.Equals(MagicFor) || sender.Equals(MagicDex) || sender.Equals(MagicCon) || sender.Equals(MagicInt) || sender.Equals(MagicSag) || sender.Equals(MagicCha)
				|| sender.Equals(TempFor) || sender.Equals(TempDex) || sender.Equals(TempCon) || sender.Equals(TempInt) || sender.Equals(TempSag) || sender.Equals(TempCha)
				)
				RefreshStatistique();
			else if (sender.Equals(MagieAcro) || sender.Equals(MagieArca) || sender.Equals(MagieAthl) || sender.Equals(MagieDisc) || sender.Equals(MagieDres) || sender.Equals(MagieEsca)
				|| sender.Equals(MagieHist) || sender.Equals(MagieInti) || sender.Equals(MagieIntu) || sender.Equals(MagieInve) || sender.Equals(MagieMede) || sender.Equals(MagieNatu)
				|| sender.Equals(MagiePerc) || sender.Equals(MagiePers) || sender.Equals(MagieReli) || sender.Equals(MagieRepr) || sender.Equals(MagieSurv) || sender.Equals(MagieTrom)
				)
				RefreshCompetence();

			if (sender.Equals(BaseFor) || sender.Equals(BaseDex) || sender.Equals(BaseCon) || sender.Equals(BaseInt) || sender.Equals(BaseSag) || sender.Equals(BaseCha))
				CheckCreation();
		}

		// ### KeyDown (Raccourcis Clavier) ### \\
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
			{
				if (e.Key == Key.N)
					CreateCharacter();
				else if (e.Key == Key.R)
					RefreshLinkLevel();
				else if (e.Key == Key.O)
					ChooseCharacter();
				else if (e.Key == Key.S)
					SaveCharacter();
				else if (e.Key == Key.E)
					EditionMode();
			}

			if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
			{
				if (e.Key == Key.E)
					ExportCharacter();
				else if (e.Key == Key.I)
					ImportCharacter();
			}
		}
	}
}
