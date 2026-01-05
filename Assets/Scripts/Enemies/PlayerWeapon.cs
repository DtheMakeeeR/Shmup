using UnityEngine;

namespace Shmup
{
    public class PlayerWeapon : Weapon
    {
        [SerializeField]
        InputReader input;
        float fireTimer;
        private void Start()
        {
            if (input == null)
            {
                Debug.Log($"{gameObject.name} has no input");
            }
        }
        private void Update()
        {
            fireTimer += Time.deltaTime;

            if (input.Fire && fireTimer > weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}
