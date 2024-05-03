using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CommonEquipmentInfo", menuName = "Equipment Logic/CommonEquipmentInfo")]
public class CommonEquipmentInfo : ScriptableObject
{
    [field: Header("Equipment Sprites")]
    [field: SerializeField] public Sprite WeaponSprite { get; private set; }
    [field: SerializeField] public Sprite ShieldSprite { get; private set; }
    [field: SerializeField] public Sprite HelmetSprite { get; private set; }

    [field: Header("Equipment Values")]
    [field: SerializeField] public int DamageMaxValue { get; private set; }
    [field: SerializeField] public int DefenceMaxValue { get; private set; }
    [field: SerializeField] public int HPMaxValue { get; private set; }

    [field: Header("Default")]
    [field: SerializeField] public Sprite DefaultSprite { get; private set; }
    [field: SerializeField] public string DefaultStats { get; private set; }

    [field: Header("Comparison")]
    [field: SerializeField] public Sprite ArrowAp { get; private set; }
    [field: SerializeField] public Sprite ArrowDown { get; private set; }
}
