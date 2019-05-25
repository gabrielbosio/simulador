using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class InputBehaviour : MonoBehaviour
{
    public float maximo;
    public InputField inputField;
    protected NormalizadorBehaviour normalizadorBehaviour;

    public void SetNormalizador(NormalizadorBehaviour normalizadorBehaviour) {
        this.normalizadorBehaviour = normalizadorBehaviour;
    }

    public abstract void ToogleVariable(bool variable);

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
