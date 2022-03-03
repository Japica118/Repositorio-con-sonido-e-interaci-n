using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //Clip de audio para la muerte del Mario
    public AudioClip deathSFX;
    //Clip de audio muerte goomba
    public AudioClip goombaSFX;
    //Clip de audio monedas
    public AudioClip coinSFX;
    //Clip de audio bandera
    public AudioClip FlagpoleSFX;
   


    //Variable del audio source
    private AudioSource _audioSoucer;

    void Awake()
    {
        _audioSoucer = GetComponent<AudioSource>();
    }

    public void DeathSound()
    {
        _audioSoucer.PlayOneShot(deathSFX);
    }

    public void GoombaSound()
    {
        _audioSoucer.PlayOneShot(goombaSFX);
    }

    public void CoinSound()
    {
        _audioSoucer.PlayOneShot(coinSFX);
    }

      public void FlagpoleSound()
    {
        _audioSoucer.PlayOneShot(FlagpoleSFX);
    }


    

}