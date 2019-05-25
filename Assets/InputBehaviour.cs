using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class InputBehaviour : MonoBehaviour
{
    public float maximo;
    public InputField inputField;
    public Toggle toogle;
    protected NormalizadorBehaviour normalizadorBehaviour;

    public void SetNormalizador(NormalizadorBehaviour normalizadorBehaviour)
    {
        this.normalizadorBehaviour = normalizadorBehaviour;
    }

    public abstract bool CanToogleVariable(bool variable);

    public void ToogleVariable(bool variable)
    {
        variable = CanToogleVariable(variable);
        toogle.isOn = variable;
    }

    public abstract void ActualizarValor(float valor);

    public void CambiarValor(string valor)
    {
        if (valor.Length > 0)
        {
            float valorFloat = CambiarValor(Convert.ToSingle(valor));
            ActualizarValor(valorFloat);
        }
    }

    public float CambiarValor(float valor)
    {
        valor = Mathf.Max(0, Mathf.Min(valor, maximo));
        inputField.text = valor.ToString();
        return valor;
    }
}
