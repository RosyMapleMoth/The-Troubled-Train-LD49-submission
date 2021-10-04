using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControlController : MonoBehaviour
{


    private const int DEPTH = 9;
    private const int HIGHT = 7;
    private const int WIDTH = 13;
    private const int HIGHT_OFFSET = -3;
    private const int WIDTH_OFFSET = -6;
    private const int UI_SCALER = 4;
    public bool[,] controlBoard;
    private List<Control> currentlyAvilableControls;
    public GameObject[] allControls;


    // Start is called before the first frame update
    void Start()
    {
        controlBoard = new bool[HIGHT,WIDTH];

        currentlyAvilableControls = new List<Control>();
        foreach (GameObject control in allControls)
        {
            currentlyAvilableControls.Add(control.GetComponent<Control>());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool areValidMovesLeft()
    {
        if (currentlyAvilableControls.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    } 



    public void addRandomControl()
    {
        if (! areValidMovesLeft())
        {
            return;
        }

        int attempts = 0;
        bool placement_successful = false;
        int tempControlIndex = Random.Range(0, currentlyAvilableControls.Count);
        Control control = currentlyAvilableControls[tempControlIndex].GetComponent<Control>();
        do 
        {
            int tempRow = Random.Range(0, HIGHT);
            int tempCol = Random.Range(0, WIDTH);

            Debug.Log ("Control Controller : Attempting to place UI element at at internal (" + tempRow + "," + tempCol + ") real (" + (UI_SCALER*(tempRow + HIGHT_OFFSET)) + "," + (UI_SCALER*(tempCol + WIDTH_OFFSET)+ ")"));
            if (IsValidPosition(tempRow, tempCol, control))
            {
                
                GameObject temp = Instantiate(control.ControlBody,Camera.main.transform.position,Camera.main.transform.rotation);
                temp.transform.SetParent(Camera.main.transform);
                Debug.Log ("Control Controller : Placing element at internal (" + tempRow + "," + tempCol + ") real (" + (UI_SCALER*(tempRow + HIGHT_OFFSET)) + "," + (UI_SCALER*(tempCol + WIDTH_OFFSET)+ ")"));
                temp.transform.localPosition = new Vector3 (UI_SCALER*(tempCol + WIDTH_OFFSET), UI_SCALER*(tempRow + HIGHT_OFFSET), DEPTH);
                placement_successful = true;

                for (int r = 0; r < control.ySize;r++)
                {
                    for (int c = 0; c < control.xSize; c++)
                    {
                        controlBoard[r+tempRow,c+tempCol] = true;
                    }
                }
            }
            else 
            {
                Debug.Log ("Control Controller : Unable to place element at internal (" + tempRow + "," + tempCol + ") real (" + (UI_SCALER*(tempRow + HIGHT_OFFSET)) + "," + (UI_SCALER*(tempCol + WIDTH_OFFSET))+ ")");
                attempts++;
            }
        } while (!placement_successful && attempts < 10);

        if (!placement_successful)
        {
            Vector2 tempVec = checkForAvilableSpace(control);
            if (!tempVec.Equals(Vector2.negativeInfinity))
            {
                GameObject temp = Instantiate(control.ControlBody,Camera.main.transform.position,Camera.main.transform.rotation);
                temp.transform.SetParent(Camera.main.transform);
                Debug.Log ("Control Controller : Placing element at internal (" + tempVec.x + "," + tempVec.y + ") real (" + (UI_SCALER*(tempVec.x + HIGHT_OFFSET)) + "," + (UI_SCALER*(tempVec.x + WIDTH_OFFSET)+ ")"));
                temp.transform.localPosition = new Vector3 (UI_SCALER*(tempVec.y + WIDTH_OFFSET), UI_SCALER*(tempVec.x + HIGHT_OFFSET), DEPTH);
                placement_successful = true;

                for (int r = 0; r < control.ySize;r++)
                {
                    for (int c = 0; c < control.xSize; c++)
                    {
                        controlBoard[r+(int)tempVec.x,c+(int)tempVec.y] = true;
                    }
                }
            }
            else
            {
                currentlyAvilableControls.Remove(control);
                if (currentlyAvilableControls.Count > 0)
                {
                    addRandomControl();
                }
            }
        }
    }

    public bool addSpecificControl(Control control)
    {
        int attempts = 0;
        bool placement_successful = false;
        do 
        {
            int tempRow = Random.Range(0, HIGHT);
            int tempCol = Random.Range(0, WIDTH);


            if (IsValidPosition(tempRow, tempCol, control))
            {
                GameObject temp = Instantiate(control.ControlBody,Camera.main.transform.position,Camera.main.transform.rotation);
                temp.transform.SetParent(Camera.main.transform);
                Debug.Log ("Control Controller : placing element at internal row " + tempRow + " , col " + tempCol + " real row " + (UI_SCALER*(tempRow + HIGHT_OFFSET)) + " , col " + (UI_SCALER*(tempCol + WIDTH_OFFSET)));
                temp.transform.localPosition = new Vector3 (UI_SCALER*(tempCol + WIDTH_OFFSET), UI_SCALER*(tempRow + HIGHT_OFFSET), DEPTH);
                placement_successful = true;

                for (int r = 0; r < control.ySize;r++)
                {
                    for (int c = 0; c < control.xSize; c++)
                    {
                        controlBoard[r+tempRow,c+tempCol] = true;
                    }
                }
    
            }
            else 
            {
                Debug.Log("Stack Overflow when adding new UI element. skipping add event");
                attempts++;
            }
        } while (!placement_successful && attempts < 10);

        
        if (!placement_successful)
        {
            Vector2 tempVec = checkForAvilableSpace(control);
            if (!tempVec.Equals(Vector2.negativeInfinity))
            {
                GameObject temp = Instantiate(control.ControlBody,Camera.main.transform.position,Camera.main.transform.rotation);
                temp.transform.SetParent(Camera.main.transform);
                Debug.Log ("Control Controller : Placing element at internal (" + tempVec.x + "," + tempVec.y + ") real (" + (UI_SCALER*(tempVec.x + HIGHT_OFFSET)) + "," + (UI_SCALER*(tempVec.x + WIDTH_OFFSET)+ ")"));
                temp.transform.localPosition = new Vector3 (UI_SCALER*(tempVec.y + WIDTH_OFFSET), UI_SCALER*(tempVec.x + HIGHT_OFFSET), DEPTH);
                placement_successful = true;

                for (int r = 0; r < control.ySize;r++)
                {
                    for (int c = 0; c < control.xSize; c++)
                    {
                        controlBoard[r+(int)tempVec.x,c+(int)tempVec.y] = true;
                    }
                }
                return true;
            }
            else
            {
                Debug.Log("Could not find space for your Control");
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    public bool addSpecificControlAt(int row, int col, Control control)
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
                    controlBoard[r+row,c+col] = true;
                }
            }
            return true;
        }
        else
        {
            Debug.Log("Spot is not avilable for selected UI element");
            return false;
        }
    }



    public bool addSpecificControlAt(Vector2 pos, Control control)
    {
        int row  = (int)pos.x;
        int col = (int)pos.y;
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
                    controlBoard[r+row,c+col] = true;
                }
            }
            return true;
        }
        else
        {
            Debug.Log("Spot is not avilable for selected UI element");
            return false;
        }
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
        for (int r = 0; r < control.ySize; r++)
        {
            for (int c = 0; c < control.xSize; c++)
            {
                if (row + r >= HIGHT || col + c >= WIDTH || controlBoard[r+row,c+col])
                {
                    Debug.Log ("Control Controller : Can not place element at (" + row + "," + col + ") becuase of error at (" + (row + r) + "," + (col + c)+")");
                    return false;
                }

            }
        }
        return true;
    }


    public Vector2 checkForAvilableSpace(Control control)
    {
        for (int r = 0; r < HIGHT;r++)
        {
            for (int c = 0; c < WIDTH; c++)
            {
                if (controlBoard[r,c])
                {
                    continue;
                }
                else if (IsValidPosition(r,c,control))
                {
                    return new Vector2(r,c);
                }
            }
        }
        return Vector2.negativeInfinity;
    }
}
