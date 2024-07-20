using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.Item;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod.Items.Fishing;
using CalamityMod.Items.Critters;
using CalamityMod.Items.Fishing.AstralCatches;
using CalamityMod.Items.Fishing.SunkenSeaCatches;
using CalamityMod.Items.Fishing.BrimstoneCragCatches;
using CalamityMod.Items.Placeables;
using static yitangCalamity.yitangCalamity;
using yitangCalamity.Global.Config;

namespace yitangCalamity.NPCs
{
    [AutoloadHead]
    internal class Harpy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Like)
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
                .SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Like)
                .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Merchant, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Hate);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.Add(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface);
            bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("因翅膀受伤从天空掉落后被人类所救，之后由于无法再次飞翔，这个名叫哈比的鸟妖便一直生活在了地面上。她将出售以前她在大自然里遇到的各种小动物、植物和渔获。"));
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = NPCAIStyleID.Passive;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (int k = 0; k < Main.maxPlayers; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }
                if (player.inventory.Any(item => item.type == ItemID.Bass))
                {
                    return ytCalamityConfig.Instance.ytNPCHarpy;
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string> { "Harpy" };
        }

        public override string GetChat()
        {
            if (Main.dayTime)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return "你知道的，雨天会导致飞行困难，所以我喜欢阳光明媚的天气！";
                }
            }
            if (Main.raining)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return "之前我在海里捕鱼的时候，老是会捞上来垃圾，到底是谁在往水里乱扔东西呀？";
                }
            }
            switch (Main.rand.Next(8))
            {
                case 0:
                    return "离开天空后，回归大自然，于是我开始尝试去接触植物和小动物。";
                case 1:
                    return "曾经有人告诉我，种植和保护植物可是件难事，这需要耐心、努力和奉献。";
                case 2:
                    return "我对泰拉瑞亚小动物们的收集几乎快完成了。";
                case 3:
                    return "虽然有很多植物种子，但我这里可没有什么神奇的通天魔豆。";
                case 4:
                    return "俗话说得好，授人以鱼不如授人以渔。所以我去抓了很多，要看一看嘛。";
                case 5:
                    return "之前我在海里捕鱼的时候，老是会捞上来垃圾，到底是谁在往水里乱扔东西呀？";
                case 6:
                    return "你去过硫磺海吗？我敢打赌，那片大海以前绝对不是现在这个样子……把环境变成那样，如此恶劣的行为！真的很讨厌呢。";
				default:
                    return "飞翔的感觉很有趣，也很棒……但有时我也会幻想拥有一双手臂。";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "动植物";
            button2 = "渔获";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "PlantsCritters";
            }
            else
            {
                shop = "Fishery";
            }

        }

        public override void AddShops()
        {
            var ps = new NPCShop(Type, "PlantsCritters");
            var fishery = new NPCShop(Type, "Fishery");

            #region 动植物

            #region 植物和草种子
            //蘑菇↓
            ps.Add(CustomPrice(ItemID.Mushroom, buyPrice(0, 0, 0, 10)))
                .Add(CustomPrice(ItemID.GlowingMushroom, buyPrice(0, 0, 0, 25)))
                .Add(CustomPrice(ItemID.ViciousMushroom, buyPrice(0, 0, 0, 25)))
                .Add(CustomPrice(ItemID.VileMushroom, buyPrice(0, 0, 0, 25)))
                //草种子↓
                .Add(CustomPrice(ItemID.GrassSeeds, buyPrice(0, 0, 0, 10)))
                .Add(CustomPrice(ItemID.JungleGrassSeeds, buyPrice(0, 0, 0, 25)))
                .Add(CustomPrice(ItemID.MushroomGrassSeeds, buyPrice(0, 0, 0, 25)))
                .Add(CustomPrice(ItemID.CrimsonSeeds, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.CorruptSeeds, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.AshGrassSeeds, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.HallowedSeeds, buyPrice(0, 0, 1, 0)), new Condition[] { Condition.Hardmode })
                //草药和草药种子↓
                .Add(CustomPrice(ItemID.Acorn, buyPrice(0, 0, 0, 10)))
                .Add(CustomPrice(ItemID.Daybloom, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.DaybloomSeeds, buyPrice(0, 0, 0, 5)))
                .Add(CustomPrice(ItemID.Blinkroot, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.BlinkrootSeeds, buyPrice(0, 0, 0, 5)))
                .Add(CustomPrice(ItemID.Moonglow, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.MoonglowSeeds, buyPrice(0, 0, 0, 5)))
                .Add(CustomPrice(ItemID.Waterleaf, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.WaterleafSeeds, buyPrice(0, 0, 0, 5)))
                .Add(CustomPrice(ItemID.Shiverthorn, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.ShiverthornSeeds, buyPrice(0, 0, 0, 5)))
                .Add(CustomPrice(ItemID.Deathweed, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.DeathweedSeeds, buyPrice(0, 0, 0, 5)))
                .Add(CustomPrice(ItemID.Fireblossom, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.FireblossomSeeds, buyPrice(0, 0, 0, 5)))
                //其他植物和种子↓
                .Add(CustomPrice(ItemID.Pumpkin, buyPrice(0, 0, 0, 50)))
                .Add(CustomPrice(ItemID.PumpkinSeed, buyPrice(0, 0, 0, 5)))
            #endregion

            #region 小动物
                //森林↓
                .Add(ItemID.LadyBug)
                .Add(ItemID.Bird)
                .Add(ItemID.BlueJay)
                .Add(ItemID.Cardinal)
                .Add(ItemID.Bunny)
                .Add(ItemID.Squirrel)
                .Add(ItemID.SquirrelRed)
                .Add(ItemID.Worm)
                .Add(ItemID.TruffleWorm, new Condition[] { Condition.Hardmode })
                .Add(ItemID.Grasshopper)
                .Add(ItemID.Goldfish)
                .Add(ItemID.Turtle)
                .Add(ItemID.Duck)
                .Add(ItemID.MallardDuck)
                .Add(ItemID.WaterStrider)
                .Add(ItemID.Stinkbug)
                //森林夜晚↓
                .Add(ItemID.Firefly)
                .Add(ItemID.Owl)
                .Add(ItemID.FairyCritterBlue)
                .Add(ItemID.FairyCritterGreen)
                .Add(ItemID.FairyCritterPink)
                //丛林↓
                .Add(ItemID.Grubby)
                .Add(ItemID.Sluggy)
                .Add(ItemID.Buggy)
                .Add(ItemID.Frog)
                .Add(ItemID.TurtleJungle)
                .Add(ItemID.YellowCockatiel)
                .Add(ItemID.GrayCockatiel)
                .Add(ItemID.ScarletMacaw)
                .Add(ItemID.BlueMacaw)
                .Add(ItemID.Toucan)
                //雪原↓
                .Add(ItemID.Penguin)
                //沙漠↓
                .Add(ItemID.Scorpion)
                .Add(ItemID.BlackScorpion)
                .Add(ItemID.Grebe)
                .Add(ItemID.Pupfish)
                //地下和洞穴↓
                .Add(ItemID.Snail)
                .Add(ItemID.Mouse)
                //发光蘑菇↓
                .Add(ItemID.GlowingSnail)
                //海洋↓
                .Add(ItemID.Seagull)
                .Add(ItemID.Seahorse)
                //地狱↓
                .Add(ItemID.Lavafly)
                .Add(ItemID.MagmaSnail)
                //墓地↓
                .Add(ItemID.Rat)
                .Add(ItemID.Maggot)
                //微光↓
                .Add(ItemID.Shimmerfly)
                //神圣之地↓
                .Add(ItemID.LightningBug, new Condition[] { Condition.Hardmode })
                //蝴蝶↓
                .Add(ItemID.MonarchButterfly)
                .Add(ItemID.SulphurButterfly)
                .Add(ItemID.JuliaButterfly)
                .Add(ItemID.UlyssesButterfly)
                .Add(ItemID.ZebraSwallowtailButterfly)
                .Add(ItemID.PurpleEmperorButterfly)
                .Add(ItemID.RedAdmiralButterfly)
                .Add(ItemID.TreeNymphButterfly)
                .Add(ItemID.HellButterfly)
                .Add(ItemID.EmpressButterfly, new Condition[] { Condition.DownedPlantera })
                //蜻蜓↓
                .Add(ItemID.RedDragonfly)
                .Add(ItemID.BlueDragonfly)
                .Add(ItemID.GreenDragonfly)
                .Add(ItemID.YellowDragonfly)
                .Add(ItemID.BlackDragonfly)
                .Add(ItemID.OrangeDragonfly)
				//(yitang的走后门操作)
				.Add(CustomPrice(ItemType<CharredLasher>(), buyPrice(0, 1, 0, 0)))
			#endregion

			#region 染料
				//染料↓
				.Add(CustomPrice(ItemID.RedHusk, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.OrangeBloodroot, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.YellowMarigold, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.LimeKelp, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.GreenMushroom, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.TealMushroom, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.CyanHusk, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.SkyBlueFlower, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.BlueBerries, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.PurpleMucos, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.VioletHusk, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.PinkPricklyPear, buyPrice(0, 1, 0, 0)))
                .Add(CustomPrice(ItemID.BlackInk, buyPrice(0, 1, 0, 0)));
            #endregion

            #endregion

            #region 渔获

            #region 原版
            //珊瑚海星贝壳↓
            fishery.Add(ItemID.Coral)
                .Add(ItemID.Seashell)
                .Add(ItemID.Starfish)
                //渔夫任务鱼饵↓
                .Add(ItemID.ApprenticeBait)
                .Add(ItemID.JourneymanBait)
                .Add(ItemID.MasterBait)
                .Add(CustomPrice(ItemType<GrandMarquisBait>(), buyPrice(0, 1, 0, 0)))
                //水母鱼饵↓
                .Add(ItemID.BlueJellyfish)
                .Add(ItemID.GreenJellyfish)
                .Add(ItemID.PinkJellyfish)
                //血月鱼饵桶↓
                .Add(ItemID.ChumBucket)
                //鱼-普通↓
                .Add(ItemID.Bass)
                .Add(ItemID.ArmoredCavefish)
                .Add(ItemID.SpecularFish)
                .Add(ItemID.Stinkfish)
                .Add(ItemID.BombFish)
                //鱼-雪原↓
                .Add(ItemID.AtlanticCod)
                .Add(ItemID.FrostMinnow)
                .Add(ItemID.FrostDaggerfish)
                //鱼-丛林↓
                .Add(ItemID.NeonTetra)
                .Add(ItemID.DoubleCod)
                .Add(ItemID.VariegatedLardfish)
                .Add(ItemID.Honeyfin)
                //鱼-沙漠↓
                .Add(ItemID.Oyster)
                .Add(ItemID.Flounder)
                .Add(ItemID.RockLobster)
                //鱼-天空↓
                .Add(ItemID.Salmon)
                .Add(ItemID.Damselfish)
                //鱼-海洋↓
                .Add(ItemID.Shrimp)
                .Add(ItemID.RedSnapper)
                .Add(ItemID.Trout)
                .Add(ItemID.Tuna)
                //鱼-猩红之地↓
                .Add(ItemID.CrimsonTigerfish)
                .Add(ItemID.Hemopiranha)
                //鱼-腐化之地↓
                .Add(ItemID.Ebonkoi)
                //鱼-熔岩↓
                .Add(ItemID.FlarefinKoi)
                .Add(ItemID.Obsidifish)
                //鱼-神圣之地↓
                .Add(ItemID.PrincessFish)
                .Add(ItemID.Prismite)
                .Add(ItemID.ChaosFish)
                //鱼-其他↓
                .Add(ItemID.OldShoe)
                .Add(ItemID.FishingSeaweed)
                .Add(ItemID.TinCan)
                .Add(ItemID.GoldenCarp)
            #endregion

            #region 模组
                //鱼饵↓
                .Add(CustomPrice(ItemType<BabyGhostBellItem>(), buyPrice(0, 0, 10, 0)))
                .Add(CustomPrice(ItemType<SeaMinnowItem>(), buyPrice(0, 0, 10, 0)))
                .Add(CustomPrice(ItemType<TwinklerItem>(), buyPrice(0, 0, 20, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<ArcturusAstroidean>(), buyPrice(0, 0, 20, 0)), new Condition[] { Condition.Hardmode })
                //鱼↓
                .Add(CustomPrice(ItemType<EnchantedStarfish>(), buyPrice(0, 1, 50, 0)))
                //鱼-沉沦之海↓
                .Add(CustomPrice(ItemType<PrismaticGuppy>(), buyPrice(0, 0, 10, 0)))
                .Add(CustomPrice(ItemType<SunkenSailfish>(), buyPrice(0, 0, 10, 0)))
                .Add(CustomPrice(ItemType<GreenwaveLoach>(), buyPrice(0, 5, 0, 0)))
                //鱼-硫磺海↓
                .Add(CustomPrice(ItemType<PlantyMush>(), buyPrice(0, 0, 15, 0)))
                //鱼-硫火之崖↓
                .Add(CustomPrice(ItemType<Shadowfish>(), buyPrice(0, 0, 10, 0)))
                .Add(CustomPrice(ItemType<CoastalDemonfish>(), buyPrice(0, 0, 10, 0)))
                .Add(CustomPrice(ItemType<CharredLasher>(), buyPrice(0, 10, 0, 0)))
                //鱼-星辉瘟疫↓
                .Add(CustomPrice(ItemType<TwinklingPollox>(), buyPrice(0, 0, 10, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<ProcyonidPrawn>(), buyPrice(0, 0, 10, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<AldebaranAlewife>(), buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode })
                //鱼-摸彩袋
                .Add(CustomPrice(ItemType<StuffedFish>(), buyPrice(0, 1, 50, 0)))
                .Add(CustomPrice(ItemType<GlimmeringGemfish>(), buyPrice(0, 2, 0, 0)))
                .Add(CustomPrice(ItemType<Gorecodile>(), buyPrice(0, 3, 50, 0)))
                .Add(CustomPrice(ItemType<FishofEleum>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<FishofLight>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<FishofNight>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<FishofFlight>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<SunbeamFish>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemType<Havocfish>(), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.Hardmode });
            #endregion

            #endregion

            ps.Register();
            fishery.Register();
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 3f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 20;
            randExtraCooldown = 20;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Leaf;
            attackDelay = 20;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 5;
        }
    }
}