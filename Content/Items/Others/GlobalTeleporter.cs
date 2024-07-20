using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using yitangCalamity.Common;

namespace yitangCalamity.Content.Items.Others
{
    public class GlobalTeleporter : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 30;
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.LightPurple;
		}
		
		public override void UpdateInventory(Player player)
		{
			player.yitangCalamity().GlobalTeleporter = true;
		}
	}
}