using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveScript : MonoBehaviour
{
    private float speed = 0.01f;
    private Rigidbody m_RigidBody;
    private Vector3 curMousePosition;
    private Vector3 offsetPosition;
    private Vector3 curPosition;
    private Vector3 offset;
    private Vector3 velocity;

    public float force = 10000;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        m_RigidBody.velocity = Vector3.zero;

        m_RigidBody.useGravity = false;
        curMousePosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        transform.position += Vector3.up * 2;
        
        offsetPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        offset = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y) - curMousePosition;
        curPosition = transform.position;
        
        transform.position = offsetPosition + offset * speed;
        velocity = offsetPosition + offset * speed - curPosition;
    }

    private void OnMouseUp()
    {
        m_RigidBody.useGravity = true;
        m_RigidBody.AddForce(velocity * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }
}
