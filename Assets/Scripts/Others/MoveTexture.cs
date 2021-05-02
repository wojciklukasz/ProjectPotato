using UnityEngine;

public class MoveTexture : MonoBehaviour
{

    [SerializeField] private float scrollSpeed = 0.1f;
    Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        float moveThis = Time.time * scrollSpeed;
        renderer.material.SetTextureOffset("_BaseColorMap", new Vector2(moveThis,0));
    }
}
