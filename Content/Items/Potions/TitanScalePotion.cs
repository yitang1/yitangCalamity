using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Materials;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
	public class TitanScalePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.ResearchUnlockCount = 10;
        }

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 34;
			Item.useTurn = true;
			Item.maxStack = 9999;
			Item.rare = ItemRarityID.Yellow;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useStyle = 2;
			Item.UseSound = new SoundStyle?(SoundID.Item3);
			Item.consumable = true;
			Item.buffType = ModContent.BuffType<TitanScale>();
			Item.buffTime = 28800;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.TitanPotion)
				.AddIngredient(ItemID.BeetleHusk)
				.AddTile(TileID.AlchemyTable)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient<BloodOrb>(10)
				.AddIngredient(ItemID.BeetleHusk)
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
	}
}