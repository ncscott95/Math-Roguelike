using UnityEngine;

public class PlayerEntity : Entity
{
    public static PlayerEntity Instance;
    public const int MAX_ABILITIES = 4;
    public Ability[] Abilities = new Ability[MAX_ABILITIES];
    
    // TODO: debug, remove later
    public AbilityAttack LinearAttack
    { get; set; }
    public AbilityAttack SineAttack
    { get; set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogWarning("Tried to create more than one instance of the PlayerEntity singleton!");
            Destroy(this);
        }
    }

    void Start()
    {
        // TODO: replace with local variables
        LinearAttack = AbilityBank.Instance.NewAbility(FunctionTypes.LINEAR);
        LinearAttack.PosVars[1].Value = 25f;
        LinearAttack.DmgVars[3].Value = 1f;
        Abilities[0] = LinearAttack;

        SineAttack = AbilityBank.Instance.NewAbility(FunctionTypes.SINE);

        AbilityAttack roseAttack = AbilityBank.Instance.NewAbility(FunctionTypes.ROSEX);
        roseAttack.DmgVars[1].Value = 1f;
        roseAttack.DmgVars[2].Value = 5f;
        roseAttack.DmgVars[3].Value = 2f;
        Abilities[1] = roseAttack;
    }
    
    public override void TakeDamage(float damage)
    {
        Debug.Log($"Player hit for {damage} dmg");
        base.TakeDamage(damage);
    }
}
