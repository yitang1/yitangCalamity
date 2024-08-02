using System;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod;
using CalamityMod.Cooldowns;
using CalamityMod.Items.Materials;
using CalamityMod.Rarities;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
	public class DraconicElixir : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 10;
		}

		public override void SetDefaults()
		{
			Item.width = 50;
			Item.height = 44;
			Item.useTurn = true;
			Item.maxStack = 9999;
			Item.rare = ModContent.RarityType<Violet>();
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.useStyle = 9;
			Item.UseSound = new SoundStyle?(SoundID.Item3);
			Item.consumable = true;
			Item.buffType = ModContent.BuffType<DraconicSurgeBuff>();
			Item.buffTime = 28800;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}

		public override bool CanUseItem(Player player)
		{
			return !player.HasCooldown(SilvaRevive.ID);
		}

		public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frameI, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			Texture2D texture = ModContent.Request<Texture2D>("yitangCalamity/Content/Items/Potions/DraconicElixir_Animated", (AssetRequestMode)2).Value;
			spriteBatch.Draw(texture, position, new Rectangle?(Item.GetCurrentFrame(ref this.frame, ref this.frameCounter, 8, 10, true)), Color.White, 0f, origin, scale, 0, 0f);
			return false;
		}

		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("yitangCalamity/Content/Items/Potions/DraconicElixir_Animated", (AssetRequestMode)2).Value;
			spriteBatch.Draw(texture, Item.position - Main.screenPosition, new Rectangle?(Item.GetCurrentFrame(ref this.frame, ref this.frameCounter, 8, 10, true)), lightColor, 0f, Vector2.Zero, 1f, 0, 0f);
			return false;
		}

		public override void AddRecipes()
		{
            CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient<YharonSoulFragment>()
				.AddIngredient(ItemID.Daybloom)
				.AddIngredient(ItemID.Moonglow)
				.AddIngredient(ItemID.Fireblossom)
				.AddTile(TileID.AlchemyTable)
				.Register();

            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient<BloodOrb>(50)
                .AddIngredient<YharonSoulFragment>()
                .AddTile(TileID.AlchemyTable)
                .Register();
		}

		public int frameCounter;

		public int frame;
	}
}