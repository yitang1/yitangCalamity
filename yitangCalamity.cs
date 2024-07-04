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
	}
}