using System;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace yitangCalamity.Global.Config
{
	public class ytCalamityConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

        public static ytCalamityConfig Instance;

        //[Header("FuckCalamityAll")]
        //[ReloadRequired]
        //[DefaultValue(true)]
        //public bool FuckCalamityAll1;

        //[DefaultValue(true)]
        //public bool FuckCalamityAll2;

        [Header("ytCNPCs")]
        [DefaultValue(true)]
        public bool ytNPCStarMerchant;

        //[DefaultValue(true)]
        //public bool ytNPCeeeeeeeee;

        [DefaultValue(true)]
		[ReloadRequired]
		public bool ytNPCInvincible;

        [DefaultValue(true)]
		[ReloadRequired]
		public bool ytCritterInvincible;

        [Header("ytCRecipes")]
        [ReloadRequired]
        [DefaultValue(false)]
        public bool ytCRecipes;

        //[Header("MobHealth")]
        //[Increment(0.5f)]
        //[Range(1, 10f)]
        //[DefaultValue(0f)]
        //[Slider]
        //public float MobHealth;

        //[Header("WeaponOut")]
        //[DefaultValue(true)]
        //public bool WeaponOut;

        //public List<ItemDefinition> Blacklist = new List<ItemDefinition>();

        //[Range(0, 1000)]
        //[DefaultValue(100)]
        //public int Scale;

        //[Header("Arrow")]
        //[DefaultValue(true)]
        //public bool LifeformAnalyzer;

        //[Range(40, 4000)]
        //[DefaultValue(4000)]
        //public int LocatorRange;

        //public HashSet<NPCDefinition> DisabledLocatorNpcs = new HashSet<NPCDefinition>();
    }
}