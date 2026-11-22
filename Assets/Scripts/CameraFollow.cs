using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float smoothSpeed = 5f;

    public float camOffset = -15f;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(
            target.transform.position.x,
            target.transform.position.y,
            camOffset
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }


}
