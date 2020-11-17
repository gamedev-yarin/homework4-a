using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  this component moves its object right and left or up and down in dynamic speed.
 */

public class Oscillator : MonoBehaviour {
    [SerializeField]
    float Speed = 1f;
    [Tooltip("Defines the distance that the object will move from the starting point to each direction")]
    [SerializeField]
    float MaximumDistance = 1f;
    [Tooltip("if check the object move up and down")]
    [SerializeField]
    bool upAndDown = false;


    Vector3 startPos;
    private float x = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float tSpeed = Speed/100; //  Decreases the number speed
        x += tSpeed;
        if (!upAndDown) transform.position = startPos + new Vector3(Mathf.Sin(x) * MaximumDistance, 0f, 0f);
        else transform.position = startPos + new Vector3(0f, Mathf.Sin(x) * MaximumDistance, 0);

    }

}


