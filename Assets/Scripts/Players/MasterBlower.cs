using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBlower : MonoBehaviour
{

    public float BlowingForce;

    public HashSet<Rigidbody2D> AffectedPlatforms;

    // Use this for initialization
    void Start()
    {
        AffectedPlatforms = new HashSet<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Blow"))
        {
            Debug.Log("Blowing "+AffectedPlatforms.Count);
            foreach (var platform in AffectedPlatforms)
            {
                var diff = platform.transform.position - transform.position;
                var push = diff.normalized * BlowingForce;
                platform.AddForce(push);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Added "+other.gameObject.name);
        AffectedPlatforms.Add(other.gameObject.GetComponent<Rigidbody2D>());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        AffectedPlatforms.Remove(other.gameObject.GetComponent<Rigidbody2D>());
    }
}
