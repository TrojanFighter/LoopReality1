using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPort : MonoBehaviour
{

    private RenderTexture m_RenderTexture;
    private Material m_material;
    public Material materialSource;
    public MeshRenderer m_screenRenderer;
    public Camera m_ScreenCamera;
    private bool inited = false;
    public Transform m_AttachPoint,m_DesktopSpace,m_InterfaceSpace;
    public GameObject m_NextDisplayPortPrefab,m_MouseGO,m_CursorGO,m_NextDisplayPortGO;

    void Start()
    {
        Init();
    }

    bool Init()
    {
        if (inited)
        {
            return false;
        }

        m_RenderTexture=new RenderTexture(800,800,-1,RenderTextureFormat.ARGB32);
        m_ScreenCamera.targetTexture = m_RenderTexture;
        m_material=new Material(materialSource);
        m_material.mainTexture = m_RenderTexture;
        m_screenRenderer.sharedMaterial = m_material;
        inited = true;
        return true;
    }

    public void CreateNextDisplayPort()
    {
        m_NextDisplayPortGO = GameObject.Instantiate(m_NextDisplayPortGO, m_AttachPoint.position, m_AttachPoint.rotation);
        m_NextDisplayPortGO.transform.SetParent(m_AttachPoint);
        m_NextDisplayPortGO.transform.localPosition=Vector3.zero;
    }
}
