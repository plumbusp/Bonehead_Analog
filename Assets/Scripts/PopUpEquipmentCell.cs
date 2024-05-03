using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpEquipmentCell : EquipmentCell
{
    [SerializeField] private TMP_Text _name;

    [SerializeField] private Image _attackComparisonIcon;
    [SerializeField] private Image _defenceComparisonIcon;
    [SerializeField] private Image _HPComparisonIcon;

    private CommonEquipmentInfo _equipmentInfo;

    public override void InitializeEmptyItem(Sprite sprite, string stats)
    {
        _name.text = "";
        base.InitializeEmptyItem(sprite, stats);
    }
    public void Initialize(CommonEquipmentInfo equipmentInfo)
    {
        _equipmentInfo = equipmentInfo;

        _attackComparisonIcon.enabled = false;
        _defenceComparisonIcon.enabled = false;
        _HPComparisonIcon.enabled = false;
    }
    public override void InitializeItem(IEquipmentItem item)
    {
        _name.text = item.GetType().ToString();
        base.InitializeItem(item);
    }

    public void InitializeItemWithComparison(IEquipmentItem item, IEquipmentItem compare)
    {
        if(item.GetType() != compare.GetType())
        {
            Debug.Log("Mistake occure! Types don't matches");
            InitializeItem(item);
        }
        //Reset Comparison icones to default 
        _attackComparisonIcon.enabled = false;
        _defenceComparisonIcon.enabled = false;
        _HPComparisonIcon.enabled = false;

        _name.text = item.GetType().ToString();
        base.InitializeItem(item);

        #region Attack Comparison
        if (item.Attack > compare.Attack)
        {
            ChangeSprite(_attackComparisonIcon, _equipmentInfo.ArrowAp);
            return;
        }

        else if (item.Attack < compare.Attack)
        {
            ChangeSprite(_attackComparisonIcon, _equipmentInfo.ArrowDown);
            return;
        }

        #endregion

        # region Defence Comparison
        if (item.Defence > compare.Defence)
        {
            ChangeSprite(_defenceComparisonIcon, _equipmentInfo.ArrowAp);
            return;
        }

        else if (item.Defence < compare.Defence)
        {
            ChangeSprite(_defenceComparisonIcon, _equipmentInfo.ArrowDown);
            return;
        }

        #endregion

        # region HP Comparison
        if (item.HPIncrease > compare.HPIncrease)
        {
            ChangeSprite(_HPComparisonIcon, _equipmentInfo.ArrowAp);
            return;
        }

        else if (item.HPIncrease < compare.HPIncrease)
        {
            ChangeSprite(_HPComparisonIcon, _equipmentInfo.ArrowDown);
            return;
        }

        #endregion
    }
    private void ChangeSprite(Image image, Sprite sprite)
    {
        image.enabled = true;
        image.sprite = sprite;
    }

}
