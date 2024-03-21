using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	[SerializeField] AudioLibrarySO audioLibrary = null;
    private AudioSource player = null;

    private void Awake()
    {
        player = GetComponent<AudioSource>();
    }

    public void PlayAudio(string key)
    {
        Stop();
        player.clip = audioLibrary[key];
        player.Play();
    }

    public void Pause()
    {
        player.Pause();
    }

    public void Stop()
    {
        player.Stop();
    }

    public void PlayOneShot(string key)
    {
        player.PlayOneShot(audioLibrary[key]);
    }
}
