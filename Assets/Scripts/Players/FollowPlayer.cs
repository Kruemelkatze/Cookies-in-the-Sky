using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private Transform target;
	public float smoothTime = 0.3f;
	private Vector3 velocity = Vector3.zero;

	public GameObject player;
	// Use this for initialization
	void Start () {
		target = player.transform;
        transform.position = target.TransformPoint (new Vector3 (0, 0, -10));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = target.TransformPoint (new Vector3 (0, 0, -10));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
