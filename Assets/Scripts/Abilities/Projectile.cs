using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Entity source;
    private int ignoreLayer;
    private float damage;

    public void Fire(Ability.PositionFunction fx, Ability.PositionFunction fy, 
            List<FunctionBank.Variable> vars, Entity source, float damage)
    {
        this.source = source;
        ignoreLayer = source.gameObject.layer;
        this.damage = damage;
        StartCoroutine(Move(fx, fy, vars));
    }

    private IEnumerator Move(Ability.PositionFunction fx, Ability.PositionFunction fy, List<FunctionBank.Variable> vars)
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != ignoreLayer)
        {
            Debug.Log($"Collided with {collision}");
            collision.gameObject.GetComponent<Entity>().Health -= damage;
        }
    }
}
