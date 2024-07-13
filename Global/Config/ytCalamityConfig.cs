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

		[Header("FuckCalamityAll")]
		[ReloadRequired]
		[DefaultValue(true)]
		public bool FuckCalamityAll1 { get; set; }

		[DefaultValue(true)]
		[ReloadRequired]
		public bool FuckCalamityAll2 => FuckCalamityAll1;

		[Header("ytCNPCs")]
        [DefaultValue(true)]
        public bool ytNPCStarMerchant { get; set; }

		[DefaultValue(true)]
        public bool ytNPCBuilder { get; set; }

		[DefaultValue(true)]
        public bool ytNPCBrewer { get; set; }

		[DefaultValue(true)]
        public bool ytNPCAngela { get; set; }

		[DefaultValue(true)]
        public bool ytNPCMiner { get; set; }

		[DefaultValue(true)]
        public bool ytNPCHarpy { get; set; }

		[DefaultValue(true)]
        public bool ytNPCTinkerer { get; set; }

		[DefaultValue(true)]
        public bool ytNPCAngler { get; set; }

		[DefaultValue(true)]
		[ReloadRequired]
		public bool ytNPCInvincible { get; set; }

		[DefaultValue(true)]
		[ReloadRequired]
		public bool ytCritterInvincible { get; set; }

		[Header("ytCRecipes")]
        [ReloadRequired]
        [DefaultValue(false)]
        public bool ytCRecipes { get; set; }

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