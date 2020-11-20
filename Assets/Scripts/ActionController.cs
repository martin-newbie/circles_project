using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField] private Text actionText;
    public static bool gotItem;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            actionText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                OnPickUp();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            actionText.gameObject.SetActive(false);
            gotItem = true;
        }
    }

    void OnPickUp()
    {
        Debug.Log("DDD");
        gameObject.SetActive(false);
    }
}
