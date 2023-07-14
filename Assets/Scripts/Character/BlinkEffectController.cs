using UnityEngine;
using UnityEngine.Video;

public class BlinkEffectController : MonoBehaviour
{
    [SerializeField] private GameObject blinkEffect;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerStats playerStats;

    private float initialFOV;
    private Vector3 initialScale;
    private float timer;
    private float blinkInterval = 15f; // 3 saniyede bir göz kırpma videosunu oynatmak için süre

    private void Start()
    {
        initialFOV = mainCamera.fieldOfView;
        initialScale = blinkEffect.transform.localScale;

        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        float currentFOV = mainCamera.fieldOfView;

        // FOV değiştiyse göz kırpma videosunun boyutunu güncelle
        if (currentFOV != initialFOV)
        {
            float fovRatio = initialFOV / currentFOV;

            // Göz kırpma videosunun boyutunu güncelle
            blinkEffect.transform.localScale = initialScale / fovRatio;
        }

        // Açlık veya susuzluk seviyesi 15'in altına düştüğünde belirli bir sürede bir göz kırpması oynat
        if ((playerStats.hunger < 15f || playerStats.thirst < 15f) && Time.time >= timer + blinkInterval)
        {
            timer = Time.time;
            PlayBlinkEffect();
        }
    }

    private void PlayBlinkEffect()
    {
        // Göz kırpmayı oynatma işlemini burada gerçekleştir

        // Göz kırpma efektini etkinleştir
        blinkEffect.SetActive(true);

        // İlgili video oynatma kodlarını veya animasyon işlemlerini buraya yerleştir
        // Örnek olarak, blinkEffect üzerindeki bir VideoPlayer bileşeni varsa, aşağıdaki gibi oynatılabilir:
        VideoPlayer videoPlayer = blinkEffect.GetComponent<VideoPlayer>();
        if (videoPlayer != null)
        {
            videoPlayer.Play();
        }
    }
}
