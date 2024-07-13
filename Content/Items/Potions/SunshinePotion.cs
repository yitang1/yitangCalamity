using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
    public class SunshinePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;
        }

        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;
            Item.useStyle = 2;
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.buffType = ModContent.BuffType<Sunshine>();
            Item.buffTime = 18000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Daybloom)
                .AddIngredient(ItemID.Blinkroot)
                .AddIngredient(ItemID.Fireblossom)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}