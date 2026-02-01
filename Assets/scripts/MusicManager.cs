using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip musicClip;    // drag & drop musik game di Inspector
    private AudioSource audioSource;

    void Awake()
    {
        // Cegah duplikasi MusicManager saat pindah scene
        MusicManager[] managers = FindObjectsOfType<MusicManager>();
        if (managers.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);  // musik tetap jalan saat ganti scene

        // Setup AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        audioSource.Play();  // mulai main musik
    }
}
