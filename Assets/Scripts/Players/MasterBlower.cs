using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBlower : MonoBehaviour
{

    public float BlowingForce;

    public float FadeSpeedSec = 0.5f;
    public float Fadeness = 0;
    public float FadeMin = 0f;

    public HashSet<Rigidbody2D> AffectedPlatforms;

    private SpriteRenderer _windSprite;

    // Use this for initialization
    void Start()
    {
        AffectedPlatforms = new HashSet<Rigidbody2D>();
        _windSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Grid.GameLogic.IsDialogActive && Input.GetButton("Blow"))
        {
            Fadeness += Time.deltaTime / FadeSpeedSec;

            foreach (var platform in AffectedPlatforms)
            {
                var diff = platform.transform.position - transform.position;
                var push = diff.normalized * BlowingForce;
                platform.AddForce(push);
            }
        }
        else
        {
            Fadeness -= Time.deltaTime / FadeSpeedSec;
        }
        Fadeness = Range(FadeMin, Fadeness, 1);
        _windSprite.color = new Color(_windSprite.color.r, _windSprite.color.g, _windSprite.color.b, Fadeness);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AffectedPlatforms.Add(other.gameObject.GetComponent<Rigidbody2D>());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        AffectedPlatforms.Remove(other.gameObject.GetComponent<Rigidbody2D>());
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
