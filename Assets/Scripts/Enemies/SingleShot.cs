using UnityEngine;

namespace Shmup
{
    [CreateAssetMenu(menuName = "Shmup/WeaponStrategy/SingleShot", fileName = "SingleShot")]
    public class SingleShot : WeaponStrategy
    {
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            projectile.transform.SetParent(firePoint);
            projectile.layer = (int)layer;

            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);


            Destroy(projectile, projectileLifeTime);
        }
    }
}

