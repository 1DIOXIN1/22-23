using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioMixer))]
public class AudioHandler
{
    private const string GeneralKey = "GeneralVolume";
    private float _offVolumeValue = -80;
    private float _onVolumeValue = 0;
    private AudioMixer _audioMixer;

    public AudioHandler(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;

        _audioMixer.GetFloat(GeneralKey, out float value);
        _onVolumeValue = value;
    }

    public void OnGeneralAudio()
    {
        _audioMixer.SetFloat(GeneralKey, _onVolumeValue);
    }

    public void OffGeneralAudio()
    {
        _audioMixer.SetFloat(GeneralKey, _offVolumeValue);
    }
}
