using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance = null;
    private float walk_speed;
    public static bool onTriggerEnter = false;

    public GameObject[] weapons;
    public bool[] hasWeapons;
    Vector2 MousePosition;
    Camera Camera;

    bool iDown;
    bool sDown1;
    bool sDown2;
    bool sDown3;
    bool isSwap;


    public static bool runCheck = false;
    public static bool moveCheck = false;


    private Animator anim;

    public static bool outOfStamina = false;

    private StatusController theStatusController;

    Vector3 position;

    GameObject nearObject;
    GameObject equipWeapon;
    public static int equipWeaponIndex = -1;

    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        theStatusController = FindObjectOfType<StatusController>();
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        MousePosition = Camera.ScreenToWorldPoint(MousePosition);
    }

    void Update()
    {
        CharacterMove();
        GetInput();
        Interation();
        Swap();
    }

    private void CharacterMove()
    {
        if (Input.GetKey(KeyCode.LeftShift) && theStatusController.GetCurrentSP() > 0)
        {
            runCheck = true;
            walk_speed = 7;
            theStatusController.DecreaseStamina(5);
        }
        else
        {
            runCheck = false;
            walk_speed = 2;
        }
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * walk_speed * Time.deltaTime);
                moveCheck = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * walk_speed * Time.deltaTime);
                moveCheck = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * walk_speed * Time.deltaTime);
                moveCheck = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * walk_speed * Time.deltaTime);
                moveCheck = true;
            }
        }
        else
        {
            moveCheck = false;
        }
        
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        }
        
    }
    private void Run()
    {

    }

    void GetInput()
    {
        iDown = Input.GetButtonDown("Interation");
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
    }

    void Swap()
    {
        if(sDown1 && (!hasWeapons[0] || equipWeaponIndex == 0))
        {
            return;
        }
        if (sDown2 && (!hasWeapons[1] || equipWeaponIndex == 1))
        {
            return;
        }
        if (sDown3 && (!hasWeapons[2] || equipWeaponIndex == 2))
        {
            return;
        }
        int weaponIndex = -1;
        if (sDown1) weaponIndex = 0;
        if (sDown2) weaponIndex = 1;
        if (sDown3) weaponIndex = 2;
        if(sDown1 || sDown2 || sDown3)
        {
            if(equipWeapon != null)
                equipWeapon.SetActive(false);
            equipWeaponIndex = weaponIndex;
            equipWeapon = weapons[weaponIndex];
            equipWeapon.SetActive(true);
        }
    }

    void Interation()
    {
        if(iDown && nearObject != null)
        {
            if(nearObject.tag == "Weapon")
            {
                Item item = nearObject.GetComponent<Item>();
                int weaponIndex = item.value;
                hasWeapons[weaponIndex] = true;
                Destroy(nearObject);
            }
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        onTriggerEnter = true;
        Item.GetCollider(other.gameObject, ref nearObject);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerEnter = false;
    }

    public void GetCollider(ref GameObject near)
    {
        nearObject = near;
    }
}
