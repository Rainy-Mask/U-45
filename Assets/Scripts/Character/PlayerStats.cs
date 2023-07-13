using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    private bool sanityBelowZero;
    [SerializeField]private AudioSource sanitySource;


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

        if (PlayerPrefs.HasKey("hunger"))//Oyun başladıktan sonra daha öncesinde kaydedilmiş mi onu kontrol ediyor .Kayededilmiş ise o andaki değerleri atıyor.
        {
            hunger = PlayerPrefs.GetFloat("hunger");
            thirst = PlayerPrefs.GetFloat("thirst");
            sanity = PlayerPrefs.GetFloat("sanity");
            weightCapacity = PlayerPrefs.GetFloat("weightCapasity");
        }
    }

    public void SaveStats()//Karakter statlaini kaydetmeye yarar
    {
        PlayerPrefs.SetFloat("hunger", hunger);
        PlayerPrefs.SetFloat("thirst", thirst);
        PlayerPrefs.SetFloat("sanity", sanity);
        PlayerPrefs.SetFloat("weightCapasity", weightCapacity);
    }

    private void Update()
    {
        // Her güncellemede özellikleri kontrol edebilirsiniz
        CheckHunger();
        CheckThirst();
        CheckSanity();
        //CheckWeightCapacity();
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
        
        if(sanityBelowZero)
        {
            sanitySource.enabled = true;
        }
        else
        {
            sanitySource.enabled = false;
        }


    }

    public void CheckWeightCapacity()
    {
        if(weightCapacity >= 50)
        {
            Debug.Log("YAVAŞLAMASI ICIN KOD");


        }
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

    public void DecreaseWeightCapasity(float amaount)
    {

        weightCapacity -= amaount;
        weightCapacity = Mathf.Clamp(weightCapacity, 0f, 200f);
    }

    public void IncreaseHunger(float amaount)
    {
        
        hunger += amaount;
        hunger = Mathf.Clamp(hunger, 0f, 100f);
    }
    public void IncreaseThirst(float amaount)
    {
        
        thirst += amaount;
        thirst = Mathf.Clamp(thirst, 0f, 100f);
    }

    public void IncreaseWeightCapasity(float amaount)
    {
        weightCapacity += amaount;
        weightCapacity = Mathf.Clamp(weightCapacity, 0f, 200f);
        Debug.Log("TAŞIMA KAPASİTESİ : " + weightCapacity); // kaldır bunu sonradan test amaçlı :)
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
