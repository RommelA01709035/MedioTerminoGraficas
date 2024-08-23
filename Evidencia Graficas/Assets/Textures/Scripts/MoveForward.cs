using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate( Vector3.forward * speed * Time.deltaTime);
    }
}
