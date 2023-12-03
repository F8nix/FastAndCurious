using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorColor : MonoBehaviour
{
    public Transform indicator;
    public Collider[] colliders = new Collider[3];
    public int collidersCount = 0;
    public Material indicatorMaterial;
    // Start is called before the first frame update
    void Start()
    {
        indicatorMaterial = this.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        GraphicsUpdate();
    }

    private void GraphicsUpdate() {
        
        collidersCount = Physics.OverlapSphereNonAlloc(indicator.transform.position, 0.25f, colliders);
        if(collidersCount > 0) {
            indicatorMaterial.color = new Color(0.1f,0,0, 0.5f);
        } else {
            indicatorMaterial.color = new Color(0,0.1f,0, 0.5f);
        }
    }
}
