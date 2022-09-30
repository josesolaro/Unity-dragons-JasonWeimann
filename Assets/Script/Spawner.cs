using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _stumps;
    [SerializeField]
    private GameObject _stumpPrefab;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _spawnTimeSeconds = 5f;
    private float _elapsedTime;
    private float _lastSpawnTime;
    private void Start()
    {
        _elapsedTime = 0;
        _lastSpawnTime = 0;
    }
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_lastSpawnTime + _spawnTimeSeconds < _elapsedTime)
        {
            _lastSpawnTime = _elapsedTime;
            var newSpawn = _stumpPrefab.GetComponent<SpriteRenderer>();
            newSpawn.sprite = _stumps[(int)(Random.Range(0, 39) / 10)];
            Instantiate(newSpawn, new Vector2(13, -4), Quaternion.identity);
            Instantiate(_enemyPrefab, new Vector2(13, Random.Range(-5, 5)), Quaternion.identity);
        }
    }
}
