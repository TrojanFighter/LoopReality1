using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouse : MonoBehaviour
{

    public Transform m_RestorePosition;
    public MouseBody m_MouseBody;
    public Vector3 m_lastPosition,deltaPosition;
    public ScreenCursor m_cursor;

    void Start()
    {
        m_lastPosition = transform.position;
    }

    public void MoveToPosition(Vector3 position)
    {
        //position=new Vector3(position.x,m_RestorePosition.position.y,position.z);
        transform.position =position;
        deltaPosition = position - m_lastPosition;
        m_cursor.DeltaMove(deltaPosition);
        m_lastPosition = position;
    }

    public void RestorePosition()
    {
        transform.position = m_RestorePosition.position;
    }
}
