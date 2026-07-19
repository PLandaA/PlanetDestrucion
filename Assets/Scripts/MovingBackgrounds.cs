using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgrounds : MonoBehaviour
{
    public Renderer bgRenderer;

    [SerializeField] float scrollSpeed;

    Material material;

    void Start()
    {
        material = bgRenderer.material;
    }

    
    void Update()
    {
        // Wrap the offset so it never grows unbounded during long endless runs.
        float x = Mathf.Repeat(material.mainTextureOffset.x + scrollSpeed * Time.deltaTime, 1f);
        material.mainTextureOffset = new Vector2(x, 0f);
    }
}
