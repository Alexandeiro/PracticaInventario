using System;
using UnityEngine;

namespace Inventory
{

    [Serializable]

    public class Other : Item, ISellable
    {
        [field: SerializeField] public float Price { get; set; }

        public float Sell()
        {
            Debug.Log("Has ganado " + Price + " dinero");
            return Price;
        }
    }
}
