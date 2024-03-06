
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip MorteBabyFeto;
    public AudioClip DannoGesù;
    public AudioClip MorteFetone;
    public AudioClip MorteFetostrello;
    public AudioClip EsplosioneBobbio;
    public AudioClip BoccettaPiena;
    public AudioClip GoldenFetoPiccolo;
    public AudioClip Beve;
    public AudioClip LancioDelDardo;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
