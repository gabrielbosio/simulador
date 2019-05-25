public class MolesInputBehaviour : InputBehaviour
{
    public override void ActualizarValor(float valor)
    {
        normalizadorBehaviour.CambiarMoles(valor);
    }

    public override void ToogleVariable(bool variable)
    {
    }
}
