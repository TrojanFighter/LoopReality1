using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseButton : MonoBehaviour
{
    public MouseButtonType m_MBType;
    public VirtualMouse m_Mouse;
    public ScreenCursor m_cursor;

    public float lastClickTime = -1f, ClickGapTime = 0.4f;
    
    public void RaycastReleased()
    {
        if (Time.time - lastClickTime < ClickGapTime)
        {
            m_cursor.CheckComputerInRange();
            //lastClickTime = Time.time;
        }
        else
        {
            lastClickTime = Time.time;
        }
    }

}
