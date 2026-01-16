using UnityEngine;

public class UI : MonoBehaviour
{
    private AudioHandler _audioHandler;

    public void Initialization(AudioHandler audioHandler)
    {
        _audioHandler = audioHandler;
    }

    public void OnGeneralAudio() => _audioHandler.OnGeneralAudio();

    public void OffGeneralAudio() => _audioHandler.OffGeneralAudio();
}
