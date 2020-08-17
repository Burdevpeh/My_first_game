using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateObject : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject coin;
    public GameObject obstacle;
    public GameObject Rbear;
    public GameObject Lbear;
    public GameObject magnet;
    public GameObject Rpresent;
    public GameObject Lpresent;
    public GameObject secondPlane;
    public GameObject shield;
    public Transform player;
    public PlayerMove movement;
    public PlayerCollision PlCollision;

    float deleteTime = 6.0f;

    float L_x_coor = -4.0f;
    float M_x_coor = 0.0f;
    float R_x_coor = 4.0f;



    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            InvokeRepeating("selection", 2.0f, 0.5f);
        }

        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            InvokeRepeating("selection", 2.0f, 2.0f);
        }

    }


    void selection()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) 
        { 
            if (movement.enabled)
            {
                int rndm = Random.Range(0, 100);

                if (rndm >= 0 && rndm <= 45)
                {
                    create(coin, 1.0f);

                }

                if (rndm > 45 && rndm <= 50)
                {
                    create(Rbear, 0.0f);
                }

                if (rndm > 50 && rndm <= 55)
                {
                    create(Lbear, 0.0f);
                }


                if (rndm > 55 && rndm <= 90)
                {
                    create(obstacle, 0.4f);
                }

                if (rndm > 90 && rndm <= 100 && player.gameObject.GetComponent<PlayerCollision>().have_magnet == false)
                {
                    create(magnet, 1.4f);
                }
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            create(secondPlane, 10.0f);
            
            if (PlCollision.coinCount <= 70)
            {
                create(secondPlane, 10.0f);

                if (PlCollision.coinCount <= 50)
                {
                    create(secondPlane, 10.0f);
                }
            }

            int rndm = Random.Range(0, 100);

            if (rndm > 50 && rndm <= 100 && player.gameObject.GetComponent<PlayerCollision>().have_shield == false)
            {
                create(shield, 10.0f);
            }
        }
    }

    void create(GameObject obj, float Y_coordinate)
    {
        GameObject clone_obj = Instantiate(obj);
        GameObject clone_objL = Instantiate(Lpresent);
        GameObject clone_objR = Instantiate(Rpresent);

        int rndm = Random.Range(0, 100);

        //FOR LEVEL 1
        if (rndm >= 0 && rndm <= 33 && obj == Rbear)
        {
            clone_obj.transform.position = new Vector3(R_x_coor, Y_coordinate, player.position.z + 70.0f);
            clone_objR.transform.position = new Vector3(R_x_coor, Y_coordinate, player.position.z + 68.0f);       
            
        }
        
        if (rndm >= 66 && rndm <= 100 && obj == Lbear)
        {
            clone_obj.transform.position = new Vector3(L_x_coor, Y_coordinate, player.position.z + 70.0f);
            clone_objL.transform.position = new Vector3(L_x_coor, Y_coordinate, player.position.z + 68.0f);
            
        }

        if (rndm >= 0 && rndm <= 33 && obj != Rbear)
        {
            clone_obj.transform.position = new Vector3(L_x_coor, Y_coordinate, player.position.z + 70.0f);
        }

        if (rndm > 33 && rndm <= 66 && obj != Lbear)
        {
            clone_obj.transform.position = new Vector3(R_x_coor, Y_coordinate, player.position.z + 70.0f);
        }

        if (rndm > 66 && rndm <= 100 && obj != Lbear && obj != Rbear)
        {
            clone_obj.transform.position = new Vector3(M_x_coor, Y_coordinate, player.position.z + 70.0f);
        }
        

            Destroy(clone_obj, deleteTime);
            Destroy(clone_objL, deleteTime);
            Destroy(clone_objR, deleteTime);
 
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
