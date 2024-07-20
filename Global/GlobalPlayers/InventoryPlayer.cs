using System;
using System.Collections.Generic;
using yitangCalamity.Content.Items.Others;
using Terraria;
using Terraria.ModLoader;
using yitangCalamity.Global.GlobalItems;
using yitangCalamity.Global.Config;

namespace yitangCalamity.Global.Players
{
	public class InventoryPlayer : ModPlayer
	{
		//新手礼包
		public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
		{
			return new Item[]
			{
				new Item(ModContent.ItemType<StarterBag>())
			};
		}

		//物品栏增益无限生效
		public override void PostUpdateBuffs()
		{
			if (!ytCalamityConfig.Instance.FuckCalamityAll1)
			{
				return;
			}
            //猪猪存钱罐↓
            Item[] item = Player.bank.item;
            for (int i = 0; i < item.Length; i++)
            {
                BuffStationEffect.GetUnlimitedBuff(item[i], Player);
            }
            //保险箱↓
            item = Player.bank2.item;
            for (int i = 0; i < item.Length; i++)
            {
                BuffStationEffect.GetUnlimitedBuff(item[i], Player);
            }
            //护卫熔炉↓
            item = Player.bank3.item;
            for (int i = 0; i < item.Length; i++)
            {
                BuffStationEffect.GetUnlimitedBuff(item[i], Player);
            }
            //虚空袋↓
            item = Player.bank4.item;
            for (int i = 0; i < item.Length; i++)
            {
                BuffStationEffect.GetUnlimitedBuff(item[i], Player);
            }
        }
    }
}
