﻿using CalamityMod;
using CalamityMod.Items.Potions;
using CalRemix.Content.Buffs.Tainted;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Content.Items.Potions.Tainted
{
    public class TaintedNightOwlPotion : TaintedPotion
    {
        public override int BuffType => ModContent.BuffType<TaintedNightOwlBuff>();
        public override int BuffTime => ContentSamples.ItemsByType[PotionType].buffTime;
        public override int PotionType => ItemID.NightOwlPotion;
        public override int MeatAmount => 4;
        public override string PotionName => "Night Owl";
    }
}