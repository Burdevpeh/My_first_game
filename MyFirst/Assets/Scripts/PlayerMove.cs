using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody rigid;
    public Animator anim;
    public PlayerCollision collision;
    int right=0;
    int left=0;


    void Start()
    {
    }

    
    void Update()
    {
        movement();
    }


    void movement() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (collision.isground)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 2000);
                anim.SetBool("jump", true);
                Invoke("jumpFalse", 1.2f);
            }

        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {

            if (collision.isground)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 6000);
                anim.SetBool("jump", true);
                Invoke("jumpFalse", 3.4f);
            }

        }

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



        if (right == 1 && left == 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(4.0f, transform.position.y, transform.position.z), Time.deltaTime * 4.0f);
        }

        else if (right == 0 && left == 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0.0f, transform.position.y, transform.position.z), Time.deltaTime * 4.0f);
        }
        else if (left == 1 && right == 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-4.0f, transform.position.y, transform.position.z), Time.deltaTime * 4.0f);
        }

        transform.Translate(0, 0, 15 * Time.deltaTime);

    }

   
    void jumpFalse()
    {
        anim.SetBool("jump", false);
    }
}