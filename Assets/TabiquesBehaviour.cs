using UnityEngine;
using UnityEngine.UI;

public class TabiquesBehaviour : MonoBehaviour
{
    public ContainerBehaviour containerIzquierda;
    public ContainerBehaviour containerDerecha;
    public NormalizadorBehaviour normalizadorIzquierda;
    public NormalizadorBehaviour normalizadorDerecha;
    public GameObject contenedorTextos;
    public Text textoPresion;
    public Text textoVolumen;
    public Text textoTemperatura;
    public Text textoMoles;

    void Start()
    {
        contenedorTextos.SetActive(false);
    }

    public void ActivarTabique(bool activado)
    {
        containerIzquierda.ActivarTabique(activado, containerDerecha.transform.localScale.x);
        containerDerecha.ActivarTabique(activado, containerIzquierda.transform.localScale.x);
        contenedorTextos.SetActive(!activado);
        if (!activado)
        {
            CalcularTotales();
        }
    }

    private void CalcularTotales()
    {
        float volumenTotal = normalizadorDerecha.volumen + normalizadorIzquierda.volumen;
        float molesTotales = normalizadorDerecha.moles + normalizadorIzquierda.moles;
        float presionTotal = (normalizadorDerecha.presion * normalizadorDerecha.volumen +
            normalizadorIzquierda.presion * normalizadorIzquierda.volumen) / volumenTotal;
        float temperaturaTotal = presionTotal * volumenTotal / (molesTotales * NormalizadorBehaviour.CONSTANTE_GASES);
        textoPresion.text = "P: " + presionTotal.ToString() + " atm";
        textoVolumen.text = "V: " + volumenTotal.ToString() + " L";
        textoTemperatura.text = "T: " + temperaturaTotal.ToString() + " K";
        textoMoles.text = "N: " + molesTotales.ToString() + " mol";
    }
}
