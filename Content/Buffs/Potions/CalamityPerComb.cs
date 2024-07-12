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
            yitangCalamityPlayer ytCNPlayer = player.yitangCalamity();

            calamityPlayer.bounding = true;
            calamityPlayer.calcium = true;
            calamityPlayer.sulphurskin = true;
            ytCNPlayer.triumph = true;
            ytCNPlayer.yPower = true;
            ytCNPlayer.cadence = true;

            calamityPlayer.crimEffigy = true;
            calamityPlayer.corrEffigy = true;
            calamityPlayer.decayEffigy = true;
        }
    }
}