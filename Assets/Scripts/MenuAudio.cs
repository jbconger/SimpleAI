using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] public AudioSource audioPlayer;
    [SerializeField] private AudioClip startSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip pauseSound;
    [SerializeField] private AudioClip mapSound;

    public void PlayStartSound()
	{
        audioPlayer.clip = startSound;
        audioPlayer.Play();
    }

    public void PlayClickSound()
	{
        audioPlayer.clip = clickSound;
        audioPlayer.Play();
	}

    public void PlayMapSound()
	{
        audioPlayer.clip = mapSound;
        audioPlayer.Play();
	}

    public void PlayPauseSound()
	{
        audioPlayer.clip = pauseSound;
        audioPlayer.Play();
    }
}
