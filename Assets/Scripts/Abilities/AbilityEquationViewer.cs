using TMPro;
using UnityEngine;

public class AbilityEquationViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI abilityNameText;
    [SerializeField] private TextMeshProUGUI posXEquationText;
    [SerializeField] private TextMeshProUGUI posYEquationText;
    [SerializeField] private TextMeshProUGUI dmgEquationText;
    private Ability ability;

    void OnEnable()
    {
        SetAbilityDetails(0);
    }

    public void SetAbilityDetails(int abilityIndex)
    {
        if (PlayerEntity.Instance != null) ability = PlayerEntity.Instance.Abilities[abilityIndex];
        if (ability != null && ability is AbilityAttack attack)
        {
            abilityNameText.text = ability.AbilityName;
            posXEquationText.text = $"x = {attack.FunctionPosX.StringValue(attack.PosVars[0].Value, attack.PosVars[1].Value, attack.PosVars[2].Value, attack.PosVars[3].Value)}";
            posYEquationText.text = $"y = {attack.FunctionPosY.StringValue(attack.PosVars[0].Value, attack.PosVars[1].Value, attack.PosVars[2].Value, attack.PosVars[3].Value)}";
            dmgEquationText.text = $"d = {attack.FunctionDmg.StringValue(attack.DmgVars[0].Value, attack.DmgVars[1].Value, attack.DmgVars[2].Value, attack.DmgVars[3].Value)}";
        }
        else
        {
            posXEquationText.text = "x = [NO ABILITY]";
            posYEquationText.text = "y = [NO ABILITY]";
            dmgEquationText.text = "d = [NO ABILITY]";
        }
    }
}
