using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresionInputBehaviour : MonoBehaviour {
    public GameObject gas;
    private GasBehaviour gasBehaviour;
    private InputField inputField;
    private float valor;

	// Use this for initialization
	void Start () {
        gasBehaviour = gas.GetComponent<GasBehaviour>();
        inputField = GetComponent<InputField>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float presionGas = gasBehaviour.presion;

        if (valor != presionGas)
        {
            valor = presionGas;
            inputField.text = gasBehaviour.presion.ToString();
        }

        gasBehaviour.presionFija = !inputField.enabled;
    }

    public void CambiarPresion(string presion)
    {

        if (presion.Length > 0)
        {
            float presionParseado = Convert.ToSingle(presion);

            if (presionParseado > 0)
            {
                gasBehaviour.CambiarPresion(presionParseado);
            }
            else
            {
                inputField.text = valor.ToString();
            }
        }
    }
}
