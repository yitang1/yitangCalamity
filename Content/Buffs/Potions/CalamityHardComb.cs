using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Buffs.Potions;
using CalamityMod.Buffs.Alcohol;
using CalamityMod.CalPlayer;
using CalamityMod.Buffs.Placeables;
using yitangCalamity.Common;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Buffs.Potions
{
    public class CalamityHardComb : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            BuffID.Sets.LongerExpertDebuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            CalamityPlayer calamityPlayer = player.Calamity();
            yitangCalamityPlayer ytCalamityPlayer = player.yitangCalamity();

			calamityPlayer.bounding = true;
			calamityPlayer.calcium = true;
			calamityPlayer.sulphurskin = true;
			calamityPlayer.shadow = true;
			ytCalamityPlayer.triumph = true;
			ytCalamityPlayer.teslaPotion = true;
			ytCalamityPlayer.cadence = true;
			ytCalamityPlayer.yPower = true;

			calamityPlayer.soaring = true;
            calamityPlayer.photosynthesis = true;
            calamityPlayer.fabsolVodka = true;
            calamityPlayer.gravityNormalizer = true;
            ytCalamityPlayer.revivify = true;
            ytCalamityPlayer.penumbra = true;
            ytCalamityPlayer.armorShattering = true;
            ytCalamityPlayer.tScale = true;

            calamityPlayer.crimEffigy = true;
            calamityPlayer.corrEffigy = true;
            calamityPlayer.decayEffigy = true;

            //蓝色的失重蜡烛
            player.moveSpeed += 0.1f;
            calamityPlayer.blueCandle = true;
			//粉色的活力蜡烛
            calamityPlayer.pinkCandle = true;
			//紫色的恢复蜡烛
			/*DefenseEffectiveness.Value是防御的难度系数，【经典是0.5】/【专家是0.75】/【大师是1】，无法直接更改。
             第三个公式意思是在三个难度下，玩家的防御系数相当于是 【0.5+0.15】/【0.75+0.15】/【1+0.15】，
             也就是所谓的物品简介里“增强了玩家15%的防御效果”的意思。*/
			float original = player.DefenseEffectiveness.Value;
            float num = original + DefenseRatioBonus;
            player.DefenseEffectiveness *= num / original;
            //黄色的恶念蜡烛Buff在本Mod里有一个克隆版效果(和灾厄的唯一区别就是玩家身上不会有buff图标)

            player.buffImmune[ModContent.BuffType<CirrusPurpleCandleBuff>()] = true;
            player.buffImmune[ModContent.BuffType<CirrusYellowCandleBuff>()] = true;
        }

        public static float DefenseRatioBonus = 0.15f;
    }
}