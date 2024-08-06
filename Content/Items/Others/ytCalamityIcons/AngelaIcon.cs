using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yitangCalamity.Content.Items.Others.ytCalamityIcons
{
	internal class AngelaIcon : ModItem
	{
		public override string Texture => "yitangCalamity/NPCs/Angela_Head";

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.White;
		}
	}
}
