using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneryMovementScript : MonoBehaviour
{
    public Vector2 scenerySpeed = new Vector2(7,7);
    public Vector2 sceneryDirection = new Vector2(-1,0);

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(scenerySpeed.x * sceneryDirection.x, scenerySpeed.y * sceneryDirection.y, 0);

        transform.Translate(movement * Time.deltaTime);
    }
}
