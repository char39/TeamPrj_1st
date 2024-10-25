using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SoundManage : MonoBehaviour
{
    private void PlaySound(AudioClip clip)
    {
        GameObject originSound = transform.GetChild(0).gameObject;
        GameObject sound = Instantiate(originSound, transform);
        AudioSource source = sound.AddComponent<AudioSource>();
        source.PlayOneShot(clip);
        Debug.Log("PlaySound: " + clip.name);
        Destroy(sound, clip.length);
    }

    public void PlayEnterWave() => PlaySound(enterWave);
    public void PlayFallOnPlanet() => PlaySound(fallOnPlanet);
    public void PlayEnterAtmosphere() => PlaySound(enterAtmosphere);
    public void PlayExitAtmosphere() => PlaySound(exitAtmosphere);
    public void PlayClear() => PlaySound(clear);
    public void PlayFail() => PlaySound(fail);
    public void PlaySlingshotStretched() => PlaySound(slingshotStretched);
    public void PlayBirdFly() => PlaySound(birdFly);
    public void PlayFreezePig() => PlaySound(freezePig);
}
