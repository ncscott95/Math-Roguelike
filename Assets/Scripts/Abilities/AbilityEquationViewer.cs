using TMPro;
using UnityEngine;

public class AbilityEquationViewer : MonoBehaviour
{
    public AbilityEquationViewer Instance;
    [SerializeField] private TextMeshProUGUI posXEquationText;
    [SerializeField] private TextMeshProUGUI posYEquationText;
    [SerializeField] private TextMeshProUGUI dmgEquationText;
    private AbilityAttack ability;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogWarning("Tried to create more than one instance of the AbilityEquationViewer singleton!");
            Destroy(this);
        }
    }

    void OnEnable()
    {
        SetAbilityDetails(0);
    }

    public void SetAbilityDetails(int abilityIndex)
    {
        if (PlayerEntity.Instance != null) ability = PlayerEntity.Instance.Abilities[abilityIndex];
        if (ability != null)
        {
            posXEquationText.text = $"x = {ability.FunctionPosX.StringValue(ability.PosVars[0].Value, ability.PosVars[1].Value, ability.PosVars[2].Value, ability.PosVars[3].Value)}";
            posYEquationText.text = $"y = {ability.FunctionPosY.StringValue(ability.PosVars[0].Value, ability.PosVars[1].Value, ability.PosVars[2].Value, ability.PosVars[3].Value)}";
            dmgEquationText.text = $"d = {ability.FunctionDmg.StringValue(ability.DmgVars[0].Value, ability.DmgVars[1].Value, ability.DmgVars[2].Value, ability.DmgVars[3].Value)}";
        }
        else
        {
            posXEquationText.text = "x = [NO ABILITY]";
            posYEquationText.text = "y = [NO ABILITY]";
            dmgEquationText.text = "d = [NO ABILITY]";
        }
    }
}
