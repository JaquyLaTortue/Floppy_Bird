using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _bird;
    [SerializeField]private PipeSpawner _pipeSpawner;
    private FlapMovement _flapMovement;
    private BirdCollisions _birdCollisions;

    private void Start()
    {
        _flapMovement = _bird.GetComponent<FlapMovement>();
        _birdCollisions = _bird.GetComponent<BirdCollisions>();
    }

    // Start the game when called by setting up the flap movement and starting the pipe spawner
    public void GameStart()
    {
        _birdCollisions.StartSetUp();
        _flapMovement.StartSetUp();
        _pipeSpawner.StartSpawnLoop();
    }
}
