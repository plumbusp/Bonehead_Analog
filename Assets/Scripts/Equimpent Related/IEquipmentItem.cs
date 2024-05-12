using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Equipment
{
    public interface IEquipmentItem
    {
        public Sprite Sprite { get; }
        public int Defence
        {
            get
            {
                return 0;
            }
        }
        public int Attack
        {
            get
            {
                return 0;
            }
        }
        public int HPIncrease
        {
            get
            {
                return 0;
            }
        }
    }
}
