using System;
using UnityEngine;

namespace Shmup
{
    public class ParalaxController : MonoBehaviour 
    {
        [SerializeField]
        Transform[] backgrounds;
        [SerializeField]
        float smoothing = 10f;
        [SerializeField]
        float multiplier = 10f;

        [SerializeField]
        Transform cam;
        Vector3 previousCamPos;

        private void Awake()
        {
            cam = Camera.main.transform;
        }

        private void Start()
        {
            previousCamPos = cam.position;
        }

        private void Update()
        {
            MakeParalax();

            previousCamPos = cam.position;
        }

        private void MakeParalax()
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                var parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                var targetY = backgrounds[i].position.y + parallax;


                var targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);

                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }
        }
    }
}