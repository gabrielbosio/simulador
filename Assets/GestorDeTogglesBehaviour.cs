using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestorDeTogglesBehaviour : MonoBehaviour {
    private const int CANTIDAD_DE_PROPIEDADES_FIJAS_MAXIMA = 2;
    private int cantidadDePropiedadesFijas = 0;
    private bool seDebenFijarPropiedades = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FijarPropiedad(GameObject toggle)
    {
        if (seDebenFijarPropiedades)
        {
            Toggle toggleBehaviour = toggle.GetComponent<Toggle>();
        
            if (toggleBehaviour != null)
            {
                cantidadDePropiedadesFijas += toggleBehaviour.isOn ? -1 : 1;

                if (cantidadDePropiedadesFijas > CANTIDAD_DE_PROPIEDADES_FIJAS_MAXIMA)
                {
                    cantidadDePropiedadesFijas = CANTIDAD_DE_PROPIEDADES_FIJAS_MAXIMA;
                    seDebenFijarPropiedades = false;
                    toggleBehaviour.isOn = true;
                }
            }
        }
        else
        {
            seDebenFijarPropiedades = true;
        }
    }
}
