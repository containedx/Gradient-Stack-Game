using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [Header("Line Atributes")]
    public LineRenderer brickRenderer;
    public Vector3 leftPosition;
    public Vector3 rightPosition;

    [Header("Movement Atributes")]
    public BrickMovement movement;

    [Header("Physics")]
    public Rigidbody brickRb; 

    
    public float leftEdge { get { return transform.position.x + leftPosition.x; } } // przy odwolaniu przyjma taka wartosc ::
    public float rightEdge { get { return transform.position.x + rightPosition.x; } }

    public float length { get { return (leftPosition - rightPosition).magnitude; } }

    public void Start()
    {
      
    }

    public void Update()
    {
        //aktualizacja ruchu         
        movement?.UpdatePosition(transform);  // transform tego obiektu 
    }

    public void UpdateLine()
    {
        brickRenderer.positionCount = 2;
        brickRenderer.SetPosition(0, leftPosition);   
        brickRenderer.SetPosition(1, rightPosition);
    }

    public void UpdateLine(float leftEdge, float rightEdge)
    {
        leftPosition.x = leftEdge;
        rightPosition.x = rightEdge;
        UpdateLine(); 
    }

    public void UpdateColor(Color color)
    {
        brickRenderer.startColor = color;
        brickRenderer.endColor = color;       
    }

    public void AddGravity()
    {
        brickRb.isKinematic = false; 
    }

}

[System.Serializable]
public class BrickMovement
{
    public float speed;
    public float range;
    public bool proocedMove;

    public void UpdatePosition(Transform brickTransform)
    {
        if (proocedMove)
        {
            //poruszaj od -r do r z szybkoscia speed
            var newX = Mathf.Lerp(-range, range, Mathf.InverseLerp(-1f, 1f, Mathf.Sin(Time.time * speed)));

            //zmieniamy tylko X
            brickTransform.position = new Vector3(newX, brickTransform.position.y, brickTransform.position.z);
        }
    }
}
