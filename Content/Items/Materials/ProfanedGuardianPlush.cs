using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangCalamity.Content.Items.Materials
{
	internal class ProfanedGuardianPlush : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 44;
			Item.rare = 11;
			Item.value = Item.buyPrice(0, 1, 70, 0);
			Item.maxStack = 9999;
		}
	}
}