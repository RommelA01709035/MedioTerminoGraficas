using System;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    public float speed = 20f;
    public Action OnDestroyAction; 
    void Start()
    {
        Destroy(gameObject, 2f); 
        
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    void OnDestroy()
    {
        OnDestroyAction?.Invoke();
    }
}