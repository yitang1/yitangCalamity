using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Buffs.Potions;
using CalamityMod.CalPlayer;
using yitangCalamity.Common;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Buffs.Potions
{
    public class CalamityPerComb : ModBuff
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

            calamityPlayer.crimEffigy = true;
            calamityPlayer.corrEffigy = true;
            calamityPlayer.decayEffigy = true;
        }
    }
}