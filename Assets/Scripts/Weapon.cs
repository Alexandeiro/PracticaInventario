using System;
using UnityEngine;

namespace Inventory
{

    [Serializable]
    public class Weapon : Item, IUsable
    {
        [field: SerializeField] public float Damage { get; set; }
        public void Attack()
        {
            Debug.Log("Do Attack...");
        }

        public void Use()
        {
            Attack();
        }
    }

}