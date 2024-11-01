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

    private GameObject BGMObject;
    [HideInInspector] public AudioClip gameTheme;
    [HideInInspector] public AudioClip menuTheme;
    [HideInInspector] public AudioClip ColdFryTheme;
    [HideInInspector] public AudioClip EggTheme;

    private void GetAudioClip()
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

        gameTheme = Resources.Load<AudioClip>("Sounds/02. Angry Birds Space Orchestral Theme");
        menuTheme = Resources.Load<AudioClip>("Sounds/04. Cosmic Crystals");
        ColdFryTheme = Resources.Load<AudioClip>("Sounds/05. Cold Cuts");
        EggTheme = Resources.Load<AudioClip>("Sounds/06. Eggsteroids");
    }
}

/*
01. Angry Birds Space Theme
02. Angry Birds Space Orchestral Theme
03. Angry Birds Space Mirror World Theme
04. Cosmic Crystals
05. Cold Cuts
06. Eggsteroids
*/