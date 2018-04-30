using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCursor : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public Transform m_computer;
    public float computerRange;
    public DisplayPort m_port;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public void DeltaMove(Vector3 delta)
    {
        //delta=new Vector3(delta.x,delta.z,delta.y);
        m_rigidbody.position += 2*delta;
    }

    public bool CheckComputerInRange()
    {
        if( ((transform.position - m_computer.position).sqrMagnitude)<computerRange*computerRange)
        {
            m_port.CreateNextDisplayPort();
            return true;
        }
        return false;
    }
}
