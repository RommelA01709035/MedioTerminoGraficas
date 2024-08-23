using UnityEngine;
using System.Collections;
public class Damage : MonoBehaviour
{
    public float DamageValue = 10.0f;
    public GameObject shooter;
    private bool canDamage = false;
    public float delay = 0.3f; 

    void Start()
    {
        canDamage = false;
        StartCoroutine(EnableDamageAfterDelay());
    }

    IEnumerator EnableDamageAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        canDamage = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!canDamage || other.gameObject == shooter)
        {
            return;
        }

        Salud saludComponent = other.GetComponent<Salud>();
        if (saludComponent != null)
        {
            saludComponent.damageRecibido(DamageValue);
        }
    }
}

