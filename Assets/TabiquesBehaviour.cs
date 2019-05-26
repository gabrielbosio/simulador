using UnityEngine;

public class TabiquesBehaviour : MonoBehaviour
{
    public ContainerBehaviour containerIzquierda;
    public ContainerBehaviour containerDerecha;
    public NormalizadorBehaviour normalizadorIzquierda;
    public NormalizadorBehaviour normalizadorDerecha;

    public void ActivarTabique(bool activado)
    {
        containerIzquierda.ActivarTabique(activado, containerDerecha.transform.localScale.x);
        containerDerecha.ActivarTabique(activado, containerIzquierda.transform.localScale.x);
        if (!activado)
        {
            CalcularTotales();
        }
    }

    private void CalcularTotales()
    {

    }
}
