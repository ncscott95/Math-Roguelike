using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // public void Fire(MathFunction fx, MathFunction fy, float duration, float speed)
    // {
    //     StartCoroutine(Move(fx, fy, duration, speed));
    // }

    // private IEnumerator Move(MathFunction fx, MathFunction fy, float duration, float speed)
    // {
    //     float t = 0;
    //     while(t <= duration)
    //     {
    //         transform.localPosition = new Vector2(fx.Calculate(t * speed), fy.Calculate(t * speed));
    //         t += Time.deltaTime;
    //         yield return null;
    //     }
    //     Destroy(transform.parent.gameObject);
    // }

    public void Fire(Ability.PositionFunction fx, Ability.PositionFunction fy, List<MathFunction.Variable> vars)
    {
        StartCoroutine(Move(fx, fy, vars));
    }

    private IEnumerator Move(Ability.PositionFunction fx, Ability.PositionFunction fy, List<MathFunction.Variable> vars)
    {
        float duration = vars[0].Value;
        float t = 0;
        float S = vars[1].Value;
        float a = vars[2].Value;
        float n = vars[3].Value;

        while(t <= duration)
        {
            transform.localPosition = new Vector2(fx(t, S, a, n), fy(t, S, a, n));
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(transform.parent.gameObject);
    }
}
