using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using CalamityMod.Items.Potions;
using yitangCalamity.Content.Items.Potions;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
    public class CalamityPostCombination : ModItem
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
            Item.buffType = ModContent.BuffType<CalamityPostComb>();
            Item.buffTime = 36000;
        }

        public override void AddRecipes()
        {
            CreateRecipe(30)
                .AddIngredient<CalamityHardCombination>(30)
                .AddIngredient<ProfanedRagePotion>(30)
                //.AddIngredient<CeaselessHungerPotion>(30)
                .AddIngredient<DraconicElixir>(30)
                .AddTile(TileID.AlchemyTable)
                .Register();
        }
    }
}