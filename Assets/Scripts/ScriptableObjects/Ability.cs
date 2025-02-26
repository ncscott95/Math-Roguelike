using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public class AbilityFunction
    {
        public FunctionBank.FValue ValueFunction;
        public FunctionBank.FString StringValue;

        public AbilityFunction(FunctionTypes type)
        {
            if (FunctionBank.Instance == null)
            {
                Debug.LogError("FunctionBank.Instance is null!");
                return;
            }

            switch(type)
            {
                case FunctionTypes.CONSTANT:
                    ValueFunction = FunctionBank.Instance.Constant;
                    StringValue = FunctionBank.Instance.ConstantString;
                    break;
                case FunctionTypes.LINEAR:
                    ValueFunction = FunctionBank.Instance.Linear;
                    StringValue = FunctionBank.Instance.LinearString;
                    break;
                case FunctionTypes.POLYNOMIAL:
                    ValueFunction = FunctionBank.Instance.Polynomial;
                    StringValue = FunctionBank.Instance.PolynomialString;
                    break;
                case FunctionTypes.SINE:
                    ValueFunction = FunctionBank.Instance.Sine;
                    StringValue = FunctionBank.Instance.SineString;
                    break;
                case FunctionTypes.ROSEX:
                    ValueFunction = FunctionBank.Instance.RoseX;
                    StringValue = FunctionBank.Instance.RoseXString;
                    break;
                case FunctionTypes.ROSEY:
                    ValueFunction = FunctionBank.Instance.RoseY;
                    StringValue = FunctionBank.Instance.RoseYString;
                    break;
                default:
                    Debug.LogWarning("Invalid Function Type");
                    break;
            }
        }
    }

    public AbilityFunction FunctionPosX;
    public AbilityFunction FunctionPosY;
    public List<FunctionBank.Variable> PosVars;
    public AbilityFunction FunctionDmg;
    public List<FunctionBank.Variable> DmgVars;
    public GameObject Projectile;

    public void Use(Entity source)
    {
        GameObject projectileObj = ProjectilePool.Instance.GetProjectile(Projectile);
        
        projectileObj.transform.position = source.transform.position;
        projectileObj.transform.rotation = source.transform.rotation;
        
        projectileObj.GetComponentInChildren<Projectile>().Fire(source, 
            FunctionPosX.ValueFunction, FunctionPosY.ValueFunction, 
            PosVars, FunctionDmg.ValueFunction, DmgVars);
    }
}
