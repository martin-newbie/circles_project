using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private float inventorySize;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void UseInventory()
    {
        if (ActionController.gotItem)
        {
            inventorySize -= 1;
        }
    }
}
