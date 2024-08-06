using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.Item;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Events;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;
using CalamityMod;
using CalamityMod.Items.Placeables.DraedonStructures;
using CalamityMod.Items.Placeables.Furniture;
using CalamityMod.Items.Placeables.FurnitureAshen;
using CalamityMod.Items.Placeables.FurnitureVoid;
using CalamityMod.Items.Placeables.FurnitureAbyss;
using CalamityMod.Items.Placeables.FurnitureBotanic;
using CalamityMod.Items.Placeables.FurnitureCosmilite;
using CalamityMod.Items.Placeables.FurnitureEutrophic;
using CalamityMod.Items.Placeables.FurnitureMonolith;
using CalamityMod.Items.Placeables.FurniturePlagued;
using CalamityMod.Items.Placeables.FurnitureProfaned;
using CalamityMod.Items.Placeables.FurnitureStratus;
using CalamityMod.Items.Placeables.FurnitureOtherworldly;
using CalamityMod.Items.Placeables.FurnitureSilva;
using CalamityMod.Items.Placeables.FurnitureStatigel;
using CalamityMod.Items.Placeables.FurnitureExo;
using CalamityMod.Items.Placeables.FurnitureAcidwood;
using CalamityMod.Items.Placeables.FurnitureSacrilegious;
using CalamityMod.Items.Placeables;
using CalamityMod.Items.Accessories;
using static yitangCalamity.yitangCalamity;
using yitangCalamity.Global.Config;

