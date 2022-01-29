using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCharacter : MonoBehaviour
{
    [SerializeField] private float speed;

    bool isMoving;

    private void Awake()
    {
        PoemZone.OnPoemStart += StopMovement;
        PoemZone.OnPoemComplete += StartMovement;
    }

    public void StartMovement()
    {
        isMoving = true;
    }

    public void StopMovement()
    {
        isMoving = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
    }


    private void OnDestroy()
    {
        PoemZone.OnPoemStart -= StopMovement;
        PoemZone.OnPoemComplete -= StartMovement;
    }
}
