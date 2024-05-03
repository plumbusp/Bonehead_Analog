using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsEffects : MonoBehaviour
{
    public event Action<int> OnCoinsCameThrough;

    [Header("Coins Parameters")]
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _coinsParent;

    [Header("Coins Spawn Parameters")]
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private Vector2 _spawnPushForce;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _groundTime;

    [Header("Coin Moving Upwards")]
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private WaitForSeconds _groundTimeSeconds;


    private Queue<Coin> _coinsPool = new Queue<Coin>();
    private List<Coin> _spawnedCoins = new List<Coin>();

    private void Start()
    {
        _groundTimeSeconds = new WaitForSeconds(_groundTime);

        // Initializing Queue of coins
        for (int i = 0; i < 100; i++)
        {
            Coin newCoin = Instantiate(_coinPrefab, _coinsParent);
            newCoin.Initialize();
            newCoin.gameObject.SetActive(false);
            _coinsPool.Enqueue(newCoin);
        }
    }

    public void SpawnFallingCoins(int coinAmount)
    {
        if (_spawnedCoins.Count != 0) //If the spawned coins have not yet been processed
        {
            OnCoinsCameThrough?.Invoke(_spawnedCoins.Count); // process 
            MoveCoinsToTarget();
        }

        _spawnedCoins.Clear();
        Coin coin;

        for (int i = 0; i < coinAmount; i++)
        {
            if (_coinsPool.Count == 0)
                return;

            coin = _coinsPool.Dequeue();

            _spawnedCoins.Add(coin);
            coin.transform.position = _spawnTransform.position;
            coin.gameObject.SetActive(true);
            coin.rb.AddForce(_spawnPushForce);

            _coinsPool.Enqueue(coin);
        }

        StartCoroutine(AccrueCoins());
    }

    private IEnumerator AccrueCoins()
    {
        yield return _groundTimeSeconds;
        MoveCoinsToTarget();
        OnCoinsCameThrough?.Invoke(_spawnedCoins.Count);
        _spawnedCoins.Clear();
    }
    private void MoveCoinsToTarget()
    {
        foreach (var coin in _spawnedCoins)
        {
            coin.MoveTowardsTarget(_targetTransform.position, UnityEngine.Random.Range(_minSpeed, _maxSpeed), _minDistance);
        }
    }

}
