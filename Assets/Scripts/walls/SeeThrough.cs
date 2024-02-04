using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThrough : MonoBehaviour
{
    public Material transparentColor;
    private Material m_InitialColor;

    private MeshRenderer[] wallsRenderers;
    public GameObject wall;
    public Color32 objColor;
    // Start is called before the first frame update
    void Start()
    {
        m_InitialColor = wall.GetComponentInChildren<MeshRenderer>().material;
        wallsRenderers = wall.GetComponentsInChildren<MeshRenderer>();
    }

    public void SetTransparent() {
        foreach (var item in wallsRenderers)
        {
            item.GetComponentInChildren<MeshRenderer>().material = transparentColor;
        }
    }

    public void SetNormal() {
        foreach (var item in wallsRenderers)
        {
            item.GetComponentInChildren<MeshRenderer>().material = m_InitialColor;
        }
    }
}
