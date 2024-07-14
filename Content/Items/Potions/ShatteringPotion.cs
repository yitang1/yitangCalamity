using CalamityMod.Items.Materials;
using CalamityMod.Items.Potions;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
	public class ShatteringPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 10;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 18;
			Item.useTurn = true;
			Item.maxStack = 9999;
			Item.rare = ItemRarityID.Yellow;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useStyle = 2;
			Item.UseSound = new SoundStyle?(SoundID.Item3);
			Item.consumable = true;
			Item.buffType = ModContent.BuffType<ArmorShattering>();
			Item.buffTime = 28800;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<FlaskOfCrumbling>(2)
				.AddIngredient(ItemID.BeetleHusk)
				.AddTile(TileID.AlchemyTable)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient<BloodOrb>(30)
				.AddIngredient(ItemID.BeetleHusk)
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
	}
}