using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,6,-7);

    
    void Start()
    {
        
    }

   
    void LateUpdate()
    {
        
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.1f);

        
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, 0.1f);
    }
}

