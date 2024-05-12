using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Wallet: MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private CoinsEffects _coinsEffects;
    private int _money;

    private void Start()
    {
        _coinsEffects.OnCoinsCameThrough += AddCoinsMethod;
        _money = 0;
        _text.text = _money.ToString();
    }

    private void OnDestroy()
    {
        _coinsEffects.OnCoinsCameThrough -= AddCoinsMethod;
    }

    public void AddMoney(int money)
    {
        _coinsEffects.SpawnFallingCoins(money);
    }

    /// <summary>
    /// Used to be able to add/remove the AddCoins functionality to the _coinsEffects.OnCoinsCameThrough action.
    /// </summary>
    /// <param name="amount"></param>
    private void AddCoinsMethod(int amount)
    {
        StartCoroutine(AddCoins(amount));
    }

    /// <summary>
    /// Adds coins one at a time
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    private IEnumerator AddCoins(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(0.05f);
            _money++;
            _text.text = _money.ToString();
        }
    }
}
