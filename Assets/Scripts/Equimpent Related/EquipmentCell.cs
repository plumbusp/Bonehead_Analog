using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

namespace Equipment
{
    public class EquipmentCell : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _attackText;
        [SerializeField] private TMP_Text _defenceText;
        [SerializeField] private TMP_Text _HPText;

        protected CommonEquipmentInfo _equipmentInfo;

        public virtual void Initialize(CommonEquipmentInfo equipmentInfo)
        {
            _equipmentInfo = equipmentInfo;

            _image.sprite = equipmentInfo.DefaultSprite;
            _attackText.text = "";
            _defenceText.text = "";
            _HPText.text = "";
        }

        public virtual void InitializeItem(IEquipmentItem item)
        {
            _attackText.text = "";
            _defenceText.text = "";
            _HPText.text = "";

            if (item == null)
            {
                _image.sprite = _equipmentInfo.DefaultSprite;
                return;
            }

            _image.sprite = item.Sprite;

            if (item.Attack >= 0)
            {
                _attackText.text = $"Attack: {item.Attack} <br>";
            }
            if (item.Defence >= 0)
            {
                _defenceText.text += $"Defence: {item.Defence} <br>";
            }
            if (item.HPIncrease >= 0)
            {
                _HPText.text += $"HP: {item.HPIncrease}";
            }
        }
    }
}

