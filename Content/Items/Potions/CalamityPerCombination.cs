using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using CalamityMod.Items.Potions;
using CalamityMod.Items.Placeables.Furniture;
using yitangCalamity.Content.Items.Potions;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
    public class CalamityPerCombination : ModItem
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
            Item.buffType = ModContent.BuffType<CalamityPerComb>();
            Item.buffTime = 36000; //这里是填多少帧，TR60帧是1秒，也就是说这个地方如果填600，游戏里就是600/60=10秒
        }

        public override void AddRecipes()
        {
            CreateRecipe(30)
                .AddIngredient<BoundingPotion>(30)
                .AddIngredient<CalciumPotion>(30)
                .AddIngredient<SulphurskinPotion>(30)
                .AddIngredient<ShadowPotion>(30)
                .AddIngredient<TriumphPotion>(30)
                .AddIngredient<TeslaPotion>(30)
                .AddIngredient<CadencePotion>(30)
                .AddIngredient<YharimsStimulants>(30)

                .AddIngredient<CrimsonEffigy>()
                .AddIngredient<CorruptionEffigy>()
                .AddIngredient<EffigyOfDecay>()
                .AddTile(TileID.AlchemyTable)
                .Register();
        }
    }
}