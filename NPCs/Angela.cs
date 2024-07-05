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
using Terraria.GameContent.Personalities;
using Terraria.GameContent.Bestiary;
using System.Collections.Generic;
using CalamityMod;
using CalamityMod.Items.TreasureBags;
using CalamityMod.Items.Materials;
using CalamityMod.Items.SummonItems.Invasion;
using CalamityMod.Items.SummonItems;
using CalamityMod.Items.Tools.ClimateChange;
using static yitangCalamity.yitangCalamity;
using yitangCalamity.Content.Items.SummonItems;
using yitangCalamity.Content.Items.Others;
using yitangCalamity.Global.Config;
using yitangCalamity.Global.GlobalOthers;

namespace yitangCalamity.NPCs
{
	[AutoloadHead]
	internal class Angela : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 23;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 500;
			NPCID.Sets.AttackType[NPC.type] = 1;
			NPCID.Sets.AttackTime[NPC.type] = 45;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = -6;
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
			{
				Velocity = -1f,
				Direction = new int?(-1)
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(base.Type, drawModifiers);
			NPC.Happiness
				.SetBiomeAffection<OceanBiome>(AffectionLevel.Like)
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
				.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Dislike)
				.SetNPCAffection(NPCID.Cyborg, AffectionLevel.Love)
				.SetNPCAffection(NPCID.Steampunker, AffectionLevel.Like);
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 50;
			NPC.lifeMax = 1000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.Steampunker;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.Add(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface);
			bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("安吉拉操作员提供并出售各种Boss宝藏袋，以及敌怪和Boss的召唤物品。她实际上是一个拥有心智的人工智能机器人。"));
		}

		public override bool UsesPartyHat()
		{
			return true;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs)
		{
			return numTownNPCs > 5 && ytCalamityConfig.Instance.ytNPCAngela;
		}

		public override string GetChat()
		{
			bool DownedPlague = DownedBossSystem.downedPlaguebringer;
			bool DownedCryogen = DownedBossSystem.downedCryogen;
			bool DownedProvidence = DownedBossSystem.downedProvidence;
			bool DownedRavager = DownedBossSystem.downedRavager;
			bool DownedDragonfolly = DownedBossSystem.downedDragonfolly;
			bool DownedDevourerOfGods = DownedBossSystem.downedDoG;
			bool DownedSuperCalamitas = DownedBossSystem.downedCalamitas;

			if (Main.rand.NextBool(5))
			{
				if (WorldGen.crimson)
				{
					return "克苏鲁之脑也许看起来很吓人，但是失去了它的爪牙，它几乎就什么都做不了。";
				}
				if (!WorldGen.crimson)
				{
					return "世界吞噬者检测为异常，危险等级：TETH，现在它已经被写入了。您需要些来自它的物品吗？";
				}
			}
			if (Main.rand.NextBool(5) && NPC.downedQueenBee)
			{
				return "一个蜂后那么大的昆虫是不符合现在的分类标准的，我建议为她建立一个新的分类MI-XX。很奇怪还没有人为了自己的意愿驱使她们，那么让我们成为第一个吧。";
			}
			if (Main.hardMode)
			{
				if (Main.rand.NextBool(5) && DownedPlague)
				{
					return "看来我对蜂后的看法是错误的，她们的记忆中储存着一个被野心蒙蔽了双眼的科学家的漫谈，他残酷无情地把瘟疫带给了她们。让我们把她们归类为MP";
				}
				if (Main.rand.NextBool(5) && DownedCryogen)
				{
					return "把一个法师的力量转移到他自己身上，并且用其困住他并非易事，但是观察到如此残酷的行为……永冻之土，昔日的冰堡之王，愿您看到和平。";
				}
				if (Main.rand.NextBool(5) && DownedProvidence)
				{
					return "亵渎天神，这样一个古老的存在是值得记录的——她外表的材料可承受的温度，与泰拉瑞亚太阳核心的温度相当！如果能使材料具有一半的耐热性，这将彻底改变对ARS-0N囚犯的控制装置。";
				}
				if (Main.rand.NextBool(5) && DownedRavager)
				{
					return "那些制造毁灭魔像的人就应该被关进HI-MAX监狱中去，这些可怜的灵魂受尽了折磨……好吧，至少您将他们从痛苦之渊中解放了出来。";
				}
				if (Main.rand.NextBool(5) && DownedDragonfolly)
				{
					return "有意思……那些癫痫鸟实际上是丛林龙犽戎的克隆体。我很高兴看到那些实验都失败了！";
				}
				if (Main.rand.NextBool(5) && DownedDevourerOfGods)
				{
					return "神明吞噬者……您很幸运，那东西过于自满，他没有直接在您头上开个直通太阳的传送门。他所展示出的力量和智慧，意味着我要对蠕虫的类别做一个全新的分类。";
				}
				if (Main.rand.NextBool(5) && DownedSuperCalamitas)
				{
					return "至尊女巫，灾厄被击败了，但是她说还有一个比她更为强大的存在，我们必须祈祷他还没有注意到我们……";
				}
			}
			if (Main.rand.NextBool(5) && Main.hardMode)
			{
				switch (Main.rand.Next(2))
				{
					case 0:
						return "这个世界出现了某种变动，主管。邪恶正在扩张，但是与此同时，我的传感系统发现诞生了一个新的生物群落——神圣之地。";
					case 1:
						return "所有的这些机械Boss……对于他们的编号标准，肯定是创伤(Trauma)或本源(Original)、以及人造物(5)。所以我觉得它们的分类号码，可以先从T-05-开始……";
				}
			}
			if (Main.bloodMoon)
			{
				switch (Main.rand.Next(3))
				{
					case 0:
						return "血月？这不应该是每666年才发生一次的吗？";
					case 1:
						return "所有的这些奇怪生物一直向我们冲过来……真希望我们能在黎明前活下来。";
					case 2:
						return "无论怎样，都有一些乐观的理由，血月带来了一些生物，一些平时我们都见不到的生物。";
				}
			}
			if (Main.invasionType == 1)
			{
				return "哥布林……如此可怜的生物。他们唯一有用的东西就是尖刺球和鱼叉枪。";
			}
			if (Main.invasionType == 3)
			{
				return "挺奇怪的异常事件……他们都看起来像是活着的生物，但是他们的“荷兰飞盗船”的危险等级绝对有HE。";
			}
			if (Main.invasionType == 4)
			{
				return "火星人又来了。上次他们来的时候，几个大城镇被毁灭了。但是，恕我直言，当时是因为我们还没有像现在这样做好准备。";
			}
			if (NPC.downedBoss3)
			{
				if (Main.rand.Next(7) == 0)
				{
					return "我阅读了一些关于一个生物的手稿，叫做史莱姆之神。他们说这是世界上最早出现的生物之一。";
				}
			}
			if (NPC.downedMoonlord)
			{
				if (Main.rand.Next(7) == 0)
				{
					return "亚利姆……我很确定我曾经听过这个名字，但是我的记忆数据已损坏，试着去向大山猪问问关于他的事情吧……";
				}
			}
			if (NPC.downedPlantBoss)
			{
				if (Main.rand.Next(7) == 0)
				{
					return "世纪之花……这种肉食植物真的很危险，危险等级至少为HE，总之很高兴再次见到您平安归来。";
				}
			}
			if (NPC.downedGolemBoss)
			{
				if (Main.rand.Next(7) == 0)
				{
					return "这古老的机器拥有着巨大的天界之力，随着它的死亡，世界也发生了永久的改变……";
				}
			}
			var dialog = new Terraria.Utilities.WeightedRandom<string>();
			dialog.Add("您好吗，主管，我能为您做什么？");
			dialog.Add("您好，主管！今天真安静，不是么？");
			dialog.Add("您想要什么特别的东西吗，主管？");
			dialog.Add("那个“大雷鸟”看起来并不怎么危险，我只希望它不是天启鸟的一部分……");
			dialog.Add("如果您成功阻止诸神黄昏，那么您就可以做您想做的一切。");
			dialog.Add("克苏鲁之眼是个特别奇怪的生物，它看起来像是某个十分危险之物的一部分。如果它没有逃跑，那对我们来说更好。");
			dialog.Add("老实说，我不知道为什么巨大的旋转头骨是一切的关键，但不知何故，它们似乎包含了天界的力量……");
			dialog.Add("是的，我知道我们是捕获和饲养恐怖怪物的人。但谁会认为把宝藏袋放在一个巨大的怪物里面是个好主意呢？！");
			dialog.Add("主管，您知道的，宝藏袋很值钱，但，并不是所有的东西都在里面……");
			return dialog.Get();
		}

		public override List<string> SetNPCNameList()
		{
			return new List<string> { "Angela" };
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = "Boss宝藏袋";
			button2 = "召唤物品";
		}

		public override void OnChatButtonClicked(bool firstButton, ref string shopName)
		{
			if (firstButton)
			{
				shopName = "TreasureBags";
			}
			else
			{
				shopName = "SumShop";
			}
		}

		public override void AddShops()
		{
			var treasureBags = new NPCShop(Type, "TreasureBags");
			var sumShop = new NPCShop(Type, "SumShop");

			#region 灾厄Mod的Boss击败条件
			//以下是灾厄的Boss击败条件
			//去CalamityMod\Downed.cs里找灾厄各个Boss的对应Condition名
			//关于原版的Condition条件都在tModLoader-1.4.4\patches\tModLoader\Terraria\Condition.cs里
			//模组条件+原版条件的组合 => DownedBossSystem.downedCalamitasClone || NPC.downedPlantBoss);

			Condition DownedDesertScourge = new Condition("DesertScourge", () => DownedBossSystem.downedDesertScourge);
			Condition DownedCrabulon = new Condition("Crabulon", () => DownedBossSystem.downedCrabulon);
			Condition DownedPerfs = new Condition("Perfs", () => DownedBossSystem.downedPerforator);
			Condition DownedHiveMind = new Condition("HiveMind", () => DownedBossSystem.downedHiveMind);
			Condition DownedPerfsOrHive = new Condition("PerfsHiveMind", () => DownedBossSystem.downedPerforator || DownedBossSystem.downedHiveMind);
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
			Condition DownedGuardians = new Condition("Guardians", () => DownedBossSystem.downedGuardians);
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
			Condition DownedExoAndCal = new Condition("ExoAndCal", () => DownedBossSystem.downedExoMechs && DownedBossSystem.downedCalamitas);

			#endregion

			#region 源自炼金术士Mod的物品
			//炼金术士Mod的物品
			treasureBags
				//.Add(CustomPrice(ItemType<GlobalTeleporter>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.Hardmode })
				//.Add(CustomPrice(ItemType<GlobalTeleporterUp>(), buyPrice(0, 25, 0, 0)), new Condition[] { Condition.DownedMoonLord })
				//.Add(CustomPrice(ItemType<WorldControlUnit>(), buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
			#endregion

			#region 原版Boss宝藏袋
				//原版Boss宝藏袋
				.Add(CustomPrice(ItemID.KingSlimeBossBag, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedKingSlime })
				.Add(CustomPrice(ItemID.EyeOfCthulhuBossBag, buyPrice(0, 10, 0, 0)), new Condition[] { Condition.DownedEyeOfCthulhu })
				.Add(CustomPrice(ItemID.BrainOfCthulhuBossBag, buyPrice(0, 15, 0, 0)), new Condition[] { ModConditions.DownedBrainofCthulhu })
				.Add(CustomPrice(ItemID.EaterOfWorldsBossBag, buyPrice(0, 15, 0, 0)), new Condition[] { ModConditions.DownedEaterofWorlds })
				.Add(CustomPrice(ItemID.QueenBeeBossBag, buyPrice(0, 20, 0, 0)), new Condition[] { Condition.DownedQueenBee })
				.Add(CustomPrice(ItemID.SkeletronBossBag, buyPrice(0, 25, 0, 0)), new Condition[] { Condition.DownedSkeletron })
				.Add(CustomPrice(ItemID.DeerclopsBossBag, buyPrice(0, 30, 0, 0)), new Condition[] { Condition.DownedDeerclops })
				.Add(CustomPrice(ItemID.WallOfFleshBossBag, buyPrice(0, 35, 0, 0)), new Condition[] { Condition.Hardmode })

				.Add(CustomPrice(ItemID.QueenSlimeBossBag, buyPrice(0, 40, 0, 0)), new Condition[] { Condition.DownedQueenSlime })
				.Add(CustomPrice(ItemID.SkeletronPrimeBossBag, buyPrice(0, 45, 0, 0)), new Condition[] { Condition.DownedSkeletronPrime })
				.Add(CustomPrice(ItemID.DestroyerBossBag, buyPrice(0, 45, 0, 0)), new Condition[] { Condition.DownedDestroyer })
				.Add(CustomPrice(ItemID.TwinsBossBag, buyPrice(0, 45, 0, 0)), new Condition[] { Condition.DownedTwins })
				.Add(CustomPrice(ItemID.PlanteraBossBag, buyPrice(0, 50, 0, 0)), new Condition[] { Condition.DownedPlantera })
				.Add(CustomPrice(ItemID.FairyQueenBossBag, buyPrice(0, 55, 0, 0)), new Condition[] { Condition.DownedEmpressOfLight })
				.Add(CustomPrice(ItemID.GolemBossBag, buyPrice(0, 60, 0, 0)), new Condition[] { Condition.DownedGolem })
				.Add(CustomPrice(ItemID.FishronBossBag, buyPrice(0, 65, 0, 0)), new Condition[] { Condition.DownedDukeFishron })
				.Add(CustomPrice(ItemID.BossBagBetsy, buyPrice(0, 70, 0, 0)), new Condition[] { Condition.DownedOldOnesArmyT3 })
				.Add(CustomPrice(ItemID.MoonLordBossBag, buyPrice(0, 75, 0, 0)), new Condition[] { Condition.DownedMoonLord })
			#endregion

			#region 模组Boss宝藏袋
				//模组Boss宝藏袋
				.Add(CustomPrice(ItemType<DesertScourgeBag>(), buyPrice(0, 5, 0, 0)), new Condition[] { DownedDesertScourge })
				.Add(CustomPrice(ItemType<CrabulonBag>(), buyPrice(0, 5, 0, 0)), new Condition[] { DownedCrabulon })
				.Add(CustomPrice(ItemType<PerforatorBag>(), buyPrice(0, 15, 0, 0)), new Condition[] { DownedPerfs })
				.Add(CustomPrice(ItemType<HiveMindBag>(), buyPrice(0, 15, 0, 0)), new Condition[] { DownedHiveMind })
				.Add(CustomPrice(ItemType<SlimeGodBag>(), buyPrice(0, 30, 0, 0)), new Condition[] { DownedSlimeGod })

				.Add(CustomPrice(ItemType<CryogenBag>(), buyPrice(0, 35, 0, 0)), new Condition[] { DownedCryogen })
				.Add(CustomPrice(ItemType<AquaticScourgeBag>(), buyPrice(0, 40, 0, 0)), new Condition[] { DownedAquaticScourge })
				.Add(CustomPrice(ItemType<BrimstoneWaifuBag>(), buyPrice(0, 45, 0, 0)), new Condition[] { DownedBrimstoneElemental })
				.Add(CustomPrice(ItemType<CalamitasCloneBag>(), buyPrice(0, 50, 0, 0)), new Condition[] { DownedCloneCalamitas })
				.Add(CustomPrice(ItemType<LeviathanBag>(), buyPrice(0, 55, 0, 0)), new Condition[] { DownedLeviathan })
				.Add(CustomPrice(ItemType<AstrumAureusBag>(), buyPrice(0, 55, 0, 0)), new Condition[] { DownedAureus })
				.Add(CustomPrice(ItemType<PlaguebringerGoliathBag>(), buyPrice(0, 60, 0, 0)), new Condition[] { DownedPlague })
				.Add(CustomPrice(ItemType<RavagerBag>(), buyPrice(0, 60, 0, 0)), new Condition[] { DownedRavager })
				.Add(CustomPrice(ItemType<AstrumDeusBag>(), buyPrice(0, 70, 0, 0)), new Condition[] { DownedDeus });
			if (TryFind<ModItem>("CatalystMod/AstrageldonBag", out ModItem AstrageldonBag))
			{
				treasureBags.Add(CustomPrice(AstrageldonBag.Type, buyPrice(1, 0, 0, 0)), new Condition[] { ModConditions.DownedAstrageldon });
			}

			treasureBags.Add(CustomPrice(ItemType<DragonfollyBag>(), buyPrice(0, 80, 0, 0)), new Condition[] { DownedDragonfolly })
				.Add(CustomPrice(ItemType<ProvidenceBag>(), buyPrice(0, 80, 0, 0)), new Condition[] { DownedProvidence })
				.Add(CustomPrice(ItemType<PolterghastBag>(), buyPrice(0, 85, 0, 0)), new Condition[] { DownedPolterghast })
				.Add(CustomPrice(ItemType<OldDukeBag>(), buyPrice(0, 0, 90, 0)), new Condition[] { DownedOldDuke })
				.Add(CustomPrice(ItemType<StormWeaverBag>(), buyPrice(0, 95, 0, 0)), new Condition[] { DownedStormWeaver })
				.Add(CustomPrice(ItemType<CeaselessVoidBag>(), buyPrice(0, 95, 0, 0)), new Condition[] { DownedCeaselessVoid })
				.Add(CustomPrice(ItemType<SignusBag>(), buyPrice(0, 95, 0, 0)), new Condition[] { DownedSignus })
				.Add(CustomPrice(ItemType<DevourerofGodsBag>(), buyPrice(1, 50, 0, 0)), new Condition[] { DownedDevourerOfGods })
				.Add(CustomPrice(ItemType<YharonBag>(), buyPrice(2, 0, 0, 0)), new Condition[] { DownedYharon })
				.Add(CustomPrice(ItemType<DraedonBag>(), buyPrice(3, 50, 0, 0)), new Condition[] { DownedExoMechs })
				.Add(CustomPrice(ItemType<CalamitasCoffer>(), buyPrice(4, 0, 0, 0)), new Condition[] { DownedSuperCalamitas });
			#endregion

			#region 召唤物品

			#region 事件召唤物品
			sumShop
				//.Add(CustomPrice(ItemType<RainMagic>(), buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemID.BloodMoonStarter, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemID.GoblinBattleStandard, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemType<CausticTear>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.DownedEyeOfCthulhu })
				.Add(CustomPrice(ItemType<TorrentialTear>(), buyPrice(0, 1, 70, 0)), new Condition[] { Condition.DownedSkeletron })
				.Add(CustomPrice(ItemID.PirateMap, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode })
				.Add(CustomPrice(ItemID.SnowGlobe, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode })
				.Add(CustomPrice(ItemID.SolarTablet, buyPrice(0, 3, 50, 0)), new Condition[] { Condition.DownedMechBossAny })
				.Add(CustomPrice(ItemID.PumpkinMoonMedallion, buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera })
				.Add(CustomPrice(ItemType<MartianDistressRemote>(), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedGolem })
				.Add(CustomPrice(ItemID.NaughtyPresent, buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });

			#endregion

			#region Boss召唤物品

			#region 原版Boss+Fargo相关
			//史莱姆王
			sumShop.Add(CustomPrice(ItemID.SlimeCrown, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			//特洛伊松鼠
			if (TryFind<ModItem>("FargowiltasSouls/SquirrelCoatofArms", out ModItem SquirrelCoatofArms))
			{
				sumShop.Add(CustomPrice((SquirrelCoatofArms.Type), buyPrice(0, 1, 0, 0)), Array.Empty<Condition>());
			}
			//克苏鲁之眼
			sumShop.Add(CustomPrice(ItemID.SuspiciousLookingEye, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			//克苏鲁之脑
			sumShop.Add(CustomPrice(ItemID.BloodySpine, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			//世界吞噬者
			sumShop.Add(CustomPrice(ItemID.WormFood, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			//蜂王
			sumShop.Add(CustomPrice(ItemID.Abeemination, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			//骷髅王
			if (TryFind<ModItem>("Fargowiltas/SuspiciousSkull", out ModItem SuspiciousSkull))
			{
				sumShop.Add(CustomPrice((SuspiciousSkull.Type), buyPrice(0, 2, 50, 0)), Array.Empty<Condition>());
			}
			//独眼巨鹿
			sumShop.Add(CustomPrice(ItemID.DeerThing, buyPrice(0, 2, 50, 0)), Array.Empty<Condition>());
			//戴薇安
			if (TryFind<ModItem>("FargowiltasSouls/DevisCurse", out ModItem DevisCurse))
			{
				sumShop.Add(CustomPrice((DevisCurse.Type), buyPrice(0, 2, 50, 0)), Array.Empty<Condition>());
			}
			//血肉之墙
			sumShop.Add(CustomPrice(ItemID.GuideVoodooDoll, buyPrice(0, 2, 50, 0)), Array.Empty<Condition>());

			//史莱姆皇后
			sumShop.Add(CustomPrice(ItemID.QueenSlimeCrystal, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			//放逐遗爵
			if (TryFind<ModItem>("FargowiltasSouls/MechLure", out ModItem MechLure))
			{
				sumShop.Add(CustomPrice((MechLure.Type), buyPrice(0, 2, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//毁灭者
			sumShop.Add(CustomPrice(ItemID.MechanicalWorm, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			//双子魔眼
			sumShop.Add(CustomPrice(ItemID.MechanicalEye, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			//机械骷髅王
			sumShop.Add(CustomPrice(ItemID.MechanicalSkull, buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			//飘渺游光
			if (TryFind<ModItem>("FargowiltasSouls/FragilePixieLamp", out ModItem FragilePixieLamp))
			{
				sumShop.Add(CustomPrice((FragilePixieLamp.Type), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			}
			//世纪之花
			sumShop.Add(CustomPrice(ItemType<Portabulb>(), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			//光之女皇
			sumShop.Add(CustomPrice(ItemID.EmpressButterfly, buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			//石巨人
			sumShop.Add(CustomPrice(ItemID.LihzahrdPowerCell, buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });
			//猪龙鱼公爵
			sumShop.Add(CustomPrice(ItemID.TruffleWorm, buyPrice(0, 4, 50, 0)), new Condition[] { Condition.Hardmode });
			//拜月教邪教徒
			if (TryFind<ModItem>("Fargowiltas/CultistSummon", out ModItem CultistSummon))
			{
				sumShop.Add(CustomPrice((CultistSummon.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			sumShop.Add(CustomPrice(ItemType<EidolonTablet>(), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			//月亮领主
			sumShop.Add(CustomPrice(ItemID.CelestialSigil, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedCultist });

			//九大英灵
			if (TryFind<ModItem>("FargowiltasSouls/SigilOfChampions", out ModItem SigilOfChampions))
			{
				sumShop.Add(CustomPrice((SigilOfChampions.Type), buyPrice(0, 7, 50, 0)), new Condition[] { Condition.DownedMoonLord });
			}
			//憎恶
			if (TryFind<ModItem>("FargowiltasSouls/AbomsCurse", out ModItem AbomsCurse))
			{
				sumShop.Add(CustomPrice((AbomsCurse.Type), buyPrice(0, 10, 0, 0)), new Condition[] { Condition.DownedMoonLord });
			}
			//突变体
			if (TryFind<ModItem>("FargowiltasSouls/MutantsCurse", out ModItem MutantsCurse))
			{
				sumShop.Add(CustomPrice((MutantsCurse.Type), buyPrice(0, 50, 0, 0)), new Condition[] { DownedExoAndCal });
			}
			#endregion

			#region 灾厄Mod相关
			sumShop.Add(CustomPrice(ItemType<DesertMedallion>(), buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemType<DecapoditaSprout>(), buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemType<BloodyWormFood>(), buyPrice(0, 3, 0, 0)), new Condition[] { DownedPerfsOrHive })
				.Add(CustomPrice(ItemType<Teratoma>(), buyPrice(0, 3, 0, 0)), new Condition[] { DownedPerfsOrHive })
				.Add(CustomPrice(ItemType<OverloadedSludge>(), buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())

			   .Add(CustomPrice(ItemType<CryoKey>(), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode })
			   .Add(CustomPrice(ItemType<Seafood>(), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode })
			   .Add(CustomPrice(ItemType<CharredIdol>(), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode })
			   .Add(CustomPrice(ItemType<EyeofDesolation>(), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			if (TryFind<ModItem>("FargowiltasCrossmod/SirensPearl", out ModItem SirensPearl))
			{
				sumShop.Add(CustomPrice((SirensPearl.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.Hardmode });
			}
			sumShop.Add(CustomPrice(ItemType<AstralChunk>(), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.Hardmode })
				.Add(CustomPrice(ItemType<Abombination>(), buyPrice(0, 4, 50, 0)), new Condition[] { Condition.DownedGolem })
				.Add(CustomPrice(ItemType<DeathWhistle>(), buyPrice(0, 4, 50, 0)), new Condition[] { Condition.DownedGolem })
				.Add(CustomPrice(ItemType<TitanHeart>(), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			if (TryFind<ModItem>("CatalystMod/AstralCommunicator", out ModItem AstralCommunicator))
			{
				sumShop.Add(CustomPrice((AstralCommunicator.Type), buyPrice(0, 3, 70, 0)), new Condition[] { Condition.Hardmode });
			}

			sumShop.Add(CustomPrice(ItemType<ProfanedShard>(), buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedMoonLord })
				.Add(CustomPrice(ItemType<ProfanedCore>(), buyPrice(0, 5, 50, 0)), new Condition[] { DownedGuardians })
				.Add(CustomPrice(ItemType<ExoticPheromones>(), buyPrice(0, 6, 0, 0)), new Condition[] { Condition.DownedCultist })
				.Add(CustomPrice(ItemType<NecroplasmicBeacon>(), buyPrice(0, 7, 0, 0)), new Condition[] { Condition.DownedMoonLord })
				.Add(CustomPrice(ItemType<BloodwormItem>(), buyPrice(0, 8, 0, 0)), new Condition[] { Condition.DownedMoonLord })
				.Add(CustomPrice(ItemType<CosmicWorm>(), buyPrice(0, 9, 0, 0)), new Condition[] { Condition.DownedMoonLord })
				.Add(CustomPrice(ItemType<YharonEgg>(), buyPrice(0, 10, 0, 0)), new Condition[] { DownedDragonfolly })
				.Add(CustomPrice(ItemType<CeremonialUrn>(), buyPrice(0, 20, 0, 0)), new Condition[] { DownedSuperCalamitas });
			#endregion

			#endregion

			#region 敌怪召唤物品

			#region 灾厄Mod 迷你Boss
			//巨像蛤
			if (TryFind<ModItem>("FargowiltasCrossmod/ClamPearl", out ModItem ClamPearl))
			{
				sumShop.Add(CustomPrice((ClamPearl.Type), buyPrice(0, 2, 0, 0)), new Condition[] { DownedDesertScourge });
			}
			//雨云元素
			if (TryFind<ModItem>("FargowiltasCrossmod/StormIdol", out ModItem StormIdol))
			{
				sumShop.Add(CustomPrice((StormIdol.Type), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			}
			//大地元素
			if (TryFind<ModItem>("FargowiltasCrossmod/QuakeIdol", out ModItem QuakeIdol))
			{
				sumShop.Add(CustomPrice((QuakeIdol.Type), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			}
			//峭咽潭
			if (TryFind<ModItem>("FargowiltasCrossmod/SulphurBearTrap", out ModItem SulphurBearTrap))
			{
				sumShop.Add(CustomPrice((SulphurBearTrap.Type), buyPrice(0, 3, 50, 0)), new Condition[] { DownedAquaticScourge });
			}
			//装甲掘地虫
			if (TryFind<ModItem>("FargowiltasCrossmod/AbandonedRemote", out ModItem AbandonedRemote))
			{
				sumShop.Add(CustomPrice((AbandonedRemote.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });
			}
			//旱海狂鲨
			sumShop.Add(CustomPrice(ItemType<SandstormsCore>(), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });
			//瘟疫使者
			if (TryFind<ModItem>("FargowiltasCrossmod/PlaguedWalkieTalkie", out ModItem PlaguedWalkieTalkie))
			{
				sumShop.Add(CustomPrice((PlaguedWalkieTalkie.Type), buyPrice(0, 4, 50, 0)), new Condition[] { Condition.DownedGolem });
			}
			//辐核骇兽
			if (TryFind<ModItem>("FargowiltasCrossmod/NuclearChunk", out ModItem NuclearChunk))
			{
				sumShop.Add(CustomPrice((NuclearChunk.Type), buyPrice(0, 7, 0, 0)), new Condition[] { DownedPolterghast });
			}
			//渊海狂鲨
			if (TryFind<ModItem>("FargowiltasCrossmod/MaulerSkull", out ModItem MaulerSkull))
			{
				sumShop.Add(CustomPrice((MaulerSkull.Type), buyPrice(0, 7, 0, 0)), new Condition[] { DownedPolterghast });
			}
			//巨像乌贼
			if (TryFind<ModItem>("FargowiltasCrossmod/ColossalTentacle", out ModItem ColossalTentacle))
			{
				sumShop.Add(CustomPrice((ColossalTentacle.Type), buyPrice(0, 7, 0, 0)), new Condition[] { DownedPolterghast });
			}
			//猎魂鲨
			if (TryFind<ModItem>("FargowiltasCrossmod/DeepseaProteinShake", out ModItem DeepseaProteinShake))
			{
				sumShop.Add(CustomPrice((DeepseaProteinShake.Type), buyPrice(0, 7, 0, 0)), new Condition[] { DownedPolterghast });
			}
			//幻海妖龙
			if (TryFind<ModItem>("FargowiltasCrossmod/WyrmTablet", out ModItem WyrmTablet))
			{
				sumShop.Add(CustomPrice((WyrmTablet.Type), buyPrice(0, 7, 0, 0)), new Condition[] { DownedPolterghast });
			}
			//始源妖龙
			sumShop.Add(CustomPrice(ItemType<SubnauticalPlate>(), buyPrice(0, 40, 0, 0)), new Condition[] { DownedExoAndCal });
			#endregion

			//巨型蠕虫/挖掘怪
			if (TryFind<ModItem>("Fargowiltas/WormSnack", out ModItem WormSnack))
			{
				sumShop.Add(CustomPrice((WormSnack.Type), buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			}
			//粉史莱姆
			if (TryFind<ModItem>("Fargowiltas/PinkSlimeCrown", out ModItem PinkSlimeCrown))
			{
				sumShop.Add(CustomPrice((PinkSlimeCrown.Type), buyPrice(0, 2, 50, 0)), Array.Empty<Condition>());
			}
			//侏儒
			if (TryFind<ModItem>("Fargowiltas/GnomeHat", out ModItem GnomeHat))
			{
				sumShop.Add(CustomPrice((GnomeHat.Type), buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			}
			//哥布林侦察兵
			if (TryFind<ModItem>("Fargowiltas/GoblinScrap", out ModItem GoblinScrap))
			{
				sumShop.Add(CustomPrice((GoblinScrap.Type), buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			}
			//不死矿工
			if (TryFind<ModItem>("Fargowiltas/AttractiveOre", out ModItem AttractiveOre))
			{
				sumShop.Add(CustomPrice((AttractiveOre.Type), buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			}
			//宁芙
			if (TryFind<ModItem>("Fargowiltas/HeartChocolate", out ModItem HeartChocolate))
			{
				sumShop.Add(CustomPrice((HeartChocolate.Type), buyPrice(0, 2, 0, 0)), Array.Empty<Condition>());
			}
			//蒂姆
			if (TryFind<ModItem>("Fargowiltas/HolyGrail", out ModItem HolyGrail))
			{
				sumShop.Add(CustomPrice((HolyGrail.Type), buyPrice(0, 2, 70, 0)), Array.Empty<Condition>());
			}
			//骷髅博士
			if (TryFind<ModItem>("Fargowiltas/Eggplant", out ModItem Eggplant))
			{
				sumShop.Add(CustomPrice((Eggplant.Type), buyPrice(0, 2, 70, 0)), Array.Empty<Condition>());
			}
			//金史莱姆
			if (TryFind<ModItem>("Fargowiltas/GoldenSlimeCrown", out ModItem GoldenSlimeCrown))
			{
				sumShop.Add(CustomPrice((GoldenSlimeCrown.Type), buyPrice(0, 3, 0, 0)), Array.Empty<Condition>());
			}
			//游荡眼球怪鱼/僵尸人鱼
			if (TryFind<ModItem>("Fargowiltas/SuspiciousLookingLure", out ModItem SuspiciousLookingLure))
			{
				sumShop.Add(CustomPrice((SuspiciousLookingLure.Type), buyPrice(0, 2, 70, 0)), Array.Empty<Condition>());
			}
			//地牢史莱姆
			if (TryFind<ModItem>("Fargowiltas/SlimyLockBox", out ModItem SlimyLockBox))
			{
				sumShop.Add(CustomPrice((SlimyLockBox.Type), buyPrice(0, 2, 70, 0)), new Condition[] { Condition.DownedSkeletron });
			}

			//宝箱怪/冰雪宝箱怪
			if (TryFind<ModItem>("Fargowiltas/SuspiciousLookingChest", out ModItem SuspiciousLookingChest))
			{
				sumShop.Add(CustomPrice((SuspiciousLookingChest.Type), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			}
			//猩红宝箱怪
			if (TryFind<ModItem>("Fargowiltas/CrimsonChest", out ModItem CrimsonChest))
			{
				sumShop.Add(CustomPrice((CrimsonChest.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//腐化宝箱怪
			if (TryFind<ModItem>("Fargowiltas/CorruptChest", out ModItem CorruptChest))
			{
				sumShop.Add(CustomPrice((CorruptChest.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//神圣宝箱怪
			if (TryFind<ModItem>("Fargowiltas/HallowChest", out ModItem HallowChest))
			{
				sumShop.Add(CustomPrice((HallowChest.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//丛林宝箱怪
			if (TryFind<ModItem>("Fargowiltas/JungleChest", out ModItem JungleChest))
			{
				sumShop.Add(CustomPrice((JungleChest.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//蛇发女妖
			if (TryFind<ModItem>("Fargowiltas/AthenianIdol", out ModItem AthenianIdol))
			{
				sumShop.Add(CustomPrice((AthenianIdol.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//符文巫师
			if (TryFind<ModItem>("Fargowiltas/RuneOrb", out ModItem RuneOrb))
			{
				sumShop.Add(CustomPrice((RuneOrb.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//小丑
			if (TryFind<ModItem>("Fargowiltas/ClownLicense", out ModItem ClownLicense))
			{
				sumShop.Add(CustomPrice((ClownLicense.Type), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			}
			//飞龙
			if (TryFind<ModItem>("Fargowiltas/CloudSnack", out ModItem CloudSnack))
			{
				sumShop.Add(CustomPrice((CloudSnack.Type), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
			}
			//彩虹史莱姆
			if (TryFind<ModItem>("Fargowiltas/DilutedRainbowMatter", out ModItem DilutedRainbowMatter))
			{
				sumShop.Add(CustomPrice((DilutedRainbowMatter.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//冰雪巨人
			if (TryFind<ModItem>("Fargowiltas/CoreoftheFrostCore", out ModItem CoreoftheFrostCore))
			{
				sumShop.Add(CustomPrice((CoreoftheFrostCore.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//沙尘精
			if (TryFind<ModItem>("Fargowiltas/ForbiddenForbiddenFragment", out ModItem ForbiddenForbiddenFragment))
			{
				sumShop.Add(CustomPrice((ForbiddenForbiddenFragment.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//哥布林术士
			if (TryFind<ModItem>("Fargowiltas/ShadowflameIcon", out ModItem ShadowflameIcon))
			{
				sumShop.Add(CustomPrice((ShadowflameIcon.Type), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode, Condition.DownedGoblinArmy });
			}
			//海盗船长
			if (TryFind<ModItem>("Fargowiltas/PirateFlag", out ModItem PirateFlag))
			{
				sumShop.Add(CustomPrice((PirateFlag.Type), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode, Condition.DownedPirates });
			}
			//血浆哥布林鲨鱼
			if (TryFind<ModItem>("Fargowiltas/HemoclawCrab", out ModItem HemoclawCrab))
			{
				sumShop.Add(CustomPrice((HemoclawCrab.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//血鳗鱼
			if (TryFind<ModItem>("Fargowiltas/BloodUrchin", out ModItem BloodUrchin))
			{
				sumShop.Add(CustomPrice((BloodUrchin.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//恐惧鹦鹉螺
			sumShop.Add(CustomPrice(ItemType<RedBait>(), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.Hardmode });
			//蛾
			if (TryFind<ModItem>("Fargowiltas/MothLamp", out ModItem MothLamp))
			{
				sumShop.Add(CustomPrice((MothLamp.Type), buyPrice(0, 3, 50, 0)), new Condition[] { Condition.Hardmode });
			}
			//红魔鬼
			if (TryFind<ModItem>("Fargowiltas/DemonicPlushie", out ModItem DemonicPlushie))
			{
				sumShop.Add(CustomPrice((DemonicPlushie.Type), buyPrice(0, 3, 70, 0)), new Condition[] { Condition.DownedMechBossAny });
			}
			//钉头
			if (TryFind<ModItem>("Fargowiltas/Pincushion", out ModItem Pincushion))
			{
				sumShop.Add(CustomPrice((Pincushion.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });
			}
			//蛾怪
			if (TryFind<ModItem>("Fargowiltas/MothronEgg", out ModItem MothronEgg))
			{
				sumShop.Add(CustomPrice((MothronEgg.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });
			}
			//骷髅狙击手 + 骷髅特警 + 骷髅突击手
			if (TryFind<ModItem>("Fargowiltas/AmalgamatedSkull", out ModItem AmalgamatedSkull))
			{
				sumShop.Add(CustomPrice((AmalgamatedSkull.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });
			}
			//褴褛邪教徒法师 + 死灵法师 + 魔教徒
			if (TryFind<ModItem>("Fargowiltas/AmalgamatedSpirit", out ModItem AmalgamatedSpirit))
			{
				sumShop.Add(CustomPrice((AmalgamatedSpirit.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });
			}
			//骷髅李
			if (TryFind<ModItem>("Fargowiltas/LeesHeadband", out ModItem LeesHeadband))
			{
				sumShop.Add(CustomPrice((LeesHeadband.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });
			}
			//圣骑士
			if (TryFind<ModItem>("Fargowiltas/GrandCross", out ModItem GrandCross))
			{
				sumShop.Add(CustomPrice((GrandCross.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedPlantera });
			}
			#endregion

			#endregion

			treasureBags.Register();
			sumShop.Register();
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 70;
			knockback = 3f;
		}

		public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)
		{
			scale = 1f;
			horizontalHoldoutOffset = 20;
			if (!NPC.downedMoonlord)
			{
				item = TextureAssets.Item[ItemID.Shotgun].Value;
			}
			if (NPC.downedMoonlord)
			{
				item = TextureAssets.Item[ItemID.VortexBeater].Value;
			}
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			if (!NPC.downedMoonlord)
			{
				attackDelay = 10;
				projType = 279;
			}
			if (NPC.downedMoonlord)
			{
				attackDelay = 4;
				projType = 638;
			}
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
		}
	}
}