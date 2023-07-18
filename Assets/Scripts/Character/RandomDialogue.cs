using UnityEngine;

public class RandomDialogue : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private void Start()
    {
        if (audioSource != null && audioClips.Length > 0)
        {
            // Rastgele bir ses seç
            AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];

            // Sesi çal
            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
}
