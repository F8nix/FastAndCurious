using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    private readonly int cellLeftMinId = 0;
    private readonly int cellLeftMaxId = 3;
    private readonly int cellRightMinId = 4;
    private readonly int cellRightMaxId = 7;
    private readonly int cellUpMinId = 8;
    private readonly int cellUpMaxId = 11;
    private readonly int cellDownMinId = 12;
    private readonly int cellDownMaxId = 15;


    public GameObject cell;

    public GameObject cellCentre;
    public ColliderListener onEnterTrigger;

    public LayerMask playerLayer;


    public int id;
    public int toDeactivation;

    public List<string> connectionsDirections;

    private List<CellManager> nextCells;

    public CellsStatusManager cellsStatusManager;

    // Start is called before the first frame update
    private void Start()
    {
        onEnterTrigger = GetComponentInChildren<ColliderListener>();
    }

    private void OnEnable()
    {
    toDeactivation = 2;
    cellsStatusManager.onPlayerEnterNewCell.AddListener(OnPlayerEnterNewCell);
        if (onEnterTrigger == null){
            onEnterTrigger = GetComponentInChildren<ColliderListener>();
        }
        onEnterTrigger.onTriggerEnter.AddListener(OnTriggerEnter);
    }

    private void OnDisable()
    {
        cellsStatusManager.onPlayerEnterNewCell.RemoveListener(OnPlayerEnterNewCell);
        if(id!=-1){
        onEnterTrigger.onTriggerEnter.RemoveListener(OnTriggerEnter);
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void PositionNearbyCells()
    {
        nextCells = new();
        foreach (string direction in connectionsDirections)
        {
            var cell = PutCellIntoDirection(direction);
            nextCells.Add(cell);
        }
    }

    public CellManager PutCellIntoDirection(string direction)
    {
        CellManager cell;
        int cellMinId;
        int cellMaxId;
        Vector3 cellDirection;

        switch (direction)
        {
            case "up":
                cellMinId = cellDownMinId;
                cellMaxId = cellDownMaxId;
                cellDirection = Vector3.forward;
                break;

            case "down":
                cellMinId = cellUpMinId;
                cellMaxId = cellUpMaxId;
                cellDirection = Vector3.back;
                break;
            
            case "right":
                cellMinId = cellLeftMinId;
                cellMaxId = cellLeftMaxId;
                cellDirection = Vector3.right;
                break;

            case "left":
                cellMinId = cellRightMinId;
                cellMaxId = cellRightMaxId;
                cellDirection = Vector3.left;
                break;

            default:
                Debug.Log("directionless room or direction choosing error");
                return null;
        }
        cell = cellsStatusManager.GetRandomCell(cellMinId, cellMaxId);
        ActivateAndMoveCell(cell.cell, cellDirection);
        return cell;
    }

    public void ActivateAndMoveCell(GameObject cell, Vector3 direction)
    {
        cell.SetActive(true);
        cell.transform.position = cellCentre.transform.position;
        cell.transform.position += direction * 10.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")){
            return;
        }
        //Debug.Log("on trig ent");
        cellsStatusManager.onPlayerEnterNewCell.Invoke(this);
        PositionNearbyCells();
        onEnterTrigger.onTriggerEnter.RemoveListener(OnTriggerEnter);
    }

    private void OnPlayerEnterNewCell(CellManager cellManager) {
        if(cellManager == this){
            return;
        }
        toDeactivation--;
        if(nextCells != null) {
            for (int i = 0; i < nextCells.Count; i++)
            {
                CellManager cell = nextCells[i];
                if (cell != cellManager){
                    cell.cell.SetActive(false);                
                } else {
                    nextCells.Remove(cell);
                    i--;
                }
            }
            nextCells = null;
        }
        if (toDeactivation <= 0)
        {
            cell.SetActive(false);
        }
    }
}
