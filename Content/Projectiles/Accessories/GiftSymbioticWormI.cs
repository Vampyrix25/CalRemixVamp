using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using CalRemix.Content.Projectiles.Accessories;

namespace CalRemix.Content.Projectiles.Accessories
{
    public class GiftSymbioticWormI : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Volatile Symbiotic Worm");
            Main.projFrames[Type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;
            Projectile.timeLeft = 120;
            Projectile.penetrate = -1;
            Projectile.maxPenetrate = -1;
        }
        public override void AI()
        {
            int index = Projectile.FindTargetWithLineOfSight(480);
            if (!index.WithinBounds(Main.maxNPCs))
                return;
            NPC npc = Main.npc[index];
            if (npc != null)
                Projectile.velocity = Projectile.DirectionTo(npc.Center) * 8f;
            if (Projectile.timeLeft < 3)
            {
                IchorSplatter();
            }
        }
        private void IchorSplatter()
        {
            Player player = Main.player[Projectile.owner];
            int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(30);
            damage = player.ApplyArmorAccDamageBonusesTo(damage);
            if(Main.myPlayer == Projectile.owner)
            {
                int splatter = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<GiftIchor>(), damage, 0, Projectile.owner);
            }
            Projectile.Kill();
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 position = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Rectangle sourceRectangle = new(0, texture.Height / 4 * Projectile.frame, texture.Width, texture.Height / 4);
            Vector2 origin = sourceRectangle.Size() / 2f;
            Color drawColor = Projectile.GetAlpha(new Color(255, 255, 255, 255));
            Main.spriteBatch.Draw(texture, position, sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
