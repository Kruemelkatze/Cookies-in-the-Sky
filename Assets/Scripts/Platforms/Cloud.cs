using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cloud : MonoBehaviour
{
    private Collider2D collider;
    private SpriteRenderer sprite;
    private Rigidbody2D rigid;
    public float StartPushForce;
    public bool PlayerTouching = false;
    public float FadeSpeedSec = 3;
    public float Fadeness = 1;
    public float FadeMin = 0.1f;

    // Use this for initialization
    void Start()
    {
        var colliders = GetComponents<Collider2D>();
        foreach (var c in colliders)
        {
            if (!c.isTrigger)
            {
                this.collider = c;
                break;
            }
        }
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        rigid.AddForce(Random.insideUnitCircle * StartPushForce);
    }

    // Update is called once per frame
    void Update()
    {
        float prevFadeness = Fadeness;
        if(PlayerTouching)
            Fadeness -= Time.deltaTime / FadeSpeedSec;
        else
            Fadeness += Time.deltaTime / FadeSpeedSec;

        Fadeness = Range(FadeMin, Fadeness, 1);
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Fadeness);

        collider.enabled = Math.Abs(Fadeness - FadeMin) > 0.005;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerTouching = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerTouching = false;
        }
    }
    float Range(float min, float val, float max)
    {
        if (val < min)
            return min;
        if (val > max)
            return max;
        return val;
    }
}
