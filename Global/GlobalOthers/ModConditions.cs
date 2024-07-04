using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace yitangCalamity.Global.GlobalOthers
{
	public class ModConditions : ModSystem
	{
		public override void Unload()
		{
			if (!ModConditions.catalystLoaded)
			{
				ModConditions.catalystMod = null;
			}
		}
		public override void Load()
		{
			if (!ModConditions.catalystLoaded)
			{
				ModConditions.catalystMod = null;
			}
		}

		public override void PostSetupContent()
		{
			ModConditions.catalystLoaded = ModLoader.TryGetMod("CatalystMod", out Mod CatalystMod);
			ModConditions.catalystMod = CatalystMod;
		}

		public override void OnWorldLoad()
		{
			ModConditions.Resetdowned();
		}

		public override void OnWorldUnload()
		{
			ModConditions.Resetdowned();
		}

		public override void SaveWorldData(TagCompound tag)
		{
			tag.Add("downedAstrageldon", ModConditions.downedAstrageldon);
			tag.Add("downedEaterofWorlds", ModConditions.downedEaterofWorlds);
			tag.Add("downedGnome", ModConditions.downedGnome);
		}

		public override void LoadWorldData(TagCompound tag)
		{
			ModConditions.downedAstrageldon = tag.Get<bool>("downedAstrageldon");
			ModConditions.downedEaterofWorlds = tag.Get<bool>("downedEaterofWorlds");
			ModConditions.downedGnome = tag.Get<bool>("downedGnome");
		}

		public static void Resetdowned()
		{
			ModConditions.downedAstrageldon = false;
			ModConditions.downedEaterofWorlds = false;
			ModConditions.downedGnome = false;
		}

		internal static bool catalystLoaded;

		internal static Mod catalystMod;

		internal static bool downedAstrageldon;
        internal static bool downedEaterofWorlds;
        internal static bool downedGnome;

        public static Condition DownedAstrageldon = new Condition("ModConditions.downedAstrageldon", () => ModConditions.downedAstrageldon);
        public static Condition DownedEaterofWorlds = new Condition("ModConditions.downedEaterofWorlds", () => ModConditions.downedEaterofWorlds);
        public static Condition DownedGnome = new Condition("ModConditions.downedGnome", () => ModConditions.downedGnome);
	}

	public class CheckIfNPCIsDead : GlobalNPC
	{
		public override void OnKill(NPC npc)
		{
            if (ModConditions.catalystLoaded
				&& ModConditions.catalystMod.TryFind<ModNPC>("Astrageldon", out ModNPC Astrageldon)
				&& npc.type == Astrageldon.Type)
            {
                ModConditions.downedAstrageldon = true;
            }
            if (npc.type == NPCID.EaterofWorldsHead)
            {
                ModConditions.downedEaterofWorlds = true;
            }
			if (npc.type == NPCID.Gnome)
            {
                ModConditions.downedGnome = true;
            }
        }
	}
}