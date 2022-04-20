using Terraria;
using Terraria.Utilities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using SushiCrew.Content.QuestSystem;

namespace SushiCrew.Content.NPCs
{
    public enum Gender
    {
        male,
        female,
        other
    }

    [AutoloadHead]
    public abstract class NPC_TownBase : NPCBase
	{
        protected string[] PossibleNames;
        protected WeightedRandom<string> PossibleBasicChats;

        protected string ChatButtonName_1;
        protected string ChatButtonName_2;

        protected bool ChatButton1IsShop;
        protected bool ChatButton2IsShop;

        protected Gender NPCGender;

        protected int[] BasicShopItems;

        /// <summary>
        /// Used when AttackType is set to 0, 1, or 2
        /// </summary>
        protected int AttackProjectileID;
        /// <summary>
        /// Used when AttackType is set to 1
        /// </summary>
        protected int AttackGunItemID;
        protected float AttackGunItemScale;
        protected int AttackGunItemCloseness;
        /// <summary>
        /// Used when AttackType is set to 3
        /// </summary>
        protected int AttackMeleeItemID;  
        protected int AttackMeleeItemSize;  
        protected float AttackMeleeItemScale;  
        protected Vector2 AttackMeleeItemOffset;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            Main.npcFrameCount[NPC.type] = 26;
            
            NPCID.Sets.ExtraFramesCount[NPC.type] = 14;//9
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;//4
            NPCID.Sets.DangerDetectRange[NPC.type] = 1000;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 50;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            NPC.townNPC = true;
            NPC.friendly = true;

            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.knockBackResist = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            PossibleNames = new string[] { "SETNAMES" };
            PossibleBasicChats = new WeightedRandom<string>();

            ChatButtonName_1 = "Button 1";
            ChatButtonName_2 = "Button 2";

            ChatButton1IsShop = false;
            ChatButton2IsShop = false;

            NPCGender = Gender.male;

            BasicShopItems = new int[] { };

            AttackProjectileID = ProjectileID.WoodenArrowFriendly;

            AttackGunItemID = -1;
            AttackGunItemScale = 1f;
            AttackGunItemCloseness = 40;

            AttackMeleeItemID = -1;
            AttackMeleeItemSize = 1;
            AttackMeleeItemScale = 1f;
            AttackMeleeItemOffset = Vector2.Zero;

        }

        public override string TownNPCName()
        {
            int selectedIndex = Main.rand.Next(0, PossibleNames.Length);
            return PossibleNames[selectedIndex];
        }

        public override string GetChat()
        {
            if (PossibleBasicChats.elements.Count <= 0)
            {
                return "SETCHATS";
            }
            else
            {
                return PossibleBasicChats.Get();
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = ChatButtonName_1;
            button2 = ChatButtonName_2; 
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                OnFirstChatButtonClicked(ref shop);
            }
            else
            {
                OnSecondChatButtonClicked(ref shop);
            }
        }

        protected virtual void OnFirstChatButtonClicked(ref bool shop)
        {
            if (ChatButton1IsShop)
            {
                shop = true;
            }
            //Main.LocalPlayer.GetModPlayer<QuestPlayer>().AttemptRecieveQuest(101);
        }

        protected virtual void OnSecondChatButtonClicked(ref bool shop)
        {
            if (ChatButton2IsShop)
            {
                shop = true;
            }
            //QuestPlayer questPlayer = Main.LocalPlayer.GetModPlayer<QuestPlayer>();
            //if (questPlayer.AttemptCompleteQuest(101))
            //{
            //    Main.NewText("Completed!");
            //}

        }

        public override bool CanGoToStatue(bool toKingStatue)
        {
            if (NPCGender == Gender.male && toKingStatue)
            {
                return true;
            }
            else if (NPCGender == Gender.female && !toKingStatue)
            {
                return true;
            }
            else if (NPCGender == Gender.other)
            {
                return true;
            }

            return false;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (BasicShopItems.Length <= 0)
            {
                // No basic items setup
                return;
            }

            foreach (int i in BasicShopItems)
            {
                shop.item[nextSlot].SetDefaults(i);
                nextSlot++;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = NPC.damage;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = AttackProjectileID;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            if (AttackGunItemID == -1)
            {
                base.DrawTownAttackGun(ref scale, ref item, ref closeness);
                return;
            }

            item = AttackGunItemID;
            scale = AttackGunItemScale;
            closeness = AttackGunItemCloseness;
            
        }
        
        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
        {
            if (AttackMeleeItemID == -1)
            {
                base.DrawTownAttackSwing(ref item, ref itemSize, ref scale, ref offset);
                return;
            }
            Main.instance.LoadItem(AttackMeleeItemID);
            item = TextureAssets.Item[AttackMeleeItemID].Value;
            itemSize = AttackMeleeItemSize;
            scale = AttackMeleeItemScale;
            offset = AttackMeleeItemOffset;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return true;
        }
    }
}