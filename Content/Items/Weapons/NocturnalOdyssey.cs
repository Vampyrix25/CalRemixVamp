using CalamityMod.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalRemix.Content.Projectiles.Weapons;
using CalamityMod.Rarities;
using CalRemix.Content.Items.Materials;
using CalamityMod.Tiles.Furniture.CraftingStations;

namespace CalRemix.Content.Items.Weapons
{
    public class NocturnalOdyssey : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {

            Item.width = 50;
            Item.height = 50;
            Item.rare = ModContent.RarityType<Violet>();
            Item.useTime = 120;
            Item.useAnimation = 120;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.consumable = false;
            Item.autoReuse = false;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 460;
            Item.knockBack = 0;
            Item.noMelee = true;
            Item.shootSpeed = 85f;
            Item.mana = 55;
            Item.ArmorPenetration = 9999;
            Item.shoot = ModContent.ProjectileType<NocturnalOne>();

        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<NocticReactiveEssence>(20).
                AddTile<DraedonsForge>().
                Register();
        }
    }
}