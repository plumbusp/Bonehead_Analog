using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class EquipmentGenerator : MonoBehaviour
{
    [SerializeField] private int _damageMaxValue;
    [SerializeField] private int _defenceMaxValue;
    [SerializeField] private int _HPMaxValue;

    [SerializeField] private int _singleValueMaxRepeat;

    private IEquipmentItem _lastGeneratedObject;
    private int _repeatingObjectCount;

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
                value = Random.Range(0, _damageMaxValue);
                Weapon weapon = new Weapon(value);
                if (RepeatedTooMuch(weapon))
                    break;
                newItem = weapon;
                return true;

            case 1:
                value = Random.Range(0, _defenceMaxValue);
                Shield shield = new Shield(value);
                if (RepeatedTooMuch(shield))
                    break;

                newItem = shield;
                return true;

            case 2:
                value = Random.Range(0, _HPMaxValue);
                Helmet helmet = new Helmet(value);
                if (RepeatedTooMuch(helmet))
                    break;

                newItem = helmet; 
                return true;

            default: 
                Debug.LogWarning("Can't generate item using the index " + i);
                break;
        }
        return false;
    }
    private bool RepeatedTooMuch(IEquipmentItem newGeneratedObject)
    {
        _lastGeneratedObject = newGeneratedObject;
        if (_lastGeneratedObject.GetType() == newGeneratedObject.GetType())
        {
            if(_repeatingObjectCount >= _singleValueMaxRepeat)
            {
                return true;
            }
            _repeatingObjectCount++;
            return false;
        }
        else
        {
            _repeatingObjectCount = 0;
            return false;
        }
    }
}
