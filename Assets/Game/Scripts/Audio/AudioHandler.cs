using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioMixer))]
public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private float _offVolumeValue = -80;
    private float _onVolumeValue = 0;
    private const string GeneralKey = "GeneralVolume";

    private void Awake() => Initialization();

    public void OnGeneralAudio()
    {
        _audioMixer.SetFloat(GeneralKey, _onVolumeValue);
    }

    public void OffGeneralAudio()
    {
        _audioMixer.SetFloat(GeneralKey, _offVolumeValue);
    }
    
    private void Initialization()
    {
        _audioMixer.GetFloat(GeneralKey, out float value);
        _onVolumeValue = value;
    }
}
