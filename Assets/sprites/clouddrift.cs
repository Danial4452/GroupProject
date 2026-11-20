using UnityEngine;

public class CloudDrift : MonoBehaviour
{
    public float speed = 0.2f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
