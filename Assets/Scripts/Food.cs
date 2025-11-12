using System;
using UnityEngine;


namespace Inventory
{

    public interface IConsumable { }


    [Serializable]
    public class Food : Item, IUsable, ISellable, IConsumable
    {

        [field: SerializeField] public float HealingPoints { get; set; }
        [field: SerializeField] public float Price { get; set; }

        public float Sell()
        {
            Debug.Log("Has ganado " + Price + " dinero");
            return Price;
        }

        public void Use()
        {
            Debug.Log("Te has comido " + Name + " y ganas " + HealingPoints + " de vida");
        }
    }

}
