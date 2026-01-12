using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] SpawnerWithDuration _spawner;

    private Camera _camera;
    private Controller _controller;

    private void Awake()
    {
        _camera = Camera.main;
        _controller = new TopDownController(_player, _player, _player, _spawner, _camera);

        _spawner.Initialization(_player.transform);
    }

    private void Update()
    {
        if(_player.IsDead())
            _controller.Disable();
        else
            _controller.Enable();

        _controller.Update(Time.deltaTime);
    }
}
