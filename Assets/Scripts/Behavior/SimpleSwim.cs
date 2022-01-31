using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSwim : MonoBehaviour
{
    [SerializeField] private float speed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }
}
