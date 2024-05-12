using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Equipment
{
    public class PopUpEquipmentCell : EquipmentCell
    {
        [SerializeField] private TMP_Text _name;

        [SerializeField] private Image _attackComparisonIcon;
        [SerializeField] private Image _defenceComparisonIcon;
        [SerializeField] private Image _HPComparisonIcon;

        public override void Initialize(CommonEquipmentInfo equipmentInfo)
        {
            base.Initialize(equipmentInfo);

            _attackComparisonIcon.enabled = false;
            _defenceComparisonIcon.enabled = false;
            _HPComparisonIcon.enabled = false;
        }

        public override void InitializeItem(IEquipmentItem item)
        {
            base.InitializeItem(item);

            if(item != null)
            {
                _name.text = item.GetType().ToString();
            }
        }

        public void InitializeItemWithComparison(IEquipmentItem item, IEquipmentItem compare)
        {
            if (item.GetType() != compare.GetType())
            {
                Debug.Log("Mistake occure! Types don't matches");
                InitializeItem(item);
            }

            base.InitializeItem(item);
            _name.text = item.GetType().ToString();

            DisableAllIcons();
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

            #region Defence Comparison
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

            #region HP Comparison
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
        private void DisableAllIcons()
        {
            _attackComparisonIcon.enabled = false;
            _defenceComparisonIcon.enabled = false;
            _HPComparisonIcon.enabled = false;
        }
    }
}

