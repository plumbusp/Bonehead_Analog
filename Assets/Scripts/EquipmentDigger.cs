using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDigger : MonoBehaviour
{
    public Action OnChoiceMade;
    [SerializeField] private PopUpEquipmentCell _oldCell;
    [SerializeField] private PopUpEquipmentCell _newCell;

    private EquipmentGenerator _equipmentGenerator;
    private EquipmentInventory _equipmentInventory;
    private CommonEquipmentInfo _equipmentInfo;

    private Wallet _wallet;

    private Coroutine _coroutine;

    private IEquipmentItem _newItem = null;
    private IEquipmentItem _currentItem = null;

    public void Initialize(EquipmentGenerator equipmentGenerator, EquipmentInventory equipmentInventory, CommonEquipmentInfo equipmentInfo, Wallet wallet)
    {
        _equipmentGenerator = equipmentGenerator;
        _equipmentInventory = equipmentInventory;
        _equipmentInfo = equipmentInfo;
        _wallet = wallet;
    }
    // Calls generation logic
    public void Dig()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(DigCoroutine());
    }
    private IEnumerator DigCoroutine()
    {
        //Generaing new Item
        while (true)
        {
            if (_equipmentGenerator.TryGenerateItem(out _newItem))
            {
                _newCell.InitializeItem(_newItem);
                Debug.Log("Generated Item is " + _newItem);
                break;
            }
        }
        //Trying to get current item of new item's equipment type
        if (_equipmentInventory.TryGetCurrentItem(_newItem, out IEquipmentItem currentItem))
        {
            _oldCell.InitializeItem(currentItem);
        }
        else
        {
            _oldCell.InitializeEmptyItem(_equipmentInfo.DefaultSprite, _equipmentInfo.DefaultStats);
        }
            
        yield return null;

    }

    public void Equip()
    {
        if (_newItem == null)
            return;

        _equipmentInventory.SetNewItem(_newItem);

        //Sell current item
        if(_currentItem != null)
        {
            int currentItemCost = _currentItem.Defence + _currentItem.Attack + _currentItem.HPIncrease;
            _wallet.AddMoney(currentItemCost);
        }

        _currentItem = _newItem;
        _newItem = null;
        OnChoiceMade?.Invoke();
    }
    public void Drop()
    {
        if (_newItem == null)
            return;

        // Sell new item
        int newItemCost = _newItem.Defence + _newItem.Attack + _newItem.HPIncrease;
        _wallet.AddMoney(newItemCost);

        _newItem = null;
        OnChoiceMade?.Invoke();
    }
}
