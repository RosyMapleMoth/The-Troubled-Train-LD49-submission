using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlController : MonoBehaviour
{


    private const int DEPTH = 4;
    private const int HIGHT = 7;
    private const int WIDTH = 13;
    private const int HIGHT_OFFSET = -3;
    private const int WIDTH_OFFSET = -6;
    private const int UI_SCALER = 4;


    public bool[,] ControlBoard;
    public GameObject[] DEBUG_typesOfControl;


    // Start is called before the first frame update
    void Start()
    {
        ControlBoard = new bool[HIGHT,WIDTH];
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void addRandomControl()
    {
        int tempRow = Random.Range(0, HIGHT);
        int tempCol = Random.Range(0, WIDTH);
        int tempControlIndex = Random.Range(0, DEBUG_typesOfControl.Length);
        Control control = DEBUG_typesOfControl[tempControlIndex].GetComponent<Control>();

        if (IsValidPosition(tempRow, tempCol, control))
        {
            GameObject temp = Instantiate(control.ControlBody,Camera.main.transform.position,Camera.main.transform.rotation);
            temp.transform.SetParent(Camera.main.transform);
            Debug.Log ("Control Controller : placing element at internal row " + tempRow + " , col " + tempCol + " real row " + (UI_SCALER*(tempRow + HIGHT_OFFSET)) + " , col " + (UI_SCALER*(tempCol + WIDTH_OFFSET)));
            temp.transform.localPosition = new Vector3 (UI_SCALER*(tempCol + WIDTH_OFFSET), UI_SCALER*(tempRow + HIGHT_OFFSET), DEPTH);

            for (int r = 0; r < control.ySize;r++)
            {
                for (int c = 0; c < control.xSize; c++)
                {
                    ControlBoard[r+tempRow,c+tempCol] = true;
                }
            }
        }
        else 
        {
            try 
            {
                addRandomControl();
            }
            catch
            {
                Debug.Log("Stack Overflow when adding new UI element. skipping add event");
            }
        }
    }

    public void addSpecificControl(Control Control)
    {
        int tempRow = Random.Range(0, HIGHT);
        int tempCol = Random.Range(0, WIDTH);
        int tempControlIndex = Random.Range(0, DEBUG_typesOfControl.Length);
        Control control = DEBUG_typesOfControl[tempControlIndex].GetComponent<Control>();

        if (IsValidPosition(tempRow, tempCol, control))
        {
            GameObject temp = Instantiate(control.ControlBody,Camera.main.transform.position,Camera.main.transform.rotation);
            temp.transform.SetParent(Camera.main.transform);
            Debug.Log ("Control Controller : placing element at internal row " + tempRow + " , col " + tempCol + " real row " + (UI_SCALER*(tempRow + HIGHT_OFFSET)) + " , col " + (UI_SCALER*(tempCol + WIDTH_OFFSET)));
            temp.transform.localPosition = new Vector3 (UI_SCALER*(tempCol + WIDTH_OFFSET), UI_SCALER*(tempRow + HIGHT_OFFSET), 4);

            for (int r = 0; r < control.ySize;r++)
            {
                for (int c = 0; c < control.xSize; c++)
                {
                    ControlBoard[r+tempRow,c+tempCol] = true;
                }
            }
        }
    }
    

    public void addSpecificControlAt(int row, int col, Control control)
    {
        if (IsValidPosition(row, col, control))
        {
            GameObject temp = Instantiate(control.ControlBody,Camera.main.transform.position,Camera.main.transform.rotation);
            temp.transform.SetParent(Camera.main.transform);
            Debug.Log ("Control Controller : placing element at internal row " + row + " , col " + col + " real row " + (UI_SCALER*(row + HIGHT_OFFSET)) + " , col " + (UI_SCALER*(col + WIDTH_OFFSET)));
            temp.transform.localPosition = new Vector3 (UI_SCALER*(col + WIDTH_OFFSET), UI_SCALER*(row + HIGHT_OFFSET), DEPTH);

            for (int r = 0; r < control.ySize;r++)
            {
                for (int c = 0; c < control.xSize; c++)
                {
                    ControlBoard[r+row,c+col] = true;
                }
            }
        }
    }



    public void LogCurrentInternalUIBoard()
    {

    }


    /// <summary>
    /// Returns if the currently selected peice can be placed in the position given
    /// </summary>
    /// <param name="row">row to place in</param>
    /// <param name="col">col to place</param>
    /// <param name="control"></param>
    /// <returns></returns>
    private bool IsValidPosition(int row, int col, Control control)
    {

        Debug.Log ("attempting to place UI element at row " + row + " , col " + col);
        for (int r = 0; r < control.ySize; r++)
        {
            for (int c = 0; c < control.xSize; c++)
            {
                if (row + r >= HIGHT || col + c >= WIDTH || ControlBoard[r+row,c+col])
                {
                    Debug.Log ("Control Controller : Can not place element at row " + row + " , col " + col + " becuase of error at row " + (row + r) + " , col " + (col + c));
                    return false;
                }

            }
        }
        return true;
    }


}
