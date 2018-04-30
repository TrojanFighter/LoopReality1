using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCursor : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public void DeltaMove(Vector3 delta)
    {
        //delta=new Vector3(delta.x,delta.z,delta.y);
        m_rigidbody.position += delta;
    }
}
