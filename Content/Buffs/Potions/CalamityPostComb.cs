using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Buffs.Placeables;
using CalamityMod.Buffs.Potions;
using CalamityMod.Buffs.Alcohol;
using yitangCalamity.Common;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Buffs.Potions
{
    public class CalamityPostComb : ModBuff
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
			float original = player.DefenseEffectiveness.Value;
			float num = original + DefenseRatioBonus;
			player.DefenseEffectiveness *= num / original;
			//黄色的恶念蜡烛Buff在本Mod里有一个克隆版效果(和灾厄的唯一区别就是玩家身上不会有buff图标)

			ytCalamityPlayer.profanedRage = true;
			//calamityPlayer.ceaselessHunger = true;
			ytCalamityPlayer.draconicSurge = true;

            player.buffImmune[ModContent.BuffType<CirrusPurpleCandleBuff>()] = true;
            player.buffImmune[ModContent.BuffType<CirrusYellowCandleBuff>()] = true;
        }

        public static float DefenseRatioBonus = 0.15f;
    }
}