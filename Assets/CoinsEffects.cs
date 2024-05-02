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
    [SerializeField] private float _speed;


    private WaitForSeconds _spawnDelaySeconds;
    private WaitForSeconds _groundTimeSeconds;


    private Queue<Coin> _coinsPool = new Queue<Coin>();
    private List<Coin> _spawnedCoins = new List<Coin>();

    private void Start()
    {
        // Initializing Queue of coins
        for (int i = 0; i < 100; i++)
        {
            Coin newCoin = Instantiate(_coinPrefab, _coinsParent);
            newCoin.Initialize();
            newCoin.gameObject.SetActive(false);
            _coinsPool.Enqueue(newCoin);
        }
    }

    public IEnumerator SpawnFallingCoins(int coinAmount)
    {
        _spawnedCoins.Clear();
        Coin coin;

        for (int i = 0; i < coinAmount; i++)
        {
            if (_coinsPool.Count == 0)
                break;

            coin = _coinsPool.Dequeue();

            _spawnedCoins.Add(coin);
            coin.gameObject.SetActive(true);
            coin.transform.position = _spawnTransform.position;
            coin.Rigidbody.AddForce(_spawnPushForce);

            _coinsPool.Enqueue(coin);
            yield return _spawnDelaySeconds;
        }

        StartCoroutine(WaitAndAccrueCoins());
        yield break;
    }

    private IEnumerator WaitAndAccrueCoins()
    {
        yield return _groundTimeSeconds;
        OnCoinsCameThrough?.Invoke(_spawnedCoins.Count);
        foreach (var coin in _spawnedCoins)
        {
            coin.transform.position = Vector3.MoveTowards(coin.transform.position, _targetTransform.position, _speed);
            if (Vector3.Distance(coin.transform.position, _targetTransform.position) <= _minDistance)
            {
                coin.gameObject.SetActive(false);
            }
        }
    }

}
