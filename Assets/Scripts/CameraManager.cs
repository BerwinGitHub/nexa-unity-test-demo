using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Vector3 oldPos;
    Vector3 newPos;
    void Start()
    {
        oldPos = transform.position;
        newPos = GameObject.Find("cameraPos").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.getinstance().IsMix)
            ChengeCamera(transform.position, newPos);
        else ChengeCamera(transform.position, oldPos);
    }
    void ChengeCamera(Vector3 currentPos, Vector3 newPos)
    {
        if (Vector3.Distance(currentPos, newPos) > 0.001f)
        {
            transform.position = Vector3.Lerp(currentPos, newPos, 0.2f);
        }
    }
}
