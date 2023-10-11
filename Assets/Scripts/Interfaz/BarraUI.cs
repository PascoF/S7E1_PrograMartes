using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarraUI : MonoBehaviour
{
    [Header("Referencias")]

    [Header("Puntaje")]
    float puntaje;
    float puntajeMax;

    public void Barra(float puntaje, float puntajeMax)
    {
        this.puntaje = Mathf.Clamp(puntaje, 0f, puntajeMax);
        this.puntajeMax = puntajeMax;

    }
}
