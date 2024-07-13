using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Buffs.Placeables;
using yitangCalamity.Content.Buffs.Potions;
using yitangCalamity.Global.Config;

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

			if (player.HasBuff<CirrusPurpleCandleBuff>()
				&& (!player.HasBuff<CalamityHardComb>() || !player.HasBuff<CalamityPostComb>())
				&& ytCalamityConfig.Instance.FuckCalamityAll1)
			{
				/*现在这个DefenseEffectiveness应该是已经拥有蜡烛buff后计算过的难度系数，
				player.DefenseEffectiveness的值就是classCandleNum或expertCandleNum或masterCandleNum的值。
				经典是0.5 + 0.1 = 0.6，专家是0.75 + 0.1 = 0.85，大师是1 + 0.1 = 1.1。*/
				if (!Main.expertMode)
				{
					float classCandleNum = 0.6f;
					float targetNum = 0.65f;
					float newNum = targetNum / classCandleNum;
					player.DefenseEffectiveness *= newNum;
				}
				else if (Main.expertMode)
				{
					float expertCandleNum = 0.85f;
					float targetNum = 0.9f;
					float newNum = targetNum / expertCandleNum;
					player.DefenseEffectiveness *= newNum;
				}
				else if (Main.masterMode)
				{
					float masterCandleNum = 1.1f;
					float targetNum = 1.15f;
					float newNum = targetNum / masterCandleNum;
					player.DefenseEffectiveness *= newNum;
				}
				//最后难度系数应该分别变成经典的0.65、专家的0.9、大师的1.15。
			}
        }
	}
}