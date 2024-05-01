using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class EquipmentCell : MonoBehaviour
{
    [SerializeField] private Sprite _equipmenSprite;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _statsText;
    public void UpdateItem(IEquipmentItem item)
    {
        _statsText.text = "";
        if(item.Attack >= 0)
        {
            _statsText.text = $"Attack: {item.Attack} <br>";
        }
        if (item.Defence >= 0)
        {
            _statsText.text += $"Defence: {item.Defence} <br>";
        }
        if (item.HPIncrease >= 0)
        {
            _statsText.text += $"HP: {item.HPIncrease}";
        }
    }
}
