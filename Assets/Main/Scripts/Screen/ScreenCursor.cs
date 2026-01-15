﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCursor : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public Transform m_computer;
    public float computerRange;
    public DisplayPort m_port;

    private LayerMask mouseBody, mouseButton;
    private MouseBody lastMouseBody;
    private MouseButton lastMouseButton;
    private RaycastHit m_hit;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        mouseBody = LayerMask.GetMask("MouseBody");
        mouseButton = LayerMask.GetMask("MouseButton");
    }

    public void Raycasting(bool isClicked)
    {
        if (Physics.Raycast(transform.position, transform.forward, out m_hit, 24f, mouseBody))
        {
            lastMouseBody = m_hit.collider.GetComponent<MouseBody>();
            if (lastMouseBody != null && isClicked)
            {
                lastMouseBody.Raycasting(transform.position, true);
            }
        }
    }

    public void RaycastReleased()
    {
        if (lastMouseBody != null)
        {
            lastMouseBody.RaycastReleased();
            lastMouseBody = null;
        }

        if (Physics.Raycast(transform.position, transform.forward, out m_hit, 24f, mouseButton))
        {
            lastMouseButton = m_hit.collider.GetComponent<MouseButton>();
            if (lastMouseButton != null)
            {
                lastMouseButton.RaycastReleased();
            }
        }
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
