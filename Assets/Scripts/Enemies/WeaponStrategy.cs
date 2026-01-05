using UnityEngine;

namespace Shmup
{
    public abstract class WeaponStrategy : ScriptableObject
    {
        [SerializeField]
        int damadge = 10;
        [SerializeField]
        float fireRate = 0.5f;
        [SerializeField]
        protected float projectileSpeed = 2f;
        [SerializeField]
        protected float projectileLifeTime = 5f;
        [SerializeField]
        protected GameObject projectilePrefab;

        public int Damadge => damadge;
        public float FireRate => fireRate;

        public virtual void Initialize()
        {

        }

        public abstract void Fire(Transform firePoint, LayerMask layer);
    }
}
