using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Equipment
{
    public class Shield : IEquipmentItem
    {
        public Sprite Sprite { get; private set; }
        public int Defence { get; private set; }
        public Shield(int defence, Sprite sprite)
        {
            Defence = defence;
            Sprite = sprite;
        }
    }

}

