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
        if (targetObject.activeSelf)
        {
            Vector3 currentPos = mainTransform.position;
            currentPos.x = target.position.x;
            currentPos.y = target.position.y;
            mainTransform.position = currentPos;
        }
    }
}
