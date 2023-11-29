using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private Rigidbody m_RigidBody;
    private Vector3 pointScreen;
    private Vector3 offset;
    private Vector3 velocity;

    public float force;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        m_RigidBody.velocity = Vector3.zero;

        m_RigidBody.useGravity = false;
        pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        print(pointScreen);
        offset = transform.position -
                 Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z));
        print(offset);
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        velocity = curPosition - transform.position;
        transform.position = curPosition;
        
        print(m_RigidBody.velocity);
    }

    private void OnMouseUp()
    {
        m_RigidBody.useGravity = true;
        m_RigidBody.AddForce(velocity * force);
    }
}
