using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed = 12f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}