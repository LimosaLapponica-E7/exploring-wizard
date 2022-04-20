using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform mainTransform;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        if (targetObject.activeSelf)
        {
            Vector3 currentPos = mainTransform.position;
            Vector3 smoothPos = Vector3.SmoothDamp(mainTransform.position, target.position, ref velocity, 0.075f);
            currentPos.x = smoothPos.x;
            currentPos.y = smoothPos.y;
            mainTransform.position = currentPos;
        }
    }
}
