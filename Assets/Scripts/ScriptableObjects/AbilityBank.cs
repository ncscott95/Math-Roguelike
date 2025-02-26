using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityBank")]
public class AbilityBank : ScriptableObject
{
    static AbilityBank _instance;
    public static AbilityBank Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = Resources.Load<AbilityBank>("AbilityBank");
            }
            return _instance;
        }
    }
    
    public List<GameObject> ProjectilePrefabs;

    private List<FunctionBank.Variable> defaultLinearPosVars { get => new(){ new("Duration", 2f), new("Speed", 10f), new("---", 0f), new("---", 0f) }; }
    private List<FunctionBank.Variable> defaultSinePosVars { get => new(){ new("Duration", 4f), new("Speed", 5f), new("Width", 0.5f), new("Frequency", 10f) }; }
    private List<FunctionBank.Variable> defaultRosePosVars { get => new(){ new("Duration", 4f), new("Speed", 10f), new("Radius", 2f), new("Angular Frequency", 2f) }; }
    private List<FunctionBank.Variable> defaultDmgVars { get => new(){ new("Initial", 0f), new("Speed", 10f), new("Multiplier", 1f), new("Power", 0f) }; }

    public Ability NewAbility(FunctionTypes type)
    {
        Ability ability = CreateInstance<Ability>();

        switch(type)
        {
            case FunctionTypes.LINEAR:
                ability.FunctionPosX = new(FunctionTypes.LINEAR);
                ability.FunctionPosY = new(FunctionTypes.CONSTANT);
                ability.PosVars = defaultLinearPosVars;
                ability.Projectile = ProjectilePrefabs[0];
                break;
            case FunctionTypes.SINE:
                ability.FunctionPosX = new(FunctionTypes.LINEAR);
                ability.FunctionPosY = new(FunctionTypes.SINE);
                ability.PosVars = defaultSinePosVars;
                ability.Projectile = ProjectilePrefabs[0];
                break;
            case FunctionTypes.ROSEX:
                ability.FunctionPosX = new(FunctionTypes.ROSEX);
                ability.FunctionPosY = new(FunctionTypes.ROSEY);
                ability.PosVars = defaultRosePosVars;
                ability.Projectile = ProjectilePrefabs[1];
                break;
            default:
                Debug.LogWarning("Invalid function type");
                break;
        }

        ability.FunctionDmg = new(FunctionTypes.POLYNOMIAL);
        ability.DmgVars = defaultDmgVars;

        return ability;
    }
}
