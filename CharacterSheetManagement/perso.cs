namespace CharacterSheetManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("perso")]
    public partial class perso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_perso { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string nom { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string classe { get; set; }

        public long level { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string race { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string loyaute { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string bonte { get; set; }

        public long HP { get; set; }

        public long DV { get; set; }

        public long DVType { get; set; }

        public long baseFor { get; set; }

        public long baseDex { get; set; }

        public long baseCon { get; set; }

        public long baseInt { get; set; }

        public long baseSag { get; set; }

        public long baseCha { get; set; }

        public long levelFor { get; set; }

        public long levelDex { get; set; }

        public long levelCon { get; set; }

        public long levelInt { get; set; }

        public long levelSag { get; set; }

        public long levelCha { get; set; }

        public long magicFor { get; set; }

        public long magicDex { get; set; }

        public long magicCon { get; set; }

        public long magicInt { get; set; }

        public long magicSag { get; set; }

        public long magicCha { get; set; }

        public long tempFor { get; set; }

        public long tempDex { get; set; }

        public long tempCon { get; set; }

        public long tempInt { get; set; }

        public long tempSag { get; set; }

        public long tempCha { get; set; }

        public long magieJDSFor { get; set; }

        public long magieJDSDex { get; set; }

        public long magieJDSCon { get; set; }

        public long magieJDSInt { get; set; }

        public long magieJDSSag { get; set; }

        public long magieJDSCha { get; set; }

        public long tempJDSFor { get; set; }

        public long tempJDSDex { get; set; }

        public long tempJDSCon { get; set; }

        public long tempJDSInt { get; set; }

        public long tempJDSSag { get; set; }

        public long tempJDSCha { get; set; }

        public long bonusInit { get; set; }

        public long feet { get; set; }

        public long armure { get; set; }

        public long? intermediaire { get; set; }

        public long? lourde { get; set; }

        public long? bouclier { get; set; }

        public long magieCA { get; set; }

        public long tempCA { get; set; }

        public long magieAcro { get; set; }

        public long magieArca { get; set; }

        public long magieAthl { get; set; }

        public long magieDisc { get; set; }

        public long magieDres { get; set; }

        public long magieEsca { get; set; }

        public long magieHist { get; set; }

        public long magieInti { get; set; }

        public long magieIntu { get; set; }

        public long magieInve { get; set; }

        public long magieMede { get; set; }

        public long magieNatu { get; set; }

        public long magiePerc { get; set; }

        public long magiePers { get; set; }

        public long magieReli { get; set; }

        public long magieRepr { get; set; }

        public long magieSurv { get; set; }

        public long magieTrom { get; set; }

        public long? sortINT { get; set; }

        public long? sortSAG { get; set; }

        public long? sortCHA { get; set; }

        public long magieMelee { get; set; }

        public long magieDistance { get; set; }

        public long magieSort { get; set; }
    }
}
