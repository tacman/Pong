using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerControls : MonoBehaviour
{
    
    public float speed = 5.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Debug.Log("Start()");
    }

    private void OnMovement(InputValue value)
    {
        Debug.Log("got OnMovement");
        var inputMovement = value.Get<Vector2>();
        var inputDirection = new Vector2(inputMovement.x, inputMovement.y);
        
        // get the current velocity
        var vel = rb2d.velocity;
        Debug.Log($"Current Vel  {vel.y} -> speed " + JsonUtility.ToJson(inputDirection));
        vel.y = inputMovement.y * speed;
        rb2d.velocity = vel;

    }

    // Update is called once per frame
    void Update () {
        // this is the paddle position
        var pos = transform.position;
        if (pos.y > boundY) {
            pos.y = boundY;
        }
        else if (pos.y < -boundY) {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
