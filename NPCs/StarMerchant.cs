using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.Item;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Events;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables.Ores;
using CalamityMod.Items.Placeables;
using CalamityMod.Items.Potions;
using yitangCalamity.Global;
using yitangCalamity.Global.Config;
using yitangCalamity.Global.GlobalOthers;
using yitangCalamity.Content.Items.Materials;
using static yitangCalamity.yitangCalamity;

namespace yitangCalamity.NPCs
{
	[AutoloadHead]
    internal class StarMerchant : ModNPC
    {
        public override void SetStaticDefaults()
		{
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f,
            };
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Love)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Nurse, AffectionLevel.Like);
        }

		public override void SetDefaults()
		{
			NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 34;
            NPC.height = 50;
            NPC.aiStyle = 7;
            NPC.damage = 40;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.DD2_LightningBugDeath;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.Add(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface);
			bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("一位神秘的魔法科学家，在经历长久的旅行后，现在她回到这里从事材料的买卖。"));
		}

		public override bool CanTownNPCSpawn(int numTownNPCs)
		{
			return numTownNPCs > 3 && ytCalamityConfig.Instance.ytNPCStarMerchant;
		}

		public override string GetChat()
		{
            if (Main.rand.NextBool(5) && Main.hardMode)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return "这，破碎的星辉，滋生并腐烂的瘟疫，扭曲的梦幻之景……为何星空中会有如此让人无法理解的东西。";
                    case 1:
                        return "这星辉瘟疫，或许是来自行星的残骸，但到底是如何被摧毁和感染污秽的，我们不得而知。";
                }
            }
            var dialog = new Terraria.Utilities.WeightedRandom<string>();
            dialog.Add("你观察过夜空吗？有时漫天星河，有时深邃无垠，真的很容易让人沉迷其中。");
            dialog.Add("在夜晚，你会发现有时会有星星坠落，但它们在白天就会转瞬即逝，这到底是为什么呢……");
            dialog.Add("除了坠落之星，你见过星尘吗？据说那是来自银河之中群星的碎片。");
            dialog.Add("在我以前的旅行中，我曾经顺路与一个商队同行，当时躺在马车里欣赏星空的场景，仍然让我历历在目。");
            dialog.Add("曾经有人对我说，即便是璀璨又浩瀚的繁星之中，也存在着污秽之物，那是什么意思？");
            return dialog.Get();
        }

		public override List<string> SetNPCNameList()
		{
            return new List<string> { "Lily", "Cookie", "Aurora", "Shiny" };
		}

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "原版材料";
            button2 = "模组材料";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = "VanillaMaterials";
            }
            else
            {
                shopName = "ModMaterials";
            }
        }

        public override void AddShops()
        {
            var vanillaMaterials = new NPCShop(Type, "VanillaMaterials");
            var modMaterials = new NPCShop(Type, "ModMaterials");

            #region 灾厄Mod的Boss击败条件
            Condition DownedDesertScourge = new Condition("DesertScourge", () => DownedBossSystem.downedDesertScourge);
            Condition DownedCrabulon = new Condition("Crabulon", () => DownedBossSystem.downedCrabulon);
            Condition DownedPerfs = new Condition("Perfs", () => DownedBossSystem.downedPerforator);
            Condition DownedHiveMind = new Condition("HiveMind", () => DownedBossSystem.downedHiveMind);
            Condition DownedPerfsHiveMind = new Condition("PerfsHiveMind", () => DownedBossSystem.downedPerforator || DownedBossSystem.downedHiveMind);
            Condition DownedSlimeGod = new Condition("SlimeGod", () => DownedBossSystem.downedSlimeGod);

            Condition DownedCryogen = new Condition("Cryogen", () => DownedBossSystem.downedCryogen);
            Condition DownedAquaticScourge = new Condition("AquaticScourge", () => DownedBossSystem.downedAquaticScourge);
            Condition DownedBrimstoneElemental = new Condition("BrimstoneElemental", () => DownedBossSystem.downedBrimstoneElemental);
            Condition DownedCloneCalamitas = new Condition("CalClone", () => DownedBossSystem.downedCalamitasClone);
            Condition DownedPlanteraCalClone = new Condition("PlanteraCalClone", () => DownedBossSystem.downedCalamitasClone || NPC.downedPlantBoss);
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
            #endregion

            #region 原版材料
            vanillaMaterials.Add(CustomPrice(ItemID.Bottle, buyPrice(0, 0, 0, 75)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BottledWater, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BottledHoney, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Daybloom, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Moonglow, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Blinkroot, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Waterleaf, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Deathweed, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Shiverthorn, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Fireblossom, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HerbBag, buyPrice(0, 0, 10, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Mushroom, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GlowingMushroom, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ViciousMushroom, buyPrice(0, 0, 3, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.VileMushroom, buyPrice(0, 0, 3, 0)), Array.Empty<Condition>())
                .Add(ItemID.Coral, Array.Empty<Condition>())
                .Add(ItemID.Seashell, Array.Empty<Condition>())
                .Add(ItemID.Starfish, Array.Empty<Condition>())
                .Add(ItemID.FallenStar, Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Bass, buyPrice(0, 2, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Obsidian, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CrispyHoneyBlock, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Gel, buyPrice(0, 0, 0, 50)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PinkGel, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Lens, buyPrice(0, 0, 0, 75)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BlackLens, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Cobweb, buyPrice(0, 0, 2, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FlinxFur, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.JungleSpores, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Stinger, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Vine, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Feather, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.AntlionMandible, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.RottenChunk, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.Vertebrae, buyPrice(0, 0, 1, 0)), Array.Empty<Condition>())
                .Add(ItemID.WormTooth, Array.Empty<Condition>())
                .Add(ItemID.SharkFin, Array.Empty<Condition>())
                .Add(ItemID.TatteredCloth, Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.TissueSample, buyPrice(0, 0, 8, 0)), new Condition[] { Condition.DownedEowOrBoc })
                .Add(CustomPrice(ItemID.ShadowScale, buyPrice(0, 0, 8, 0)), new Condition[] { Condition.DownedEowOrBoc })
                .Add(CustomPrice(ItemID.Bone, buyPrice(0, 0, 2, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(ItemID.SoulofLight, new Condition[] { Condition.Hardmode })
                .Add(ItemID.SoulofNight, new Condition[] { Condition.Hardmode })
                .Add(ItemID.SoulofFlight, new Condition[] { Condition.Hardmode })
                .Add(ItemID.CursedFlame, new Condition[] { Condition.Hardmode })
                .Add(ItemID.Ichor, new Condition[] { Condition.Hardmode })
                .Add(ItemID.DarkShard, new Condition[] { Condition.Hardmode })
                .Add(ItemID.LightShard, new Condition[] { Condition.Hardmode })
                .Add(ItemID.AncientCloth, new Condition[] { Condition.Hardmode })
                .Add(ItemID.PixieDust, new Condition[] { Condition.Hardmode })
                .Add(ItemID.UnicornHorn, new Condition[] { Condition.Hardmode })
                .Add(ItemID.CrystalShard, new Condition[] { Condition.Hardmode })
                .Add(ItemID.SpiderFang, new Condition[] { Condition.Hardmode })
                .Add(ItemID.FrostCore, new Condition[] { Condition.Hardmode })
                .Add(ItemID.AncientBattleArmorMaterial, new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.RodofDiscord, buyPrice(5, 0, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.SoulofMight, buyPrice(0, 1, 20, 0)), new Condition[] { Condition.DownedDestroyer })
                .Add(CustomPrice(ItemID.SoulofSight, buyPrice(0, 1, 20, 0)), new Condition[] { Condition.DownedTwins })
                .Add(CustomPrice(ItemID.SoulofFright, buyPrice(0, 1, 20, 0)), new Condition[] { Condition.DownedSkeletronPrime })
                .Add(CustomPrice(ItemID.HallowedBar, buyPrice(0, 1, 30, 0)), new Condition[] { Condition.DownedMechBossAny })
                .Add(CustomPrice(ItemID.TurtleShell, buyPrice(0, 1, 10, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.Ectoplasm, buyPrice(0, 1, 50, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.BrokenHeroSword, buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemID.LunarTabletFragment, buyPrice(0, 1, 50, 0)), new Condition[] { Condition.DownedPlantera })
                //由于灾厄Mod设定四柱小怪也会掉四柱碎片，所以就相当于击败教徒后而不击败天界柱就能获得碎片
                .Add(ItemID.FragmentSolar, new Condition[] { Condition.DownedCultist })
                .Add(ItemID.FragmentVortex, new Condition[] { Condition.DownedCultist })
                .Add(ItemID.FragmentNebula, new Condition[] { Condition.DownedCultist })
                .Add(ItemID.FragmentStardust, new Condition[] { Condition.DownedCultist });
            #endregion

            #region 模组材料
            //if (TryFind<ModItem>("yitangOthers/MagicMagnet", out ModItem MagicMagnet))
            //{
            //    modMaterials.Add(CustomPrice((MagicMagnet.Type, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>());
            //}
            modMaterials.Add(CustomPrice(ItemType<WulfrumMetalScrap>(), buyPrice(0, 0, 5, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<EnergyCore>(), buyPrice(0, 0, 10, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<DubiousPlating>(), buyPrice(0, 0, 10, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<MysteriousCircuitry>(), buyPrice(0, 0, 10, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<SeaPrism>(), buyPrice(0, 0, 10, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<PearlShard>(), buyPrice(0, 0, 20, 0)), new Condition[] { DownedDesertScourge })
                .Add(CustomPrice(ItemType<StormlionMandible>(), buyPrice(0, 0, 15, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<BlightedGel>(), buyPrice(0, 0, 6, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<MurkyPaste>(), buyPrice(0, 0, 15, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<AncientBoneDust>(), buyPrice(0, 0, 15, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<DemonicBoneAsh>(), buyPrice(0, 0, 25, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<BloodOrb>(), buyPrice(0, 0, 50, 50)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemType<SulphuricScale>(), buyPrice(0, 0, 20, 0)), new Condition[] { Condition.DownedEyeOfCthulhu })
                .Add(CustomPrice(ItemType<BloodSample>(), buyPrice(0, 0, 75, 0)), new Condition[] { DownedPerfs })
                .Add(CustomPrice(ItemType<RottenMatter>(), buyPrice(0, 0, 75, 0)), new Condition[] { DownedHiveMind })
                .Add(CustomPrice(ItemType<AerialiteOre>(), buyPrice(0, 0, 75, 0)), new Condition[] { DownedPerfsHiveMind })
                .Add(CustomPrice(ItemType<PurifiedGel>(), buyPrice(0, 0, 85, 0)), new Condition[] { DownedSlimeGod })
                .Add(CustomPrice(ItemType<MolluskHusk>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<EssenceofEleum>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<EssenceofSunlight>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<EssenceofHavoc>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<StarblightSoot>(), buyPrice(0, 0, 5, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<TrapperBulb>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<CryonicOre>(), buyPrice(0, 1, 5, 0)), new Condition[] { DownedCryogen })
                .Add(CustomPrice(ItemType<CorrodedFossil>(), buyPrice(0, 1, 5, 0)), new Condition[] { DownedAquaticScourge })
                .Add(CustomPrice(ItemType<UnholyCore>(), buyPrice(0, 1, 5, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<LivingShard>(), buyPrice(0, 1, 5, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemType<PerennialOre>(), buyPrice(0, 1, 5, 0)), new Condition[] { Condition.DownedPlantera })
                .Add(CustomPrice(ItemType<AshesofCalamity>(), buyPrice(0, 1, 5, 0)), new Condition[] { DownedCloneCalamitas })
                .Add(CustomPrice(ItemType<SolarVeil>(), buyPrice(0, 1, 5, 0)), new Condition[] { DownedPlanteraCalClone })
                .Add(CustomPrice(ItemType<DepthCells>(), buyPrice(0, 1, 5, 0)), new Condition[] { DownedLeviathan })
                .Add(CustomPrice(ItemType<Lumenyl>(), buyPrice(0, 1, 5, 0)), new Condition[] { DownedLeviathan })
                .Add(CustomPrice(ItemType<AureusCell>(), buyPrice(0, 1, 5, 0)), new Condition[] { DownedAureus })
                .Add(CustomPrice(ItemType<PlagueCellCanister>(), buyPrice(0, 1, 10, 0)), new Condition[] { Condition.DownedGolem })
                .Add(CustomPrice(ItemType<ScoriaOre>(), buyPrice(0, 1, 10, 0)), new Condition[] { Condition.DownedGolem })
                .Add(CustomPrice(ItemType<MeldBlob>(), buyPrice(0, 1, 20, 0)), new Condition[] { Condition.DownedCultist })
                .Add(CustomPrice(ItemType<AstralOre>(), buyPrice(0, 1, 20, 0)), new Condition[] { DownedDeus })
                .Add(CustomPrice(ItemType<GalacticaSingularity>(), buyPrice(0, 1, 25, 0)), new Condition[] { Condition.DownedCultist });
            if (TryFind<ModItem>("CatalystMod/AstraJelly", out ModItem AstraJelly))
            {
                modMaterials.Add(CustomPrice(AstraJelly.Type, buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode });
            }
            if (TryFind<ModItem>("CatalystMod/MetanovaOre", out ModItem MetanovaOre))
            {
                modMaterials.Add(CustomPrice(MetanovaOre.Type, buyPrice(0, 1, 70, 0)), new Condition[] { ModConditions.DownedAstrageldon });
            }
            modMaterials.Add(CustomPrice(ItemType<ExodiumCluster>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.DownedMoonLord })
                .Add(CustomPrice(ItemType<UnholyEssence>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.DownedMoonLord })
                .Add(CustomPrice(ItemType<Necroplasm>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.DownedMoonLord })
                .Add(CustomPrice(ItemType<EffulgentFeather>(), buyPrice(0, 1, 70, 0)), new Condition[] { DownedDragonfolly })
                .Add(CustomPrice(ItemType<ProfanedGuardianPlush>(), buyPrice(0, 1, 70, 0)), new Condition[] { DownedGuardians })
                .Add(CustomPrice(ItemType<DivineGeode>(), buyPrice(0, 2, 0, 0)), new Condition[] { DownedProvidence })
                .Add(CustomPrice(ItemType<UelibloomOre>(), buyPrice(0, 2, 0, 0)), new Condition[] { DownedProvidence })
                .Add(CustomPrice(ItemType<Bloodstone>(), buyPrice(0, 2, 0, 0)), new Condition[] { DownedProvidence })
                .Add(CustomPrice(ItemType<ArmoredShell>(), buyPrice(0, 2, 50, 0)), new Condition[] { DownedStormWeaver })
                .Add(CustomPrice(ItemType<DarkPlasma>(), buyPrice(0, 2, 50, 0)), new Condition[] { DownedCeaselessVoid })
                .Add(CustomPrice(ItemType<TwistingNether>(), buyPrice(0, 2, 50, 0)), new Condition[] { DownedSignus })
                .Add(CustomPrice(ItemType<RuinousSoul>(), buyPrice(0, 2, 50, 0)), new Condition[] { DownedPolterghast })
                .Add(CustomPrice(ItemType<ReaperTooth>(), buyPrice(0, 2, 50, 0)), new Condition[] { DownedPolterghast })
                .Add(CustomPrice(ItemType<CosmiliteBar>(), buyPrice(0, 3, 0, 0)), new Condition[] { DownedDevourerOfGods })
                .Add(CustomPrice(ItemType<EndothermicEnergy>(), buyPrice(0, 3, 50, 0)), new Condition[] { DownedDevourerOfGods })
                .Add(CustomPrice(ItemType<NightmareFuel>(), buyPrice(0, 3, 50, 0)), new Condition[] { DownedDevourerOfGods })
                .Add(CustomPrice(ItemType<DarksunFragment>(), buyPrice(0, 3, 50, 0)), new Condition[] { DownedDevourerOfGods })
                .Add(CustomPrice(ItemType<YharonSoulFragment>(), buyPrice(0, 4, 0, 0)), new Condition[] { DownedYharon })
                .Add(CustomPrice(ItemType<AuricOre>(), buyPrice(0, 4, 50, 0)), new Condition[] { DownedYharon })
                .Add(CustomPrice(ItemType<ExoPrism>(), buyPrice(0, 5, 0, 0)), new Condition[] { DownedExoMechs })
                .Add(CustomPrice(ItemType<AshesofAnnihilation>(), buyPrice(0, 5, 0, 0)), new Condition[] { DownedSuperCalamitas });
            #endregion

            vanillaMaterials.Register();
            modMaterials.Register();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 5f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.SuperStar;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}