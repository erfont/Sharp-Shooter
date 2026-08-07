using UnityEngine;

public class SideMover : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.5f; // how far it moves up/down
    [SerializeField] private float frequency = 1f;    // how fast it moves
    private Vector3 startPos;


    void Start()
    {
       startPos = transform.position;
    }

    void Update()
    {
        
        float newX = startPos.x + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }
}
