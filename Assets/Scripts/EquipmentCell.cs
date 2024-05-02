using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class EquipmentCell : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _statsText;

    public virtual void InitializeEmptyItem(Sprite sprite, string stats)
    {
        _image.sprite = sprite;
        _statsText.text = stats;
    }

    public virtual void InitializeItem(IEquipmentItem item)
    {
        _image.sprite = item.Sprite;

        _statsText.text = "";
        if (item.Attack >= 0)
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
