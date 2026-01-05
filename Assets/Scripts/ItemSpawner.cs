using MEC;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using static UnityEditor.PlayerSettings;

namespace Shmup
{
    public class ItemSpawner: MonoBehaviour
    {
        [SerializeField]
        Item[] items;
        [SerializeField]
        float spawnInterval = 5f;
        [SerializeField]
        float spawnRadius = 5f;
        private void Start()
        {
            Timing.RunCoroutine(SpawnItems());
        }

        private IEnumerator<float> SpawnItems()
        {
            while(true)
            {
                yield return Timing.WaitForSeconds(spawnInterval);
                Debug.Log("SPAWN ITEM");
                //var pos = transform.position + UnityEngine.Random.insideUnitSphere.With(z: 0) * spawnRadius;
                //var item = Instantiate(items[UnityEngine.Random.Range(0, items.Length)], pos, Quaternion.identity);
                var item = Instantiate(items[UnityEngine.Random.Range(0, items.Length)]);
                item.transform.position = (transform.position + UnityEngine.Random.insideUnitSphere * spawnRadius).With(z:0);
            }
        }
    }
}
