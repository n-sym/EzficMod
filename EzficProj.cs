using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ezfic
{
    class EzficProj : GlobalProjectile
    {
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if(projectile.type == ProjectileID.FallingStar && Main.rand.Next(100) < Main.player[projectile.owner].rangedCrit) crit = true;
            base.ModifyHitNPC(projectile, target, ref damage, ref knockback, ref crit, ref hitDirection);
        }
    }
}
