using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpEquipmentCell : EquipmentCell
{
    [SerializeField] private TMP_Text _name;

    public override void InitializeItem(IEquipmentItem item)
    {
        _name.text = item.GetType().ToString();
        base.InitializeItem(item);
    }

}
