using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using yitangCalamity.CN.CalamityCN.Utils;

namespace yitangCalamity.Global.GlobalItems.FuckCalamity.FuckCalamityGlobalAccessory
{
    public class VanillaGlobalItem : GlobalItem
	{
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            //仆从召唤杖的工具提示中添加仆从栏位数量的占用情况
            if (item.DamageType == DamageClass.Summon && !item.sentry)
            {
                string keyM = Language.GetTextValue("Mods.yitangCalamity.Commons.Tips.SummonMinionSlot");
                if (Main.LocalPlayer.slotsMinions >= Main.LocalPlayer.maxMinions)
                {
                    keyM = Language.GetTextValue("Mods.yitangCalamity.Commons.Tips.SummonMinionSlotFull");
                }
                string textM = Language.GetTextValueWith(keyM, new
                {
                    CurrentM = Math.Round(Main.LocalPlayer.slotsMinions, 0),
                    TotalM = Main.LocalPlayer.maxMinions
                });
                TooltipLine lineM = new(Mod, Mod.Name, textM);
                tooltips.Add(lineM);
            }

            //哨兵召唤杖的工具提示中添加哨兵栏位数量的占用情况
            if (item.DamageType == DamageClass.Summon && item.sentry)
            {
                string keyS = Language.GetTextValue("Mods.yitangCalamity.Commons.Tips.SummonSentrieSlot");
                if (getNumSentries() >= Main.LocalPlayer.maxTurrets)
                {
                    keyS = Language.GetTextValue("Mods.yitangCalamity.Commons.Tips.SummonSentrieSlotFull");
                }
                string textS = Language.GetTextValueWith(keyS, new
                {
                    CurrentS = getNumSentries(),
                    TotalS = Main.LocalPlayer.maxTurrets
                });
                TooltipLine lineS = new(Mod, Mod.Name, textS);
                tooltips.Add(lineS);
            }
            //混沌传送杖
            //if (item.type == ItemID.RodofDiscord)
            //{
            //    tooltips.ReplaceText("导致混沌状态", "导致混沌状态\n混沌状态导致失去的生命值减半");
            //}
        }

        private int getNumSentries()
        {
            int count = 0;

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile p = Main.projectile[i];
                Player player = Main.player[p.owner];

                if (p.active && p.owner == player.whoAmI && p.sentry)
                {
                    count++;
                }
            }
            return count;
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			//十字章护身符和十字章护盾因为配方里新加了暖手宝，所以免疫冷冻和冰冻
			if (item.type == ItemID.AnkhCharm)
			{
                player.buffImmune[BuffID.Chilled] = true;
                player.buffImmune[BuffID.Frozen] = true;
            }
			if (item.type == ItemID.AnkhShield)
			{
                player.buffImmune[BuffID.Chilled] = true;
                player.buffImmune[BuffID.Frozen] = true;
                player.buffImmune[BuffID.WindPushed] = true; //添加灾厄免疫强风的设定
            }
		}
    }
}