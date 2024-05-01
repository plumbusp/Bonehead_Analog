using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : IEquipmentItem
{
    public int HPIncrease { get; private set; }
    public Helmet(int hPIncrease)
    {
        HPIncrease = hPIncrease;
    }
}
