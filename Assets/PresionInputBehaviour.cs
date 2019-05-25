public class PresionInputBehaviour : InputBehaviour
{
    public override void ActualizarValor(float valor)
    {
        normalizadorBehaviour.CambiarPresion(valor);
    }

    public override void ToogleVariable(bool variable)
    {
    }
}
