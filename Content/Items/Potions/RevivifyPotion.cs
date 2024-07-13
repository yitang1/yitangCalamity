using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Materials;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
	public class RevivifyPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.ResearchUnlockCount = 10;
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.useTurn = true;
			Item.maxStack = 9999;
			Item.rare = ItemRarityID.LightRed;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useStyle = 2;
			Item.UseSound = new SoundStyle?(SoundID.Item3);
			Item.consumable = true;
			Item.buffType = ModContent.BuffType<Revivify>();
			Item.buffTime = 18000;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe(5)
				.AddIngredient(ModContent.ItemType<StarblightSoot>(), 20)
				.AddIngredient(ItemID.HolyWater, 5)
				.AddIngredient(ItemID.CrystalShard, 5)
				.AddIngredient(ModContent.ItemType<EssenceofSunlight>(), 3)
				.AddTile(TileID.AlchemyTable)
				.Register();
			CreateRecipe(1)
				.AddIngredient(ItemID.HolyWater, 1)
				.AddIngredient(ModContent.ItemType<BloodOrb>(), 20)
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
	}
}