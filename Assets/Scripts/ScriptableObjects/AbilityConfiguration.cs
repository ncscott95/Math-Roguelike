using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityConfig", menuName = "Game/Ability Configuration")]
public class AbilityConfiguration : ScriptableObject
{
    public string abilityName;
    public float cooldownTime;
    public FunctionTypes positionXType;
    public FunctionTypes positionYType;
    public FunctionTypes damageType;
    
    [SerializeField]
    private PositionVariableSerializable[] positionVariablesArray = new PositionVariableSerializable[4];
    [SerializeField]
    private DamageVariableSerializable[] damageVariablesArray = new DamageVariableSerializable[4];
    public GameObject projectilePrefab;
    
    [System.Serializable]
    public class PositionVariableSerializable
    {
        public string name;
        public float value;
        
        public FunctionBank.Variable ToVariable()
        {
            return new FunctionBank.Variable(name, value);
        }
    }
    
    [System.Serializable]
    public class DamageVariableSerializable 
    {
        public string name;
        public float value;
        
        public FunctionBank.Variable ToVariable()
        {
            return new FunctionBank.Variable(name, value);
        }
    }
    
    public List<FunctionBank.Variable> GetPositionVariables()
    {
        List<FunctionBank.Variable> result = new List<FunctionBank.Variable>();
        foreach (var item in positionVariablesArray)
        {
            if (item != null)
                result.Add(item.ToVariable());
        }
        return result;
    }
    
    public List<FunctionBank.Variable> GetDamageVariables()
    {
        List<FunctionBank.Variable> result = new List<FunctionBank.Variable>();
        foreach (var item in damageVariablesArray)
        {
            if (item != null)
                result.Add(item.ToVariable());
        }
        return result;
    }
}
