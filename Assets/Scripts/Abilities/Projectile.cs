using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Entity source;
    private int ignoreLayer;
    private float damage;

    float time;

    public void Fire(Entity source, Ability.MathFunction fx, Ability.MathFunction fy, 
            List<FunctionBank.Variable> posVars, Ability.MathFunction fd, List<FunctionBank.Variable> dmgVars)
    {
        ignoreLayer = source.gameObject.layer;
        time = 0;
        StartCoroutine(Timer(posVars[0].Value));
        StartCoroutine(Move(fx, fy, posVars));
        StartCoroutine(CalcDamage(fd, dmgVars));
    }

    private IEnumerator Timer(float duration)
    {
        while(time <= duration)
        {
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(transform.parent.gameObject);
    }

    private IEnumerator Move(Ability.MathFunction fx, Ability.MathFunction fy, List<FunctionBank.Variable> vars)
    {
        float speed = vars[1].Value;
        float a = vars[2].Value;
        float n = vars[3].Value;

        while(true)
        {
            transform.localPosition = new Vector2(fx(time, speed, a, n), fy(time, speed, a, n));
            yield return null;
        }
    }

    private IEnumerator CalcDamage(Ability.MathFunction fd, List<FunctionBank.Variable> vars)
    {
        float initial = vars[0].Value;
        float speed = vars[1].Value;
        float multiplier = vars[2].Value;
        float power = vars[3].Value;

        while(true)
        {
            damage = initial + fd(time, speed, multiplier, power);
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != ignoreLayer)
        {
            Debug.Log($"Hit {collision.gameObject.name} for {damage} dmg");
            collision.gameObject.GetComponent<Entity>().Health -= damage;
        }
    }
}
