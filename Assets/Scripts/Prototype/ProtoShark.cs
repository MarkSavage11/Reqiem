using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoShark : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }
}
