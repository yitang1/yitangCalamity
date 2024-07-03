using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables;
using CalamityMod.Tiles.Furniture.CraftingStations;
using yitangCalamity.Global.Config;

namespace yitangCalamity.Global.Recipes
{
    public class AddOtherModsRecipes : ModSystem
    {
        //这个地方的代码，是不进行强制引用的前提下，而做到了添加其他mod的物品配方
        public override void AddRecipes()
        {
			#region 灾劫Mod
			if (ModLoader.HasMod("CatalystMod")) //如果加载了灾劫Mod的话，就会添加配方，没有加载就不会生效
            {
                //旧神星镰的合成配方
                ModLoader.TryGetMod("CatalystMod", out Mod catalyst);
                Recipe.Create(catalyst.Find<ModItem>("ScytheoftheAbandonedGod").Type, 1)
                    .AddIngredient(catalyst.Find<ModItem>("AstralsEnd").Type, 1)
                    .AddIngredient(catalyst.Find<ModItem>("Astragelgun").Type, 1)
                    .AddIngredient(catalyst.Find<ModItem>("ExaltedHorizon").Type, 1)
                    .AddIngredient(catalyst.Find<ModItem>("AstralpodStaff").Type, 1)
                    .AddIngredient(catalyst.Find<ModItem>("InterstellarVolution").Type, 1)
                    .AddIngredient<GalacticaSingularity>(5)
                    .AddTile(TileID.LunarCraftingStation)
                    .Register();

                #region 灾劫Mod 鞭子
                //灾劫Mod 鞭子的合成配方
                //珊瑚粉碎者
                Recipe.Create(catalyst.Find<ModItem>("CoralCrusher").Type, 1)
                    .AddIngredient(ItemID.Coral, 5)
                    .AddIngredient(ItemID.Starfish, 2)
                    .AddIngredient<EutrophicSand>(2)
                    .AddTile(TileID.Anvils)
                    .Register();
                //胶联双鞭
                Recipe.Create(catalyst.Find<ModItem>("CongeledDuoWhip").Type, 1)
                    .AddIngredient<PurifiedGel>(18)
                    .AddIngredient<BlightedGel>(18)
                    .AddTile<StaticRefiner>()
                    .Register();
                //谐鸣振爆索
                Recipe.Create(catalyst.Find<ModItem>("ResonantStriker").Type, 1)
                    .AddIngredient(ItemID.SwordWhip, 1)
                    .AddIngredient<EffulgentFeather>(5)
                    .AddTile(TileID.LunarCraftingStation)
                    .Register();
                //恒怨之刑
                Recipe.Create(catalyst.Find<ModItem>("UnrelentingTorment").Type, 1)
                    .AddIngredient(ItemID.MaceWhip, 1)
                    .AddIngredient<RuinousSoul>(5)
                    .AddIngredient<Necroplasm>(10)
                    .AddTile(TileID.LunarCraftingStation)
                    .Register();
                //宣泄
                Recipe.Create(catalyst.Find<ModItem>("Catharsis").Type, 1)
                    .AddIngredient(ItemID.RainbowWhip, 1)
                    .AddIngredient<AshesofAnnihilation>(5)
                    .AddIngredient<AshesofCalamity>(5)
                    .AddTile<DraedonsForge>()
                    .Register();
				#endregion

			}
			#endregion
		}

        public override void PostAddRecipes()
        {
            //【更多天顶武器Mod】
            if (ModLoader.HasMod("MoreZenith") && yitangCConfig.Instance.ytCRecipes)
            {
                ModLoader.TryGetMod("MoreZenith", out Mod morezenith);
                for (int i = 0; i < Recipe.numRecipes; i++)
                {
                    Recipe recipe = Main.recipe[i];
                    #region 天顶系列武器
                    //移除天顶系列武器合成配方里的圣金源锭
                    if ((recipe.HasResult(morezenith.Find<ModItem>("ZenithBoomerang").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("ZenithBow").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("PartysFate").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("PartyMaster").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("ZenithScythe").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("ZenithShortsword").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("LastSpectrum").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("ZenithWand").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("ZenithYoyo").Type))
						&& recipe.HasIngredient<AuricBar>())
                    {
                        recipe.RemoveIngredient(ModContent.ItemType<AuricBar>());
                    }
                    #endregion

                    #region 泰拉系列武器
                    //移除泰拉系列武器合成配方里的生命碎片
                    if ((recipe.HasResult(morezenith.Find<ModItem>("Terrarang").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("TerraVengeance").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("TerraPersuader").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("TerraFlamethrower").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("TerraScythe").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("TerraShortsword").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("TerraTome").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("TerraScepter").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("TerraYoyo").Type))
						&& recipe.HasIngredient<LivingShard>())
                    {
                        recipe.RemoveIngredient(ModContent.ItemType<LivingShard>());
                    }
                    #endregion

                    #region 永夜系列武器
                    //移除永夜系列武器合成配方里的纯净凝胶
                    if ((recipe.HasResult(morezenith.Find<ModItem>("FlyingDagger").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("NightsRecurve").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("NightsBlaster").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("NightsWrath").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("NightsScythe").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("NightsShortsword").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("NightsVerge").Type)
                        || recipe.HasResult(morezenith.Find<ModItem>("NightsYoyo").Type))
						&& recipe.HasIngredient<PurifiedGel>())
                    {
                        recipe.RemoveIngredient(ModContent.ItemType<PurifiedGel>());
                    }
                    #endregion
                }
            }
        }
    }
}