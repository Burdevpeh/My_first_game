using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    bool flag = false;
    public Transform par;
    float player_x;
    float player_y;
    float player_z;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            par.position = Vector3.Lerp(par.position, new Vector3(player_x, player_y, player_z+13.0f), Time.deltaTime*3.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            flag = true;
            player_x = 0.0f;
            player_y = other.transform.position.y;
            player_z = other.transform.position.z;
        }
    }
}
