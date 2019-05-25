using System;
using UnityEngine;

/// <summary>
/// Calculos estableciendo PV=NRT
/// P en atm, V en l, N en mol, T en K
/// 
/// Al haber cambios en un valor se ajustan raiz x de la variacion los otros valores siendo x la catidad de variables
/// Ej:
/// Dado que son varaibles V y N,
/// Siendo P = 1, V = 22.4, N = 1, T = 273
/// 1*22.4=1*0.082051282*273
/// Se cambia P a 5
/// Se aplica deltaP = 5
/// Entonces
/// deltas = Math.Pow(5, 1/2) = 2.23606
/// deltaV = 1/deltas (Ya que esta del mismo lado en la ecuacion)
/// deltaN = deltas
/// resultado 
/// V = Vi * deltaV = 22.4 * 1 / 2.23606 = 10.0176
/// N = Ni * deltaN = 1 * 2.23606 = 2.23606
/// 5*10.0176=2.23606*0.082051282*273
/// </summary>
public class NormalizadorBehaviour : MonoBehaviour
{

    private readonly float CONSTANTE_GASES = 0.082051282f;
    public InputBehaviour presionInput;
    public InputBehaviour volumenInput;
    public InputBehaviour temperaturaInput;
    public InputBehaviour molesInput;
    public GasBehaviour gasBehaviour;

    private float presion = 1f;
    private float volumen = 22.4f;
    private float temperatura = 273f;
    private float moles = 1f;

    // Cero es fijo uno es variable, para el ajuste acorde a la cantidad de variables
    private int presionVariable = 1;
    private int volumenVariable = 1;
    private int temperaturaVariable = 1;
    private int molesVariable = 1;

    // Use this for initialization
    void Start()
    {
        presionInput.SetNormalizador(this);
        presionInput.CambiarValor(presion);
        volumenInput.SetNormalizador(this);
        volumenInput.CambiarValor(volumen);
        temperaturaInput.SetNormalizador(this);
        temperaturaInput.CambiarValor(temperatura);
        molesInput.SetNormalizador(this);
        molesInput.CambiarValor(moles);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float CambiarPresion(float presion)
    {
        AjusteDelta(this.presion, presion, true);
        this.presion = presion;
        ActualizarMoles();
        ActualizarVolumen();
        ActualizarTemperatura();
        return presion;
    }

    public void CambiarVolumen(float volumen)
    {
        AjusteDelta(this.volumen, volumen, true);
        this.volumen = volumen;
        ActualizarMoles();
        ActualizarPresion();
        ActualizarTemperatura();
    }

    public void CambiarMoles(float moles)
    {
        AjusteDelta(this.moles, moles, false);
        this.moles = moles;
        ActualizarPresion();
        ActualizarVolumen();
        ActualizarTemperatura();
        ActualizarParticleSystem();
    }

    public void CambiarTemperatura(float temperatura)
    {
        AjusteDelta(this.temperatura, temperatura, false);
        this.temperatura = temperatura;
        ActualizarMoles();
        ActualizarPresion();
        ActualizarVolumen();
    }

    /// <summary>
    /// Ajusta los valores segun la variacion de otro valor
    /// </summary>
    /// <param name="valorInicial">Valor del parametro antes del cambio</param>
    /// <param name="valorActual">Valor del parametro luego del cambio</param>
    /// <param name="izquierda">Si el valor se encuentra del lado izquierdo de PV=NRP (Pensar un metodo mejor para resolver)</param>
    private void AjusteDelta(float valorInicial, float valorActual, bool izquierda)
    {
        float delta = valorActual / valorInicial;
        delta = Mathf.Pow(delta, 1 / (presionVariable + volumenVariable + temperaturaVariable + molesVariable - 1));
        if (izquierda)
        {
            delta = 1 / delta;
        }
        if (presionVariable == 1)
        {
            presion *= delta;
        }
        if (volumenVariable == 1)
        {
            volumen *= delta;
        }
        if (temperaturaVariable == 1)
        {
            presion /= delta;
        }
        if (molesVariable == 1)
        {
            presion /= delta;
        }
    }

    private void ActualizarPresion()
    {
        if (presionVariable == 1)
        {
            presion = moles * CONSTANTE_GASES * temperatura / volumen;
        }
    }

    private void ActualizarMoles()
    {
        if (molesVariable == 1)
        {
            moles = Convert.ToSingle(presion * volumen / (CONSTANTE_GASES * temperatura));
            ActualizarParticleSystem();
        }
    }

    private void ActualizarTemperatura()
    {
        if (temperaturaVariable == 1)
        {
            temperatura = presion * volumen / (moles * CONSTANTE_GASES);
        }
    }

    private void ActualizarVolumen()
    {
        if (volumenVariable == 1)
        {
            volumen = moles * CONSTANTE_GASES * temperatura / presion;
            //GameObject.Find("VolumenInput").GetComponent<VolumenInputBehaviour>().ActualizarContenedor(volumen);

            //contenedor.transform.localScale = escalaInicialContenedor * volumen / valorInicial;
            //gasParticleSystem.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
            //gasParticleSystem.Play();
        }
    }

    private void ActualizarParticleSystem()
    {
        gasBehaviour.ActualizarParticleSystem(presion, volumen, temperatura, moles);
    }
}
