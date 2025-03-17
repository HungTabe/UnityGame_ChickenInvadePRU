using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // tao bien quan li audio soure

    public AudioSource MusicAudioSource;
    public AudioSource vfxAudioSource;

    // tao bien luu tru audio Clip

    public AudioClip MusicClip;
    public AudioClip bulletClip;
    public AudioClip chickenClip;
    void Start()
    {
        MusicAudioSource.clip = MusicClip;
        MusicAudioSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        vfxAudioSource.clip = sfxClip;
        vfxAudioSource.PlayOneShot(sfxClip);
    }
}
