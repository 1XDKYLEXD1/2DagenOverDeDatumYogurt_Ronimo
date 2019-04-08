using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public float _MinXPosition, _MaxXPosition, _Speed;

    private void Update()
    {
        MoveWithKeyboard();
        MoveWithMouse();
    }

    private float CalculateRelativePercentage(float one, float two)
    {
        float Percentage;

        Percentage = ((one / two) * 100);

        return Percentage;
    }

    #region Movement

    private void MoveWithMouse()
    {
        Vector2 mousePos;
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float screenWidth = Screen.width;

        float zero, twenty, eighty, hundred;

        zero = 0;
        twenty = screenWidth * 0.2f;
        eighty = screenWidth * 0.8f;
        hundred = screenWidth;

        //Debug.Log("Twenty Percent: " + twenty);
        //Debug.Log("Eighty Percent: " + eighty);
        //Debug.Log("Onehundred Percent: " + hundred);

        //Debug.Log("Mouse Position: " + mousePos.x);

        if(transform.position.x > _MinXPosition || transform.position.x < _MaxXPosition)
        {
            if (mousePos.x < twenty && mousePos.x > zero)
            {
                transform.position -= -Vector3.left * Time.deltaTime * _Speed;
            }

            if (mousePos.x > eighty && mousePos.x < hundred)
            {
                transform.position -= -Vector3.right * Time.deltaTime * _Speed;
            }
        }      
    }

    private void MoveWithKeyboard()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > _MinXPosition)
        {
            transform.position -= -Vector3.left * Time.deltaTime * _Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < _MaxXPosition)
        {
            transform.position -= -Vector3.right * Time.deltaTime * _Speed;
        }

        if (transform.position.x < _MinXPosition)
        {
            transform.position = new Vector3(_MinXPosition, 0, 0);
        }
        if (transform.position.x > _MaxXPosition)
        {
            transform.position = new Vector3(_MaxXPosition, 0, 0);
        }
    }

    #endregion

}
