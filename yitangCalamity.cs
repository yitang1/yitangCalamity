using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace yitangCalamity
{
	public class yitangCalamity : Mod
	{
		public static Item CustomPrice(int type, int price)
		{
			var item = new Item();
			item.SetDefaults(type);
			item.shopCustomPrice = price;
			return item;
		}

		public const string ShopName = "Terraria/Angler/Shop";

		public const string VanityShopName = "Terraria/Angler/Decor";

		public static bool ShouldEnableAnglerShop()
		{
			return !ModLoader.HasMod("NoFishingQuests") && !ModLoader.HasMod("AnglerShopsAlternative");
		}
	}
}