using System;
using UnityEngine;
namespace Shmup
{
    public class Player : Plane
    {
        [SerializeField]
        float maxFuel;
        [SerializeField]
        float fuelConsumptionRate;

        float fuel;

        public float GetFuelNormalized() => (fuel / maxFuel);

        public void AddFuel(float amount)
        {
            fuel += amount;
            if(fuel > maxFuel)
            {
                fuel = maxFuel;
            }
        }
        private void Start()
        {
            fuel = maxFuel;
        }
        private void Update()
        {
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }
        protected override void Die()
        {
            throw new NotImplementedException();
        }
    }
}
