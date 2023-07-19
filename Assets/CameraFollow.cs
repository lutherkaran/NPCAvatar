using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    Vector3 offSet = new Vector3(0, 1.5f, 2);
    [SerializeField] Transform target;

    void LateUpdate()
    {
        if (target)
            this.transform.position = target.position + offSet;
    }
}
