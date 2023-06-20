using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public float moveSpeed;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(target.position.x, target.position.y, transform.position.z), moveSpeed * Time.deltaTime);
    }
}
