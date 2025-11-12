using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{

    public class ItemButton : MonoBehaviour
    {

        public Item CurrentItem
        {
            get
            {
                return currentItem;
            }
            set
            {
                currentItem = value;
                buttonText.text = value.Name;
            }
        }

        public event Action OnClick;

        private TextMeshProUGUI buttonText;
        private Button button;
        private Item currentItem;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            button = GetComponent<Button>();
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
            button.onClick.AddListener(() => OnClick?.Invoke());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}