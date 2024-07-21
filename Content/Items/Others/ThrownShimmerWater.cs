using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Content.Projectiles.Others;

namespace yitangCalamity.Content.Items.Others
{
    public class ThrownShimmerWater : ModItem
    {
		public const int Number = 1;

		public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 20;
            Item.consumable = true;
            Item.damage = Number;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.useStyle = 1;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<ShimmerWater>();
            Item.shootSpeed = 9f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(10)
                .AddIngredient(ItemID.BottledWater, 1)
                .AddIngredient(ItemID.Daybloom, 1)
                .AddIngredient(ItemID.Moonglow, 1)
                .AddIngredient(ItemID.Blinkroot, 1)
                .AddCondition(Condition.NearShimmer)
                .Register();
        }
    }
}