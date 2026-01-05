using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shmup
{
    public class PlayerHud : MonoBehaviour
    {
        [SerializeField]
        Image healthBar;
        [SerializeField]
        Image fuelBar;
        [SerializeField]
        TMP_Text scoreText;

        private void Update()
        {
            healthBar.fillAmount = GameManager.Instance.Player.GetHealthNormalized();
            fuelBar.fillAmount = GameManager.Instance.Player.GetFuelNormalized();
            scoreText.text = $"Score: {GameManager.Instance.GetScore()}";
        }

    }
}
