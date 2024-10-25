using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SoundManage : MonoBehaviour
{
    [HideInInspector] public AudioClip enterWave;
    [HideInInspector] public AudioClip fallOnPlanet;
    [HideInInspector] public AudioClip enterAtmosphere;
    [HideInInspector] public AudioClip exitAtmosphere; 
    [HideInInspector] public AudioClip clear;
    [HideInInspector] public AudioClip birdFly;
    [HideInInspector] public AudioClip fail;
    [HideInInspector] public AudioClip slingshotStretched;
    [HideInInspector] public AudioClip freezePig;

    void Start()
    {
        enterWave = Resources.Load<AudioClip>("Sounds/bird next military a2");
        fallOnPlanet = Resources.Load<AudioClip>("Sounds/collision01");
        enterAtmosphere = Resources.Load<AudioClip>("Sounds/EnterAtmosphere");
        exitAtmosphere = Resources.Load<AudioClip>("Sounds/ExitAtmosphere");
        clear = Resources.Load<AudioClip>("Sounds/level clear military a1");
        fail = Resources.Load<AudioClip>("Sounds/level failed piglets a2");
        slingshotStretched = Resources.Load<AudioClip>("Sounds/slingshot streched");
        birdFly = Resources.Load<AudioClip>("Sounds/bird shot-a2");
        freezePig = Resources.Load<AudioClip>("Sounds/light damage a3");
    }
}