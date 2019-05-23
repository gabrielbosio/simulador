using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperaturaInputBehaviour : MonoBehaviour {
    public GameObject gas;
    private GasBehaviour gasBehaviour;
    private InputField inputField;
    private float valor;

    // Use this for initialization
    void Start()
    {
        gasBehaviour = gas.GetComponent<GasBehaviour>();
        inputField = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        float temperaturaGas = gasBehaviour.temperatura;

        if (valor != temperaturaGas)
        {
            valor = temperaturaGas;
            inputField.text = gasBehaviour.temperatura.ToString();
        }

        gasBehaviour.temperaturaFija = !inputField.enabled;
    }

    public void CambiarTemperatura(string temperatura)
    {
        if (temperatura.Length > 0)
        {
            float temperaturaParseado = Convert.ToSingle(temperatura);

            if (temperaturaParseado > 0)
            {
                gasBehaviour.CambiarTemperatura(temperaturaParseado);
            }
            else
            {
                inputField.text = valor.ToString();
            }
        }
    }
}
