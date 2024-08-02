using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Materials;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
	public class ProfanedRagePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 10;
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 42;
			Item.useTurn = true;
			Item.maxStack = 9999;
			Item.rare = ItemRarityID.Purple;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useStyle = 2;
			Item.UseSound = new SoundStyle?(SoundID.Item3);
			Item.consumable = true;
			Item.buffType = ModContent.BuffType<ProfanedRageBuff>();
			Item.buffTime = 18000;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.RagePotion)
				.AddIngredient<UnholyEssence>()
				.AddIngredient<GalacticaSingularity>()
				.AddTile(TileID.AlchemyTable)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient<BloodOrb>(40)
				.AddIngredient<UnholyEssence>()
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
	}
}