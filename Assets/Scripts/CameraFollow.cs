using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -35f);
    }
}
