public class PresionInputBehaviour : InputBehaviour
{
    public override void ActualizarValor(float valor)
    {
        normalizadorBehaviour.CambiarPresion(valor);
    }

    public override bool CanToogleVariable(bool variable)
    {
        return normalizadorBehaviour.TooglePresion(variable);
    }
}
