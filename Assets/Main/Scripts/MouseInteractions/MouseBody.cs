using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBody : MonoBehaviour {

	public VirtualMouse m_Mouse;
	public void Raycasting(Vector3 mousePosition)
	{
		m_Mouse.MoveToPosition(mousePosition);
		//Debug.Log("Raycasting "+mousePosition);
	}

	public void RaycastReleased()
	{
		Debug.Log("Raycasted Restore");
		m_Mouse.RestorePosition();
	}
}
