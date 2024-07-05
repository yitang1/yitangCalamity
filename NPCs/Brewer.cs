using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.Item;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;
using CalamityMod;
using CalamityMod.Items.Potions;
using CalamityMod.Items.Potions.Alcohol;
using CalamityMod.Items.Fishing.BrimstoneCragCatches;
using static yitangCalamity.yitangCalamity;
using yitangCalamity.Content.Items.Materials;
using yitangCalamity.Global.Config;
//using yitangCalamity.Content.Items.Potions;

namespace yitangCalamity.NPCs
{
	[AutoloadHead]
    internal class Brewer : ModNPC
    {
        public override void SetStaticDefaults()
		{
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
                .SetBiomeAffection<JungleBiome>(AffectionLevel.Like)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
                .SetNPCAffection<StarMerchant>(AffectionLevel.Like);
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
            AnimationType = NPCID.Mechanic;
        }

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.Add(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface);
			bestiaryEntry.Info.Add(new FlavorTextBestiaryInfoElement("药剂师制作并出售各种各样的药水供你购买，同时，她还有着研究神秘炼金术的兴趣。"));
		}

		public override bool UsesPartyHat()
		{
			return true;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs)
		{
			return numTownNPCs > 4 && ytCalamityConfig.Instance.ytNPCBrewer;
		}

