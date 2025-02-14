using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public void Fire(MathFunction fx, MathFunction fy, float duration, float speed)
    {
        StartCoroutine(Move(fx, fy, duration, speed));
    }

    private IEnumerator Move(MathFunction fx, MathFunction fy, float duration, float speed)
    {
        float t = 0;
        while(t <= duration)
        {
            transform.localPosition = new Vector2(fx.Calculate(t * speed), fy.Calculate(t * speed));
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(transform.parent.gameObject);
    }
}
