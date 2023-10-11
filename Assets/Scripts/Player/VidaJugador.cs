using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public float PuntosVida;
    public float VidaMaxima = 5;

    public Slider BarraVida;

    void Start()
    {
        PuntosVida = VidaMaxima;
    }


    public void TakeHit(int damage)
    {
        PuntosVida -= damage;

    }
    // Update is called once per frame
    void Update()
    {
        BarraVida.value = PuntosVida;

        if (this.PuntosVida <= 0f)
        {
            SceneManager.LoadScene(2);
        }

    }
}
