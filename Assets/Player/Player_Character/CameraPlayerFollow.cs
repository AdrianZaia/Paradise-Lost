using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed = 0.1f;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Control.Instance.transform.position + offset, followSpeed);
    }
}
