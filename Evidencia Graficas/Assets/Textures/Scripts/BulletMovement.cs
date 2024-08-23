using System;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20f;
    public float damageAmount = 10f; 
    public Action OnDestroyAction; 
   

    void Start()
    {
        Destroy(gameObject, 2f); 
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        Salud healthComponent = collision.gameObject.GetComponent<Salud>();
        if (healthComponent != null)
        {
            healthComponent.damageRecibido(damageAmount); 
        }

        Destroy(gameObject);
    }

    void OnDestroy()
    {
        OnDestroyAction?.Invoke();
    }
}
