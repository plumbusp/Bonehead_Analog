using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CommonEquipmentInfo", menuName = "Equipment Logic/CommonEquipmentInfo")]
public class CommonEquipmentInfo : ScriptableObject
{
    [field: SerializeField] public Sprite WeaponSprite { get; private set; }
    [field: SerializeField] public Sprite ShieldSprite { get; private set; }
    [field: SerializeField] public Sprite HelmetSprite { get; private set; }

    [field: SerializeField] public int DamageMaxValue { get; private set; }
    [field: SerializeField] public int DefenceMaxValue { get; private set; }
    [field: SerializeField] public int HPMaxValue { get; private set; }

    [field: SerializeField] public Sprite DefaultSprite { get; private set; }
    [field: SerializeField] public string DefaultStats { get; private set; }
}
