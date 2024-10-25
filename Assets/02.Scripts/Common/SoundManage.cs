using UnityEngine;

public partial class SoundManage : MonoBehaviour
{
    void Start()
    {
        GetAudioClip();
        BGMObject = Instantiate(transform.GetChild(0).gameObject, transform);
        BGMObject.name = "BGM";
    }

    private void PlaySound(AudioClip clip)
    {
        GameObject originSound = transform.GetChild(0).gameObject;
        GameObject sound = Instantiate(originSound, transform);
        AudioSource source = sound.GetComponent<AudioSource>();
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

    private void PlayBGM(AudioClip clip)
    {
        AudioSource source = BGMObject.GetComponent<AudioSource>();
        if (source.clip == clip)
            return;
        source.clip = clip;
        source.loop = true;
        source.Play();
    }

    public void PlayGameStartTheme() => PlayBGM(gameTheme);
    public void PlayMenuTheme() => PlayBGM(menuTheme);
    public void PlayColdFryTheme() => PlayBGM(ColdFryTheme);
    public void PlayEggTheme() => PlayBGM(EggTheme);
}