namespace yitangCalamity.NPCs
{
	[AutoloadHead]
    internal class Builder : ModNPC
    {
        public override void SetStaticDefaults()
		{
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;
            NPCID.Sets.AttackType[NPC.type] = 3;
            NPCID.Sets.AttackTime[NPC.type] = 35;
            NPCID.Sets.AttackAverageChance[NPC.type] = 50;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = -1f,
                Direction = -1
            };
            NPC.Happiness
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Like)
                .SetBiomeAffection<JungleBiome>(AffectionLevel.Love)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Painter, AffectionLevel.Love)
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Like);
        }

		public override void SetDefaults()
		{
			NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 100;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.Add(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface);
			bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("建筑师提供并出售各种不同的建筑物块和家具，同时他也是一名装修专家。"));
		}

		public override bool CanTownNPCSpawn(int numTownNPCs)
		{
			return numTownNPCs > 3 && ytCalamityConfig.Instance.ytNPCBuilder;
		}

		public override string GetChat()
		{
            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        return "我喜欢我们的门后有一大堆僵尸，但我讨厌他们打破我的门！";
                    case 1:
                        return "杀掉那个僵尸！杀掉那个兔子！以血的名义起誓——！哦，抱歉，我没注意到你在这里。";
                    case 2:
                        return "啊哈，这种不安全的感觉，没错没错，偏执狂会极度热爱这种，当血月在天空升起的那一刻。";
                    case 3:
                        return "你对我的信仰感兴趣吗？它涉及向血月奉献和牺牲。";
                }
            }
            if (Main.invasionType == 1)
            {
                return "你知道我为什么讨厌这些哥布林吗？他们真的太吵了。";
            }
            if (Main.invasionType == 3)
            {
                return "海盗万岁！他们给我提供了金家具！";
            }
            if (Main.invasionType == 4)
            {
                return "啊哈！最后再适当的加一些金属镀层来完成我的屋顶！";
            }
            var dialog = new Terraria.Utilities.WeightedRandom<string>();
            dialog.Add("你知道木头怎么才不会烧起来吗？在某些情况下，经过一系列操作确实能做到。真的奇怪……");
            dialog.Add("不，我不是家伙(guy)，我是老兄(dude)。");
            dialog.Add("嗯，你最近做的那件事几乎能给人留下深刻的印象。(不存在的)");
            dialog.Add("我看了你的建筑，但是我仍然觉得不怎么样。");
            dialog.Add("我曾经受雇于某家公司，建造一个超大规模的高科技高安全性装置。让我来给你讲讲我在安全和抵御入侵方面的杰作。");
            return dialog.Get();
        }

		public override List<string> SetNPCNameList()
		{
            return new List<string> { "Joe", "Mark", "Walter", "Li" };
		}

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "天然物块";
            button2 = "建筑物块";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = "NaturalBlocks";
            }
            else
            {
                shopName = "BuildingBlocks";
            }
        }

        public override void AddShops()
        {
            var naturalBlocks = new NPCShop(Type, "NaturalBlocks");
            var buildingBlocks = new NPCShop(Type, "BuildingBlocks");

            #region 灾厄Mod的Boss击败条件
            Condition DownedDesertScourge = new Condition("DesertScourge", () => DownedBossSystem.downedDesertScourge);
            Condition DownedCrabulon = new Condition("Crabulon", () => DownedBossSystem.downedCrabulon);
            Condition DownedPerfs = new Condition("Perfs", () => DownedBossSystem.downedPerforator);
            Condition DownedHiveMind = new Condition("HiveMind", () => DownedBossSystem.downedHiveMind);
            Condition DownedSlimeGod = new Condition("SlimeGod", () => DownedBossSystem.downedSlimeGod);

            Condition DownedCryogen = new Condition("Cryogen", () => DownedBossSystem.downedCryogen);
            Condition DownedAquaticScourge = new Condition("AquaticScourge", () => DownedBossSystem.downedAquaticScourge);
            Condition DownedBrimstoneElemental = new Condition("BrimstoneElemental", () => DownedBossSystem.downedBrimstoneElemental);
            Condition DownedCloneCalamitas = new Condition("CalClone", () => DownedBossSystem.downedCalamitasClone);
            Condition DownedLeviathan = new Condition("Leviathan", () => DownedBossSystem.downedLeviathan);
            Condition DownedAureus = new Condition("Aureus", () => DownedBossSystem.downedAstrumAureus);
            Condition DownedPlague = new Condition("Plague", () => DownedBossSystem.downedPlaguebringer);
            Condition DownedRavager = new Condition("Ravager", () => DownedBossSystem.downedRavager);
            Condition DownedDeus = new Condition("Deus", () => DownedBossSystem.downedAstrumDeus);

            Condition DownedDragonfolly = new Condition("Dragonfolly", () => DownedBossSystem.downedDragonfolly);
            Condition DownedProvidence = new Condition("Providence", () => DownedBossSystem.downedProvidence);
            Condition DownedPolterghast = new Condition("Polterghast", () => DownedBossSystem.downedPolterghast);
            Condition DownedOldDuke = new Condition("OldDuke", () => DownedBossSystem.downedBoomerDuke);
            Condition DownedStormWeaver = new Condition("StormWeaver", () => DownedBossSystem.downedStormWeaver);
            Condition DownedCeaselessVoid = new Condition("CeaselessVoid", () => DownedBossSystem.downedCeaselessVoid);
            Condition DownedSignus = new Condition("Signus", () => DownedBossSystem.downedSignus);
            Condition DownedTheThree = new Condition("Three", () => DownedBossSystem.downedStormWeaver && DownedBossSystem.downedCeaselessVoid && DownedBossSystem.downedSignus);
            Condition DownedDevourerOfGods = new Condition("DoG", () => DownedBossSystem.downedDoG);
            Condition DownedYharon = new Condition("Yharon", () => DownedBossSystem.downedYharon);
            Condition DownedExoMechs = new Condition("ExoMechs", () => DownedBossSystem.downedExoMechs);
            Condition DownedSuperCalamitas = new Condition("SCal", () => DownedBossSystem.downedCalamitas);
            #endregion

            #region 天然物块
            //土块和石块
            naturalBlocks.Add(CustomPrice(ItemID.DirtBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.StoneBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CrimstoneBlock, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.EbonstoneBlock, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PearlstoneBlock, buyPrice(0, 0, 0, 5)), new Condition[] { Condition.Hardmode })
                //沙块
                .Add(CustomPrice(ItemID.SandBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CrimsandBlock, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.EbonsandBlock, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PearlsandBlock, buyPrice(0, 0, 0, 5)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.DesertFossil, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HardenedSand, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CrimsonHardenedSand, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CorruptHardenedSand, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HallowHardenedSand, buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                //泥块
                .Add(CustomPrice(ItemID.ClayBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.MudBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SlushBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SiltBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                //雪块
                .Add(CustomPrice(ItemID.SnowBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.IceBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.RedIceBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PurpleIceBlock, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PinkIceBlock, buyPrice(0, 0, 0, 5)), new Condition[] { Condition.Hardmode })
                //灰烬块
                .Add(CustomPrice(ItemID.AshBlock, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                //花岗岩和大理石
                .Add(CustomPrice(ItemID.Granite, buyPrice(0, 0, 0, 20)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Marble, buyPrice(0, 0, 0, 20)), Array.Empty<Condition>())
                //栽培类
                .Add(CustomPrice(ItemID.Hay, buyPrice(0, 0, 0, 1)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Cactus, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Pumpkin, buyPrice(0, 0, 0, 5)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BambooBlock, buyPrice(0, 0, 0, 4)), Array.Empty<Condition>())
                //空岛
                .Add(CustomPrice(ItemID.Cloud, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.RainCloud, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SunplateBlock, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                //蜂巢
                .Add(CustomPrice(ItemID.Hive, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HoneyBlock, buyPrice(0, 0, 3, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CrispyHoneyBlock, buyPrice(0, 0, 3, 0)), Array.Empty<Condition>())
                //灾厄Mod的天然物块
                .Add(CustomPrice(ItemType<EutrophicSand>(), buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<Navystone>(), buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<SulphurousSand>(), buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<BrimstoneSlag>(), buyPrice(0, 0, 0, 20)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<ScorchedBone>(), buyPrice(0, 0, 0, 20)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<PlantyMush>(), buyPrice(0, 0, 3, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<AbyssGravel>(), buyPrice(0, 0, 0, 20)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<Voidstone>(), buyPrice(0, 0, 5, 0)), new Condition[] { Condition.Hardmode })
                //星辉瘟疫
                .Add(CustomPrice(ItemType<AstralDirt>(), buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<AstralStone>(), buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<AstralSnow>(), buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<AstralIce>(), buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<AstralSand>(), buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<AstralSandstone>(), buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<HardenedAstralSand>(), buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<AstralClay>(), buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode });

            #endregion

            #region 建筑物块
            //照明物块
            buildingBlocks.Add(CustomPrice(ItemID.WhiteTorch, buyPrice(0, 0, 0, 20)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.UltrabrightTorch, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GlassLantern, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GlassLamp, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LampPost, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                //木材
                .Add(CustomPrice(ItemID.Wood, buyPrice(0, 0, 0, 5)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BorealWood, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.RichMahogany, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Shadewood, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Ebonwood, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Pearlwood, buyPrice(0, 0, 0, 20)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.PalmWood, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.DynastyWood, buyPrice(0, 0, 0, 20)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.AshWood, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SpookyWood, buyPrice(0, 0, 1, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemType<AstralMonolith>(), buyPrice(0, 0, 0, 30)), new Condition[] { Condition.Hardmode })
                //圣诞节糖棒块
                .Add(CustomPrice(ItemID.CandyCaneBlock, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GreenCandyCaneBlock, buyPrice(0, 0, 0, 10)), Array.Empty<Condition>())
                //玻璃
                .Add(CustomPrice(ItemID.Glass, buyPrice(0, 0, 0, 5)), Array.Empty<Condition>())
                //石砖
                .Add(CustomPrice(ItemID.GrayBrick, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SandstoneBrick, buyPrice(0, 0, 0, 2)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ObsidianBrick, buyPrice(0, 0, 0, 5)), Array.Empty<Condition>())
                //地牢砖
                .Add(CustomPrice(ItemID.BlueBrick, buyPrice(0, 0, 0, 15)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GreenBrick, buyPrice(0, 0, 0, 15)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PinkBrick, buyPrice(0, 0, 0, 15)), Array.Empty<Condition>())
                //彩虹砖
                .Add(CustomPrice(ItemID.RainbowBrick, buyPrice(0, 0, 0, 25)), new Condition[] { Condition.Hardmode })
                //丛林蜥蜴砖
                .Add(CustomPrice(ItemID.LihzahrdBrick, buyPrice(0, 0, 1, 0)), new Condition[] { Condition.DownedGolem })
                //活火块
                .Add(CustomPrice(ItemID.LivingFireBlock, buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                //火星管道
                .Add(CustomPrice(ItemID.MartianConduitPlating, buyPrice(0, 0, 1, 0)), new Condition[] { Condition.DownedMartians })
                //制作站
                .Add(CustomPrice(ItemID.WorkBench, buyPrice(0, 0, 20, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.IronAnvil, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.MythrilAnvil, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.Furnace, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Hellforge, buyPrice(0, 2, 0, 0)), new Condition[] { Condition.DownedEowOrBoc })
                .Add(CustomPrice(ItemID.TitaniumForge, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.Book, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HeavyWorkBench, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LivingLoom, buyPrice(0, 0, 10, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GlassKiln, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SkyMill, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.IceMachine, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HoneyDispenser, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Sawmill, buyPrice(0, 0, 10, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Loom, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Keg, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.AlchemyTable, buyPrice(0, 1, 0, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(CustomPrice(ItemID.BoneWelder, buyPrice(0, 1, 0, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(CustomPrice(ItemID.MeatGrinder, buyPrice(0, 1, 50, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.FleshCloningVaat, buyPrice(0, 2, 0, 0)), new Condition[] { Condition.DownedMechBossAny })
                .Add(CustomPrice(ItemID.LesionStation, buyPrice(0, 2, 0, 0)), new Condition[] { Condition.DownedMechBossAny })
                .Add(CustomPrice(ItemID.LihzahrdFurnace, buyPrice(0, 2, 50, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.LunarCraftingStation, buyPrice(0, 15, 0, 0)), new Condition[] { Condition.DownedCultist });
            if (TryFind<ModItem>("Fargowiltas/GoldenDippingVat", out ModItem GoldenDippingVat))
            {
                buildingBlocks.Add(CustomPrice((GoldenDippingVat.Type), buyPrice(0, 2, 0, 0)), new Condition[] { Condition.Hardmode });
            }
            if (TryFind<ModItem>("Fargowiltas/MultitaskCenter", out ModItem MultitaskCenter))
            {
                buildingBlocks.Add(CustomPrice((MultitaskCenter.Type), buyPrice(0, 20, 0, 0)), new Condition[] { Condition.DownedMoonLord });
            }
            if (TryFind<ModItem>("Fargowiltas/ElementalAssembler", out ModItem ElementalAssembler))
            {
                buildingBlocks.Add(CustomPrice((ElementalAssembler.Type), buyPrice(0, 30, 0, 0)), new Condition[] { Condition.DownedMoonLord });
            }
            //关于建筑的饰品
            buildingBlocks.Add(CustomPrice(ItemID.PortableStool, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemID.AncientChisel, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedSkeletron })
				.Add(CustomPrice(ItemID.BrickLayer, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedGoblinArmy })
				.Add(CustomPrice(ItemID.ExtendoGrip, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedGoblinArmy })
				.Add(CustomPrice(ItemID.PaintSprayer, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedGoblinArmy })
				.Add(CustomPrice(ItemID.PortableCementMixer, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedGoblinArmy })
				.Add(CustomPrice(ItemID.TreasureMagnet, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedSkeletron })
				.Add(CustomPrice(ItemID.HandOfCreation, buyPrice(0, 30, 0, 0)), new Condition[] { Condition.DownedMoonLord })
				.Add(CustomPrice(ItemType<AncientFossil>(), buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemType<ArchaicPowder>(), buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedSkeletron });
            #endregion

            naturalBlocks.Register();
            buildingBlocks.Register();
        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 8f;
		}

        public override void DrawTownAttackSwing(ref Texture2D item, ref Rectangle itemFrame, ref int itemSize, ref float scale, ref Vector2 offset)
        {
            scale = 1f;
            item = TextureAssets.Item[ItemID.IronHammer].Value;
            itemSize = 40;
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
        {
            itemWidth = 50;
            itemHeight = 50;
        }
    }
}