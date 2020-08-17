using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    PlayerCollision bunny;
    Transform player;
    
    float dist;


    // Start is called before the first frame update
    void Start()
    {
        bunny = GameObject.Find("Zombunny").GetComponent<PlayerCollision>();
        player = GameObject.Find("Zombunny").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (bunny.have_magnet)
        {
            dist = Vector3.Distance(transform.position, player.position);
            if (dist <= 20)
            {
                transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * 8.0f);
            }
        }
    }
}
