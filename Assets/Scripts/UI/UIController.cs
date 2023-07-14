using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider thirstSlider;
    [SerializeField] private Slider sanitySlider;
    [SerializeField] private Text hungerText;
    [SerializeField] private Text thirstText;
    [SerializeField] private Text sanityText;

    [SerializeField] private PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        // Hunger değerini güncelle
        if (hungerSlider != null && hungerText != null)
        {
            hungerSlider.value = playerStats.hunger;
            hungerText.text = "Hunger: " + playerStats.hunger.ToString();
        }

        // Thirst değerini güncelle
        if (thirstSlider != null && thirstText != null)
        {
            thirstSlider.value = playerStats.thirst;
            thirstText.text = "Thirst: " + playerStats.thirst.ToString();
        }

        // Sanity değerini güncelle
        if (sanitySlider != null && sanityText != null)
        {
            sanitySlider.value = playerStats.sanity;
            sanityText.text = "Sanity: " + playerStats.sanity.ToString();
        }
    }
}
