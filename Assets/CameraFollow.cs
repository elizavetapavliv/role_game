using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float x_max;
    [SerializeField]
    private float y_max;
    [SerializeField]
    private float x_min;
    [SerializeField]
    private float y_min;
    private Transform target;
	void Start ()
    {
        target = GameObject.Find("Player").transform;
    }
    void LateUpdate()
    {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, x_min, x_max), Mathf.Clamp(target.position.y, y_min, y_max), transform.position.z);
    }
}