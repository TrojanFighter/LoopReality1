using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPort : MonoBehaviour
{

	public Camera m_camera;
	private Ray m_ray;
	private RaycastHit m_padhit,m_mousehit;
	private bool bPressing = false;
	private bool bReleasing = false;
	public Vector3 mousepadPosition;
	private LayerMask mousepad, mouseBody,mouseButton;

	public MouseBody lastMouseBody;
	public MouseButton lastMouseButton;
	
	// Use this for initialization
	void Start () {
		mousepad=LayerMask.GetMask("MouseInterface");
		mouseBody=LayerMask.GetMask("MouseBody");
		mouseButton=LayerMask.GetMask("MouseButton");
	}
	
	// Update is called once per frame
	void Update () {
		m_ray= m_camera.ScreenPointToRay(Input.mousePosition);
		bPressing = Input.GetMouseButton(0);
		bReleasing = Input.GetMouseButtonUp(0);
		if (Physics.Raycast(m_ray.origin,m_ray.direction, out m_padhit, 24f,mousepad))
		{
			if (m_padhit.collider == null)
			{
				return;
			}
			if (bPressing)
			{
				mousepadPosition = m_padhit.point;
				
				//Debug.Log(m_padhit.collider.gameObject.name+ " mousepadPosition: "+mousepadPosition);
			}
			if (bReleasing)
			{
				mousepadPosition = Vector3.zero;
			}
		}
		
		if (Physics.Raycast(m_ray.origin,m_ray.direction, out m_mousehit,24f,mouseBody)) {
			if (m_mousehit.collider == null)
			{
				Debug.Log(m_mousehit.collider.gameObject.name+ " mousepadPosition: "+mousepadPosition);
				return;
			}

			if (bPressing)
			{
				lastMouseBody = m_mousehit.collider.GetComponent<MouseBody>();
				if (lastMouseBody!=null)
				{
					lastMouseBody.Raycasting(mousepadPosition);
				}
				else
				{
					Debug.Log("Pressing "+m_mousehit.collider.gameObject.name);
				}
			}
		}

		if (Physics.Raycast(m_ray.origin, m_ray.direction, out m_padhit, 24f, mouseButton))
		{
			if (m_padhit.collider == null)
			{
				Debug.Log(m_padhit.collider.gameObject.name+ " mousepadPosition: "+mousepadPosition);
				return;
			}

			if (bPressing)
			{
				lastMouseButton = m_padhit.collider.GetComponent<MouseButton>();
				if (lastMouseButton!=null)
				{
					lastMouseButton.RaycastReleased();
				}
				else
				{
					Debug.Log("Pressing "+m_padhit.collider.gameObject.name);
				}
			}
		}

		if (bReleasing)
		{
			if (lastMouseBody!=null)
			{
				lastMouseBody.RaycastReleased();
			}
		}
	}
}
