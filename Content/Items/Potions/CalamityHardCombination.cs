using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Items.Potions;
using CalamityMod.Items.Potions.Alcohol;
using CalamityMod.Items.Placeables.Furniture;
using yitangCalamity.Content.Items.Potions;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
    public class CalamityHardCombination : ModItem
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
            Item.buffType = ModContent.BuffType<CalamityHardComb>();
            Item.buffTime = 36000; //这里是填多少帧，TR60帧是1秒，也就是说这个地方如果填600，游戏里就是600/60=10秒
        }

        public override void AddRecipes()
        {
            CreateRecipe(30)
                .AddIngredient<CalamityPerCombination>(30)
                .AddIngredient<SoaringPotion>(30)
                .AddIngredient<PhotosynthesisPotion>(30)
                .AddIngredient<FabsolsVodka>(30)
                .AddIngredient<GravityNormalizerPotion>(30)
                .AddIngredient<RevivifyPotion>(30)
                .AddIngredient<TitanScalePotion>(30)

                .AddIngredient<WeightlessCandle>()
                .AddIngredient<VigorousCandle>()
                .AddIngredient<ResilientCandle>()
                .AddIngredient<SpitefulCandle>()
                .AddTile(TileID.AlchemyTable)
                .Register();
        }
    }
}