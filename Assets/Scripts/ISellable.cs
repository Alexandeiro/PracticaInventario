using UnityEngine;

namespace Inventory
{

    public interface ISellable
    {
        public float Price { get; set; }

        public float Sell();

    }
}
