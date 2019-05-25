using UnityEngine;

public class ContainerBehaviour : MonoBehaviour
{
    public GameObject container = null;
    public const float relacionVolumenSize = 0.0447f;

    public void ActualizarVolumen(float volumen)
    {
        float size = relacionVolumenSize * volumen;
        container.transform.localScale = new Vector3(size, size, size);
    }
}
