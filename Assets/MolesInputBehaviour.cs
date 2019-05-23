using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MolesInputBehaviour : MonoBehaviour {
    private const float MOLES_MAXIMO = 10;
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
        float molesGas = gasBehaviour.moles;

        if (valor != molesGas)
        {
            valor = molesGas;

            if (molesGas > MOLES_MAXIMO)
            {
                gasBehaviour.CambiarMoles(MOLES_MAXIMO);
            }

            inputField.text = gasBehaviour.moles.ToString();
        }

        gasBehaviour.molesFijo = !inputField.enabled;
    }

    public void CambiarMoles(string moles)
    {
        if (moles.Length > 0)
        {
            float molesParseado = Math.Min(Convert.ToSingle(moles), MOLES_MAXIMO);

            if (molesParseado > 0)
            {
                gasBehaviour.CambiarMoles(molesParseado);
            }
            else
            {
                inputField.text = valor.ToString();
            }
        }
    }
}
