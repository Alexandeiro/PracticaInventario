using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{


    public class InventorySystem : MonoBehaviour
    {
        [Header("UI Reffs")]
        [SerializeField] private ItemButton prefabButton;
        [SerializeField] private Transform inventoryPanel;
        [SerializeField] private Button useButton;
        [SerializeField] private Button sellButton;


        [Header("Object Definition")]
        [SerializeField] private Weapon[] weapons;
        [SerializeField] private Food[] foods;
        [SerializeField] private Other[] others;

        [Header("Item Pool")]
        [SerializeField] private List<Item> items = new List<Item>();
        [Header("Item Selected")]
        [SerializeField] private ItemButton currentItemSelected;

        void Start()
        {
            InitializeItems();
            InitializeUI();

            useButton.onClick.AddListener(UseCurrentItem);
            sellButton.onClick.AddListener(SellCurrentItem);
        }
        private void SellCurrentItem()
        {
            (currentItemSelected.CurrentItem as ISellable).Sell();
            Consume(currentItemSelected);
        }

        private void UseCurrentItem()
        {
            (currentItemSelected.CurrentItem as IUsable).Use();
            if (currentItemSelected.CurrentItem is IConsumable)
            {
                Consume(currentItemSelected);
            }
            
        }
        private void Consume(ItemButton currentItemSelected)
        {
            Destroy(currentItemSelected.gameObject);
            currentItemSelected = null;
            sellButton.gameObject.SetActive(false);
            useButton.gameObject.SetActive(false);
        }

        private void InitializeUI()
        {
            for (int i = 0; i < items.Count; i++)
            {
                ItemButton newButton = Instantiate(prefabButton, prefabButton.transform.parent);
                newButton.CurrentItem = items[i];
                newButton.OnClick += () => AddItem(newButton);
            }
            prefabButton.gameObject.SetActive(false);
        }

        public void AddItem(ItemButton buttonItemToAdd)
        {
            ItemButton newButtonItem = Instantiate(buttonItemToAdd, inventoryPanel);
            newButtonItem.CurrentItem = buttonItemToAdd.CurrentItem;
            newButtonItem.OnClick += () => SelectItem(newButtonItem);
        }

        

        public void SelectItem(ItemButton currentItem)
        {
            currentItemSelected = currentItem;

            if (currentItemSelected.CurrentItem is ISellable) 
            {
                sellButton.gameObject.SetActive(true);
            }
            else
            {
                sellButton.gameObject.SetActive(false);
            }
            if (currentItemSelected.CurrentItem is IUsable) 
            {
                useButton.gameObject.SetActive(true);
            }
            else
            {
                useButton.gameObject.SetActive(false);
            }

        }


        private void InitializeItems()
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                items.Add(weapons[i]);
            }
            for (int i = 0; i < foods.Length; i++)
            {
                items.Add(foods[i]);
            }
            for (int i = 0; i < others.Length; i++)
            {
                items.Add(others[i]);
            }
        }

        void Update()
        {

        }

        
    }
}