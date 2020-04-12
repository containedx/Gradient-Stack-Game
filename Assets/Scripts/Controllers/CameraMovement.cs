using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera sceneCamera; 
    public float heightModifier;
    public float speed; 

    public void UpdatePosition(float y)
    {
        float newY = Mathf.Lerp(sceneCamera.transform.position.y, y + heightModifier, Time.deltaTime * speed);
        sceneCamera.transform.position = new Vector3(0f, newY, -1f);
    }
}
