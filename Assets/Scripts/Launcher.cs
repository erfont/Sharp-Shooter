using UnityEngine;

public class Launcher : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3 direction = Vector3.forward;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float minSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       Vector3 final_direction = new Vector3(
        Random.Range(-1*direction.x, direction.x), 
        direction.y, 
        Random.Range(-1*direction.z, direction.z));
       rb.AddForce(final_direction.normalized * Random.Range(minSpeed, maxSpeed), ForceMode.VelocityChange);
    }


}
