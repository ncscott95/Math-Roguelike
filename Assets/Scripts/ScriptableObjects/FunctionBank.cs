using UnityEngine;

[CreateAssetMenu(fileName = "FunctionBank")]
public class FunctionBank : ScriptableObject
{
    public class Variable
    {
        public string Name;
        public float Value;

        public Variable(string name, float value)
        {
            Name = name;
            Value = value;
        }
    }

    static FunctionBank _instance;
    public static FunctionBank Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = Resources.Load<FunctionBank>("FunctionBank");
            }
            return _instance;
        }
    }

    public float Constant(float t, float S, float a, float n)
    {
        return a;
    }

    public float Linear(float t, float S, float a, float n)
    {
        return S * t;
    }

    public float Polynomial(float t, float S, float a, float n)
    {
        return a * Mathf.Pow(S * t, n);
    }

    public float Sine(float t, float S, float a, float n)
    {
        return a * Mathf.Sin(n * S * t);
    }

    public float RoseX(float t, float S, float a, float n)
    {
        return -1f * a * Mathf.Sin(n * S * t) * Mathf.Cos(S * t);
    }

    public float RoseY(float t, float S, float a, float n)
    {
        return -1f * a * Mathf.Sin(n * S * t) * Mathf.Sin(S * t);
    }
}
