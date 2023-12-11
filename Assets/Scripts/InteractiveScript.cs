using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using UnityEngine;

public class InteractiveScript : MonoBehaviour
{
    public InteractableType type;
    
    private Rigidbody m_RigidBody;
    private Vector3 _velocity;

    private Vector3 _screenPosition;
    private Vector3 _prevPosition;
    private Vector3 _curPosition;

    private Plane _plane = new Plane(Vector3.down, 5);

    public float force = 10000;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        m_RigidBody.velocity = Vector3.zero;

        m_RigidBody.useGravity = false;
    }

    private void OnMouseDrag()
    {
        _screenPosition = Input.mousePosition;
        _prevPosition = transform.position;

        var ray = Camera.main.ScreenPointToRay(_screenPosition);

        if (_plane.Raycast(ray, out float distance))
        {
            _curPosition = ray.GetPoint(distance);
        }
        
        transform.position = _curPosition;
        
        _velocity = _curPosition - _prevPosition;
    }

    private void OnMouseUp()
    {
        m_RigidBody.useGravity = true;
        m_RigidBody.AddForce(_velocity * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        var container = other.GetComponent<GarbageContainer>();

        if (container)
        {
            container.Interact(this);
        }
    }
}
