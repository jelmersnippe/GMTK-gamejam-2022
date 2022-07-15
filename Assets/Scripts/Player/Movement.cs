using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    public void Move(Vector2 input)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(input.x, input.y), speed * Time.deltaTime);
    }
}
