using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventory : MonoBehaviour
{
    [SerializeField] private EquipmentCell _weaponCell;
    [SerializeField] private EquipmentCell _shieldCell;
    [SerializeField] private EquipmentCell _helmetCell;

    private Weapon _currentWeapon;
    private Shield _currentShield;
    private Helmet _currentHelmet;

    public void SetNewItem(IEquipmentItem newItem)
    {
        SetNewItem((dynamic)newItem);
        _weaponCell.UpdateItem(newItem);
    }
    #region Methods to set new item
    private void SetWeaponItem(Weapon newWeapon) => _currentWeapon = newWeapon;
    private void SetWeaponItem(Shield newShield) => _currentShield = newShield;
    private void SetWeaponItem(Helmet newHelmet) => _currentHelmet = newHelmet;
    #endregion

    public bool TryGetCurrentItem(IEquipmentItem referenceItem, out IEquipmentItem currentItem) 
    { 
        currentItem = GetCurrentItem((dynamic)referenceItem);
        if(currentItem == null)
            return false;
        return true;
    }
    #region Methods for dynamic finding of inventory items
    private Weapon GetCurrentItem(Weapon weaponReference)
    {
        if (_currentWeapon == null)
            return null;
        return _currentWeapon;
    }

    private Shield GetCurrentItem(Shield shieldReference)
    {
        if (_currentShield == null)
            return null;
        return _currentShield;
    }

    private Helmet GetCurrentItem(Helmet helmetReference)
    {
        if (_currentHelmet == null)
            return null;
        return _currentHelmet;
    }
    #endregion
}
