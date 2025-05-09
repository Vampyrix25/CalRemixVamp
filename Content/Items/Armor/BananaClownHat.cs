﻿using CalamityMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalRemix.Content.Cooldowns;

namespace CalRemix.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BananaClownHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Banana Clown Mask");
            // Tooltip.SetDefault("2 magic damage");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = CalamityGlobalItem.RarityBlueBuyPrice;
            Item.rare = ItemRarityID.Blue;
            Item.defense = 1;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage<MagicDamageClass>().Flat += 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BananaClownSleeves>() && legs.type == ModContent.ItemType<BananaClownPants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = CalRemixHelper.LocalText("Items.BananaClownHat.SetBonus").Value;
            player.GetModPlayer<CalRemixPlayer>().bananaClown = true;
            player.GetModPlayer<CalamityPlayer>().cooldowns.TryGetValue(BananaClownCooldown.ID, out var cd);
            if (player.HasCooldown(BananaClownCooldown.ID) && cd.timeLeft > 3600)
            {
                player.manaCost = 0;
                player.GetDamage<MagicDamageClass>() += 0.1f;
            }
        }
    }
}
