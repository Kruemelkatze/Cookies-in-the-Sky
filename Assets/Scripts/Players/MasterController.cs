using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    public float axisX, axisY, angular;
    public float Speed, AngularSpeed;
    // Use this for initialization
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.axisX = Input.GetAxis("Horizontal");
        this.axisY = Input.GetAxis("Vertical");
        this.angular = Input.GetAxis("HorizontalRight");

        rigid2D.velocity = new Vector2(axisX * Speed, axisY * Speed);
        rigid2D.angularVelocity = -angular * AngularSpeed;

        DoNotLeaveCamera();
    }

    void DoNotLeaveCamera()
    {
        var viewPos = Grid.GameCamera.WorldToViewportPoint(transform.position);
        float vx = Range(0, viewPos.x, 1);
        float vy = Range(0, viewPos.y, 1);

        transform.position = Grid.GameCamera.ViewportToWorldPoint(new Vector3(vx, vy, viewPos.z));
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
