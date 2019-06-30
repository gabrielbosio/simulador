using UnityEngine;

public class GasBehaviour : MonoBehaviour
{
    private ParticleSystem gas;
    public const int esferasPorMol = 30;
    public const float velocidadPorTemperatura = 0.018f;
    public const float relacionVolumenRadio = 0.178f;

    void Start()
    {
        gas = GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// Recrea el gas con los nuevos parametros
    /// </summary>
    /// <param name="presion">No se utiliza</param>
    /// <param name="volumen">Define a que distancia del centro comenzaran los elementos</param>
    /// <param name="temperatura">Define la velocidad de los elementos</param>
    /// <param name="moles">Defina la cantidad de elementos</param>
    public void ActualizarParticleSystem(float presion, float volumen, float temperatura, float moles)
    {
        ParticleSystem.MainModule asd = gas.main;
        asd.startSpeed = velocidadPorTemperatura * temperatura;
        ParticleSystem.ShapeModule shapeModule = gas.shape;
        shapeModule.radius = relacionVolumenRadio * volumen;
        ParticleSystem.Burst[] nuevoBurst = new ParticleSystem.Burst[gas.emission.burstCount];
        gas.emission.GetBursts(nuevoBurst);
        nuevoBurst[0].count = Mathf.Ceil(esferasPorMol * moles);
        gas.emission.SetBursts(nuevoBurst);
        gas.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        gas.Play();
    }
}
