using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Salud : MonoBehaviour
{
    public float salud = 100;
    public float maxSalud = 100;

    [Header("Interfaz")]
    public Image BarraSalud;
    public Text textoSalud;
    public Text textoStatus;
    private Animator animator; 
    public Bear bear; 
    public PlayerController playerController; 

    void Start()
    {
        if (BarraSalud == null)
            BarraSalud = GameObject.Find("Barra").GetComponent<Image>();

        if (textoSalud == null)
            textoSalud = GameObject.Find("Text (Legacy)").GetComponent<Text>();

        if (textoStatus == null)
            textoStatus = GameObject.Find("textoStatus").GetComponent<Text>();

        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        ActualizarInterfaz();
    }

    public void damageRecibido(float _damage)
    {
        Debug.Log("Salud antes del daño: " + salud);
        salud -= _damage;
        if (salud <= 0)
        {
            salud = 0;
            StartCoroutine(EliminarJugador()); 
        }
        Debug.Log("Salud después del daño: " + salud);
    }

    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = salud / maxSalud;
        textoSalud.text = "Salud: " + salud.ToString("f0");
    }

    IEnumerator EliminarJugador()
    {
        if (animator != null)
        {
            Debug.Log("Se murió");
            if (CompareTag("Player"))
            {
                textoStatus.text = "¡Perdiste!";
                Destroy(gameObject); 
                bear.DoEnd(); 
                
            }
            else if (CompareTag("Oso"))
            {
                textoStatus.text = "¡Ganaste!";
                Destroy(gameObject); 
                playerController.DoEnd(); 
                
            }
        }

        yield return new WaitForSeconds(5.0f); 

        
    }

}
