using System;
using Terraria;
using Terraria.ModLoader;
using CalamityMod.Items.Placeables.Furniture;
using CalamityMod.Buffs.Placeables;
using yitangCalamity.Content.Buffs.Potions;
using yitangCalamity.Global.Config;
using yitangCalamity.Content.Buffs.Others;
using yitangCalamity.Common;
using yitangCalamity.Content.Items.Others;

namespace yitangCalamity.Global.GlobalItems
{
    //一些增益类放置物品可以在物品栏、存钱罐、保险箱、虚空袋、护卫熔炉等常时生效
    public class BuffStationEffect : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }

        public override void UpdateInventory(Item item, Player player)
        {
            BuffStationEffect.GetUnlimitedBuff(item, player);
        }

        public static void GetUnlimitedBuff(Item item, Player player)
        {
            if (item.IsAir || !ytCalamityConfig.Instance.FuckCalamityAll1)
            {
                return;
            }

			if (item.stack >= 1)
			{
				//世界传送装置球
				if (item.type == ModContent.ItemType<GlobalTeleporter>())
				{
					player.yitangCalamity().GlobalTeleporter = true;
				}
				if (item.type == ModContent.ItemType<GlobalTeleporterUp>())
				{
					player.yitangCalamity().GlobalTeleporterUp = true;
				}
			}

			if (item.stack >= 1 && (!player.HasBuff<CalamityHardComb>() || !player.HasBuff<CalamityPostComb>()))
            {
                if (!player.HasBuff<CalamityPerComb>())
                {
                    //血腥雕像↓
                    if (item.type == ModContent.ItemType<CrimsonEffigy>())
                    {
                        player.AddBuff(ModContent.BuffType<CrimsonEffigyBuff>(), 2, true, false);
                        return;
                    }
                    //腐化雕像↓
                    if (item.type == ModContent.ItemType<CorruptionEffigy>())
                    {
                        player.AddBuff(ModContent.BuffType<CorruptionEffigyBuff>(), 2, true, false);
                        return;
                    }
                    //腐朽雕像↓
                    if (item.type == ModContent.ItemType<EffigyOfDecay>())
                    {
                        player.AddBuff(ModContent.BuffType<EffigyOfDecayBuff>(), 2, true, false);
                        return;
                    }
                }
                //失重蜡烛↓
                if (item.type == ModContent.ItemType<WeightlessCandle>())
                {
                    player.AddBuff(ModContent.BuffType<CirrusBlueCandleBuff>(), 2, true, false);
                    return;
                }
                //活力蜡烛↓
                if (item.type == ModContent.ItemType<VigorousCandle>())
                {
                    player.AddBuff(ModContent.BuffType<CirrusPinkCandleBuff>(), 2, true, false);
                    return;
                }
                //恢复蜡烛↓
                if (item.type == ModContent.ItemType<ResilientCandle>())
                {
					if (ytCalamityConfig.Instance.FuckCalamityAll1)
					{
						player.AddBuff(ModContent.BuffType<PurpleCandleBuffNew>(), 2, true, false);
					}
					else if (!ytCalamityConfig.Instance.FuckCalamityAll1)
					{
						player.AddBuff(ModContent.BuffType<CirrusPurpleCandleBuff>(), 2, true, false);
					}
                    return;
                }
                //恶念蜡烛↓
                if (item.type == ModContent.ItemType<SpitefulCandle>())
                {
                    player.AddBuff(ModContent.BuffType<CirrusYellowCandleBuff>(), 2, true, false);
                    return;
                }
            }
        }
    }
}