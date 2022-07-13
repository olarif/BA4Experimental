using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageFlash : MonoBehaviour
{
    SpriteRenderer[] sprites;

    public Color damageTint;
    public float flashTime = 0.1f;

    void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    public void DamagePlayer()
    {
        foreach (SpriteRenderer sr in sprites)
        {
            StartCoroutine("TakeDamage", sr);
        }
    }

    public IEnumerator TakeDamage(SpriteRenderer sr)
    {
        sr.color = damageTint;
        yield return new WaitForSeconds(flashTime);
        sr.color = Color.white;
    }
}
