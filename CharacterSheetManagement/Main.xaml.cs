using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

		/// <summary>
		/// Indique si la langue doit être modifiré ou non.
		/// </summary>
		bool bool_SwitchLanguage = true;

		// ### Stats du personnage ### \\
		short _maitrise;
		long id = 1;

		/// ### CONSTRUCTEUR ### \\\
		public Main()
		{
			InitializeComponent();
			RefreshLink();

			/// Décommenter pour le débuggage. (Affiche les exceptions non-gérées.
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
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
			if (bool_SwitchReadOnly) { Switch = false; if (bool_SwitchLanguage) { Edition.Header = "Mode Edition"; } else { Edition.Header = "Edition Enabled"; } Creation.Visibility = Visibility.Visible; }
			else { Switch = true; if (bool_SwitchLanguage) { Edition.Header = "Mode Lecture"; } else { Edition.Header = "Read Only"; } Creation.Visibility = Visibility.Hidden; }

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

		/// <summary>
		/// Switch la langue des labels.
		/// </summary>
		private void SwitchLanguage()
		{
			if (bool_SwitchLanguage)
			{
				/// ### Menu ### \\\
				// File Menu.
				File.Header = "File";
				New.Header = "New";
				Opener.Header = "Open";
				Save.Header = "Save";
				Delete.Header = "Delete";
				// Import/Export Menu.
				Import.Header = "Import";
				Export.Header = "Export";
				// Edition Menu.
				if (bool_SwitchReadOnly) { Edition.Header = "Read Only"; } else { Edition.Header = "Edition Enabled"; }
				// Language Menu.
				Language.Header = "Language : ENG";
				

				/// ### CHARACTER'S INFO ### \\\
				LabelClass.Text = "Class :";
				LabelAlignment.Text = "Alignment :";
				Bon.Content = "G";
				Mauvais.Content = "E";
				LabelProficiency.Text = "Proficiency";

				/// ### STATISTICS ### \\\
				// Titles.
				LabelStatistics.Text = "Statistics";
				LabelStats.Text = "Stats";
				LabelMagic.Text = "Magic";
				// Stats.
				LabelStrength.Text = "STR";
				LabelWisdom.Text = "WIS";

				/// ### SAVING THROWS ### \\\
				LabelSavingThrows.Text = "Saving Throws";
				LabelStrengthST.Text = "    STR";
				LabelWisdomST.Text = "    WIS";

				/// ### HIT DICE ### \\\
				LabelActualDice.Text = "Actual";
				LabelHit.Text = "Hit";
				LabelDice.Text = "Dice";

				/// ### SPEED ### \\\
				LabelSpeed.Text = "Speed";

				/// ### ARMOR CLASS ### \\\
				LabelArmorClass.Text = "Armor Class";
				LabelArmor.Text = "Armor";
				LabelBonusMagieCA.Text = "Bonus Magic";
				LabelShield.Text = "Shield";
				Intermediaire.Content = "Medium";
				Lourde.Content = "Heavy"; Lourde.Margin = new Thickness(20, 0, 0, 0);

				/// ### SKILLS ### \\\
				LabelSkill.Text = "Skills";
				LabelNameSkill.Text = "Name";
				// Names. (Ordered by alphabetical order.)
				LabelAcro.Text = "   Acrobatics"; Grid.SetRow(LabelAcro, 2); Grid.SetRow(MaitriseAcro, 2); Grid.SetRow(Acrobatie, 2); Grid.SetRow(BaseAcro, 2); Grid.SetRow(MagieAcro, 2);
				LabelAnim.Text = "   Animal Handling"; Grid.SetRow(LabelAnim, 3); Grid.SetRow(MaitriseDres, 3); Grid.SetRow(Dressage, 3); Grid.SetRow(BaseDres, 3); Grid.SetRow(MagieDres, 3);
				LabelArca.Text = "   Arcana"; Grid.SetRow(LabelArca, 4); Grid.SetRow(MaitriseArca, 4); Grid.SetRow(Arcanes, 4); Grid.SetRow(BaseArca, 4); Grid.SetRow(MagieArca, 4);
				LabelAthl.Text = "   Athletics"; Grid.SetRow(LabelAthl, 5); Grid.SetRow(MaitriseAthl, 5); Grid.SetRow(Athletisme, 5); Grid.SetRow(BaseAthl, 5); Grid.SetRow(MagieAthl, 5);
				LabelDece.Text = "   Deception"; Grid.SetRow(LabelDece, 6); Grid.SetRow(MaitriseTrom, 6); Grid.SetRow(Tromperie, 6); Grid.SetRow(BaseTrom, 6); Grid.SetRow(MagieTrom, 6);
				LabelHist.Text = "   History"; Grid.SetRow(LabelHist, 7); Grid.SetRow(MaitriseHist, 7); Grid.SetRow(Histoire, 7); Grid.SetRow(BaseHist, 7); Grid.SetRow(MagieHist, 7);
				LabelInsi.Text = "   Insight"; Grid.SetRow(LabelInsi, 8); Grid.SetRow(MaitriseIntu, 8); Grid.SetRow(Intuition, 8); Grid.SetRow(BaseIntu, 8); Grid.SetRow(MagieIntu, 8);
				LabelInti.Text = "   Intimidation"; Grid.SetRow(LabelInti, 9); Grid.SetRow(MaitriseInti, 9); Grid.SetRow(Intimidation, 9); Grid.SetRow(BaseInti, 9); Grid.SetRow(MagieInti, 9);
				LabelInve.Text = "   Investigation"; Grid.SetRow(LabelInve, 10); Grid.SetRow(MaitriseInve, 10); Grid.SetRow(Investigation, 10); Grid.SetRow(BaseInve, 10); Grid.SetRow(MagieInve, 10);
				LabelMedi.Text = "   Medicine"; Grid.SetRow(LabelMedi, 11); Grid.SetRow(MaitriseMede, 11); Grid.SetRow(Medecine, 11); Grid.SetRow(BaseMede, 11); Grid.SetRow(MagieMede, 11);
				LabelNatu.Text = "   Nature"; Grid.SetRow(LabelNatu, 12); Grid.SetRow(MaitriseNatu, 12); Grid.SetRow(Nature, 12); Grid.SetRow(BaseNatu, 12); Grid.SetRow(MagieNatu, 12);
				LabelPerc.Text = "   Perception"; Grid.SetRow(LabelPerc, 13); Grid.SetRow(MaitrisePerc, 13); Grid.SetRow(Perception, 13); Grid.SetRow(BasePerc, 13); Grid.SetRow(MagiePerc, 13);
				LabelPerf.Text = "   Performance"; Grid.SetRow(LabelPerf, 14); Grid.SetRow(MaitriseRepr, 14); Grid.SetRow(Representation, 14); Grid.SetRow(BaseRepr, 14); Grid.SetRow(MagieRepr, 14);
				LabelPers.Text = "   Persuasion"; Grid.SetRow(LabelPers, 15); Grid.SetRow(MaitrisePers, 15); Grid.SetRow(Persuasion, 15); Grid.SetRow(BasePers, 15); Grid.SetRow(MagiePers, 15);
				LabelReli.Text = "   Religion"; Grid.SetRow(LabelReli, 16); Grid.SetRow(MaitriseReli, 16); Grid.SetRow(Religion, 16); Grid.SetRow(BaseReli, 16); Grid.SetRow(MagieReli, 16);
				LabelSlei.Text = "   Sleight of hand"; Grid.SetRow(LabelSlei, 17); Grid.SetRow(MaitriseEsca, 17); Grid.SetRow(Escamotage, 17); Grid.SetRow(BaseEsca, 17); Grid.SetRow(MagieEsca, 17);
				LabelStea.Text = "   Stealth"; Grid.SetRow(LabelStea, 18); Grid.SetRow(MaitriseDisc, 18); Grid.SetRow(Discretion, 18); Grid.SetRow(BaseDisc, 18); Grid.SetRow(MagieDisc, 18);
				LabelSurv.Text = "   Survival"; Grid.SetRow(LabelSurv, 19); Grid.SetRow(MaitriseSurv, 19); Grid.SetRow(Survie, 19); Grid.SetRow(BaseSurv, 19); Grid.SetRow(MagieSurv, 19);

				/// ### SPELL ### \\\
				SpellcasterLabel.Text = "Spellcasting Ability";

				/// ### ATTACK ROLL ### \\\
				LabelHits.Text = "Attack Roll";
				LabelMelee.Text = "Melee";
				LabelRanged.Text = "Range"; LabelRanged.Padding = new Thickness(-1);
				LabelSpell.Text = "Spell";
			}
			else
			{
				/// ### Menu ### \\\
				// File Menu.
				File.Header = "Fichier";
				New.Header = "Nouveau";
				Opener.Header = "Ouvrir";
				Save.Header = "Sauvegarder";
				Delete.Header = "Supprimer";
				// Import/Export Menu.
				Import.Header = "Importer";
				Export.Header = "Exporter";
				// Edition Menu.
				if (bool_SwitchReadOnly) { Edition.Header = "Mode Lecture"; } else { Edition.Header = "Mode Edition"; }
				// Language Menu.
				Language.Header = "Langue : FR";

				/// ### CHARACTER'S INFO ### \\\
				LabelClass.Text = "Classe :";
				LabelAlignment.Text = "Alignement :";
				Bon.Content = "B";
				Mauvais.Content = "M";
				LabelProficiency.Text = "Maîtrise";

				/// ### STATISTICS ### \\\
				// Titles.
				LabelStatistics.Text = "Statistiques";
				LabelStats.Text = "Stats";
				LabelMagic.Text = "Magie";
				// Stats.
				LabelStrength.Text = "FOR";
				LabelWisdom.Text = "SAG";

				/// ### SAVING THROWS ### \\\
				LabelSavingThrows.Text = "Jets de Sauvegarde";
				LabelStrengthST.Text = "    FOR";
				LabelWisdomST.Text = "    SAG";

				/// ### HIT DICE ### \\\
				LabelActualDice.Text = "Actuel";
				LabelHit.Text = "Dé";
				LabelDice.Text = "Vie";

				/// ### SPEED ### \\\
				LabelSpeed.Text = "Vitesse";

				/// ### ARMOR CLASS ### \\\
				LabelArmorClass.Text = "Classe d'Armure";
				LabelArmor.Text = "Armure";
				LabelShield.Text = "Bouclier";
				Intermediaire.Content = "Inter";
				Lourde.Content = "Lourde"; Lourde.Margin = new Thickness(0, 0, 0, 0);
				LabelBonusMagieCA.Text = "Bonus Magie";

				/// ### SKILLS ### \\\
				LabelSkill.Text = "Compétences";
				LabelNameSkill.Text = "Nom";
				// Names. (Ordered by alphabetical order.)
				LabelAcro.Text = "   Acrobatie"; Grid.SetRow(LabelAcro, 2); Grid.SetRow(MaitriseAcro, 2); Grid.SetRow(Acrobatie, 2); Grid.SetRow(BaseAcro, 2); Grid.SetRow(MagieAcro, 2);
				LabelArca.Text = "   Arcanes"; Grid.SetRow(LabelArca, 3); Grid.SetRow(MaitriseArca, 3); Grid.SetRow(Arcanes, 3); Grid.SetRow(BaseArca, 3); Grid.SetRow(MagieArca, 3);
				LabelAthl.Text = "   Athlétisme"; Grid.SetRow(LabelAthl, 4); Grid.SetRow(MaitriseAthl, 4); Grid.SetRow(Athletisme, 4); Grid.SetRow(BaseAthl, 4); Grid.SetRow(MagieAthl, 4);
				LabelStea.Text = "   Discrétion"; Grid.SetRow(LabelStea, 5); Grid.SetRow(MaitriseDisc, 5); Grid.SetRow(Discretion, 5); Grid.SetRow(BaseDisc, 5); Grid.SetRow(MagieDisc, 5);
				LabelAnim.Text = "   Dressage"; Grid.SetRow(LabelAnim, 6); Grid.SetRow(MaitriseDres, 6); Grid.SetRow(Dressage, 6); Grid.SetRow(BaseDres, 6); Grid.SetRow(MagieDres, 6);
				LabelSlei.Text = "   Escamotage"; Grid.SetRow(LabelSlei, 7); Grid.SetRow(MaitriseEsca, 7); Grid.SetRow(Escamotage, 7); Grid.SetRow(BaseEsca, 7); Grid.SetRow(MagieEsca, 7);
				LabelHist.Text = "   Histoire"; Grid.SetRow(LabelHist, 8); Grid.SetRow(MaitriseHist, 8); Grid.SetRow(Histoire, 8); Grid.SetRow(BaseHist, 8); Grid.SetRow(MagieHist, 8);
				LabelInti.Text = "   Intimidation"; Grid.SetRow(LabelInti, 9); Grid.SetRow(MaitriseInti, 9); Grid.SetRow(Intimidation, 9); Grid.SetRow(BaseInti, 9); Grid.SetRow(MagieInti, 9);
				LabelInsi.Text = "   Intuition"; Grid.SetRow(LabelInsi, 10); Grid.SetRow(MaitriseIntu, 10); Grid.SetRow(Intuition, 10); Grid.SetRow(BaseIntu, 10); Grid.SetRow(MagieIntu, 10);
				LabelInve.Text = "   Investigation"; Grid.SetRow(LabelInve, 11); Grid.SetRow(MaitriseInve, 11); Grid.SetRow(Investigation, 11); Grid.SetRow(BaseInve, 11); Grid.SetRow(MagieInve, 11);
				LabelMedi.Text = "   Médecine"; Grid.SetRow(LabelMedi, 12); Grid.SetRow(MaitriseMede, 12); Grid.SetRow(Medecine, 12); Grid.SetRow(BaseMede, 12); Grid.SetRow(MagieMede, 12);
				LabelNatu.Text = "   Nature"; Grid.SetRow(LabelNatu, 13); Grid.SetRow(MaitriseNatu, 13); Grid.SetRow(Nature, 13); Grid.SetRow(BaseNatu, 13); Grid.SetRow(MagieNatu, 13);
				LabelPerc.Text = "   Perception"; Grid.SetRow(LabelPerc, 14); Grid.SetRow(MaitrisePerc, 14); Grid.SetRow(Perception, 14); Grid.SetRow(BasePerc, 14); Grid.SetRow(MagiePerc, 14);
				LabelPers.Text = "   Persuasion"; Grid.SetRow(LabelPers, 15); Grid.SetRow(MaitrisePers, 15); Grid.SetRow(Persuasion, 15); Grid.SetRow(BasePers, 15); Grid.SetRow(MagiePers, 15);
				LabelReli.Text = "   Religion"; Grid.SetRow(LabelReli, 16); Grid.SetRow(MaitriseReli, 16); Grid.SetRow(Religion, 16); Grid.SetRow(BaseReli, 16); Grid.SetRow(MagieReli, 16);
				LabelPerf.Text = "   Représentation"; Grid.SetRow(LabelPerf, 17); Grid.SetRow(MaitriseRepr, 17); Grid.SetRow(Representation, 17); Grid.SetRow(BaseRepr, 17); Grid.SetRow(MagieRepr, 17);
				LabelSurv.Text = "   Survie"; Grid.SetRow(LabelSurv, 18); Grid.SetRow(MaitriseSurv, 18); Grid.SetRow(Survie, 18); Grid.SetRow(BaseSurv, 18); Grid.SetRow(MagieSurv, 18);
				LabelDece.Text = "   Tromperie"; Grid.SetRow(LabelDece, 19); Grid.SetRow(MaitriseTrom, 19); Grid.SetRow(Tromperie, 19); Grid.SetRow(BaseTrom, 19); Grid.SetRow(MagieTrom, 19);

				/// ### SPELL ### \\\
				SpellcasterLabel.Text = "Caractéristique de lanceur de sort";

				/// ### ATTACK ROLL ### \\\
				LabelHits.Text = "Bonus aux Touchers";
				LabelMelee.Text = "Mélée";
				LabelRanged.Text = "Dist."; LabelRanged.Padding = new Thickness(0);
				LabelSpell.Text = "Sorts";
			}

			bool_SwitchLanguage = !bool_SwitchLanguage;
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

			if (newInput.Length == 0)
				newInput = "0";

			(sender as TextBox).Text = newInput;
		}

		// ### Les Refresh ### \\
		/// <summary>
		/// Lorsque le niveau du personnage est modifié déclenche tous les autres refresh en plus d'actualiser la maîtrise.
		/// </summary>
		private void RefreshLink()
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
			RefreshSpeed();
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
			ModForce.Text = CalculMod(Force.Text).ToString();
			ModDexterite.Text = CalculMod(Dexterite.Text).ToString();
			ModConstitution.Text = CalculMod(Constitution.Text).ToString();
			ModIntelligence.Text = CalculMod(Intelligence.Text).ToString();
			ModSagesse.Text = CalculMod(Sagesse.Text).ToString();
			ModCharisme.Text = CalculMod(Charisme.Text).ToString();

			RefreshBase();
			RefreshHP();
			RefreshSkill();
			RefreshToucher();
			RefreshJDS();
			RefreshInitiative();
			RefreshArmor();
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
		private void RefreshSkill()
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
		private void RefreshSpeed()
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
		private void RefreshArmor()
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
		/// <summary>
		/// Bascule en mode édition avec le call des fonctions "switch"
		/// </summary>
		private void EditionMode()
		{
			SwitchReadOnly();
			SwitchEnable();
			SwitchCursor();
		}

		/// <summary>
		/// Créer un personnage par sa sauvegarde dans la base.
		/// </summary>
		private void CreateCharacter()
		{
			try
			{
				using (db db = new db())
				{
					var retrieve = from personnage in db.persoes where personnage.nom == Nom.Text select personnage;

					retrieve.Single();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Erreur de Chargement.");
			}
			finally
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
		}

		/// <summary>
		/// Permet de choisir un personnage dans la base local du programme.
		/// </summary>
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
				}
				catch (Exception)
				{
					MessageBox.Show("Erreur de Chargement.");
				}
				finally
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
					catch (Exception)
					{

					}
				}
				RefreshLink();
			}
		}

		/// <summary>
		/// Update le personnage dans la BDD.
		/// </summary>
		private void SaveCharacter()
		{
			using (db db = new db())
			{
				try
				{
					var checkIdentity = from check in db.persoes where check.id_perso == id select check;
				}
				catch (Exception)
				{
					MessageBox.Show("Base Absente.");
				}
				finally
				{
					var perso = new perso { id_perso = id };

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

					var dbperso = db.persoes.Find(perso.id_perso);

					dbperso.nom = Nom.Text;
					dbperso.classe = Classe.Text;
					dbperso.level = long.Parse(Level.Text);
					dbperso.race = Race.Text;
					dbperso.loyaute = loyal;
					dbperso.bonte = bon;
					dbperso.HP = long.Parse(HP.Text);
					dbperso.DV = long.Parse(DVNow.Text);
					dbperso.DVType = long.Parse(DVType.Text);
					dbperso.baseFor = long.Parse(BaseFor.Text);
					dbperso.baseDex = long.Parse(BaseDex.Text);
					dbperso.baseCon = long.Parse(BaseCon.Text);
					dbperso.baseInt = long.Parse(BaseInt.Text);
					dbperso.baseSag = long.Parse(BaseSag.Text);
					dbperso.baseCha = long.Parse(BaseCha.Text);
					dbperso.levelFor = long.Parse(LevelFor.Text);
					dbperso.levelDex = long.Parse(LevelDex.Text);
					dbperso.levelCon = long.Parse(LevelCon.Text);
					dbperso.levelInt = long.Parse(LevelInt.Text);
					dbperso.levelSag = long.Parse(LevelSag.Text);
					dbperso.levelCha = long.Parse(LevelCha.Text);
					dbperso.magicFor = long.Parse(MagicFor.Text);
					dbperso.magicDex = long.Parse(MagicDex.Text);
					dbperso.magicCon = long.Parse(MagicCon.Text);
					dbperso.magicInt = long.Parse(MagicInt.Text);
					dbperso.magicSag = long.Parse(MagicSag.Text);
					dbperso.magicCha = long.Parse(MagicCha.Text);
					dbperso.tempFor = long.Parse(TempFor.Text);
					dbperso.tempDex = long.Parse(TempDex.Text);
					dbperso.tempCon = long.Parse(TempCon.Text);
					dbperso.tempInt = long.Parse(TempInt.Text);
					dbperso.tempSag = long.Parse(TempSag.Text);
					dbperso.tempCha = long.Parse(TempCha.Text);
					dbperso.magieJDSFor = long.Parse(MagieJDSFor.Text);
					dbperso.magieJDSDex = long.Parse(MagieJDSDex.Text);
					dbperso.magieJDSCon = long.Parse(MagieJDSCon.Text);
					dbperso.magieJDSInt = long.Parse(MagieJDSInt.Text);
					dbperso.magieJDSSag = long.Parse(MagieJDSSag.Text);
					dbperso.magieJDSCha = long.Parse(MagieJDSCha.Text);
					dbperso.tempJDSFor = long.Parse(TempJDSFor.Text);
					dbperso.tempJDSDex = long.Parse(TempJDSDex.Text);
					dbperso.tempJDSCon = long.Parse(TempJDSCon.Text);
					dbperso.tempJDSInt = long.Parse(TempJDSInt.Text);
					dbperso.tempJDSSag = long.Parse(TempJDSSag.Text);
					dbperso.tempJDSCha = long.Parse(TempJDSCha.Text);
					dbperso.bonusInit = long.Parse(BonusInit.Text);
					dbperso.feet = long.Parse(Feet.Text);
					dbperso.armure = long.Parse(Armure.Text);
					dbperso.lourde = lourde;
					dbperso.intermediaire = intermediaire;
					dbperso.bouclier = bouclier;
					dbperso.magieCA = long.Parse(MagieCA.Text);
					dbperso.tempCA = long.Parse(TempCA.Text);
					dbperso.magieAcro = long.Parse(MagieAcro.Text);
					dbperso.magieArca = long.Parse(MagieArca.Text);
					dbperso.magieAthl = long.Parse(MagieAthl.Text);
					dbperso.magieDisc = long.Parse(MagieDisc.Text);
					dbperso.magieDres = long.Parse(MagieDres.Text);
					dbperso.magieEsca = long.Parse(MagieEsca.Text);
					dbperso.magieHist = long.Parse(MagieHist.Text);
					dbperso.magieInti = long.Parse(MagieInti.Text);
					dbperso.magieIntu = long.Parse(MagieIntu.Text);
					dbperso.magieInve = long.Parse(MagieInve.Text);
					dbperso.magieMede = long.Parse(MagieMede.Text);
					dbperso.magieNatu = long.Parse(MagieNatu.Text);
					dbperso.magiePerc = long.Parse(MagiePerc.Text);
					dbperso.magiePers = long.Parse(MagiePers.Text);
					dbperso.magieReli = long.Parse(MagieReli.Text);
					dbperso.magieRepr = long.Parse(MagieRepr.Text);
					dbperso.magieSurv = long.Parse(MagieSurv.Text);
					dbperso.magieTrom = long.Parse(MagieTrom.Text);
					dbperso.sortINT = sortint;
					dbperso.sortSAG = sortsag;
					dbperso.sortCHA = sortcha;
					dbperso.magieMelee = long.Parse(MagieMelee.Text);
					dbperso.magieDistance = long.Parse(MagieDistance.Text);
					dbperso.magieSort = long.Parse(MagieSort.Text);

					db.SaveChanges();
				}
			}
		}

		/// <summary>
		/// Permet d'importer un personnage exporté par la méthode ExportCharacter();
		/// </summary>
		private void ImportCharacter()
		{
			MessageBox.Show("Fonction non implémentée");
		}

		/// <summary>
		/// Permet d'exporter un personnage.
		/// </summary>
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
		private int CalculMod(string value)
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
		// ### Affichage des Exceptions non-Gérées ### \\
		/// <summary>
		/// Affiche les erreurs non gérées.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		static void MyHandler(object sender, UnhandledExceptionEventArgs args)
		{
			Exception e = (Exception)args.ExceptionObject;
			MessageBox.Show("MyHandler caught : " + e.Message + " \n InnerException : " + e.InnerException);
		}

		// ### Clicks ### \\
		/// <summary>
		/// Lors d'un click sur le bouton d'édition.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Edition_Click(object sender, RoutedEventArgs e)
		{
			EditionMode();
		}

		/// <summary>
		/// Lors d'un click sur le bouton nouveau.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void New_Click(object sender, RoutedEventArgs e)
		{
			CreateCharacter();
		}

		/// <summary>
		/// Lors d'un click sur le bouton ouvrir.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Open_Click(object sender, RoutedEventArgs e)
		{
			ChooseCharacter();
		}

		/// <summary>
		/// Lors d'un click sur le bouton enregistrer.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Save_Click(object sender, RoutedEventArgs e)
		{
			SaveCharacter();
		}

		/// <summary>
		/// Lors d'un click sur le bouton supprimer.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Fonction non implémentée");
		}

		/// <summary>
		/// Lors d'un click sur le bouton importer.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Import_Click(object sender, RoutedEventArgs e)
		{
			ImportCharacter();
		}

		/// <summary>
		/// Lors d'un click sur le bouton exporter.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Export_Click(object sender, RoutedEventArgs e)
		{
			ExportCharacter();
		}

		/// <summary>
		/// Lors du click sur le bouton de changement de langue.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Language_Click(object sender, RoutedEventArgs e)
		{
			SwitchLanguage();
		}
		
		// ### Checked ### \\
		/// <summary>
		/// Quand une des checkbox de l'armure est check.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Armor_Checked(object sender, RoutedEventArgs e)
		{
			if (sender.Equals(Intermediaire))
				Lourde.IsChecked = false;
			else if (sender.Equals(Lourde))
				Intermediaire.IsChecked = false;

			RefreshArmor();
		}

		/// <summary>
		/// Quand une des checkbox de l'armure est uncheck.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Armor_Unchecked(object sender, RoutedEventArgs e)
		{
			RefreshArmor();
		}

		/// <summary>
		/// Quand une des checkbox de SpellCaster est check.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Spell_Checked(object sender, RoutedEventArgs e)
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
		private void Spell_Unchecked(object sender, RoutedEventArgs e)
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
			RefreshSkill();
		}

		/// <summary>
		/// Quand une des checkbox de compétence est uncheck.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void MaitriseCompetence_Unchecked(object sender, RoutedEventArgs e)
		{
			RefreshSkill();
		}

		// ### Key Up (Check input) ### \\
		/// <summary>
		/// Quand une des TextBox perd le focus de la souris.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Global_KeyUp(object sender, KeyEventArgs e)
		{
			// Ici on vérifie qu l'utilisateur a bien entré des chiffres
			if (sender.Equals(HP) || sender.Equals(Feet)) CheckNumberOnly(sender, 3);
			else CheckNumberOnly(sender);

			// En fonction de la TextBox qui a appellé l'évènement on refresh le bloc associé.
			if (sender.Equals(DVMax) || sender.Equals(DVType)) RefreshHP();
			else if (sender.Equals(Level)) RefreshLink();
			else if (sender.Equals(Feet)) RefreshSpeed();
			else if (sender.Equals(BonusInit)) RefreshInitiative();
			else if (sender.Equals(MagieCA) || sender.Equals(TempCA) || sender.Equals(Armure)) RefreshArmor();
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
				RefreshSkill();

			if (sender.Equals(BaseFor) || sender.Equals(BaseDex) || sender.Equals(BaseCon) || sender.Equals(BaseInt) || sender.Equals(BaseSag) || sender.Equals(BaseCha))
				CheckCreation();
		}

		// ### KeyDown (Keyboard Shortcuts) ### \\
		/// <summary>
		/// Vérifie les touches qui sont pressées pour les raccourcis clavier.
		/// </summary>
		/// <param name="sender">L'objet qui appelle l'évènement.</param>
		/// <param name="e">L'évènement.</param>
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
			{
				if (e.Key == Key.N)
					CreateCharacter();
				else if (e.Key == Key.R)
					RefreshLink();
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
