using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMove : MonoBehaviour
{

    public Rigidbody rigid;
    public Rigidbody bunny;
    public Animator anim;
    public PlayerCollision PlCollision;
    int right = 0;
    int left = 0;
    int flag1 = 0;
    bool flag2 = true;
    float dist;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        movement();
        if(flag1==0 && PlCollision.have_shield==false)
        {
            attack();
            
        }
        dist = transform.position.z - bunny.position.z;

        if (flag1 == 1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 3.0f), Time.deltaTime * 3.0f);

            if (dist < 0)
            {
                flag1 = 2;
            }
        }
        

        if (flag1 == 2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 3.0f), Time.deltaTime * 2.0f);
            anim.SetBool("attack", false);

            if (dist > 30)
            {
                flag1 = 0;
                flag2 = true;
            }
        }

    }

    void attack()
    {
        int rndm = Random.Range(0, 1000);   
        if (rndm >= 0 && rndm <= 1)
        {
            flag2 = false;
            anim.SetBool("attack", true);
            flag1 = 1;
        }
    }

    void movement()
    {
        if (flag2 == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (left == 1)
                {
                    left = 0;
                }
                else
                {
                    right = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (right == 1)
                {
                    right = 0;
                }
                else
                {
                    left = 1;
                }


            }

        }

        if (right == 1 && left == 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(4.0f, transform.position.y, transform.position.z), Time.deltaTime * 0.5f);
        }

        else if (right == 0 && left == 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0.0f, transform.position.y, transform.position.z), Time.deltaTime * 0.5f);
        }
        else if (left == 1 && right == 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-4.0f, transform.position.y, transform.position.z), Time.deltaTime * 0.5f);
        }

        transform.Translate(0, 0, -15 * Time.deltaTime);
    }

}
