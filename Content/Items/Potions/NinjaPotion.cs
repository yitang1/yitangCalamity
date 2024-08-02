using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yitangCalamity.Content.Buffs.Potions;

namespace yitangCalamity.Content.Items.Potions
{
    public class NinjaPotion : ModItem
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
            Item.value = Item.buyPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.buffType = ModContent.BuffType<NinjaSkill>();
            Item.buffTime = 28800;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Deathweed)
                .AddRecipeGroup(nameof(ItemID.Ichor))
                .AddIngredient(ItemID.SoulofNight)
                .AddIngredient(ItemID.ChlorophyteOre)
                .AddIngredient(ItemID.Ectoplasm)
                .AddTile(TileID.AlchemyTable)
                .Register();
        }
    }
}