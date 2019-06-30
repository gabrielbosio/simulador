using UnityEngine;
using UnityEngine.UI;

public class TabiquesBehaviour : MonoBehaviour
{
    public ContainerBehaviour containerIzquierda;
    public ContainerBehaviour containerDerecha;
    public NormalizadorBehaviour normalizadorIzquierda;
    public NormalizadorBehaviour normalizadorDerecha;
    public GameObject contenedorTextos;
    public GameObject gasIzquierda;
    public GameObject gasDerecha;
    public Text textoPresion;
    public Text textoVolumen;
    public Text textoTemperatura;
    public Text textoMoles;
    private bool activado = true;

    void Start()
    {
        contenedorTextos.SetActive(!activado);
    }

    public void ActivarTabique()
    {
        activado = !activado;
        containerIzquierda.ActivarTabique(activado, containerDerecha.transform.localScale.x);
        containerDerecha.ActivarTabique(activado, containerIzquierda.transform.localScale.x);
        contenedorTextos.SetActive(!activado);
        if (activado)
        {
            ParticleSystem particleSystemDerecha = gasDerecha.GetComponent<ParticleSystem>();
            ParticleSystem particleSystemIzquierda = gasIzquierda.GetComponent<ParticleSystem>();
            particleSystemDerecha.Clear();
            particleSystemDerecha.Play();
            particleSystemIzquierda.Clear();
            particleSystemIzquierda.Play();
        }
        else
        {
            CalcularTotales();
        }
    }

    public void Actualizar()
    {
        if (!activado)
        {
            activado = !activado;
            ActivarTabique();
            normalizadorDerecha.ActualizarEntorno();
            normalizadorIzquierda.ActualizarEntorno();
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
