using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Equipment
{
    public class Helmet : IEquipmentItem
    {
        public Sprite Sprite { get; private set; }
        public int HPIncrease { get; private set; }

        public Helmet(int hPIncrease, Sprite sprite)
        {
            HPIncrease = hPIncrease;
            Sprite = sprite;
        }
    }
}

