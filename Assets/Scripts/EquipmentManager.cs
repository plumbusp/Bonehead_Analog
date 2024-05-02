using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private CommonEquipmentInfo _equipmentInfo;
    [SerializeField] private EquipmentGenerator _equipmentGenerator;
    [SerializeField] private EquipmentInventory _equipmentInventory;

    [SerializeField] private GameObject _popUp;
    private EquipmentDigger _equipmentDigger;

    private void Start()
    {
        _equipmentDigger = _popUp.GetComponentInChildren<EquipmentDigger>();
        _equipmentGenerator.Initialize(_equipmentInfo);
        _equipmentDigger.Initialize(_equipmentGenerator, _equipmentInventory, _equipmentInfo);
    }
    public void OpenNewPopUp()
    {
        //TO-DO Make Animations
        _popUp.SetActive(true);
        _equipmentDigger.Dig();
    }
}
