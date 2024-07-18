using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using CalamityMod.Items;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using CalamityMod.Items.DraedonMisc;
using CalamityMod.Items.Fishing.AstralCatches;
using CalamityMod.Items.Fishing.BrimstoneCragCatches;
using CalamityMod.Items.Fishing.SunkenSeaCatches;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Mounts;
using CalamityMod.Items.Pets;
using CalamityMod.Items.Placeables;
using CalamityMod.Items.Placeables.Furniture;
using CalamityMod.Items.Placeables.Ores;
using CalamityMod.Items.Potions;
using CalamityMod.Items.SummonItems;
using CalamityMod.Items.SummonItems.Invasion;
using CalamityMod.Items.Tools;
using CalamityMod.Items.Tools.ClimateChange;
using CalamityMod.Items.TreasureBags.MiscGrabBags;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Typeless;
using CalamityMod.Items.Weapons.DraedonsArsenal;
using CalamityMod.Tiles.Furniture.CraftingStations;
using yitangCalamity.Content.Items.Materials;

namespace yitangCalamity.Global.Recipes
{
	public class AddCalamityRecipes : ModSystem
	{
		public override void AddRecipes()
		{
			#region 饰品
			//钨钢屏障生成仪
			Recipe.Create(ItemType<RoverDrive>())
				.AddIngredient<WulfrumMetalScrap>(8)
				.AddIngredient<EnergyCore>()
				.AddTile(TileID.Anvils)
				.Register();
			//纯净胶质
			Recipe.Create(ItemType<CleansingJelly>())
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.IronskinPotion)
				.AddIngredient(ItemID.Glowstick, 5)
				.AddTile(TileID.Bottles)
				.Register();
			//活力胶质
			Recipe.Create(ItemType<VitalJelly>())
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.SwiftnessPotion)
				.AddIngredient(ItemID.Glowstick, 5)
				.AddTile(TileID.Bottles)
				.Register();
			//生命胶质 
			Recipe.Create(ItemType<LifeJelly>())
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.RegenerationPotion)
				.AddIngredient(ItemID.Glowstick, 5)
				.AddTile(TileID.Bottles)
				.Register();
			//巨大甲壳
			Recipe.Create(ItemType<GiantShell>())
				.AddIngredient(ItemID.RedHusk)
				.AddIngredient(ItemID.StoneBlock, 5)
				.AddIngredient(ItemID.Gel, 10)
				.AddTile(TileID.Anvils)
				.Register();
			//蟹爪壳
			Recipe.Create(ItemType<CrawCarapace>())
				.AddIngredient(ItemID.Seashell)
				.AddIngredient(ItemID.StoneBlock, 5)
				.AddIngredient(ItemID.Gel, 10)
				.AddTile(TileID.Anvils)
				.Register();
			//阿米迪亚斯电火花石
			Recipe.Create(ItemType<AmidiasSpark>())
				.AddIngredient<StormlionMandible>(2)
				.AddIngredient(ItemID.FossilOre, 5)
				.AddIngredient(ItemID.Amber, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//瘟疫燃料背包
			Recipe.Create(ItemType<PlaguedFuelPack>())
				.AddIngredient(ItemID.SandstorminaBottle)
				.AddIngredient<PlagueCellCanister>(5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//潜遁者宝石
			Recipe.Create(ItemType<ScuttlersJewel>())
				.AddRecipeGroup(nameof(ItemID.Diamond), 3)
				.AddIngredient<AncientBoneDust>(3)
				.AddIngredient(ItemID.StoneBlock, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//墨水炸弹
			Recipe.Create(ItemType<InkBomb>())
				.AddIngredient(ItemID.Bomb, 5)
				.AddIngredient(ItemID.BlackInk, 3)
				.AddIngredient<AbyssGravel>(10)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
			//钨钢电池
			Recipe.Create(ItemType<WulfrumBattery>())
				.AddIngredient<WulfrumMetalScrap>(5)
				.AddIngredient<EnergyCore>()
				.AddTile(TileID.Anvils)
				.Register();
			//伏打凝胶
			Recipe.Create(ItemType<VoltaicJelly>())
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient<PearlShard>(3)
				.AddIngredient<StormlionMandible>()
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
			//核燃料棒
			Recipe.Create(ItemType<NuclearFuelRod>())
				.AddIngredient<CausticTear>()
				.AddIngredient<SulphurskinPotion>()
				.AddIngredient<CorrodedFossil>(5)
				.AddTile(TileID.Anvils)
				.Register();
			//星爆核心
			Recipe.Create(ItemType<StarbusterCore>())
				.AddIngredient<TitanHeart>()
				.AddIngredient<AureusCell>(3)
				.AddIngredient<StarblightSoot>(10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//深渊护身符
			Recipe.Create(ItemType<AbyssalAmulet>())
				.AddIngredient<OceanCrest>()
				.AddIngredient<AbyssGravel>(10)
				.AddTile(TileID.Anvils)
				.Register();
			//渊洋之心
			Recipe.Create(ItemType<AquaticHeart>())
				.AddIngredient<StrangeOrb>()
				.AddIngredient<SeaPrism>(20)
				.AddIngredient(ItemID.Bone, 5)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
			//寒冰屏障
			Recipe.Create(ItemType<FrostBarrier>())
				.AddRecipeGroup(nameof(ItemID.CobaltBar), 5)
				.AddIngredient(ItemID.IceBlock, 10)
				.AddIngredient<EssenceofEleum>(3)
				.AddTile(TileID.Anvils)
				.Register();
			//王冠宝石
			Recipe.Create(ItemType<CrownJewel>())
				.AddIngredient(ItemID.LargeRuby)
				.AddIngredient(ItemID.RoyalGel)
				.AddIngredient<BloodOrb>(10)
				.AddTile(TileID.Solidifier)
				.Register();
			//天蓝石
			Recipe.Create(ItemType<AeroStone>())
				.AddRecipeGroup(nameof(ItemID.PlatinumBar), 3)
				.AddIngredient(ItemID.SoulofFlight, 5)
				.AddIngredient(ItemID.Diamond, 2)
				.AddTile(TileID.Anvils)
				.Register();
			//蜜蜂护符
			Recipe.Create(ItemType<TheBee>())
				.AddIngredient(ItemID.BottledHoney, 5)
				.AddIngredient(ItemID.HoneyBlock, 5)
				.AddIngredient(ItemID.BeeWax, 10)
				.AddTile(TileID.Anvils)
				.Register();
			//再生护符
			Recipe.Create(ItemType<Regenator>())
				.AddIngredient(ItemID.PanicNecklace)
				.AddIngredient(ItemID.CharmofMyths)
				.AddIngredient<AshesofCalamity>(3)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//气功念珠
			Recipe.Create(ItemType<TrinketofChi>())
				.AddRecipeGroup("Wood", 20)
				.AddIngredient<BlightedGel>(10)
				.AddIngredient(ItemID.RedHusk)
				.AddTile(TileID.Anvils)
				.Register();
			//卢克索的礼物
			Recipe.Create(ItemType<LuxorsGift>())
				.AddIngredient(ItemID.DesertFossil, 20)
				.AddIngredient(ItemID.GoldBar, 5)
				.AddIngredient(ItemID.Ruby, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//角斗士金锁
			Recipe.Create(ItemType<GladiatorsLocket>())
				.AddIngredient(ItemID.Marble, 20)
				.AddIngredient(ItemID.GoldBar, 5)
				.AddIngredient(ItemID.Chain, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//不稳定花岗岩核心
			Recipe.Create(ItemType<UnstableGraniteCore>())
				.AddIngredient<AmidiasSpark>()
				.AddIngredient(ItemID.Granite, 20)
				.AddIngredient(ItemID.Diamond, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//真菌共生体
			Recipe.Create(ItemType<FungalSymbiote>())
				.AddIngredient(ItemID.GlowingMushroom, 15)
				.AddIngredient(ItemID.MushroomGrassSeeds, 5)
				.AddIngredient(ItemID.MudBlock, 10)
				.AddTile(TileID.Anvils)
				.Register();
			//铁靴
			Recipe.Create(ItemType<IronBoots>())
				.AddIngredient(ItemID.HermesBoots)
				.AddIngredient(ItemID.IronBar, 3)
				.AddIngredient(ItemID.Bone, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//吸音金属
			Recipe.Create(ItemType<AnechoicPlating>())
				.AddIngredient<DubiousPlating>(5)
				.AddIngredient(ItemID.IronBar, 3)
				.AddIngredient(ItemID.Bone, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//深渊咒符
			Recipe.Create(ItemType<DepthCharm>())
				.AddIngredient<DubiousPlating>(5)
				.AddIngredient<AbyssGravel>(5)
				.AddIngredient(ItemID.Bone, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//归一心元石
			Recipe.Create(ItemType<TheCommunity>())
				.AddIngredient<PearlShard>(5)
				.AddIngredient<SeaPrism>(5)
				.AddIngredient<EssenceofSunlight>(5)
				.AddIngredient<EssenceofEleum>(5)
				.AddIngredient<EssenceofHavoc>(5)
				.AddIngredient<LeviathanAmbergris>()
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//元灵之心
			Recipe.Create(ItemType<HeartoftheElements>())
				.AddIngredient<TheCommunity>()
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//风暴之眼
			Recipe.Create(ItemType<EyeoftheStorm>())
				.AddIngredient(ItemID.Cloud, 20)
				.AddIngredient<EssenceofSunlight>(3)
				.AddIngredient(ItemID.SoulofFlight, 5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//元素瓶
			Recipe.Create(ItemType<WifeinaBottle>())
				.AddIngredient(ItemID.SandstorminaBottle)
				.AddIngredient<EssenceofSunlight>(3)
				.AddIngredient(ItemID.SoulofLight, 5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//稀有元素瓶
			Recipe.Create(ItemType<WifeinaBottlewithBoobs>())
				.AddIngredient(ItemID.SandstorminaBottle)
				.AddIngredient<EssenceofSunlight>(3)
				.AddIngredient(ItemID.SoulofLight, 5)
				.AddIngredient(ItemID.AncientBattleArmorMaterial)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//魅惑珍珠
			Recipe.Create(ItemType<PearlofEnthrallment>())
				.AddIngredient(ItemID.PinkPearl)
				.AddIngredient<LeviathanAmbergris>()
				.AddIngredient(ItemID.Seashell, 5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//玫瑰石
			Recipe.Create(ItemType<RoseStone>())
				.AddIngredient<CharredRelic>()
				.AddIngredient<EssenceofHavoc>(3)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//诱惑鱼饵
			Recipe.Create(ItemType<AlluringBait>())
				.AddIngredient(ItemID.JourneymanBait)
				.AddIngredient<SulphurousSand>(5)
				.AddIngredient<PlantyMush>(5)
				.AddTile(TileID.Anvils)
				.Register();
			//变压器
			Recipe.Create(ItemType<TheTransformer>())
				.AddRecipeGroup(nameof(ItemID.TitaniumBar), 5)
				.AddIngredient(ItemID.Glass, 10)
				.AddIngredient<EssenceofSunlight>(3)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//腐烂犬齿
			Recipe.Create(ItemType<RottenDogtooth>())
				.AddRecipeGroup(nameof(ItemID.Vertebrae), 2)
				.AddIngredient<BloodOrb>(5)
				.AddRecipeGroup("AnyEvilPowder", 5)
				.AddTile(TileID.Anvils)
				.Register();
			//阳炎战旗
			Recipe.Create(ItemType<WarbanneroftheSun>())
				.AddIngredient<ProfanedGuardianPlush>()
				.AddIngredient<CoreofSunlight>(3)
				.AddIngredient(ItemID.Silk, 15)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//极乐之庇护
			Recipe.Create(ItemType<ElysianAegis>())
				.AddIngredient<BlazingCore>()
				.AddIngredient<DivineGeode>(10)
				.AddIngredient<UnholyEssence>(20)
				.AddTile(TileID.LunarCraftingStation)
				.AddCustomShimmerResult(ItemType<ElysianWings>())
				.Register();
			//极乐之翼
			Recipe.Create(ItemType<ElysianWings>())
				.AddIngredient<BlazingCore>()
				.AddIngredient<DivineGeode>(10)
				.AddIngredient<UnholyEssence>(20)
				.AddTile(TileID.LunarCraftingStation)
				.AddCustomShimmerResult(ItemType<ElysianAegis>())
				.Register();
			#endregion

			#region 近战武器
			//余震
			Recipe.Create(ItemType<Aftershock>())
				.AddIngredient(ItemID.BoneSword)
				.AddIngredient<EssenceofSunlight>(3)
				.AddIngredient(ItemID.SoulofLight, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//磐石地元叉
			Recipe.Create(ItemType<EarthenPike>())
				.AddIngredient<RedtideSpear>()
				.AddIngredient<EssenceofSunlight>(3)
				.AddIngredient(ItemID.SoulofLight, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//熔渣马格南
			Recipe.Create(ItemType<SlagMagnum>())
				.AddIngredient<Fungicide>()
				.AddIngredient<EssenceofSunlight>(3)
				.AddIngredient(ItemID.SoulofLight, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//剑锋之誓约
			Recipe.Create(ItemType<BladecrestOathsword>())
				.AddIngredient(ItemID.AshWoodSword)
				.AddIngredient(ItemID.ObsidianBrick, 10)
				.AddIngredient<DemonicBoneAsh>(3)
				.AddTile(TileID.Anvils)
				.Register();
			//旧神阔剑
			Recipe.Create(ItemType<OldLordClaymore>())
				.AddIngredient(ItemID.AshWoodSword)
				.AddIngredient(ItemID.HellstoneBrick, 10)
				.AddIngredient<DemonicBoneAsh>(3)
				.AddTile(TileID.Anvils)
				.Register();
			//星宙阔剑
			Recipe.Create(ItemType<CelestialClaymore>())
				.AddIngredient(ItemID.FieryGreatsword)
				.AddIngredient(ItemID.Frostbrand)
				.AddIngredient<EssenceofSunlight>(3)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//深渊碾碎者
			Recipe.Create(ItemType<DepthCrusher>())
				.AddIngredient(ItemID.Rockfish)
				.AddIngredient(ItemID.Coral, 5)
				.AddIngredient<SulphurousSand>(10)
				.AddTile(TileID.Anvils)
				.Register();
			//灼炎弯刀
			Recipe.Create(ItemType<BurntSienna>())
				.AddIngredient(ItemID.HardenedSand, 10)
				.AddIngredient(ItemID.FossilOre, 5)
				.AddIngredient(ItemID.FallenStar)
				.AddTile(TileID.Anvils)
				.Register();
			//水华弯刀
			Recipe.Create(ItemType<EutrophicScimitar>())
				.AddIngredient(ItemID.DyeTradersScimitar)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddIngredient<SeaPrism>(5)
				.AddTile(TileID.Anvils)
				.Register();
			//虚渊之锋
			Recipe.Create(ItemType<VoidEdge>())
				.AddIngredient<AbyssBlade>()
				.AddIngredient<RuinousSoul>(5)
				.AddIngredient<DepthCells>(10)
				.AddIngredient<Necroplasm>(20)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//风暴军刀
			Recipe.Create(ItemType<StormSaber>())
				.AddIngredient(ItemID.FalconBlade)
				.AddIngredient(ItemID.Cloud, 20)
				.AddIngredient<EssenceofSunlight>(3)
				.AddTile(TileID.Anvils)
				.Register();
			//泪刃
			Recipe.Create(ItemType<TeardropCleaver>())
				.AddRecipeGroup(nameof(ItemID.CrimtaneBar), 5)
				.AddRecipeGroup(nameof(ItemID.CrimsonSeeds), 2)
				.AddIngredient(ItemID.Lens, 2)
				.AddTile(TileID.Anvils)
				.Register();
			//海爵剑
			Recipe.Create(ItemType<BrinyBaron>())
				.AddIngredient<EutrophicScimitar>()
				.AddIngredient<DepthCells>(10)
				.AddIngredient<Lumenyl>(5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//庇护之刃
			Recipe.Create(ItemType<AegisBlade>())
				.AddIngredient<Aftershock>()
				.AddIngredient<ScoriaBar>(5)
				.AddIngredient<CoreofSunlight>(3)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//屠杀
			Recipe.Create(ItemType<Carnage>())
				.AddIngredient<TeardropCleaver>()
				.AddIngredient<BloodOrb>(10)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//寒宙弹刃
			Recipe.Create(ItemType<CosmicDischarge>())
				.AddIngredient<CrescentMoon>()
				.AddIngredient<CosmiliteBar>(5)
				.AddIngredient<EndothermicEnergy>(20)
				.AddTile(TileType<CosmicAnvil>())
				.Register();
			//镜之刃
			Recipe.Create(ItemType<MirrorBlade>())
				.AddIngredient<TheEvolution>()
				.AddIngredient(ItemID.LunarBar, 5)
				.AddIngredient<DarkPlasma>()
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//鬼妖村正
			Recipe.Create(ItemType<Murasama>())
				.AddIngredient<Phaseslayer>()
				.AddIngredient(ItemID.BrokenHeroSword)
				.AddIngredient<CosmiliteBar>(5)
				.AddIngredient<AscendantSpiritEssence>(5)
				.AddTile(TileType<CosmicAnvil>())
				.Register();
			//泰坦之臂
			Recipe.Create(ItemType<TitanArm>())
				.AddIngredient(ItemID.SlapHand)
				.AddIngredient<AureusCell>(5)
				.AddIngredient<StarblightSoot>(10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//星幻镰刀
			Recipe.Create(ItemType<AstralScythe>())
				.AddIngredient<BeastialPickaxe>()
				.AddIngredient<AureusCell>(5)
				.AddIngredient<StarblightSoot>(10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			#endregion

			#region 远程武器
			//劲弩
			Recipe.Create(ItemType<Arbalest>())
				.AddIngredient(ItemID.HallowedRepeater)
				.AddIngredient(ItemID.SoulofSight, 10)
				.AddIngredient(ItemID.Wire, 20)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//海之烧灼
			Recipe.Create(ItemType<SeasSearing>())
				.AddIngredient(ItemID.Megashark)
				.AddIngredient<Archerfish>()
				.AddIngredient<CorrodedFossil>(5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//地狱降临
			Recipe.Create(ItemType<Hellborn>())
				.AddIngredient(ItemID.ClockworkAssaultRifle)
				.AddIngredient<CharredRelic>()
				.AddIngredient<EssenceofHavoc>(5)
				.AddTile(TileID.Hellforge)
				.Register();
			//叶流
			Recipe.Create(ItemType<BlossomFlux>())
				.AddIngredient<MarksmanBow>()
				.AddIngredient<Barinautical>()
				.AddIngredient<LivingShard>(10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//北辰鹦哥鱼
			Recipe.Create(ItemType<PolarisParrotfish>())
				.AddIngredient<AldebaranAlewife>()
				.AddIngredient<StarblightSoot>(10)
				.AddIngredient(ItemID.FallenStar, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//硫火喷吐鱼
			Recipe.Create(ItemType<DragoonDrizzlefish>())
				.AddIngredient<CragBullhead>()
				.AddIngredient<DemonicBoneAsh>(3)
				.AddIngredient(ItemID.LavaBucket)
				.AddTile(TileID.Hellforge)
				.Register();
			//纯元怒焰
			Recipe.Create(ItemType<PristineFury>())
				.AddIngredient<DragoonDrizzlefish>()
				.AddIngredient<DivineGeode>(10)
				.AddIngredient<UnholyEssence>(15)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//诺法雷
			Recipe.Create(ItemType<Norfleet>())
				.AddIngredient<Scorpio>()
				.AddIngredient<CosmiliteBar>(5)
				.AddIngredient<CoreofCalamity>()
				.AddTile(TileType<CosmicAnvil>())
				.Register();
			//新星炮
			Recipe.Create(ItemType<StellarCannon>())
				.AddIngredient<OpalStriker>()
				.AddIngredient<AureusCell>(5)
				.AddIngredient(ItemID.FallenStar, 5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			#endregion

			#region 魔法武器
			//海蟒咒书
			Recipe.Create(ItemType<Serpentine>())
				.AddIngredient(ItemID.SpellTome)
				.AddIngredient<SeaPrism>(5)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddTile(TileID.Bookcases)
				.Register();
			//蜿蜒酸鳗
			Recipe.Create(ItemType<SlitheringEels>())
				.AddIngredient<Serpentine>()
				.AddIngredient<CausticTear>()
				.AddIngredient<CorrodedFossil>(5)
				.AddTile(TileID.Bookcases)
				.Register();
			//维苏威阿斯
			Recipe.Create(ItemType<Vesuvius>())
				.AddIngredient(ItemID.StaffofEarth)
				.AddIngredient(ItemID.MeteorStaff)
				.AddIngredient<ScoriaBar>(5)
				.AddRecipeGroup("CalamityMod:FleshyGeode")
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//亚利姆水晶
			Recipe.Create(ItemType<YharimsCrystal>())
				.AddIngredient<DarkSpark>()
				.AddIngredient<AuricBar>(5)
				.AddIngredient<AscendantSpiritEssence>(4)
				.AddIngredient<CoreofCalamity>()
				.AddTile(TileType<CosmicAnvil>())
				.Register();
			//深渊电击者
			Recipe.Create(ItemType<AbyssShocker>())
				.AddIngredient<AbyssGravel>(20)
				.AddIngredient<StormlionMandible>(5)
				.AddIngredient(ItemID.Bone, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//波塞冬
			Recipe.Create(ItemType<Poseidon>())
				.AddIngredient(ItemID.SpellTome)
				.AddIngredient<MolluskHusk>(5)
				.AddIngredient<SeaPrism>(5)
				.AddTile(TileID.Bookcases)
				.Register();
			//喷嗝萨克斯
			Recipe.Create(ItemType<BelchingSaxophone>())
				.AddIngredient<Acidwood>(20)
				.AddIngredient<CorrodedFossil>(5)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//远古之怒
			Recipe.Create(ItemType<WrathoftheAncients>())
				.AddIngredient(ItemID.SpellTome)
				.AddIngredient<AncientBoneDust>(5)
				.AddIngredient(ItemID.Ectoplasm, 10)
				.AddTile(TileID.Bookcases)
				.Register();
			//侧翼
			Recipe.Create(ItemType<Wingman>())
				.AddIngredient(ItemID.LaserRifle)
				.AddIngredient(ItemID.JimsDrone, 2)
				.AddIngredient(ItemID.MartianConduitPlating, 10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			#endregion

			#region 召唤武器
			//圣耀火花
			Recipe.Create(ItemType<SanctifiedSpark>())
				.AddIngredient<CinderBlossomStaff>()
				.AddIngredient<UnholyEssence>(10)
				.AddIngredient<CoreofSunlight>(3)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//冰川之拥
			Recipe.Create(ItemType<GlacialEmbrace>())
				.AddIngredient<SoulofCryogen>()
				.AddIngredient<PermafrostsConcoction>()
				.AddIngredient<EssenceofEleum>(3)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//千载寒晶
			Recipe.Create(ItemType<AncientIceChunk>())
				.AddIngredient(ItemID.IceBlock, 20)
				.AddIngredient(ItemID.FrostCore)
				.AddIngredient<EssenceofEleum>(3)
				.AddTile(TileID.Anvils)
				.Register();
			//淡忘之史
			Recipe.Create(ItemType<AbandonedSlimeStaff>())
				.AddIngredient(ItemID.SlimeStaff)
				.AddIngredient<AureusCell>(5)
				.AddIngredient<StarblightSoot>(10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//遗境魂灯
			Recipe.Create(ItemType<GuidelightofOblivion>())
				.AddIngredient<SanctifiedSpark>()
				.AddIngredient<DivineGeode>(5)
				.AddIngredient<CoreofHavoc>(3)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//直角石壳
			Recipe.Create(ItemType<OrthoceraShell>())
				.AddIngredient(ItemID.Seashell, 5)
				.AddIngredient(ItemID.DesertFossil, 5)
				.AddIngredient<CorrodedFossil>(5)
				.AddTile(TileID.Anvils)
				.Register();
			//终焉百合
			Recipe.Create(ItemType<LiliesOfFinality>())
				.AddIngredient(ItemID.FlowerofFire)
				.AddIngredient<UnholyCore>(10)
				.AddIngredient<AuricBar>(5)
				.AddTile<CosmicAnvil>()
				.Register();
			//死灵骨髓杖
			Recipe.Create(ItemType<StaffOfNecrosteocytes>())
				.AddIngredient(ItemID.Bone, 20)
				.AddIngredient<AncientBoneDust>(5)
				.AddIngredient<BlightedGel>(10)
				.AddTile(TileID.Anvils)
				.Register();
			#endregion

			#region 盗贼武器
			//弹跳眼球
			Recipe.Create(ItemType<BouncingEyeball>())
				.AddIngredient(ItemID.ThrowingKnife, 5)
				.AddIngredient(ItemID.Lens, 2)
				.AddIngredient<BloodOrb>(10)
				.AddTile(TileID.Anvils)
				.Register();
			//灰烬石钟乳
			Recipe.Create(ItemType<AshenStalactite>())
				.AddRecipeGroup("CalamityMod:GleamingDagger")
				.AddIngredient(ItemID.AshBlock, 10)
				.AddIngredient(ItemID.LavaBucket)
				.AddTile(TileID.Anvils)
				.Register();
			//咒焰匕首
			Recipe.Create(ItemType<CursedDagger>())
				.AddIngredient<CobaltKunai>(100)
				.AddIngredient(ItemID.CursedFlame, 10)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//腐脓标枪
			Recipe.Create(ItemType<IchorSpear>())
				.AddIngredient<PalladiumJavelin>(100)
				.AddIngredient(ItemID.Ichor, 10)
				.AddIngredient(ItemID.SoulofNight, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//致命缺陷
			Recipe.Create(ItemType<DefectiveSphere>())
				.AddIngredient<BlazingStar>()
				.AddIngredient<SolarVeil>(5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//憎恶血刃
			Recipe.Create(ItemType<CorpusAvertor>())
				.AddIngredient<AshenStalactite>()
				.AddRecipeGroup("CalamityMod:FleshyGeode")
				.AddIngredient<CoreofHavoc>(3)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//辐毒废水
			Recipe.Create(ItemType<SpentFuelContainer>())
				.AddIngredient<ConsecratedWater>()
				.AddIngredient<CausticTear>()
				.AddIngredient<CorrodedFossil>(5)
				.AddTile(TileID.Anvils)
				.Register();
			//孔雀翎
			Recipe.Create(ItemType<Malachite>())
				.AddIngredient<FeatherKnife>()
				.AddIngredient<PerennialBar>(10)
				.AddIngredient<InfectedArmorPlating>(5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//渊海哑铃
			Recipe.Create(ItemType<DeepSeaDumbbell>())
				.AddIngredient<Voidstone>(20)
				.AddIngredient<ReaperTooth>(3)
				.AddIngredient<Lumenyl>(20)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//死神遗镰
			Recipe.Create(ItemType<TheOldReaper>())
				.AddIngredient<CelestialReaper>()
				.AddIngredient<MutatedTruffle>()
				.AddIngredient<CorrodedFossil>(10)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//狮源流星
			Recipe.Create(ItemType<LeonidProgenitor>())
				.AddIngredient<Lionfish>()
				.AddIngredient<AureusCell>(5)
				.AddIngredient(ItemID.FallenStar, 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			//堕天星盘
			Recipe.Create(ItemType<HeavenfallenStardisk>())
				.AddIngredient<MangroveChakram>()
				.AddIngredient<AureusCell>(5)
				.AddIngredient(ItemID.FallenStar, 10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			#endregion

			#region 材料
			//血石
			Recipe.Create(ItemType<Bloodstone>(), 50)
				.AddIngredient<DivineGeode>()
				.AddIngredient<UnholyCore>()
				.AddIngredient<BloodOrb>(5)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//可疑的电路板
			Recipe.Create(ItemType<SuspiciousScrap>())
				.AddRecipeGroup(nameof(ItemID.CopperBar), 5)
				.AddIngredient<MysteriousCircuitry>(5)
				.AddTile(TileID.Anvils)
				.Register();
			//等离子驱动核心原型
			Recipe.Create(ItemType<PlasmaDriveCore>())
				.AddRecipeGroup(nameof(ItemID.IronBar), 5)
				.AddIngredient<MysteriousCircuitry>(5)
				.AddTile(TileID.Anvils)
				.Register();
			//植物混融块
			Recipe.Create(ItemType<PlantyMush>(), 5)
				.AddIngredient<AbyssGravel>()
				.AddIngredient(ItemID.MudBlock)
				.AddIngredient(ItemID.JungleGrassSeeds)
				.AddCondition(Condition.NearWater)
				.Register();
			//植物混融块
			Recipe.Create(ItemType<PlantyMush>(), 5)
				.AddIngredient<SulphurousSand>()
				.AddIngredient(ItemID.MudBlock)
				.AddIngredient(ItemID.JungleGrassSeeds)
				.AddCondition(Condition.NearWater)
				.Register();
			#endregion

			#region 消耗品
			//终末石
			Recipe.Create(ItemType<Terminus>())
				.AddIngredient(ItemID.LunarBar, 5)
				.AddIngredient<UelibloomBar>(5)
				.AddIngredient<CosmiliteBar>(5)
				.AddIngredient<AuricBar>(5)
				.AddIngredient<ShadowspecBar>(5)
				.AddTile<DraedonsForge>()
				.Register();
			#endregion

			#region 放置类物品
			//腐化雕像
			Recipe.Create(ItemType<CorruptionEffigy>())
				.AddIngredient(ItemID.DemoniteBar, 5)
				.AddIngredient(ItemID.RottenChunk, 5)
				.AddIngredient(ItemID.EbonstoneBlock, 10)
				.AddTile(TileID.DemonAltar)
				.Register();
			//血腥雕像
			Recipe.Create(ItemType<CrimsonEffigy>())
				.AddIngredient(ItemID.CrimtaneBar, 5)
				.AddIngredient(ItemID.Vertebrae, 5)
				.AddIngredient(ItemID.CrimstoneBlock, 10)
				.AddTile(TileID.DemonAltar)
				.Register();
			#endregion

			#region 工具类物品
			//巨蛇之咬
			Recipe.Create(ItemType<SerpentsBite>())
				.AddIngredient(ItemID.FishHook)
				.AddIngredient<MolluskHusk>()
				.AddIngredient<SeaPrism>(5)
				.AddTile(TileID.Anvils)
				.Register();
			//博比特虫钩
			Recipe.Create(ItemType<BobbitHook>())
				.AddIngredient<SerpentsBite>()
				.AddIngredient<RuinousSoul>()
				.AddIngredient<DepthCells>(5)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//渡魂圣物
			Recipe.Create(ItemType<RelicOfDeliverance>())
				.AddIngredient<ProfanedGuardianPlush>()
				.AddIngredient<CoreofSunlight>(3)
				.AddIngredient<UnholyEssence>(10)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//塑魂圣物
			Recipe.Create(ItemType<RelicOfResilience>())
				.AddIngredient<ProfanedGuardianPlush>()
				.AddIngredient<CoreofSunlight>(3)
				.AddIngredient<UnholyEssence>(10)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			//聚魂圣物
			Recipe.Create(ItemType<RelicOfConvergence>())
				.AddIngredient<ProfanedGuardianPlush>()
				.AddIngredient<CoreofSunlight>(3)
				.AddIngredient<UnholyEssence>(10)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
			#endregion

			#region 坐骑
			//冻原拴绳
			Recipe.Create(ItemType<TundraLeash>())
				.AddIngredient(ItemID.RopeCoil)
				.AddIngredient(ItemID.FlinxFur, 5)
				.AddIngredient(ItemID.Leather, 5)
				.AddTile(TileID.Anvils)
				.Register();
			//玛瑙挖掘机钥匙
			Recipe.Create(ItemType<OnyxExcavatorKey>())
				.AddIngredient<MarniteObliterator>()
				.AddIngredient(ItemID.Obsidian, 10)
				.AddIngredient(ItemID.Amethyst, 5)
				.AddTile(TileID.Anvils)
				.Register();
			#endregion

			#region 其他杂项
			//原型图（沉沦之海）
			Recipe.Create(ItemType<EncryptedSchematicSunkenSea>())
				.AddIngredient<DubiousPlating>(10)
				.AddIngredient<MysteriousCircuitry>(10)
				.AddIngredient(ItemID.Glass, 20)
				.AddIngredient<SeaPrism>()
				.AddTile(TileID.Anvils)
				.Register();
			//加密原型图（小行星）
			Recipe.Create(ItemType<EncryptedSchematicPlanetoid>())
				.AddIngredient<DubiousPlating>(10)
				.AddIngredient<MysteriousCircuitry>(10)
				.AddIngredient(ItemID.Glass, 20)
				.AddIngredient(ItemID.FallenStar)
				.AddTile(TileID.Anvils)
				.Register();
			//加密原型图（丛林）
			Recipe.Create(ItemType<EncryptedSchematicJungle>())
				.AddIngredient<DubiousPlating>(10)
				.AddIngredient<MysteriousCircuitry>(10)
				.AddIngredient(ItemID.Glass, 20)
				.AddIngredient(ItemID.JungleSpores)
				.AddTile(TileID.Anvils)
				.Register();
			//加密原型图（地狱）
			Recipe.Create(ItemType<EncryptedSchematicHell>())
				.AddIngredient<DubiousPlating>(10)
				.AddIngredient<MysteriousCircuitry>(10)
				.AddIngredient(ItemID.Glass, 20)
				.AddIngredient(ItemID.Hellstone)
				.AddTile(TileID.Anvils)
				.Register();
			//加密原型图（冰雪）
			Recipe.Create(ItemType<EncryptedSchematicIce>())
				.AddIngredient<DubiousPlating>(10)
				.AddIngredient<MysteriousCircuitry>(10)
				.AddIngredient(ItemID.Glass, 20)
				.AddIngredient(ItemID.IceBlock)
				.AddTile(TileID.Anvils)
				.Register();
			//奇光球
			Recipe.Create(ItemType<StrangeOrb>())
				.AddIngredient(ItemID.WhitePearl)
				.AddIngredient<AbyssGravel>(5)
				.AddIngredient(ItemID.Bone, 5)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
			#endregion

		}
	}
}