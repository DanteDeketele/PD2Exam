using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnDelay = 4f;
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] public Transform[] _waypoints;

    public List<Enemy> Enemies = new List<Enemy>();

    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnDelay)
        {
            _timer -= _spawnDelay;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, _spawnPoint).GetComponent<Enemy>();
        Enemies.Add(enemy);
    }
}
