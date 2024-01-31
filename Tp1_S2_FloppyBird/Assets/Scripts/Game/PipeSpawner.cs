using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private float[] _spawnBoundsY = new float[2];

    [SerializeField]
    private float _timeBetweenSpawn = 5f;

    [SerializeField]
    private GameObject _pipePrefab;

    [SerializeField]
    private GameObject _bird;
    private BirdCollisions _birdCollision;

    [SerializeField]
    private float _spawnMultiplier = 1;
    private float _timeSinceGameStarted = 0;
    private bool _started = false;

    private void Update()
    {
        if (_started && _birdCollision.Alive)
        {
            _timeSinceGameStarted += Time.deltaTime;
        }
    }

    public void StartSpawnLoop()
    {
        _birdCollision = _bird.GetComponent<BirdCollisions>();
        _started = true;
        SpawnPipe();
    }

    private void SpawnPipe()
    {
        if (_birdCollision.Alive)
        {
            UpdateSpawnMultiplier();
            GameObject currentPipe = Instantiate(_pipePrefab, new Vector3(transform.position.x, Random.Range(_spawnBoundsY[0], _spawnBoundsY[1]), transform.position.z), Quaternion.identity);
            currentPipe.GetComponent<Pipes>().Bird = this._bird;
            StartCoroutine(SpawnPipeCoroutine());
            return;
        }
    }

    private void UpdateSpawnMultiplier()
    {
        switch (_timeSinceGameStarted)
        {
            case > 15f and < 40f:
                _spawnMultiplier = 1.2f;
                break;

            case > 40f and < 60f:
                _spawnMultiplier = 1.6f;
                break;
            case > 60f and < 80f:
                _spawnMultiplier = 1.9f;
                break;
            case > 80f and < 120f:
                _spawnMultiplier = 2.2f;
                break;
            case > 120f:
                _spawnMultiplier = 5f;
                break;
            default:
                return;
        }
    }

    private IEnumerator SpawnPipeCoroutine()
    {
        yield return new WaitForSeconds(_timeBetweenSpawn / _spawnMultiplier);
        SpawnPipe();
    }
}
