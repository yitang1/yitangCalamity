using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Common;

namespace yitangCalamity.Content.Buffs.Potions
{
    public class YharimPower : ModBuff
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
            player.yitangCalamity().yPower = true;
		}
	}
}