using System;
using CalamityMod.Items.Materials;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Content;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
	public class CadencePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
            Item.ResearchUnlockCount = 10;
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 38;
			Item.useTurn = true;
			Item.maxStack = 9999;
			Item.rare = ItemRarityID.LightRed;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useStyle = 2;
			Item.UseSound = new SoundStyle?(SoundID.Item3);
			Item.consumable = true;
			Item.buffType = ModContent.BuffType<Cadence>();
			Item.buffTime = 21600;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.LovePotion)
				.AddIngredient(ItemID.RegenerationPotion)
				.AddIngredient(ItemID.HeartreachPotion)
				.AddIngredient(ItemID.LifeforcePotion)
				.AddTile(TileID.AlchemyTable)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient<BloodOrb>(40)
                .AddTile(TileID.AlchemyTable)
                .Register();
		}
	}
}