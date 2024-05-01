using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IEquipmentItem
{
    public int Attack { get; private set; }
    public Weapon(int attack)
    {
        Attack = attack;
    }
}
