using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public Brick previousBrick;  
    public Brick currentBrick;

    public float threshold;

    public Brick brickPrefab;

    public CameraMovement cameraMovement;
    public ColorPicker colorPicker;

    public void Start()
    {
        colorPicker.Init();
        currentBrick.UpdateColor(colorPicker.GetCurrentColor());
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StackBricks(); 
        }

        cameraMovement.UpdatePosition(currentBrick.transform.position.y); 
    }

    public void StackBricks()
    {
        float difference = previousBrick.leftEdge - currentBrick.leftEdge;
        if( Mathf.Abs(difference) > previousBrick.length)
        {
            // GAME OVER
            Debug.Log("GAMEOVER");
            return; 
        }

        CutBrick( difference ); 

        CreateNewBrick(); 
    }
    public void CreateNewBrick()
    {
        colorPicker.IncreaseStep();

        previousBrick = currentBrick;
        currentBrick = Instantiate(brickPrefab);
        currentBrick.transform.position = previousBrick.transform.position + Vector3.up;
        currentBrick.movement.proocedMove = true;
        currentBrick.UpdateLine(previousBrick.leftPosition.x, previousBrick.rightPosition.x);
        currentBrick.UpdateColor(colorPicker.GetCurrentColor()); 
    }

    public void CutBrick(float difference)
    {
        currentBrick.movement.proocedMove = false;
        currentBrick.transform.position = previousBrick.transform.position + Vector3.up;

        if (difference > threshold)
        {
            currentBrick.UpdateLine(previousBrick.leftPosition.x, currentBrick.rightPosition.x - difference);
            CreateLeftOver(currentBrick.leftPosition.x - difference, currentBrick.leftPosition.x);
        }
        else if (difference < -threshold)
        {
            currentBrick.UpdateLine(currentBrick.leftPosition.x - difference, previousBrick.rightPosition.x);
            CreateLeftOver(currentBrick.rightPosition.x, currentBrick.rightPosition.x - difference);
        }
    }

    public void CreateLeftOver(float leftEdge, float rightEdge)
    {
        Brick leftover = Instantiate(brickPrefab);
        leftover.transform.position = currentBrick.transform.position;
        leftover.UpdateLine(leftEdge, rightEdge);
        leftover.AddGravity();
        leftover.UpdateColor(colorPicker.GetCurrentColor()); 
        Destroy(leftover.gameObject, 2f); //Destroy(object, delay); 
    }

}
