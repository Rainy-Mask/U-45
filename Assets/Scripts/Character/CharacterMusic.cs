using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMusic : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musicList; // Önceden belirlenmiş müzik listesi
    [SerializeField] private AudioSource audioSource;
    private int currentMusicIndex = 0; // Şu an çalınan müziğin indeksi

    public bool IsMusicPlaying { get; private set; }

    private void Start()
    {
        /*
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        */

        audioSource.loop = false; // Müzik döngüsünü kapat

        // İlk müziği çal
        if (musicList.Count > 0)
        {
            audioSource.clip = musicList[currentMusicIndex];
        }
    }

    public int PlayNextMusic()
    {
        if (musicList.Count == 0)
        {
            Debug.LogWarning("Music list is empty!");
            return -1;
        }

        currentMusicIndex++;
        if (currentMusicIndex >= musicList.Count)
        {
            currentMusicIndex = 0; // Müzik listesini döngüye al
        }

        audioSource.clip = musicList[currentMusicIndex];
        StartCoroutine(StartMusic());
        IsMusicPlaying = true;

        return currentMusicIndex;
    }

    IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(1.6f);

        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
        IsMusicPlaying = false;
    }
}
