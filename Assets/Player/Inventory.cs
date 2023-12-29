using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    private bool inventoryActive;
    public List<Item> items = new List<Item>();

    void Start()
    {
        inventoryPanel.SetActive(false); //�ʱ���� ��Ȱ��ȭ
    }

    public void ToggleInventory()
    {
        inventoryActive = !inventoryActive;
        inventoryPanel.SetActive(inventoryActive);
    }
    public void AddItem(Item newItem)
    {
        items.Add(newItem);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

}
