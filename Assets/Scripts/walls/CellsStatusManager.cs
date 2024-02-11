using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.Events;

public class CellsStatusManager : MonoBehaviour
{
    public UnityEvent<CellManager> onPlayerEnterNewCell;
    public Dictionary<int, CellManager> cells;
    public List<CellManager> cellsForDictionary;
    // Start is called before the first frame update
    void Start()
    {
        cells = new Dictionary<int, CellManager>();
        foreach (var cell in cellsForDictionary)
        {
            AddCell(cell);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CellManager GetCell(int id) {
        if(cells.ContainsKey(id)){
            return cells[id];
        }
        return null;
    }

    public void AddCell(CellManager cell) {
        cells.Add(cell.id, cell);
    }

    public void RemoveCell(CellManager cell) {
        cells.Remove(cell.id);
    }

    public CellManager GetRandomCell(int from, int to){
        var inactiveCells = cells.Where((cell)=>cell.Value.id >= from && cell.Value.id <= to && !cell.Value.gameObject.activeInHierarchy);
        var id = UnityEngine.Random.Range(0, inactiveCells.Count());
        return inactiveCells.ElementAt(id).Value;
    }
}
