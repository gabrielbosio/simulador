using System;
using UnityEngine;

public class GasBehaviour : MonoBehaviour
{
    private const float CONSTANTE_GASES = 0.082f;
    public float presion;
    public float volumen;
    public float temperatura;
    public float moles;
    public bool presionFija = false;
    public bool volumenFijo = false;
    public bool temperaturaFija = false;
    public bool molesFijo = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarPresion(float presion)
    {
        this.presion = presion;
        ActualizarVolumen();
        ActualizarTemperatura();
        ActualizarMoles();
    }

    public void CambiarVolumen(float volumen)
    {
        this.volumen = volumen;
        ActualizarPresion();
        ActualizarTemperatura();
        ActualizarMoles();
    }

    public void CambiarMoles(float moles)
    {
        this.moles = moles;
        ActualizarPresion();
        ActualizarVolumen();
        ActualizarTemperatura();
        ActualizarParticleSystem(0,0,0,0);
    }

    public void CambiarTemperatura(float temperatura)
    {
        this.temperatura = temperatura;
        ActualizarPresion();
        ActualizarVolumen();
        ActualizarMoles();
    }

    private void ActualizarPresion()
    {
        if (!presionFija)
        {
            presion = moles * CONSTANTE_GASES * temperatura / volumen;
        }
    }

    private void ActualizarMoles()
    {
        if (!molesFijo)
        {
            moles = Convert.ToSingle(presion * volumen / (CONSTANTE_GASES * temperatura));
            ActualizarParticleSystem(0,0,0,0);
        }
    }

    private void ActualizarTemperatura()
    {
        if (!temperaturaFija)
        {
            temperatura = presion * volumen / (moles * CONSTANTE_GASES);
        }
    }

    private void ActualizarVolumen()
    {
        if (!volumenFijo)
        {
            volumen = moles * CONSTANTE_GASES * temperatura / presion;
            //GameObject.Find("VolumenInput").GetComponent<VolumenInputBehaviour>().ActualizarContenedor(volumen);
        }
    }

    public void ActualizarParticleSystem(float presion, float volumen, float temperatura, float moles)
    {
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        ParticleSystem.Burst[] nuevoBurst = new ParticleSystem.Burst[particleSystem.emission.burstCount];
        particleSystem.emission.GetBursts(nuevoBurst);
        nuevoBurst[0].count = 30 * moles;
        particleSystem.emission.SetBursts(nuevoBurst);
        particleSystem.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        particleSystem.Play();
    }
}
