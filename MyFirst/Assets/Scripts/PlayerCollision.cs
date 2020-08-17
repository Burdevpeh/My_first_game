using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMove movement;
    public GameObject shieldSphere;
    public GameObject headMagnet;
    public Transform Way_1;
    public Transform Way_2;
    public Transform player;
    public Animator animasyon;
    public TMPro.TextMeshProUGUI coinCount_txt;
    public AudioClip coin_audio;
    public AudioSource audi_obj;
    public bool isground = true;
    public bool have_magnet=false;
    public bool have_shield = false;
    public int coinCount=0;




    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Respawn")
        {
            movement.enabled = false;
            animasyon.SetBool("death", true);
            SceneManager.LoadScene(2);
        }
       

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "End_1")
        {
            Way_2.position = new Vector3(Way_1.position.x, Way_1.position.y, Way_1.position.z + 150.0f);
        }
        
        if (other.gameObject.name == "End_2")
        {
            Way_1.position = new Vector3(Way_2.position.x, Way_2.position.y, Way_2.position.z + 150.0f);
        }


        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinCount += 1;
            coinCount_txt.text = coinCount.ToString();
            audi_obj.PlayOneShot(coin_audio);
        }

        if (other.gameObject.tag == "Magnet")
        {
            Destroy(other.gameObject);
            have_magnet = true;
            headMagnet.SetActive(true);
            Invoke("resetMagnet", 10.0f);

        }
        
        if (other.gameObject.tag == "Shield")
        {
            Destroy(other.gameObject);
            have_shield = true;
            shieldSphere.SetActive(true);
            Invoke("resetShield", 10.0f);
            

            

        }


    }

    private void OnCollisionStay(Collision collision)
    {
        isground = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isground = false;
    }
    void resetMagnet()
    {
        have_magnet = false;
        headMagnet.SetActive(false);
    }

    void resetShield()
    {
        have_shield = false;
        shieldSphere.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (coinCount == 10 && SceneManager.GetActiveScene().buildIndex==0) //LEVEL1 TO 2 UI
        {
            
            SceneManager.LoadScene(3);
        }
        
        if (coinCount == 50 && SceneManager.GetActiveScene().buildIndex == 1) //LEVEL2 TO FİNAL UI
        {

            SceneManager.LoadScene(4);
        }

    }
}
