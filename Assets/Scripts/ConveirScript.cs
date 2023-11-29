using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveirScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    
    private Rigidbody m_RigidBody;
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = m_RigidBody.position;
        m_RigidBody.position += Vector3.left * (speed * Time.fixedDeltaTime);
        m_RigidBody.MovePosition(pos);
    }
}
