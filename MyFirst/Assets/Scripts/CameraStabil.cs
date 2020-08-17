using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabil : MonoBehaviour
{
    public Transform player;
    //public Vector3 offset;

   
    void Update()
    {
        //transform.position = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * 3.0f);
    }
}
