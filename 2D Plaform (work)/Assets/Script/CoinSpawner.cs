using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _coin;
    [SerializeField] private float SpawnRate = 2f;
    public float _nextEnemySpawnTime = 2.0f;

    public void Update()
    {
        if (Time.time > +_nextEnemySpawnTime)
        {
            _nextEnemySpawnTime = Time.time + SpawnRate;
            Instantiate(_coin, transform.position, transform.rotation);
        }
    }
}

