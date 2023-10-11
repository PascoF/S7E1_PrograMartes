using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGmelee : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.collider.GetComponent<VidaJugador>();

        if (player)
        {
            player.TakeHit(damage);
        }

    }



    void Update()
    {
        
    }
}
