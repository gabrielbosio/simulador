using UnityEngine;

public class TabiquesBehaviour : MonoBehaviour
{
    public ContainerBehaviour containerIzquierda;
    public ContainerBehaviour containerDerecha;

    public void ActivarTabique(bool activado)
    {
        containerIzquierda.ActivarTabique(activado);
        containerDerecha.ActivarTabique(activado);
    }
}
