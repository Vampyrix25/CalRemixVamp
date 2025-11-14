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
            Main.projFrames[Type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;
            Projectile.timeLeft = 300;
            Projectile.penetrate = -1;
            Projectile.maxPenetrate = -1;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            
            int index = Projectile.FindTargetWithLineOfSight(8000);
            if (!index.WithinBounds(Main.maxNPCs))
                return;
            NPC npc = Main.npc[index];
            if (npc != null)
            {
                Vector2 there = npc.Center - Projectile.Center;
                Vector2 steer = (Vector2)Projectile.DirectionTo(npc.Center) * (float)there.Length() * 0.002f;
                Vector2 velo = (Vector2)Projectile.velocity;
                float veloBig = velo.Length();
                // Main movement clause
                Projectile.velocity = velo + steer;
                // Speed Limit
                if (veloBig > 8 && Projectile.timeLeft > 60)
                {
                    Projectile.velocity = Projectile.velocity * 0.99f;
                }
                // End of life + Desperation dash attempt. Note GiftSymbioticWormH lacks this for now.
                if (Projectile.timeLeft < 150 && (float)there.Length() < 90)
                {
                    Projectile.Kill();
                }
                if (Projectile.timeLeft == 60 && (float)there.Length() > 215)
                {
                    Projectile.velocity = Projectile.DirectionTo(npc.Center) * 20f;
                }
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
        private void IchorSplatter()
        {
            Player player = Main.player[Projectile.owner];
            int damage = (int)player.GetTotalDamage<SummonDamageClass>().ApplyTo(30);
            damage = player.ApplyArmorAccDamageBonusesTo(damage);
            if (Main.myPlayer == Projectile.owner)
            {
                int splatter = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<GiftIchor>(), damage, 0, Projectile.owner);
            }
        }
        public override void OnKill(int timeLeft)
        {
            IchorSplatter();
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
