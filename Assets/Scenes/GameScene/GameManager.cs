using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Inventory inventory;
    public GameObject inventoryUI;
    private bool isInventoryOpen = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else if (instance != this)
        {
            Destroy(gameObject); 
        }

        inventory = FindObjectOfType<Inventory>();
    }
    public class Item
    {
        public string itemName;
        public int itemID;
        public Sprite itemIcon;
    }

        public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);
        Debug.Log("Inventory toggled: " + isInventoryOpen);
    }
}
