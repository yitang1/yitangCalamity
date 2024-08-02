using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Common;

namespace yitangCalamity.Content.Buffs.Potions
{
    public class AlchemistComb : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			yitangCalamityPlayer ytCalamityPlayer = player.yitangCalamity();

			ytCalamityPlayer.sunshine = true;
            ytCalamityPlayer.fortitude = true;
            ytCalamityPlayer.longInvincible = true;
            ytCalamityPlayer.blurring = true;
            ytCalamityPlayer.ninjaSkill = true;
        }
    }
}