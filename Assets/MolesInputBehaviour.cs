public class MolesInputBehaviour : InputBehaviour
{
    public override void ActualizarValor(float valor)
    {
        normalizadorBehaviour.CambiarMoles(valor);
    }

    public override bool CanToogleVariable(bool variable)
    {
        return normalizadorBehaviour.ToogleMoles(variable);
    }
}
