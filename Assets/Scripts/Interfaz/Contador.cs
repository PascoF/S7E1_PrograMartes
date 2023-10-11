using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Contador : MonoBehaviour
{

    public float contador = 0;
    public TextMeshProUGUI textoTiempoPro;

    void Start()
    {
        
    }

    void Update()
    {
        contador -= Time.deltaTime;
        textoTiempoPro.text = "" + contador.ToString("f1");

        if(contador < 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
