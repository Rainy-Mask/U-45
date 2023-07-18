using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private bool sanityBelowZero;
    [SerializeField] private AudioSource sanitySource;
    [SerializeField] private InventorySaveLoad inventorySaveLoad;



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

        if (PlayerPrefs.HasKey("hunger")) // Oyun başladıktan sonra daha önceden kaydedilmiş mi onu kontrol ediyor. Kaydedilmiş ise o andaki değerleri atıyor.
        {
            Debug.Log("Load Player Stats");
            hunger = PlayerPrefs.GetFloat("hunger");
            thirst = PlayerPrefs.GetFloat("thirst");
            sanity = PlayerPrefs.GetFloat("sanity");
            weightCapacity = PlayerPrefs.GetFloat("weightCapacity");
        }
    }

    public void SaveStats() // Karakter istatistiklerini kaydetmeye yarar
    {
        Debug.Log("Save Player Stats");
        PlayerPrefs.SetFloat("hunger", hunger);
        PlayerPrefs.SetFloat("thirst", thirst);
        PlayerPrefs.SetFloat("sanity", sanity);
        PlayerPrefs.SetFloat("weightCapacity", weightCapacity);
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
        if (sanity <= 0f)
        {
            sanityBelowZero = true;
            SaveCharacterState(); // Karakter durumunu kaydet
            IncreaseSanity(50f); // Karakterin akıl sağlığını artır
            StartRandomMinigame(); // Rastgele bir minigame başlat
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

    public bool CheckWeightCapacity()
    {
        if (weightCapacity >= 50)
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

    public void DecreaseWeightCapacity(float amount)
    {
        weightCapacity -= amount;
        weightCapacity = Mathf.Clamp(weightCapacity, 0f, 200f);
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

    public void IncreaseWeightCapacity(float amount)
    {
        weightCapacity += amount;
        weightCapacity = Mathf.Clamp(weightCapacity, 0f, 200f);
        Debug.Log("TAŞIMA KAPASİTESİ: " + weightCapacity);
    }

    public void IncreaseSanity(float amount)
    {
        sanity += amount;
        sanity = Mathf.Clamp(sanity, 0f, 100f);
    }

    public void SaveCharacterState()
    {
        // Karakterin konumunu ve envanter durumunu kaydet
        PlayerPrefs.SetFloat("XPos", transform.position.x);
        PlayerPrefs.SetFloat("YPos", transform.position.y);
        PlayerPrefs.SetFloat("ZPos", transform.position.z);

        // Envantersiz haliyle birlikte envanterdeki eşyaları da kaydetmek isterseniz, örnek olarak aşağıdaki gibi yapabilirsiniz
        InventoryManager inventoryManager = GetComponent<InventoryManager>();
        if (inventoryManager != null)
        {
            inventorySaveLoad.SaveInventory(); // Envantersiz haliyle birlikte envanteri de kaydet
        }
    }


private void StartRandomMinigame()
{
    // Rastgele bir minigame başlat
    // Burada Random sınıfını kullanabilirsiniz
    int randomIndex = Random.Range(2, 5); // 0, 1 veya 2 değerlerinden rastgele bir indeks seçer

    if (randomIndex == 2)
    {
        SceneManager.LoadScene(2);
        SaveCharacterState();
        SaveStats();
    }
    else if (randomIndex == 3)
    {
        SceneManager.LoadScene(3);
        SaveCharacterState();
        SaveStats();
    }
    else if (randomIndex == 4)
    {
        SceneManager.LoadScene(4);
        SaveCharacterState();
        SaveStats();
    }
}

}
