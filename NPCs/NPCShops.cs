using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.Items.Potions;

namespace yitangCalamity.NPCs
{
    public class NPCShops : GlobalNPC
    {
		public override bool InstancePerEntity => true;

        public override void ModifyShop(NPCShop shop)
        {
            switch (shop.NpcType)
            {
                case NPCID.Merchant:
					shop.Add(new Item(ItemID.ApprenticeBait, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.JourneymanBait, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 3, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.MasterBait, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Steak, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.ApplePie, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, new Condition[] { Condition.Hardmode })
						.Add(new Item(ItemID.BowlofSoup, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Apple, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Apricot, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ModContent.ItemType<Baguette>(), 1) { shopCustomPrice = new int?(Item.buyPrice(0, 0, 5, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.BestiaryGirl:
					shop.Add(new Item(ItemID.Pizza, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.MonsterLasagna, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Lemon, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Peach, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.Golfer:
					shop.Add(new Item(ItemID.Spaghetti, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.RoastedDuck, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Grapefruit, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.Demolitionist:
					shop.Add(new Item(ItemID.Hotdog, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.SpicyPepper, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Pomegranate, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.Clothier:
					shop.Add(new Item(ModContent.ItemType<BlasphemousDonut>(), 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, new Condition[] { Condition.DownedMoonLord });
                    break;
                case NPCID.Stylist:
					shop.Add(new Item(ItemID.GingerbreadCookie, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.FriedEgg, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.BloodOrange, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Rambutan, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.DyeTrader:
					shop.Add(new Item(ItemID.ShrimpPoBoy, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.BlackCurrant, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Elderberry, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.Pirate:
					shop.Add(new Item(ItemID.Sashimi, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.CookedShrimp, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.CookedFish, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
                //case NPCID.Dryad:
                //    break;
                case NPCID.Painter:
					shop.Add(new Item(ItemID.FruitSalad, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Pineapple, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Mango, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.WitchDoctor:
					shop.Add(new Item(ItemID.CoffeeCup, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.FroggleBunwich, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Grapes, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, new Condition[] { Condition.Hardmode });
                    break;
                case NPCID.ArmsDealer:
					shop.Add(new Item(ItemID.BBQRibs, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, new Condition[] { Condition.DownedPlantera })
						.Add(new Item(ItemID.BananaSplit, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.ChickenNugget, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Oyster, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 0, 10, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.Steampunker:
					shop.Add(new Item(ItemID.PurpleSolution, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 0, 15, 0)) }, new Condition[] { Condition.CrimsonWorld })
						.Add(new Item(ItemID.RedSolution, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 0, 15, 0)) }, new Condition[] { Condition.CorruptWorld })
						.Add(new Item(ItemID.Fries, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Nachos, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.LobsterTail, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.GoblinTinkerer:
					shop.Add(new Item(ItemID.Milkshake, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, new Condition[] { Condition.Hardmode })
						.Add(new Item(ItemID.Cherry, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Plum, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.Mechanic:
					shop.Add(new Item(ItemID.ChristmasPudding, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.IceCream, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.BananaDaiquiri, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.Cyborg:
					shop.Add(new Item(ItemID.ChocolateChipCookie, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Teacup, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 0, 1, 0)) }, Array.Empty<Condition>());
                    break;
                case NPCID.PartyGirl:
					shop.Add(new Item(ItemID.SliceOfCake, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, new Condition[] { Condition.BirthdayParty })
						.Add(new Item(ItemID.Bacon, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, new Condition[] { Condition.BirthdayParty })
						.Add(new Item(ItemID.PumpkinPie, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.Dragonfruit, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 0, 0)) }, new Condition[] { Condition.Hardmode })
						.Add(new Item(ItemID.Starfruit, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 0, 0)) }, new Condition[] { Condition.Hardmode });
                    break;
                case NPCID.Wizard:
					shop.Add(new Item(ItemID.SugarCookie, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.PrismaticPunch, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.SpectreStaff, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 20, 0, 0)) }, new Condition[] { Condition.DownedPlantera, Condition.NotDownedGolem })
						.Add(new Item(ItemID.InfernoFork, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 20, 0, 0)) }, new Condition[] { Condition.DownedPlantera, Condition.NotDownedGolem })
						.Add(new Item(ItemID.ShadowbeamStaff, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 20, 0, 0)) }, new Condition[] { Condition.DownedPlantera, Condition.NotDownedGolem })
						.Add(new Item(ItemID.MagnetSphere, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 20, 0, 0)) }, new Condition[] { Condition.DownedPlantera, Condition.NotDownedGolem });
                    break;
                case NPCID.Princess:
					shop.Add(new Item(ItemID.GrapeJuice, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.CreamSoda, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 2, 50, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.PeachSangria, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.PinaColada, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>())
						.Add(new Item(ItemID.BloodyMoscato, 1) { shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0)) }, Array.Empty<Condition>());
                    break;
            }

            //给模组的NPC商店添加新商品
            //if (ModLoader.HasMod("Fargowiltas"))
            //{
            //    ModLoader.TryGetMod("Fargowiltas", out Mod fargowiltas)
            //    ModNPC npc;
            //    if(fargowiltas.TryFind<ModNPC>("Abominationn", out npc))
            //    {
            //        if(shop.NpcType == npc.Type)
            //        {
            //            	.Add(new Item(fargowiltas.Find<ModItem>("Overloader").Type) { shopCustomPrice = new int?(Item.buyPrice(0, 10, 0, 0)) }, Array.Empty<Condition>())
            //        }
            //    }
            //}
        }
    }
}