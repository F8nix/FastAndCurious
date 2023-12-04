using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IndicatorAppearence : MonoBehaviour
{
    public Collider[] colliders = new Collider[3];
    public bool isColliding;
    public float radius = 0.25f;
    public Color invalidColor = new Color(0.1f,0,0, 0.5f);
    public Color validColor = new Color(0,0.1f,0, 0.5f);
    public Material indicatorMaterial;

    public GameObject currentDisplay;
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
        int collidersCount = Physics.OverlapSphereNonAlloc(transform.position, radius, colliders);
        
        isColliding = collidersCount > 0;
        indicatorMaterial.color = isColliding ? invalidColor : validColor;
    }

    public void SetAppearence(GameObject prefab) {
        if(currentDisplay != null){
            Destroy(currentDisplay);
        }
        currentDisplay = Instantiate(prefab, transform);
        var displaysList = currentDisplay.GetComponentsInChildren<MonoBehaviour>();
        foreach (var script in displaysList)
        {
            script.enabled = false;
        }
    }
}
