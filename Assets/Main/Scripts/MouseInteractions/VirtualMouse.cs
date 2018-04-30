using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouse : MonoBehaviour
{

    public Transform m_RestorePosition;
    public MouseBody m_MouseBody;
    
    public void MoveToPosition(Vector3 position)
    {
        transform.position =position;
    }

    public void RestorePosition()
    {
        transform.position = m_RestorePosition.position;
    }
}
