using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Equipment
{
    public class EquipmentItemGenerator : MonoBehaviour
    {
        [SerializeField] private int _singleValueMaxRepeat;

        private CommonEquipmentInfo _equipmentInfo;
        private int _lastGeneratedNumber = -1;
        private int _count = 0;

        public void Initialize(CommonEquipmentInfo equipmentInfo)
        {
            _equipmentInfo = equipmentInfo;
        }

        /// <summary>
        /// Returns true if an element matching the conditions was generated, false otherwise.
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public bool TryGenerateItem(out IEquipmentItem newItem)
        {
            int i = Random.Range(0, 3);

            #region Checking if the value has repeated too often, if it has -- preventing another repeat
            if (_lastGeneratedNumber == i)
            {
                if (_count >= _singleValueMaxRepeat)
                {
                    Debug.Log("Too much! " + _count);
                    newItem = null;
                    return false;
                }
                _count++;
            }
            else
            {
                _count = 1; //reset + add one repeat of current item
                _lastGeneratedNumber = i;
            }
            #endregion

            switch (i)
            {
                case 0:
                    Weapon weapon = new Weapon(Random.Range(1, _equipmentInfo.DamageMaxValue), _equipmentInfo.WeaponSprite);
                    newItem = weapon;
                    return true;
                case 1:
                    Shield shield = new Shield(Random.Range(1, _equipmentInfo.DefenceMaxValue), _equipmentInfo.ShieldSprite);
                    newItem = shield;
                    return true;
                case 2:
                    Helmet helmet = new Helmet(Random.Range(1, _equipmentInfo.HPMaxValue), _equipmentInfo.HelmetSprite);
                    newItem = helmet;
                    return true;
                default:
                    newItem = null;
                    Debug.LogWarning($"No item is assosiated with the generated number: {i}");
                    return false;
            }
        }
    }
}

