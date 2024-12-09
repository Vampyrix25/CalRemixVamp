﻿using CalamityMod.Rarities;
using CalRemix.Content.Items.Placeables.Trophies;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Content.Items.Lore
{
    public class KnowledgePyrogen : RemixLoreItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Pyrogen");
        }

        //public override string LoreText => "Oh, the Archseer, my biggest blister.\nHold on a moment. Where is she? I could've swore Draedon entrapped the correct personnel.\nIt's too late to reprimand this error. Even then, I see no similarities in them.\nPerhaps a new set of ocular lens will benefit the mad scientist.\nI admire the strength Cinder flaunted throughout her onslaught.\nTruly, words fail to capture my intrigue, no matter the quality.\nBeyond her physical prowess, she posed a threat to the inner workings of my adversaries.\nIn the face of war, I see no need to spare mind to love. Permafrost, on the other hand, may say otherwise.\nHowever, my army does not tolerate rubber-willed traitors.\nWe were able to quell the wildfire that is Cinder without Permafrost's help. A chain's only as strong as its weakest link.\nMy esteemed engineer handled the threat well. Whether it was with excessive force is past my judgment.\nI wish the collapse of their eclectic found family. Even love has its faults.";
        public override string LoreText => "A horrible defiance of the natural order.\nSimilar to the others you've faced, this construct was created for the purpose of imprisonment, but the strength of this one's captive was far too great for even its mighty seal.\nIn time, they eventually escaped, leaving their prison behind as a rotting mass of steel and rock.\nIts dormancy made it indistinguishable from the surrounding landscape, and my forces thusly overlooked it.\nHowever, slaying a god is no easy feat, and the cleanup is even more difficult; the strength of one's spirit is immense, and without assistance, the land we now walk would still been riddled with the stains of my work.\nYour own marks prove no exception to this rule. Once you defeated the profaned god, their spirit settled into the decaying construct, creating a mindless beast with extraordinary power.\nIn time, it would've become too dangerous to stop without my own intervention.\nEven if it could've been handled better, it brings me a sense of relief to see an auric soul put to rest.\nHopefully, its owner has finally found peace.";

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.rare = ModContent.RarityType<Turquoise>();
            Item.consumable = false;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<PyrogenTrophy>().
                AddTile(TileID.Bookcases).
                Register();
        }
    }
}