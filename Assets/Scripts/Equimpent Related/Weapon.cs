using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IEquipmentItem
{
    public Sprite Sprite { get; private set; }
    public int Attack { get; private set; }
    public Weapon(int attack, Sprite sprite)
    {
        Attack = attack;
        Sprite = sprite;
    }
}
