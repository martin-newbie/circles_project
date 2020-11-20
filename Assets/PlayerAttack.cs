using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float coolTime;
    private float curTime;
    [SerializeField]
    private float range;

    [SerializeField]
    private bool autoChk;

    private float currentRange;

    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentRange = range;
    }
    void Update()
    {
        if(PlayerMove.equipWeaponIndex == 0) { autoChk = true; }
        if(PlayerMove.equipWeaponIndex == 1) { autoChk = true; }
        if(PlayerMove.equipWeaponIndex == 2) { autoChk = false; }
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        z += Random.Range(-currentRange, currentRange);
        transform.rotation = Quaternion.Euler(0, 0, z);
        if(curTime <= 0 && autoChk)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(bullet, pos.position, transform.rotation);
                if(currentRange <= 20)
                {
                    currentRange += 2 * Time.deltaTime;
                }
            }
            curTime = coolTime;
        }
        if (!autoChk)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(bullet, pos.position, transform.rotation);
            }
        }
        curTime -= Time.deltaTime;
        if(currentRange > range)
        {
            currentRange -= 2 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            currentRange = 0;
        }

        Vector3 mousePos2 = Input.mousePosition;

        Debug.Log(mousePos2);

        if (mousePos2.x < 400) // 왼쪽
        {
            sr.flipX = false;
            sr.flipY = true;
        }
        if (mousePos2.x >= 400) // 오른쪽
        {
            sr.flipX = false;
            sr.flipY = false;
        }
    }

}
