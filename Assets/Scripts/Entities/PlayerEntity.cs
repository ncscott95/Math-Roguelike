using UnityEngine;

public class PlayerEntity : Entity
{
    public static PlayerEntity Instance;
    public const int MAX_ABILITIES = 4;
    public Ability[] Abilities = new Ability[MAX_ABILITIES];
    
    // TODO: debug, remove later
    public Ability LinearAttack
    { get; set; }
    public Ability SineAttack
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
        LinearAttack = AbilityBank.Instance.NewAbility(FunctionTypes.LINEAR);
        LinearAttack.PosVars[1].Value = 25f;
        LinearAttack.DmgVars[3].Value = 1f;

        SineAttack = AbilityBank.Instance.NewAbility(FunctionTypes.SINE);

        Abilities[1] = AbilityBank.Instance.NewAbility(FunctionTypes.ROSEX);
        Abilities[1].DmgVars[1].Value = 1f;
        Abilities[1].DmgVars[2].Value = 5f;
        Abilities[1].DmgVars[3].Value = 2f;

        // TODO: debug, remove later
        Abilities[0] = LinearAttack;
    }
    
    public override void TakeDamage(float damage)
    {
        Debug.Log($"Player hit for {damage} dmg");
        base.TakeDamage(damage);
    }
}
