using UnityEngine;

public class MaterialPulse : MonoBehaviour
{
    [Header("Opacity Parameters")]
    public float maxOpacity;
    public float minOpacity;
    public float opacityStep;

    [Header("Renderer and Material References")]
    public MeshRenderer objectMeshRenderer;
    public Material objectMaterial;

    private Color tempColor;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the mesh renderer attached to this object
        objectMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        objectMaterial = objectMeshRenderer.material;

        tempColor = new Color(objectMaterial.color.r, objectMaterial.color.g, objectMaterial.color.b, objectMaterial.color.a);
    }

    // Update is called once per frame
    void Update()
    {
        // if opacity has reached the bounds then reverse opacity step
        if (tempColor.a > maxOpacity || tempColor.a < minOpacity)
            opacityStep *= -1.0f;

        // add opacity to our temp color
        tempColor.a += opacityStep;

        objectMaterial.SetColor("_Color", tempColor);
    }
}
