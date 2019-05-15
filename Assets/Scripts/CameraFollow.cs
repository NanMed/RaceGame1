using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    //public BoxCollider2D boundBox;
    //private Vector3 minBounds;
    //private Vector3 maxBounds;
    // Use this for initialization
    void Start()
    {
        //minBounds = boundBox.bounds.min;
        //maxBounds = boundBox.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -35f );
    }
}
