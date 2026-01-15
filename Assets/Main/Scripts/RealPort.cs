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
    private bool mouseSelected = false;
    private float lastClickTime = -1f;
    private float clickGapTime = 0.4f;
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
        bool bMiddleClick = Input.GetMouseButtonDown(2);
		if (Physics.Raycast(m_ray.origin,m_ray.direction, out m_padhit, 24f,mousepad))
		{
			if (m_padhit.collider == null)
			{
				return;
			}
            
            // Always update mousepad position, regardless of pressing state
			mousepadPosition = m_padhit.point;
		}
		
		if (Physics.Raycast(m_ray.origin,m_ray.direction, out m_mousehit,24f,mouseBody)) {
			if (m_mousehit.collider != null)
			{
                MouseBody hitBody = m_mousehit.collider.GetComponent<MouseBody>();
                if (bMiddleClick && hitBody != null)
                {
                    if (mouseSelected && lastMouseBody == hitBody)
                    {
                        mouseSelected = false;
                        lastMouseBody.RaycastReleased();
                        lastMouseBody = null;
                    }
                    else
                    {
                        mouseSelected = true;
                        lastMouseBody = hitBody;
                    }
                }
			}
		}

        if (mouseSelected && lastMouseBody != null)
        {
            lastMouseBody.Raycasting(mousepadPosition, bPressing);
        }

		if (Physics.Raycast(m_ray.origin, m_ray.direction, out m_padhit, 24f, mouseButton))
		{
			if (m_padhit.collider == null)
			{
				Debug.Log(m_padhit.collider.gameObject.name+ " mousepadPosition: "+mousepadPosition);
				return;
			}

			if (bReleasing)
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
            if (lastMouseBody != null)
            {
                lastMouseBody.RaycastReleased();

                if (mouseSelected && lastMouseBody.m_Mouse != null)
                {
                    ScreenCursor cursor = lastMouseBody.m_Mouse.m_cursor;
                    if (cursor != null)
                    {
                        if (Time.time - lastClickTime < clickGapTime)
                        {
                            cursor.CheckComputerInRange();
                        }
                        else
                        {
                            lastClickTime = Time.time;
                        }
                    }
                }
            }
        }
	}
}
