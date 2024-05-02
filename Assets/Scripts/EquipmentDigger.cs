using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDigger : MonoBehaviour
{
    [SerializeField] private PopUpEquipmentCell _oldCell;
    [SerializeField] private PopUpEquipmentCell _newCell;

    private EquipmentGenerator _equipmentGenerator;
    private EquipmentInventory _equipmentInventory;
    private CommonEquipmentInfo _equipmentInfo;

    private Coroutine _coroutine;

    public void Initialize(EquipmentGenerator equipmentGenerator, EquipmentInventory equipmentInventory, CommonEquipmentInfo equipmentInfo)
    {
        _equipmentGenerator = equipmentGenerator;
        _equipmentInventory = equipmentInventory;
        _equipmentInfo = equipmentInfo;
    }

    public void Dig()
    {
        StartCoroutine(DigCoroutine());
    }
    private IEnumerator DigCoroutine()
    {
        //Generaing new Item
        IEquipmentItem newItem = null;
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
            _oldCell.InitializeItem(currentItem);

        else
            _oldCell.InitializeEmptyItem(_equipmentInfo.DefaultSprite, _equipmentInfo.DefaultStats);

        yield return null;

    }

}
