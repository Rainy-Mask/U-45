using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private bool sanityBelowZero;
    [SerializeField] private AudioSource sanitySource;

    public float hunger; // Açlık
    public float thirst; // Susuzluk
    public float sanity; // Akıl Sağlığı
    public float weightCapasity; // Ağırlık Kapasitesi

    private void Start()
    {
        // İlk değer atamalarını yapabilirsiniz
        hunger = 100f;
        thirst = 100f;
        sanity = 100f;
        weightCapasity = 100f;

        if (PlayerPrefs.HasKey("hunger")) // Oyun başladıktan sonra daha önceden kaydedilmiş mi onu kontrol ediyor. Kaydedilmiş ise o andaki değerleri atıyor.
        {
            hunger = PlayerPrefs.GetFloat("hunger");
            thirst = PlayerPrefs.GetFloat("thirst");
            sanity = PlayerPrefs.GetFloat("sanity");
            weightCapasity = PlayerPrefs.GetFloat("weightCapasity");
        }
    }

    public void SaveStats() // Karakter istatistiklerini kaydetmeye yarar
    {
        PlayerPrefs.SetFloat("hunger", hunger);
        PlayerPrefs.SetFloat("thirst", thirst);
        PlayerPrefs.SetFloat("sanity", sanity);
        PlayerPrefs.SetFloat("weightCapasity", weightCapasity);
    }

    private void Update()
    {
        // Her güncellemede özellikleri kontrol edebilirsiniz
        CheckHunger();
        CheckThirst();
        CheckSanity();
        CheckWeightCapasity();
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
            sanityBelowZero = true;
            // Karakter akıl sağlığı seviyesi sıfırın altına düştüğünde neler olacağını belirleyebilirsiniz
            // Örneğin karakterin canını düşürebilir, oyunu sonlandırabilir veya diğer etkileşimler yapabilirsiniz
        }
        else
        {
            sanityBelowZero = false;
        }

        if (sanityBelowZero)
        {
            sanitySource.enabled = true;
        }
        else
        {
            sanitySource.enabled = false;
        }
    }

    public bool CheckWeightCapasity()
    {
        if (weightCapasity >= 50)
            return true;

        return false;

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

    public void DecreaseWeightCapasity(float amount)
    {
        weightCapasity -= amount;
        weightCapasity = Mathf.Clamp(weightCapasity, 0f, 200f);
    }

    public void IncreaseHunger(float amount)
    {
        hunger += amount;
        hunger = Mathf.Clamp(hunger, 0f, 100f);
        Debug.Log(amount + " kadar eklendi.");
    }

    public void IncreaseThirst(float amount)
    {
        thirst += amount;
        thirst = Mathf.Clamp(thirst, 0f, 100f);
        Debug.Log(amount + " kadar eklendi.");
    }

    public void IncreaseWeightCapasity(float amount)
    {
        weightCapasity += amount;
        weightCapasity = Mathf.Clamp(weightCapasity, 0f, 200f);
        Debug.Log("TAŞIMA KAPASİTESİ: " + weightCapasity);
    }
}
