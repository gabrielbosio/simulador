using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenInputBehaviour : MonoBehaviour
{
    private const int VOLUMEN_MAXIMO = 224;
    public GameObject gas;
    public GameObject contenedor;
    private GasBehaviour gasBehaviour;
    private InputField inputField;
    private ParticleSystem gasParticleSystem;
    private float valor;
    private float valorInicial;
    private Vector3 escalaInicialContenedor;

    // Use this for initialization
    void Start()
    {
        gasBehaviour = gas.GetComponent<GasBehaviour>();
        gasParticleSystem = gas.GetComponent<ParticleSystem>();
        inputField = GetComponent<InputField>();
        valorInicial = gasBehaviour.volumen;
        escalaInicialContenedor = contenedor.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float volumenGas = gasBehaviour.volumen;

        if (valor != volumenGas) {
            valor = volumenGas;

            if (volumenGas > VOLUMEN_MAXIMO)
            {
                gasBehaviour.CambiarMoles(VOLUMEN_MAXIMO);
            }

            inputField.text = gasBehaviour.volumen.ToString();
        }

        gasBehaviour.volumenFijo = !inputField.enabled;
    }

    public void CambiarVolumen(string volumen)
    {
        if (volumen.Length > 0)
        {
            float volumenParseado = Math.Min(Convert.ToSingle(volumen), VOLUMEN_MAXIMO);

            if (volumenParseado > 0)
            {
                gasBehaviour.CambiarVolumen(volumenParseado);
                ActualizarContenedor(volumenParseado);
            }
            else
            {
                inputField.text = valor.ToString();
            }
        }
    }

    public void ActualizarContenedor(float volumen)
    {
        contenedor.transform.localScale = escalaInicialContenedor * volumen / valorInicial;
        gasParticleSystem.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        gasParticleSystem.Play();
    }
}
