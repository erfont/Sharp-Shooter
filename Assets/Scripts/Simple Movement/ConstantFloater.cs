using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class ConstantFloater : MonoBehaviour
{

    [SerializeField] private float amplitude = 0.5f; // how far it moves up/down
    [SerializeField] private float max_frequency = 1f;    // how fast it moves
    private Vector3 startPos;

    private float final_frequency;

    void Start()
    {
        startPos = transform.localPosition;
        final_frequency = Random.Range(0.5f, max_frequency);

    }

    void Update()
    {

        float newY = startPos.y + Mathf.Sin(Time.time * final_frequency) * amplitude;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}
