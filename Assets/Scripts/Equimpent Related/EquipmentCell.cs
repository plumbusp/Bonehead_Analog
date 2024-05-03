using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class EquipmentCell : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _defenceText;
    [SerializeField] private TMP_Text _HPText;

    public virtual void InitializeEmptyItem(Sprite sprite, string stats)
    {
        _image.sprite = sprite;

        _attackText.text = stats;
        _defenceText.text = stats;
        _HPText.text = stats;
    }

    public virtual void InitializeItem(IEquipmentItem item)
    {
        _image.sprite = item.Sprite;

        _attackText.text = "";
        _defenceText.text = "";
        _HPText.text = "";

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
