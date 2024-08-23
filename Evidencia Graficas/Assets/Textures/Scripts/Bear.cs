using UnityEngine;
using System.Collections;

public class Bear : MonoBehaviour
{
    private Animator animator;
    public Gun gun; 
    public float fireRate = 0.1f;
    public float moveSpeed = 2f; 
    private float nextTimeToFire = 0f;
    private int currentAnimation = 0;
    public Transform targetPoint;
    public Salud saludComponent;

    void Start()
    {
        animator = GetComponent<Animator>();
        gun = GetComponentInChildren<Gun>();
        saludComponent = GetComponent<Salud>();

        if (targetPoint == null)
        {
            targetPoint = GameObject.Find("Target").transform;
        }
    }

    void Update()
    {
        // Verifica si la salud ha llegado a cero
        if (saludComponent.salud <= 0)
        {
            StartCoroutine(DoDead());
            return;
        }

        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;

            Debug.Log("Current Animation: " + currentAnimation);

            if (currentAnimation < 5)
            {
                DoEat();
            }
            else if (currentAnimation >= 5 && currentAnimation < 10)
            {
                DoAttackMainLeft();
            }
            else if (currentAnimation >= 10 && currentAnimation <= 15)
            {
                DoFirstSpecial();
            }
            else if (currentAnimation >= 16 && currentAnimation <= 20)
            {
                DoAttackMainRight();
            }
            else if (currentAnimation >= 21 && currentAnimation <= 25)
            {
                DoSleep();
            }
            else
            {
                DoDead();
            }
        }
    }

    void Sequence(){
        
    }

    void MoveTowardsTarget()
    {
        if (targetPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
        }
    }

    void DoAttackMainRight()
    {
        animator.SetTrigger("Attack2");
        gun.ShootPatternRight();
        currentAnimation++;
    }

    void DoAttackMainLeft()
    {
        animator.SetTrigger("Attack1");
        gun.ShootPatternLeft();
        currentAnimation++;
    }

    void DoFirstSpecial()
    {
        animator.SetTrigger("Jump");
        gun.ShootPatternCircle();
        currentAnimation++;
    }

    void DoAttackEnd()
    {
        animator.SetTrigger("Attack1");
        gun.ShootPatternEnd();
        currentAnimation += 1;
    }

    void DoEat()
    {
        animator.SetTrigger("Eat");
        gun.ShootPatternCircunference();
        currentAnimation += 1;
    }

    void DoSleep()
    {
        animator.SetTrigger("Sleep");
        gun.BombBurble();
        currentAnimation += 1;
    }

    public void DoEnd(){
        animator.SetTrigger("Sleep");
    }

    IEnumerator DoDead()
    {
        if (animator != null)
        {
            animator.SetTrigger("Death");
        }

        yield return new WaitForSeconds(100.0f);

        Destroy(gameObject);
    }
}
