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

    private Coroutine _coroutine;

    private IEquipmentItem newItem = null;
    private IEquipmentItem currentItem = null;

    public void Initialize(EquipmentGenerator equipmentGenerator, EquipmentInventory equipmentInventory, CommonEquipmentInfo equipmentInfo)
    {
        _equipmentGenerator = equipmentGenerator;
        _equipmentInventory = equipmentInventory;
        _equipmentInfo = equipmentInfo;
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
            if (_equipmentGenerator.TryGenerateItem(out newItem))
            {
                _newCell.InitializeItem(newItem);
                Debug.Log("Generated Item is " + newItem);
                break;
            }
        }
        //Trying to get current item of new item's equipment type
        if (_equipmentInventory.TryGetCurrentItem(newItem, out IEquipmentItem currentItem))
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
        if (newItem == null)
            return;

        _equipmentInventory.SetNewItem(newItem);
        // TO-DO Sell current item
        newItem = null;
        currentItem = null;
        OnChoiceMade?.Invoke();
    }
    public void Drop()
    {
        if (newItem == null)
            return;

        // TO-DO Sell new item
        newItem = null;
        currentItem = null;
        OnChoiceMade?.Invoke();
    }
}
