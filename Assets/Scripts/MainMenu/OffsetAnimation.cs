using UnityEngine;

public class OffsetAnimation : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        float offset = Time.time * scrollSpeed;
       
        rend.material.SetTextureOffset("_BaseMap", new Vector2(-offset, -offset ));
    }
}