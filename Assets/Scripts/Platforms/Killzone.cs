using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    private Transform playerTransform;

    private GameObject open;
    private GameObject closed;

    // Use this for initialization
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        open = GameObject.Find("Drake");
        closed = GameObject.Find("DrakeClosed");

        closed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(playerTransform.position.x, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform == playerTransform)
        {
            closed.SetActive(true);
            open.SetActive(false);
            Grid.EventHub.TriggerKillzoneTriggered();
        }
    }
}
