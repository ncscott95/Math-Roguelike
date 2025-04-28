using UnityEngine;

public enum FunctionTypes
{
    CONSTANT,
    LINEAR,
    POLYNOMIAL,
    SINE,
    ROSEX,
    ROSEY
}

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

    // Value Calculation Functions
    public delegate float FValue(float t, float S, float a, float n);
    public float Constant(float t, float S, float a, float n) => a;
    public float Linear(float t, float S, float a, float n) => S * t;
    public float Polynomial(float t, float S, float a, float n) => a * Mathf.Pow(S * t, n);
    public float Sine(float t, float S, float a, float n) => a * Mathf.Sin(n * S * t);
    public float RoseX(float t, float S, float a, float n) => -1f * a * Mathf.Sin(n * S * t) * Mathf.Cos(S * t);
    public float RoseY(float t, float S, float a, float n) => -1f * a * Mathf.Sin(n * S * t) * Mathf.Sin(S * t);

    // String Functions
    public delegate string FString(float t, float S, float a, float n);
    public string ConstantString(float t, float S, float a, float n) => $"{a}";
    public string LinearString(float t, float S, float a, float n) => $"{(S != 1 ? S : "")}t";
    public string PolynomialString(float t, float S, float a, float n) => $"{(a != 1 ? a : "")}({(S != 1 ? S : "")}t)^{n}";
    public string SineString(float t, float S, float a, float n) => $"{(a != 1 ? a : "")}sin({n} * {(S != 1 ? S : "")}t)";
    public string RoseXString(float t, float S, float a, float n) => $"{(a != 1 ? a : "")}sin({n} * {(S != 1 ? S : "")}t)cos({(S != 1 ? S : "")}t)";
    public string RoseYString(float t, float S, float a, float n) => $"{(a != 1 ? a : "")}sin({n} * {(S != 1 ? S : "")}t)sin({(S != 1 ? S : "")}t)";
}
