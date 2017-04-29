using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float StartPushForce;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();

	    rigid.AddForce(Random.insideUnitCircle * StartPushForce);
	}

    // Update is called once per frame
    void Update () {
		
	}
}
