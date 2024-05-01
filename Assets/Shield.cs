using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : IEquipmentItem
{
    public int Defence { get; private set; }
    public Shield(int defence)
    {
        Defence = defence;
    }
}
