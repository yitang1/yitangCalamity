using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Materials;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
	public class PenumbraPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 10;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 30;
			Item.useTurn = true;
			Item.maxStack = 9999;
			Item.rare = ItemRarityID.Lime;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useStyle = 2;
			Item.UseSound = new SoundStyle?(SoundID.Item3);
			Item.consumable = true;
			Item.buffType = ModContent.BuffType<PenumbraBuff>();
			Item.buffTime = 28800;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient<SolarVeil>(3)
				.AddIngredient(ItemID.LunarTabletFragment)
				.AddTile(TileID.AlchemyTable)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient<BloodOrb>(30)
				.AddIngredient<SolarVeil>()
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
	}
}