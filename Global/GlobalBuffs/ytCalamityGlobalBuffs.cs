using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Buffs.Placeables;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Global.GlobalBuffs
{
    public class ytCalamityGlobalBuffs : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            //灾厄Mod恶念蜡烛的效果，但只给敌怪赋予恶毒buff，所以玩家身上并不显示恶毒buff的图标
            if (player.HasBuff<CalamityHardComb>() || player.HasBuff<CalamityPostComb>())
            {
                for (int m = 0; m < Main.maxNPCs; m++)
                {
                    NPC npc = Main.npc[m];
                    if (npc is null || !npc.active || npc.friendly)
                        continue;

                    float dist2 = npc.DistanceSQ(player.Center);
                    if (dist2 < 23040000f) // 4800px range
                        Main.npc[m].AddBuff(ModContent.BuffType<CirrusYellowCandleBuff>(), 20, false);
                }
            }
        }
    }
}