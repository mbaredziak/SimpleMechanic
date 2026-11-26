using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float growAmount = 0.2f;

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        Vector3 dir = Vector3.zero;
        if (kb.wKey.isPressed) dir.z += 1;
        if (kb.sKey.isPressed) dir.z -= 1;
        if (kb.aKey.isPressed) dir.x -= 1;
        if (kb.dKey.isPressed) dir.x += 1;

        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collectible>() == null) return;

        Destroy(other.gameObject);

        transform.localScale += Vector3.one * growAmount;

        Vector3 pos = transform.position;
        pos.y = transform.localScale.y;
        transform.position = pos;

        rend.material.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.8f, 1f);
    }
}