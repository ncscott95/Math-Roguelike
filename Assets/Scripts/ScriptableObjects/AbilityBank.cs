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
    
    [SerializeField] private AbilityConfiguration linearConfig;
    [SerializeField] private AbilityConfiguration sineConfig;
    [SerializeField] private AbilityConfiguration roseConfig;

    private Ability NewAbilityFromConfig(AbilityConfiguration config)
    {
        if (config == null)
        {
            Debug.LogError("Ability configuration is null!");
            return null;
        }
        
        Ability ability = CreateInstance<Ability>();
        
        ability.FunctionPosX = new Ability.AbilityFunction(config.positionXType);
        ability.FunctionPosY = new Ability.AbilityFunction(config.positionYType);
        ability.PosVars = config.GetPositionVariables();
        
        ability.FunctionDmg = new Ability.AbilityFunction(config.damageType);
        ability.DmgVars = config.GetDamageVariables();
        
        ability.Projectile = config.projectilePrefab;
        
        return ability;
    }
    
    public Ability NewAbility(FunctionTypes type)
    {
        switch(type)
        {
            case FunctionTypes.LINEAR:
                return NewAbilityFromConfig(linearConfig);
            case FunctionTypes.SINE:
                return NewAbilityFromConfig(sineConfig);
            case FunctionTypes.ROSEX:
            case FunctionTypes.ROSEY:
                return NewAbilityFromConfig(roseConfig);
            default:
                Debug.LogWarning("Invalid function type");
                return null;
        }
    }
}
