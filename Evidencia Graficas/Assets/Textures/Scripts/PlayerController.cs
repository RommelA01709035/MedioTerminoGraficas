using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This player controller class will update the events from the vehicle player.
/// Standard coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Variables multijugador
    public string inputId;
    // Variables cámara
    private Animator animator;
    public Camera mainCamera;
    public Camera hoodCamera;
    public float speed = 5.0f;
    public float turnSpeed = 0.0f;
    public float horizontalInput;
    public float forwardInput;
    public Gun gun;

    // Factor de reducción de velocidad cuando Shift está presionado
    public float speedReductionFactor = 0.5f; // Reduce la velocidad al 50%


    /// <summary>
    /// This method is called before the first frame update
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        gun = GetComponentInChildren<Gun>();
    }

    /// <summary>
    /// This method is called once per frame
    /// </summary>
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputId);
        forwardInput = Input.GetAxis("Vertical" + inputId);
        
        

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput * speedReductionFactor * 4);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput * 4);
        }
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput * 26);

        if (Input.GetKeyDown(KeyCode.C))
        {
            bulleet();
        }
    }

    void bulleet()
    {

        gun.ShootOne();
    }

    public void DoEnd(){
        animator.SetTrigger("Defend");
    }


}
