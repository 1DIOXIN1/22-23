using UnityEngine;
using UnityEngine.Audio;

public class Game : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private Player _player;
    [SerializeField] private SpawnerWithDuration _spawner;
    [SerializeField] private UI _userInterface;
    [SerializeField] private AudioMixer _audioMixer;

    private Camera _camera;
    private Controller _controller;
    private ISpawnPointHolder _spawnPointHolder;
    private AudioHandler _audioHandler;

    private void Awake()
    {
        Initialization();
    }

    private void Update()
    {
        if(_player.IsDead())
            _controller.Disable();
        else
            _controller.Enable();

        _controller.Update(Time.deltaTime);
    }
    
    private void Initialization()
    {
        _camera = Camera.main;
        
        _controller = new TopDownController(_player, _player, _player, _spawner, _camera);
        _spawnPointHolder = new CircleSpawnPointHolder(_player.transform, _spawnRadius);
        _audioHandler = new AudioHandler(_audioMixer);

        _userInterface.Initialization(_audioHandler);
        _spawner.Initialization(_spawnPointHolder);
    }
}
