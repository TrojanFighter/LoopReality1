using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBody : MonoBehaviour {

	public VirtualMouse m_Mouse;
	public void Raycasting(Vector3 mousePosition, bool isClicked)
	{
		m_Mouse.MoveToPosition(mousePosition, isClicked);
		//Debug.Log("Raycasting "+mousePosition);
	}

	public void RaycastReleased()
	{
		Debug.Log("Raycasted Restore");
		m_Mouse.RestorePosition();
	}
}
