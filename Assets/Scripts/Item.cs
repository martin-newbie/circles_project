using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : MonoBehaviour
{
    

    public enum Type
    {
        Ammo,
        Coin,
        Grenade,
        Heart,
        Weapon
    }

    public Type type;
    public int value;

    void Update()
    {
        
    }

}
