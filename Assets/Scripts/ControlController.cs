using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlController : MonoBehaviour
{

    public int hight = 11;
    public int width = 19;
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
            temp.transform.localPosition = new Vector3 (tempCol-9, tempRow-5, 10);

            for (int r = 0; r <= control.xSize;r++)
            {
                for (int c = 0; c <= control.ySize; c++)
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
    
    private bool IsValidPosition(int row, int col, Control control)
    {

        Debug.Log ("attempting to place UI element at row " + row + " , col " + col);
        for (int r = 0; r < control.ySize; r++)
        {
            for (int c = 0; c < control.xSize; c++)
            {
                if (row + r < hight && col + c < 19 && ControlBoard[r+row,c+col])
                {
                    Debug.Log ("Can not place element at row " + row + " , col " + col + " becuase of error at row " + (row + r) + " , col " + (col + c));
                    return false;
                }

            }
        }
        return true;
    }


}
