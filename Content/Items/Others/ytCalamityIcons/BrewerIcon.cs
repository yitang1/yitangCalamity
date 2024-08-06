using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangCalamity.Content.Items.Others.ytCalamityIcons
{
	internal class BrewerIcon : ModItem
	{
		public override string Texture => "yitangCalamity/NPCs/Brewer_Head";

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.White;
		}
	}
}
