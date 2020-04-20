using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{

    public ContactFilter2D filter2D;
    public Waypoint point;

    private Dictionary<int, PlayerUnit> selectedUnits = new Dictionary<int, PlayerUnit>();

    public int selectedUnitsCount;

    public void AddSelected(PlayerUnit unit, bool isShiftPressed = false)
    {
        int id = unit.GetInstanceID();

        if (!selectedUnits.ContainsKey(id))
        {
            selectedUnits.Add(id, unit);
            unit.isSelected = true;
        }
        else if (isShiftPressed)
        {
            RemoveSelected(id);
        }
    }

    public void RemoveSelected(int id)
    {
        selectedUnits[id].isSelected = false;
        selectedUnits.Remove(id);
    }

    public void RemoveSelected(PlayerUnit unit)
    {
        int id = unit.GetInstanceID();
        RemoveSelected(id);
    }

    public void RemoveAllSelected()
    {
        foreach (KeyValuePair<int, PlayerUnit> selected in selectedUnits)
        {
            if (selected.Value != null)
            {
                selected.Value.isSelected = false;
            }
        }
        selectedUnits.Clear();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastHit2D> hit = new List<RaycastHit2D>(); 
            Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, filter2D, hit);
            if (hit.Count > 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    foreach(RaycastHit2D _hit in hit)
                    { 
                        AddSelected(_hit.collider.gameObject.GetComponent<PlayerUnit>(), true);
                    }
                }
                else
                { 
                    RemoveAllSelected();
                    AddSelected(hit[0].collider.gameObject.GetComponent<PlayerUnit>());
                }
            }
            else
            {
                RemoveAllSelected();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (selectedUnits.Count > 0)
            {
                Waypoint p = Instantiate(point, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.Euler(Vector3.zero));
                p.SetType(Waypoint.Type.END);
                foreach (KeyValuePair<int, PlayerUnit> selected in selectedUnits)
                {
                    selected.Value.SetWaypoint(p);
                }
                RemoveAllSelected();
            }
        }
        selectedUnitsCount = selectedUnits.Count;
    }
}
