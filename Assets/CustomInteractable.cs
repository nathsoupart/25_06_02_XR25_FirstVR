using UnityEngine;

public class CustomInteractable : MonoBehaviour
{   
    
    private MeshRenderer _meshRenderer;
    private Color _initialColor;

    public void OnHoverBegin()
    {
        _meshRenderer.material.SetColor("_BaseColor", Color.yellow);
    }
    public void OnHoverEnd()
    {
        _meshRenderer.material.SetColor("_BaseColor", _initialColor);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _initialColor = _meshRenderer.material.GetColor("_BaseColor");
    }

   
    // Update is called once per frame
    void Update()
    {
       
    }
    
   

    
}
