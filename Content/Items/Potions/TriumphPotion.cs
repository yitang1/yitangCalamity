using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Items.Materials;
using yitangCalamity.Content;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
	public class TriumphPotion : ModItem
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
			Item.rare = ItemRarityID.Green;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useStyle = 2;
			Item.UseSound = new SoundStyle?(SoundID.Item3);
			Item.consumable = true;
			Item.buffType = ModContent.BuffType<TriumphBuff>();
			Item.buffTime = 14400;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ModContent.ItemType<PearlShard>(), 3)
				.AddTile(TileID.Bottles)
				.Register();
			CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ModContent.ItemType<BloodOrb>(), 30)
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
	}
}