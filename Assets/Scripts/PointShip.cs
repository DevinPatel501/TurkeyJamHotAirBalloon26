
using UnityEngine;

public class PointShip : MonoBehaviour
{
    public GameObject ship;
    public GameObject balloon;

    void Update()
    {
        Vector2 direction = ship.transform.position - balloon.transform.position;



        float angle = Mathf.Atan2(direction.y, direction.x)
                      * Mathf.Rad2Deg - 90f;
        Debug.Log("Arrow angle: " + angle);
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}
