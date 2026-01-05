using System;
using UnityEngine;

namespace Shmup
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        float speed = 1f;
        [SerializeField]
        GameObject muzzlePrefab;
        [SerializeField]
        GameObject hitPrefab;

        Transform parent;

        public Action Callback;
        private void Start()
        {
            if (muzzlePrefab != null)
            {
                var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(parent);

                DestroyParticleSystem(muzzleVFX);
            }
        }


        private void Update()
        {
            transform.SetParent(null);
            transform.position += transform.up * (speed * Time.deltaTime);

            Callback?.Invoke();
        }

        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;

        private void OnCollisionEnter(Collision collision)
        {
            if(hitPrefab != null)
            {
                ContactPoint contact = collision.contacts[0];
                var hitVFX = GameObject.Instantiate(hitPrefab, transform.position, Quaternion.identity);

                DestroyParticleSystem(hitVFX);
            }
            var plane = collision.gameObject.GetComponent<Plane>();
            if (plane != null)
            {
                plane.TakeDamadge(10);
            }
                
            Destroy(gameObject);
        }

        private void DestroyParticleSystem(GameObject vfx)
        {
            ParticleSystem ps = vfx.GetComponent<ParticleSystem>();
            if (ps == null)
            {
                ps = vfx.GetComponentInChildren<ParticleSystem>();
            }
            Destroy(vfx, ps.main.duration);
        }
    }
}
