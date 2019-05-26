using UnityEngine;

public class ContainerBehaviour : MonoBehaviour
{
    public GameObject container = null;
    public const float relacionVolumenSize = 0.0447f;
    public float relacionPositionSize = 5f;
    public GameObject tabique = null;

    public void ActualizarVolumen(float volumen)
    {
        float size = relacionVolumenSize * volumen;
        container.transform.localPosition = new Vector3(size * relacionPositionSize, 0, 0);
        container.transform.localScale = new Vector3(size, size, size);
    }

    public void ActivarTabique(bool activado)
    {
        tabique.SetActive(activado);
    }
}
