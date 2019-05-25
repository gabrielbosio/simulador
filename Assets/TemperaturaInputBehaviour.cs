public class TemperaturaInputBehaviour : InputBehaviour
{
    public override void ActualizarValor(float valor)
    {
        normalizadorBehaviour.CambiarTemperatura(valor);
    }

    public override bool CanToogleVariable(bool variable)
    {
        return normalizadorBehaviour.ToogleTemperatura(variable);
    }
}
