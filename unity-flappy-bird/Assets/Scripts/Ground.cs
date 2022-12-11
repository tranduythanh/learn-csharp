using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }    
    
    void Update() {
        Vector2 deltaOffset = new Vector2(animationSpeed + Time.deltaTime, 0);
        meshRenderer.material.mainTextureOffset += deltaOffset;
    }
}
