using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    public float rotationSpeed = 100f; 
    public float bounceSpeed = 2f;
    public float bounceHeight = 0.1f; 

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        
        float newY = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = initialPosition + new Vector3(0, newY, 0);
    }
}
