using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("Tools")]
    private AudioSource cast;
    private AudioSource plough;
    private AudioSource splash;
    public GameObject Tools;
    void Start()
    {
        AudioSource[] audios = Tools.GetComponents<AudioSource>();
        cast = audios[0];
        plough = audios[1];
        splash = audios[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cast(){
        cast.Play();
    }
    public void Plough(){
        plough.Play();
    }
    public void Splash(){
        if(Detection.Instance.inWater){
        splash.Play();
        }
    }

}
