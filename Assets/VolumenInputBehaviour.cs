public class VolumenInputBehaviour : InputBehaviour
{
    public override void ActualizarValor(float valor)
    {
        normalizadorBehaviour.CambiarVolumen(valor);
    }

    public override void ToogleVariable(bool variable)
    {
        //normalizadorBehaviour.ToogleVolumen(variable);
    }
}
