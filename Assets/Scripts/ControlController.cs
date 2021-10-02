using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlController : MonoBehaviour
{

    private int hight = 7;
    private int width = 13;

    private int hightNegativeOffset = -3;
    private int widthNegativeOffset = -6;
    private int UIReSize = 4;
    public bool[,] ControlBoard;
    public GameObject[] typesOfControl;
    public Transform ControlPanelPlane;


    // Start is called before the first frame update
    void Start()
    {
        ControlBoard = new bool[hight,width];
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void addRandomControl()
    {
        int tempRow = Random.Range(0, hight);
        int tempCol = Random.Range(0, width);
        int tempControlIndex = Random.Range(0, typesOfControl.Length);
        Control control = typesOfControl[tempControlIndex].GetComponent<Control>();

        if (IsValidPosition(tempRow, tempCol, control))
        {
            GameObject temp = Instantiate(control.ControlBody,Camera.main.transform.position,Camera.main.transform.rotation);
            temp.transform.SetParent(Camera.main.transform);
            Debug.Log ("Control Controller : placing element at internal row " + tempRow + " , col " + tempCol + " real row " + (UIReSize*(tempRow + hightNegativeOffset)) + " , col " + (UIReSize*(tempCol + widthNegativeOffset)));
            temp.transform.localPosition = new Vector3 (UIReSize*(tempCol + widthNegativeOffset), UIReSize*(tempRow + hightNegativeOffset), 4);

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

    public void addSpecificCongtrol(Control Control)
    {

    }
    

    public void LogCurrentInternalUIBoard()
    {

    }



    private bool IsValidPosition(int row, int col, Control control)
    {

        Debug.Log ("attempting to place UI element at row " + row + " , col " + col);
        for (int r = 0; r < control.ySize; r++)
        {
            for (int c = 0; c < control.xSize; c++)
            {
                if (row + r >= hight || col + c >= width || ControlBoard[r+row,c+col])
                {
                    Debug.Log ("Control Controller : Can not place element at row " + row + " , col " + col + " becuase of error at row " + (row + r) + " , col " + (col + c));
                    return false;
                }

            }
        }
        return true;
    }


}
