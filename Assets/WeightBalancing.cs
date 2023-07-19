using UnityEngine.Animations.Rigging;
using UnityEngine;

public class WeightBalancing : MonoBehaviour
{

    public float Headweight;
    [SerializeField] Transform target;

    private void Awake()
    {
        Headweight = this.GetComponent<Rig>().weight;
    }

    private void Update()
    {
        if (target)
        {
            // Calculate the direction from your position to the target
            Vector3 toTarget = target.position - transform.position;

            // Calculate the dot product to determine if you are behind or in front of the target
            float dotProduct = Vector3.Dot(transform.forward, toTarget.normalized);

            // Map the dot product value from (-1, 1) to (0, 1) using the Mathf.InverseLerp function
            float value = Mathf.InverseLerp(-1f, 1f, dotProduct);

            // Smoothly update the float value towards the mapped value
            float smoothValue = Mathf.Lerp(Headweight, value, Time.deltaTime * 5f);

            // Clamp the float value between 0 and 1
            Headweight = Mathf.Clamp01(smoothValue);
        }
    }
}
