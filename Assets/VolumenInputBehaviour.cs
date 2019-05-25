public class VolumenInputBehaviour : InputBehaviour
{
    public override void ActualizarValor(float valor)
    {
        normalizadorBehaviour.CambiarVolumen(valor);
    }

    public override bool CanToogleVariable(bool variable)
    {
        return normalizadorBehaviour.ToogleVolumen(variable);
    }
}
