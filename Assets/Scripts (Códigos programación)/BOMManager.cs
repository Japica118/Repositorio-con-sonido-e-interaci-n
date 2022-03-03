using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOMManager : MonoBehaviour
{
    private AudioSource _audioSoucer;
    
    
    void Awake()
    {
        //Asignamos la variable
        _audioSoucer = GetComponent<AudioSource>();
    }
        
    // Start is called before the first frame update
    void Start()
    {
        //Reproducimos la BSO
        _audioSoucer.Play();
    }

    //Funcion para parar la BOMM
    public void StopBOMM()
    {
        _audioSoucer.Stop();
    }

}
