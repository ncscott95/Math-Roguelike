using TMPro;
using UnityEngine;

public class AbilityEquationViewer : MonoBehaviour
{
    public Ability Ability;
    [SerializeField] private TextMeshProUGUI posXEquationText;
    [SerializeField] private TextMeshProUGUI posYEquationText;
    [SerializeField] private TextMeshProUGUI dmgEquationText;

    void OnEnable()
    {
        if (Ability != null)
        {
            posXEquationText.text = Ability.FunctionPosX.StringValue
            (
                Ability.PosVars[0].Value,
                Ability.PosVars[1].Value,
                Ability.PosVars[2].Value,
                Ability.PosVars[3].Value
            );

            posYEquationText.text = Ability.FunctionPosY.StringValue
            (
                Ability.PosVars[0].Value,
                Ability.PosVars[1].Value,
                Ability.PosVars[2].Value,
                Ability.PosVars[3].Value
            );

            dmgEquationText.text = Ability.FunctionDmg.StringValue
            (
                Ability.DmgVars[0].Value,
                Ability.DmgVars[1].Value,
                Ability.DmgVars[2].Value,
                Ability.DmgVars[3].Value
            );
        }
    }
}
