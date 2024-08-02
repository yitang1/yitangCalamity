using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
    public class AlchemistCombination : ModItem
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
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.buyPrice(0, 6, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.buffType = ModContent.BuffType<AlchemistComb>();
            Item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<SunshinePotion>()
                .AddIngredient<FortitudePotion>()
                .AddIngredient<InvincibilityPotion>()
                .AddIngredient<BlurringPotion>()
                .AddIngredient<NinjaPotion>()
                .AddTile(TileID.AlchemyTable)
                .Register();
        }
    }
}