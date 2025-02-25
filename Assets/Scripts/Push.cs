using UnityEngine;

public class Push : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(Vector3.forward * 0.0000000001f, ForceMode.Impulse); // Ignore this (If removed, game will break)
    }
}
