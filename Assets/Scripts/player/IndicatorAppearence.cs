using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class IndicatorAppearence : MonoBehaviour
{
    public Collider[] colliders = new Collider[3];
    public bool isColliding = true;
    public float radius = 0.25f;
    public Color invalidColor = new Color(0.1f,0,0);
    public Color validColor = new Color(0,0.1f,0);
    public Material indicatorMaterial;
    public GameObject currentDisplay;
    public (MeshRenderer, Color)[] indicatorRenderers;

    public LayerMask indicatorCollision;
    // Start is called before the first frame update
    void Start()
    {
        GraphicsUpdate();
        //indicatorMaterial = GetComponent<MeshRenderer>().material;
        //appearenceRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GraphicsUpdate();
    }

    private void GraphicsUpdate() {
        if(currentDisplay == null){
            return;
        }
        int collidersCount = Physics.OverlapSphereNonAlloc(transform.position + Vector3.up * radius, radius, colliders, indicatorCollision);
        
        if (isColliding != collidersCount > 0) {
            isColliding = collidersCount > 0;
            foreach (var (renderer, originalColor) in indicatorRenderers) { // not set to an instance of an object
                renderer.material.color = originalColor/2 + (isColliding ? invalidColor : validColor)/2;
            }
        }
    }

    public void SetAppearence(GameObject prefab) {
        if(prefab == null){
            Destroy(currentDisplay);
            return;
        }
        if(currentDisplay != null){
            Destroy(currentDisplay);
        }
        currentDisplay = Instantiate(prefab, transform);
        currentDisplay.layer = LayerMask.NameToLayer("Indicator");
        var displaysCollection = currentDisplay.GetComponentsInChildren<MonoBehaviour>();
        foreach (var script in displaysCollection)
        {
            script.enabled = false;
        }
        indicatorRenderers = currentDisplay.GetComponentsInChildren<MeshRenderer>().Select((renderer)=>(renderer ,renderer.material.color)).ToArray();
    }
}
