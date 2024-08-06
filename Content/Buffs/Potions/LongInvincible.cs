using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Common;

namespace yitangCalamity.Content.Buffs.Potions
{
    public class LongInvincible : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.yitangCalamity().longInvincible = true;
        }
    }
}