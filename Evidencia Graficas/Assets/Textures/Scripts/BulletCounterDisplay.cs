using UnityEngine;
using TMPro;

public class BulletCounterDisplay : MonoBehaviour
{
    public Gun gun; 
    public TextMeshProUGUI bulletCountText;

    void Update()
    {
        //bulletCountText.text = "Bullets Alive: " + gun.bulletCountAlive;
    }
}
