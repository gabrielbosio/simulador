public class TemperaturaInputBehaviour : InputBehaviour
{
    public override void ActualizarValor(float valor)
    {
        normalizadorBehaviour.CambiarTemperatura(valor);
    }

    public override void ToogleVariable(bool variable)
    {
    }
}
