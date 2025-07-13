using UnityEngine;

public class HelicopterAutoFly : MonoBehaviour
{
    public float speed = 10f;         // Aagay move hone ki speed
    public float rotateSpeed = 30f;   // Y-axis (upar se) ghoomne ki speed
    public float flightHeight = 25f;  // Helicopter kis height par urhe

    void Start()
    {
        // Start mein helicopter ko set height par le jao
        Vector3 pos = transform.position;
        pos.y = flightHeight;
        transform.position = pos;
    }

    void Update()
    {
        // Har frame mein yeh ensure karo ke helicopter hawa mein hi ho
        Vector3 pos = transform.position;
        pos.y = flightHeight;
        transform.position = pos;

        // Aagay ki taraf move karo
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Dheere dheere ghoomna (circular movement)
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
