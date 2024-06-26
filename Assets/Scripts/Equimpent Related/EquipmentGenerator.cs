using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class EquipmentGenerator : MonoBehaviour
{
    [SerializeField] private int _singleValueMaxRepeat;

    private CommonEquipmentInfo _equipmentInfo;
    private IEquipmentItem _lastGeneratedObject;
    private int _repeatingObjectCount;

    public void Initialize(CommonEquipmentInfo equipmentInfo)
    {
        _equipmentInfo = equipmentInfo;
    }

    private void Start()
    {
        _repeatingObjectCount = 0;
    }
    /// <summary>
    /// Returns true if an element matching the conditions was generated, false otherwise.
    /// </summary>
    /// <param name="newItem"></param>
    /// <returns></returns>
    public bool TryGenerateItem(out IEquipmentItem newItem)
    {
        int i = Random.Range(0, 3);
        int value = 0;

        newItem = null;
        switch (i)
        {
            case 0:
                value = Random.Range(1, _equipmentInfo.DamageMaxValue);
                Weapon weapon = new Weapon(value, _equipmentInfo.WeaponSprite);
                if (IsRepeatedTooMuch(weapon))
                    return false;
                newItem = weapon;
                return true;

            case 1:
                value = Random.Range(1, _equipmentInfo.DefenceMaxValue);
                Shield shield = new Shield(value, _equipmentInfo.ShieldSprite);
                if (IsRepeatedTooMuch(shield))
                    return false;

                newItem = shield;
                return true;

            case 2:
                value = Random.Range(1, _equipmentInfo.HPMaxValue);
                Helmet helmet = new Helmet(value, _equipmentInfo.HelmetSprite);
                if (IsRepeatedTooMuch(helmet))
                    return false;

                newItem = helmet; 
                return true;

            default: 
                Debug.LogWarning("Can't generate item using the index " + i);
                return false;
        }
    }
    private bool IsRepeatedTooMuch(IEquipmentItem newGeneratedObject)
    {
        if (_lastGeneratedObject !=null)
        {
            if (_lastGeneratedObject.GetType() == newGeneratedObject.GetType())
            {
                _repeatingObjectCount++;
                if (_repeatingObjectCount >= _singleValueMaxRepeat)
                {
                    Debug.Log("Too much!");
                    return true;
                }
                return false;
            }
            _repeatingObjectCount = 0;
            _lastGeneratedObject = newGeneratedObject;
            return false;
        }
        else
        {
            _lastGeneratedObject = newGeneratedObject;
            return false;
        }
    }
}
