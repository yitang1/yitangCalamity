using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Global.Config;

namespace yitangCalamity.NPCs.Angler
{
	public class ModifyShops : GlobalNPC
	{
		public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
		{
			if (npc.type != NPCID.Angler || !ytCalamityConfig.Instance.ytNPCAngler
				|| !yitangCalamity.ShouldEnableAnglerShop())
			{
				return;
			}
			if (shopName == yitangCalamity.ShopName)
			{
				AnglerShopSystem.GetAnglerShop().FillShop(items, npc, out _);
			}
			else if (shopName == yitangCalamity.VanityShopName)
			{
				AnglerShopSystem.GetAnglerVanityShop().FillShop(items, npc, out _);
			}
		}
	}
}