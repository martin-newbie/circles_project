using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : MonoBehaviour
{
    public static bool mouseEnter = false;
    static GameObject gameObj;
    static GameObject nearObj;

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

    private void OnMouseEnter()
    {
        mouseEnter = true;
        if (gameObj.tag == "Weapon")
        {
            nearObj = gameObj.gameObject;
            PlayerMove.instance.GetCollider(ref nearObj);
        }
    }

    private void OnMouseExit()
    {
        mouseEnter = false;
        if(gameObj.tag == "Weapon")
        {
            nearObj = null;
        }
    }

    public static void GetCollider(GameObject obj, ref GameObject near)
    {
        gameObj = obj;
        nearObj = near;
    }

}
