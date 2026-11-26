using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotateSpeed = 90f;

    private void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }
}