		public override string GetChat()
		{
            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        return "天上的那个是血月吗？我喜欢！它看起来好漂亮！";
                    case 1:
                        return "我出生的时候正好是血月，每当它升起时我都会变得很兴奋！";
                    case 2:
                        return "是的，我能理解为什么其他女孩们会生气，但这并不能阻止我的快乐！";
                    case 3:
                        return "就算你说现在和我一样开心，我也不会给你打折的——我又不是傻子，笨蛋。";
                }
            }
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (Main.bloodMoon && partyGirl >= 0 && Main.rand.Next(4) == 0)
            {
                return "通常我会很困惑为什么派对女孩" + Main.npc[partyGirl].GivenName + "和我一样从容冷静，但是后来我明白了。";
            }
            if (Main.invasionType == 1)
            {
                return "啊嚏！噫……那些哥布林在附近时我总是打喷嚏！";
            }
            if (Main.invasionType == 3)
            {
                return "别让他们进入我的房子……我这儿有那么多的材料和仪器。";
            }
            if (Main.invasionType == 4)
            {
                return "这是一场外星入侵吗？他们会奴役我们所有人吗？亦或是毁灭我们？没人知道答案……";
            }
            var dialog = new Terraria.Utilities.WeightedRandom<string>();
            dialog.Add("要试试这药水吗？它应该会强化翅膀。");
            dialog.Add("我不认为那是洞穴探险药水……");
            dialog.Add("我得到了来自谜语大学的学位。");
            dialog.Add("有一个传说中的悠悠球被称为萨斯卡德。");
            dialog.Add("哇哦，面包屑和海狸唾液！");
            dialog.Add("嗨，咳咳……那不是狱火药水！");
            dialog.Add("你有在附近看到双子魔眼吗？");
            dialog.Add("我曾经远离泰拉大陆去了解更多有关炼金术的知识。在旅行途中，我遇到了一位“魔法科学家”，他向我展示了一种叫做“奇术”的魔法。");
            return dialog.Get();
        }

		public override List<string> SetNPCNameList()
		{
			return new List<string> { "Lillian", "Lucy", "Alice", "Mary" };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "原版药水";
            button2 = "模组药水";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = "VanillaPotions";
            }
            else
            {
                shopName = "ModPotions";
            }
        }

        public override void AddShops()
        {
            var vanillaPotions = new NPCShop(Type, "VanillaPotions");
            var modPotions = new NPCShop(Type, "ModPotions");

            #region Boss击败条件
            //以下是灾厄的Boss击败条件
            //去CalamityMod\Downed.cs里找灾厄各个Boss的对应Condition名
            //关于原版的Condition条件都在tModLoader-1.4.4\patches\tModLoader\Terraria\Condition.cs里
            //模组条件+原版条件的组合 => DownedBossSystem.downedCalamitasClone || NPC.downedPlantBoss);
            Condition DownedDesertScourge = new Condition("DesertScourge", () => DownedBossSystem.downedDesertScourge);
            Condition DownedPerfs = new Condition("Perfs", () => DownedBossSystem.downedPerforator);
            Condition DownedHiveMind = new Condition("HiveMind", () => DownedBossSystem.downedHiveMind);
            Condition DownedPerfsHiveMind = new Condition("PerfsHiveMind", () => DownedBossSystem.downedPerforator || DownedBossSystem.downedHiveMind);
            Condition DownedSlimeGod = new Condition("SlimeGod", () => DownedBossSystem.downedSlimeGod);
            
            Condition DownedCryogen = new Condition("Cryogen", () => DownedBossSystem.downedCryogen);
            Condition DownedAquaticScourge = new Condition("AquaticScourge", () => DownedBossSystem.downedAquaticScourge);
            Condition DownedCloneCalamitas = new Condition("CalClone", () => DownedBossSystem.downedCalamitasClone);
            Condition DownedPlanteraCalClone = new Condition("PlanteraCalClone", () => DownedBossSystem.downedCalamitasClone || NPC.downedPlantBoss);
            Condition DownedLeviathan = new Condition("Leviathan", () => DownedBossSystem.downedLeviathan);
            Condition DownedAureus = new Condition("Aureus", () => DownedBossSystem.downedAstrumAureus);
            Condition DownedDeus = new Condition("Deus", () => DownedBossSystem.downedAstrumDeus);
            
            Condition DownedDragonfolly = new Condition("Dragonfolly", () => DownedBossSystem.downedDragonfolly);
            Condition DownedGuardians = new Condition("Guardians", () => DownedBossSystem.downedGuardians);
            Condition DownedProvidence = new Condition("Providence", () => DownedBossSystem.downedProvidence);
            Condition DownedProPo = new Condition("ProPo", () => DownedBossSystem.downedProvidence || DownedBossSystem.downedPolterghast);
            Condition DownedStormWeaver = new Condition("StormWeaver", () => DownedBossSystem.downedStormWeaver);
            Condition DownedCeaselessVoid = new Condition("CeaselessVoid", () => DownedBossSystem.downedCeaselessVoid);
            Condition DownedSignus = new Condition("Signus", () => DownedBossSystem.downedSignus);
            Condition DownedPolterghast = new Condition("Polterghast", () => DownedBossSystem.downedPolterghast);
            Condition DownedDevourerOfGods = new Condition("DoG", () => DownedBossSystem.downedDoG);
            Condition DownedYharon = new Condition("Yharon", () => DownedBossSystem.downedYharon);
            Condition DownedExoMechs = new Condition("ExoMechs", () => DownedBossSystem.downedExoMechs);
            Condition DownedSuperCalamitas = new Condition("SCal", () => DownedBossSystem.downedCalamitas);

            //特殊的定制击败条件
            Condition DownedSkeletronPreMode = new Condition("SkePre", () => NPC.downedBoss3 && !Main.hardMode);
            #endregion

            #region 治疗药水和魔力药水
            //原版和灾厄的治疗药水
            vanillaPotions.Add(CustomPrice(ItemID.HealingPotion, buyPrice(0, 0, 5, 0)), Array.Empty<Condition>());
            vanillaPotions.Add(CustomPrice(ItemID.Honeyfin, buyPrice(0, 0, 25, 0)), Array.Empty<Condition>());
            modPotions.Add(CustomPrice(ItemType<HadalStew>(), buyPrice(0, 0, 75, 0)), Array.Empty<Condition>());
            vanillaPotions.Add(CustomPrice(ItemID.GreaterHealingPotion, buyPrice(0, 0, 50, 0)), new Condition[] { Condition.Hardmode });
            vanillaPotions.Add(CustomPrice(ItemID.SuperHealingPotion, buyPrice(0, 1, 0, 0)), new Condition[] { Condition.DownedCultist });
            modPotions.Add(CustomPrice(ItemType<Bloodfin>(), buyPrice(0, 1, 50, 0)), new Condition[] { DownedProvidence });
            modPotions.Add(CustomPrice(ItemType<SupremeHealingPotion>(), buyPrice(0, 1, 50, 0)), new Condition[] { DownedProPo });
            modPotions.Add(CustomPrice(ItemType<OmegaHealingPotion>(), buyPrice(0, 2, 0, 0)), new Condition[] { DownedDevourerOfGods });
            //原版和灾厄的魔力药水
            vanillaPotions.Add(CustomPrice(ItemID.ManaPotion, buyPrice(0, 0, 3, 0)), Array.Empty<Condition>());
            vanillaPotions.Add(CustomPrice(ItemID.SuperManaPotion, buyPrice(0, 0, 70, 0)), new Condition[] { Condition.Hardmode });
            modPotions.Add(CustomPrice(ItemType<SupremeManaPotion>(), buyPrice(0, 1, 10, 0)), new Condition[] { Condition.DownedMoonLord });
            vanillaPotions.Add(CustomPrice(ItemID.Burger, buyPrice(0, 5, 0, 0)), Array.Empty<Condition>());
            vanillaPotions.Add(CustomPrice(ItemID.PotatoChips, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>());
            #endregion

            #region 战斗类药水
            //战斗类的药水
            vanillaPotions.Add(CustomPrice(ItemID.RegenerationPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SwiftnessPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.IronskinPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.AmmoReservationPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ArcheryPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ManaRegenerationPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.MagicPowerPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SummoningPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HeartreachPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.EndurancePotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ThornsPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.RagePotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WrathPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.InfernoPotion, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LifeforcePotion, buyPrice(0, 1, 0, 0)), new Condition[] { Condition.DownedSkeletron })
                .Add(CustomPrice(ItemID.TitanPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WarmthPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FlaskofIchor, buyPrice(0, 1, 70, 0)), new Condition[] { Condition.Hardmode })
                .Add(CustomPrice(ItemID.BattlePotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CalmingPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>());
			//灾厄Mod部分药水和灌注瓶
			modPotions.Add(CustomPrice(ItemType<FlaskOfCrumbling>(), buyPrice(0, 2, 0, 0)), new Condition[] { Condition.Hardmode })
				.Add(CustomPrice(ItemType<FlaskOfBrimstone>(), buyPrice(0, 3, 0, 0)), new Condition[] { DownedCloneCalamitas })
				.Add(CustomPrice(ItemType<FlaskOfHolyFlames>(), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedMoonLord })
				.Add(CustomPrice(ItemType<BoundingPotion>(), buyPrice(0, 1, 20, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemType<CalciumPotion>(), buyPrice(0, 1, 20, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemType<SulphurskinPotion>(), buyPrice(0, 1, 20, 0)), Array.Empty<Condition>())
				//.Add(CustomPrice(ItemType<TriumphPotion>(), buyPrice(0, 1, 20, 0)), new Condition[] { DownedDesertScourge })
				//.Add(CustomPrice(ItemType<CadencePotion>(), buyPrice(0, 1, 20, 0)), new Condition[] { Condition.DownedSkeletron })
				//.Add(CustomPrice(ItemType<YharimsStimulants>(), buyPrice(0, 1, 20, 0)), new Condition[] { Condition.DownedSkeletron })
				//.Add(CustomPrice(ItemType<RevivifyPotion>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.Hardmode })
				.Add(CustomPrice(ItemType<PhotosynthesisPotion>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.Hardmode })
				.Add(CustomPrice(ItemType<SoaringPotion>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.Hardmode })
				.Add(CustomPrice(ItemType<FabsolsVodka>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.Hardmode })
				.Add(CustomPrice(ItemType<AstralInjection>(), buyPrice(0, 1, 50, 0)), new Condition[] { DownedAureus })
				.Add(CustomPrice(ItemType<GravityNormalizerPotion>(), buyPrice(0, 1, 50, 0)), new Condition[] { DownedAureus })
				//.Add(CustomPrice(ItemType<TitanScalePotion>(), buyPrice(0, 1, 50, 0)), new Condition[] { Condition.DownedGolem })
				.Add(CustomPrice(ItemType<CeaselessHungerPotion>(), buyPrice(0, 3, 0, 0)), new Condition[] { DownedCeaselessVoid });
                //.Add(CustomPrice(ItemType<DraconicElixir>(), buyPrice(0, 2, 0, 0)), new Condition[] { DownedYharon })
                //源自炼金术士Mod的部分药水
                //.Add(CustomPrice(ItemType<SunshinePotion>(), buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                //.Add(CustomPrice(ItemType<FortitudePotion>(), buyPrice(0, 1, 50, 0)), Array.Empty<Condition>())
                //.Add(CustomPrice(ItemType<InvincibilityPotion>(), buyPrice(0, 2, 0, 0)), new Condition[] { Condition.Hardmode })
                //.Add(CustomPrice(ItemType<BlurringPotion>(), buyPrice(0, 2, 0, 0)), new Condition[] { Condition.DownedMechBossAll })
                //.Add(CustomPrice(ItemType<NinjaPotion>(), buyPrice(0, 2, 0, 0)), new Condition[] { Condition.DownedPlantera });
            
            #endregion

            #region 实用类药水
            //实用类的药水
            vanillaPotions
                .Add(CustomPrice(ItemID.NightOwlPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ShinePotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SpelunkerPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.ObsidianSkinPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.TrapsightPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.HunterPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.MiningPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
				.Add(CustomPrice(ItemID.BuilderPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GravitationPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FeatherfallPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FlipperPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GillsPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WaterWalkingPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.FishingPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.SonarPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.CratePotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LuckPotionLesser, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LuckPotion, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LuckPotionGreater, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.InvisibilityPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.GenderChangePotion, buyPrice(0, 2, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.LovePotion, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.StinkPotion, buyPrice(0, 1, 0, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.BiomeSightPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.RecallPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.WormholePotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.PotionOfReturn, buyPrice(0, 0, 80, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.TeleportationPotion, buyPrice(0, 0, 50, 0)), Array.Empty<Condition>())
                .Add(CustomPrice(ItemID.RedPotion, buyPrice(0, 1, 50, 0)), Array.Empty<Condition>());
            modPotions.Add(CustomPrice(ItemType<ZenPotion>(), buyPrice(0, 1, 20, 0)), new Condition[] { DownedSlimeGod })
                .Add(CustomPrice(ItemType<ZergPotion>(), buyPrice(0, 1, 20, 0)), new Condition[] { DownedSlimeGod });
            #endregion

            #region LuiAFK懒人Mod的无限增益物品
            //探索卷轴(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedExplorer", out ModItem UnlimitedExplorer))
            {
                modPotions.Add(CustomPrice((UnlimitedExplorer.Type), buyPrice(0, 5, 0, 0)), Array.Empty<Condition>());
            }
            //基础增益卷轴(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedBasics", out ModItem UnlimitedBasics))
            {
                modPotions.Add(CustomPrice((UnlimitedBasics.Type), buyPrice(0, 2, 50, 0)), Array.Empty<Condition>());
            }
            //伤害卷轴的合成材料(骷髅王后合并为一个)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedRage", out ModItem UnlimitedRage))
            {
                modPotions.Add(CustomPrice((UnlimitedRage.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.NotDownedSkeletron });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedWrath", out ModItem UnlimitedWrath))
            {
                modPotions.Add(CustomPrice((UnlimitedWrath.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.NotDownedSkeletron });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedSummoning", out ModItem UnlimitedSummoning))
            {
                modPotions.Add(CustomPrice((UnlimitedSummoning.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.NotDownedSkeletron });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedThorns", out ModItem UnlimitedThorns))
            {
                modPotions.Add(CustomPrice((UnlimitedThorns.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.NotDownedSkeletron });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedInferno", out ModItem UnlimitedInferno))
            {
                modPotions.Add(CustomPrice((UnlimitedInferno.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.NotDownedSkeletron });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedDamage", out ModItem UnlimitedDamage))
            {
                modPotions.Add(CustomPrice((UnlimitedDamage.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedSkeletron });
            }
            //防御卷轴的合成材料(骷髅王后合并为一个)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedHeartreach", out ModItem UnlimitedHeartreach))
            {
                modPotions.Add(CustomPrice((UnlimitedHeartreach.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.NotDownedSkeletron });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedWarmth", out ModItem UnlimitedWarmth))
            {
                modPotions.Add(CustomPrice((UnlimitedWarmth.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.NotDownedSkeletron });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedEndurance", out ModItem UnlimitedEndurance))
            {
                modPotions.Add(CustomPrice((UnlimitedEndurance.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.NotDownedSkeletron });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedDefense", out ModItem UnlimitedDefense))
            {
                modPotions.Add(CustomPrice((UnlimitedDefense.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.DownedSkeletron });
            }
            //战士卷轴(肉后合并)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedTipsy", out ModItem UnlimitedTipsy))
            {
                modPotions.Add(CustomPrice((UnlimitedTipsy.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.PreHardmode });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedMelee", out ModItem UnlimitedMelee))
            {
                modPotions.Add(CustomPrice((UnlimitedMelee.Type), buyPrice(0, 3, 0, 0)), new Condition[] { Condition.Hardmode });
            }
            //射手卷轴(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedRange", out ModItem UnlimitedRange))
            {
                modPotions.Add(CustomPrice((UnlimitedRange.Type), buyPrice(0, 3, 0, 0)), Array.Empty<Condition>());
            }
            //魔法卷轴(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedMagic", out ModItem UnlimitedMagic))
            {
                modPotions.Add(CustomPrice((UnlimitedMagic.Type), buyPrice(0, 3, 0, 0)), Array.Empty<Condition>());
            }
            //增益站卷轴(肉后合并)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedAmmoBox", out ModItem UnlimitedAmmoBox))
            {
                modPotions.Add(CustomPrice((UnlimitedAmmoBox.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.PreHardmode });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedSharpeningStation", out ModItem UnlimitedSharpeningStation))
            {
                modPotions.Add(CustomPrice((UnlimitedSharpeningStation.Type), buyPrice(0, 1, 0, 0)), new Condition[] { Condition.PreHardmode });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedBewitchingTable", out ModItem UnlimitedBewitchingTable))
            {
                modPotions.Add(CustomPrice((UnlimitedBewitchingTable.Type), buyPrice(0, 1, 0, 0)), new Condition[] { DownedSkeletronPreMode });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedSliceCake", out ModItem UnlimitedSliceCake))
            {
                modPotions.Add(CustomPrice((UnlimitedSliceCake.Type), buyPrice(0, 2, 0, 0)), new Condition[] { Condition.PreHardmode });
            }
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedStation", out ModItem UnlimitedStation))
            {
                modPotions.Add(CustomPrice((UnlimitedStation.Type), buyPrice(0, 4, 0, 0)), new Condition[] { Condition.Hardmode });
            }
            //战斗场地卷轴(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedArena", out ModItem UnlimitedArena))
            {
                modPotions.Add(CustomPrice((UnlimitedArena.Type), buyPrice(0, 4, 0, 0)), Array.Empty<Condition>());
            }
            //垂钓卷轴(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedFishing", out ModItem UnlimitedFishing))
            {
                modPotions.Add(CustomPrice((UnlimitedFishing.Type), buyPrice(0, 5, 0, 0)), Array.Empty<Condition>());
            }
            //旅行卷轴(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedTravel", out ModItem UnlimitedTravel))
            {
                modPotions.Add(CustomPrice((UnlimitedTravel.Type), buyPrice(0, 5, 0, 0)), Array.Empty<Condition>());
            }
            //飞行卷轴(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedFlight", out ModItem UnlimitedFlight))
            {
                modPotions.Add(CustomPrice((UnlimitedFlight.Type), buyPrice(0, 5, 0, 0)), Array.Empty<Condition>());
            }
            //隐身之力(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedInvisibility", out ModItem UnlimitedInvisibility))
            {
                modPotions.Add(CustomPrice((UnlimitedInvisibility.Type), buyPrice(0, 5, 0, 0)), Array.Empty<Condition>());
            }
            //传送之力(骷髅王后)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedTeleportation", out ModItem UnlimitedTeleportation))
            {
                modPotions.Add(CustomPrice((UnlimitedTeleportation.Type), buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedSkeletron });
            }
            //极限战争(骷髅王后)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UltimateBattler", out ModItem UltimateBattler))
            {
                modPotions.Add(CustomPrice((UltimateBattler.Type), buyPrice(0, 5, 0, 0)), new Condition[] { Condition.DownedSkeletron });
            }
            //极限和平(肉后)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UltimatePeaceful", out ModItem UltimatePeaceful))
            {
                modPotions.Add(CustomPrice((UltimatePeaceful.Type), buyPrice(0, 5, 0, 0)), new Condition[] { Condition.Hardmode });
            }
            //幸运卷轴(任意Boss前)
            if (TryFind<ModItem>("miningcracks_take_on_luiafk/UnlimitedLucky", out ModItem UnlimitedLucky))
            {
                modPotions.Add(CustomPrice((UnlimitedLucky.Type), buyPrice(0, 5, 0, 0)), Array.Empty<Condition>());
            }

            #endregion  

            vanillaPotions.Register();
            modPotions.Register();
        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 60;
			knockback = 4f;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 510;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 7f;
		}
    }
}