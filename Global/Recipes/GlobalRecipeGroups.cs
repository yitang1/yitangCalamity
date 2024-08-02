using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamityMod.Items.TreasureBags.MiscGrabBags;
using CalamityMod.Items.Weapons.Rogue;

namespace yitangCalamity.Global.Recipes
{
    public class GlobalRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
        {
            #region 注意事项
            /*原版Terraria默认就有的配方组：(没有的就需要自己创建)
            "Wood", "IronBar", "PresurePlate", "Sand", "Fragment",
            "Birds", "Scorpions", "Squirrels", "Bugs", "Ducks", "Butterflies",
            "Fireflies", "Snails", "Dragonflies", "Turtles", and "Fruit". 
            直接调用示例：.AddRecipeGroup("Butterflies", 1)
            (ps：使用了配方组后在RecipeBrowser模组里只显示一个物品
            而如果不用配方组而是创建两份相同的物品配方，区别仅在于等价的配方材料不同，
            这样的话在模组查询配方的界面里会显示2个物品。)*/

            //【注0】在同一个程序库里，配方组可以直接调用，不需要using引用。
            //【注1】配方里显示的贴图是配方组里排名第一个物品的贴图。
            /*【注2】配方里物品排列的顺序优先级：
            1.与目标合成物品同一系列和主题的靠前
            2.稀有和珍贵程度高的靠前
            3.需求数量少的按顺序靠后*/
            /*【注3】
            如果一个物品的合成配方项目的种类比较少，那么其合成材料数量需求就比较多；
            (例如1个武器需要1个下级武器 + A材料x10 合成)

			如果合成配方的项目比较多，那材料的需求数量就应当减少。
            (例如1个武器需要A材料x2 + B材料x2 + C材料x1 + D材料x1 合成)*/

            /*【注4】当一个饰品，可以在肉前大前期不需要打任何Boss和事件就能获得时，制作站通常是铁砧而不是工匠作坊，
			也就是说，即使是在大前期，铁砧和工匠作坊制作的物品也具有“时期前后”、“稀有和贵重程度”的区别。*/

            #endregion

            #region 各类材料
            RecipeGroup GemsGroups = new RecipeGroup(() => "任意宝石", ItemID.Diamond, ItemID.Amethyst, ItemID.Topaz, ItemID.Sapphire, ItemID.Emerald, ItemID.Ruby, ItemID.Amber);
            RecipeGroup.RegisterGroup(nameof(ItemID.Diamond), GemsGroups);

            RecipeGroup IronOreGroups = new RecipeGroup(() => "铁矿或铅矿", ItemID.IronOre, ItemID.LeadOre);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronOre), IronOreGroups);

            RecipeGroup TitaniumOreGroups = new RecipeGroup(() => "钛金矿或精金矿", ItemID.TitaniumOre, ItemID.AdamantiteOre);
            RecipeGroup.RegisterGroup(nameof(ItemID.TitaniumOre), TitaniumOreGroups);

            RecipeGroup CopperBarGroups = new RecipeGroup(() => "铜锭或锡锭", ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), CopperBarGroups);

            RecipeGroup IronBarGroups = new RecipeGroup(() => "铁锭或铅锭", ItemID.IronBar, ItemID.LeadBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.IronBar), IronBarGroups);

            RecipeGroup SilverBarGroups = new RecipeGroup(() => "银锭或钨锭", ItemID.SilverBar, ItemID.TungstenBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverBar), SilverBarGroups);

            RecipeGroup PlatinumBarGroups = new RecipeGroup(() => "铂金锭或金锭", ItemID.PlatinumBar, ItemID.GoldBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.PlatinumBar), PlatinumBarGroups);

            RecipeGroup CrimtaneBarGroups = new RecipeGroup(() => "任意邪恶锭", ItemID.CrimtaneBar, ItemID.DemoniteBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.CrimtaneBar), CrimtaneBarGroups);

            RecipeGroup CobaltBarGroups = new RecipeGroup(() => "钴锭或钯金锭", ItemID.CobaltBar, ItemID.PalladiumBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.CobaltBar), CobaltBarGroups);

            RecipeGroup TitaniumBarGroups = new RecipeGroup(() => "钛金锭或精金锭", ItemID.TitaniumBar, ItemID.AdamantiteBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.TitaniumBar), TitaniumBarGroups);

            RecipeGroup CrimsonSeedsGroups = new RecipeGroup(() => "任意邪恶种子", ItemID.CrimsonSeeds, ItemID.CorruptSeeds);
            RecipeGroup.RegisterGroup(nameof(ItemID.CrimsonSeeds), CrimsonSeedsGroups);

            RecipeGroup EvilBossMaterials = new RecipeGroup(() => "任意邪恶Boss材料", ItemID.TissueSample, ItemID.ShadowScale);
            RecipeGroup.RegisterGroup(nameof(ItemID.TissueSample), EvilBossMaterials);

            RecipeGroup PerEvilMaterials = new RecipeGroup(() => "任意邪恶材料", ItemID.Vertebrae, ItemID.RottenChunk);
            RecipeGroup.RegisterGroup(nameof(ItemID.Vertebrae), PerEvilMaterials);

            RecipeGroup HardEvilMaterials = new RecipeGroup(() => "任意困难模式邪恶材料", ItemID.Ichor, ItemID.CursedFlame);
            RecipeGroup.RegisterGroup(nameof(ItemID.Ichor), HardEvilMaterials);


            #endregion

            #region 武器、盔甲、配饰
            RecipeGroup GleamingDaggerGroups = new RecipeGroup(() => "镀金匕首或闪亮匕首", ModContent.ItemType<GleamingDagger>(), ModContent.ItemType<GildedDagger>());
            RecipeGroup.RegisterGroup("CalamityMod:GleamingDagger", GleamingDaggerGroups);

            RecipeGroup Hallowed1Groups = new RecipeGroup(() => "神圣头盔或面具", ItemID.HallowedHelmet, ItemID.HallowedMask);
            RecipeGroup.RegisterGroup(nameof(ItemID.HallowedHelmet), Hallowed1Groups);

            RecipeGroup Hallowed2Groups = new RecipeGroup(() => "神圣兜帽或头饰", ItemID.HallowedHood, ItemID.HallowedHeadgear);
            RecipeGroup.RegisterGroup(nameof(ItemID.HallowedHood), Hallowed2Groups);

            RecipeGroup EmblemGroups = new RecipeGroup(() => "任意职业徽章", ItemID.SummonerEmblem, ItemID.SorcererEmblem, ItemID.RangerEmblem, ItemID.WarriorEmblem);
            RecipeGroup.RegisterGroup(nameof(ItemID.SummonerEmblem), EmblemGroups);

            #endregion

            #region 其他
            RecipeGroup GeodeGroups = new RecipeGroup(() => "血肉晶簇或死灵晶簇", ModContent.ItemType<FleshyGeode>(), ModContent.ItemType<NecromanticGeode>());
            RecipeGroup.RegisterGroup("CalamityMod:FleshyGeode", GeodeGroups);

            RecipeGroup PlatinumWatchGroups = new RecipeGroup(() => "铂金表或金表", ItemID.PlatinumWatch, ItemID.GoldWatch);
            RecipeGroup.RegisterGroup(nameof(ItemID.PlatinumWatch), PlatinumWatchGroups);

            #endregion

        }
    }
}