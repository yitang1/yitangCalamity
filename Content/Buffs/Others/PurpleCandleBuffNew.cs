using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Buffs.Placeables;
using yitangCalamity.Common;
using CalamityMod.Tiles.Furniture;

namespace yitangCalamity.Content.Buffs.Others
{
	internal class PurpleCandleBuffNew : ModBuff
	{
		public static float DefenseRatioBonus = 0.15f;

		public override void SetStaticDefaults()
		{
			Main.pvpBuff[Type] = true;
			Main.persistentBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			Main.buffNoTimeDisplay[Type] = true;
			BuffID.Sets.TimeLeftDoesNotDecrease[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.yitangCalamity().purpleCandle = true;

			if (player.yitangCalamity().purpleCandle)
			{
				/*DefenseEffectiveness.Value是防御的难度系数，【经典是0.5】/【专家是0.75】/【大师是1】，只能通过乘除更改。
				第三个公式意思是在三个难度下，玩家的防御系数相当于是 【0.5+0.15】/【0.75+0.15】/【1+0.15】，
				也就是所谓的物品简介里“增强了玩家15%的防御效果”的意思。*/

				float original = player.DefenseEffectiveness.Value;
				float num = original + DefenseRatioBonus;
				player.DefenseEffectiveness *= num / original;

				player.buffImmune[ModContent.BuffType<CirrusPurpleCandleBuff>()] = true;
			}
		}
	}
}