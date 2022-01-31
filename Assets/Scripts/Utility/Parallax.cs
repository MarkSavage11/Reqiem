using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code for Parallax derived from AdamCYounis tutorial: https://youtu.be/tMXgLBwtsvI 

public class Parallax : MonoBehaviour
{
    public bool UseClamping = false;

    private Camera cam;
    private Transform subject;

    private SpriteRenderer renderer;

    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;
    float distanceFromSubject => transform.position.z - subject.position.z;
    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    private void Awake()
    {
        cam = Camera.main;
        subject = FindObjectOfType<SharkCharacter>().transform;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }


    private void Update()
    {
        Vector2 newPos = startPosition + travel * parallaxFactor;
        float clampedX = UseClamping ? Mathf.Clamp(newPos.x, startPosition.x - renderer.bounds.extents.x / 2, startPosition.x + renderer.bounds.extents.x / 2) : newPos.x;
        transform.position = new Vector3(newPos.x, startPosition.y, startZ);
    }
}
