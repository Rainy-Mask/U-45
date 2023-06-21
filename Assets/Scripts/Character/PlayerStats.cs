using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public float hunger; // Açlık
    public float thirst; // Susuzluk
    public float sanity; // Akıl Sağlığı
    public float weightCapacity; // Ağırlık Kapasitesi

    private void Start()
    {
        // İlk değer atamalarını yapabilirsiniz
        hunger = 100f;
        thirst = 100f;
        sanity = 100f;
        weightCapacity = 100f;
    }

    private void Update()
    {
        // Her güncellemede özellikleri kontrol edebilirsiniz
        CheckHunger();
        CheckThirst();
        CheckSanity();
        CheckWeightCapacity();
    }

    private void CheckHunger()
    {
        // Açlık kontrolü yapılabilir
        if (hunger <= 0f)
        {
            // Karakter açlık seviyesi sıfırın altına düştüğünde neler olacağını belirleyebilirsiniz
            // Örneğin karakterin canını düşürebilir, oyunu sonlandırabilir veya diğer etkileşimler yapabilirsiniz
        }
    }

    private void CheckThirst()
    {
        // Susuzluk kontrolü yapılabilir
        if (thirst <= 0f)
        {
            // Karakter susuzluk seviyesi sıfırın altına düştüğünde neler olacağını belirleyebilirsiniz
            // Örneğin karakterin canını düşürebilir, oyunu sonlandırabilir veya diğer etkileşimler yapabilirsiniz
        }
    }

    private void CheckSanity()
    {
        // Akıl sağlığı kontrolü yapılabilir
        if (sanity <= 0f)
        {
            // Karakter akıl sağlığı seviyesi sıfırın altına düştüğünde neler olacağını belirleyebilirsiniz
            // Örneğin karakterin canını düşürebilir, oyunu sonlandırabilir veya diğer etkileşimler yapabilirsiniz
        }
    }

    private void CheckWeightCapacity()
    {
        // Ağırlık kapasitesi kontrolü yapılabilir
        // Karakterin taşıma kapasitesi aşıldığında neler olacağını belirleyebilirsiniz
        // Örneğin karakterin hızını düşürebilir, hareketini engelleyebilir veya diğer etkileşimler yapabilirsiniz
    }

    public void DecreaseHunger(float amount)
    {
        hunger -= amount;
        hunger = Mathf.Clamp(hunger, 0f, 100f);
        
    }

    public void DecreaseThirst(float amount)
    {
        thirst -= amount;
        thirst = Mathf.Clamp(thirst, 0f, 100f);
        
    }

    public void DecreaseSanity(float value)
    {
        sanity -= value;
        sanity = Mathf.Clamp(sanity, 0f, 100f); // Akıl sağlığını 0 ile 100 arasında tut
    }

/*     private void UpdateHungerUI()
    {
        GameObject hungerTextObj = GameObject.Find("HungerText");
        if (hungerTextObj != null)
        {
            Text hungerText = hungerTextObj.GetComponent<Text>();
            hungerText.text = "Hunger: " + hunger.ToString("f0");
        }
    }

    private void UpdateThirstUI()
    {
        GameObject thirstTextObj = GameObject.Find("ThirstText");
        if (thirstTextObj != null)
        {
            Text thirstText = thirstTextObj.GetComponent<Text>();
            thirstText.text = "Thirst: " + thirst.ToString("f0");
        }
    }

    private void UpdateSanityUI()
    {
        GameObject sanityTextObj = GameObject.Find("SanityText");
        if (sanityTextObj != null)
        {
            Text sanityText = sanityTextObj.GetComponent<Text>();
            sanityText.text = "Sanity: " + sanity.ToString();
        }
    }
 */
}
