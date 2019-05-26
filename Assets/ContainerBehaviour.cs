using UnityEngine;

public class ContainerBehaviour : MonoBehaviour
{
    public GameObject container = null;
    public const float relacionVolumenSize = 0.0447f;
    public float relacionPositionSize = 5f;
    public GameObject tabique = null;
    public GameObject tabiqueSuperior = null;
    public GameObject tabiqueInferior = null;
    public GameObject tabiqueIzquierdo = null;
    public GameObject tabiqueDerecho = null;

    public void ActualizarVolumen(float volumen)
    {
        float size = relacionVolumenSize * volumen;
        container.transform.localPosition = new Vector3(size * relacionPositionSize, 0, 0);
        container.transform.localScale = new Vector3(size, size, size);
    }

    public void ActivarTabique(bool activado, float sizeAdyacente)
    {
        tabique.SetActive(activado);
        if (!activado)
        {
            float size = this.transform.localScale.x;
            bool subtabiques = size > sizeAdyacente;
            tabiqueSuperior.SetActive(subtabiques);
            tabiqueInferior.SetActive(subtabiques);
            tabiqueIzquierdo.SetActive(subtabiques);
            tabiqueDerecho.SetActive(subtabiques);
            if (subtabiques)
            {
                float relacion = sizeAdyacente / size;
                float sizeTabique = 0.5f * (1f - relacion);
                tabiqueSuperior.transform.localScale = new Vector3(sizeTabique, 1, 1);
                tabiqueInferior.transform.localScale = new Vector3(sizeTabique, 1, 1);
                tabiqueIzquierdo.transform.localScale = new Vector3(1, 1, sizeTabique);
                tabiqueDerecho.transform.localScale = new Vector3(1, 1, sizeTabique);
                float offset = 2.5f * (1f + relacion);
                tabiqueSuperior.transform.localPosition = new Vector3(-relacionPositionSize, offset, 0);
                tabiqueInferior.transform.localPosition = new Vector3(-relacionPositionSize, -offset, 0);
                tabiqueIzquierdo.transform.localPosition = new Vector3(-relacionPositionSize, 0, offset);
                tabiqueDerecho.transform.localPosition = new Vector3(-relacionPositionSize, 0, -offset);
            }
        }
    }
}
