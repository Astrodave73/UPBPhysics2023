using System.Net;
using UnityEngine;

public class SpringDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 restPosition;

    private float _xDistance;
    public float xDistance { get => _xDistance; }

    private int _direction; // 1 positivo, -1 negativo.
    public int direction { get => _direction; }

    private void Start()
    {
        restPosition = transform.position;
    }
    void OnMouseDown()
    {
        isDragging = true;
        
    }

    void OnMouseUp()
    {
        isDragging = false;
        _xDistance = Vector3.Distance(restPosition, transform.position);

        if (transform.position.x >= restPosition.x) _direction = 1;
        else _direction = -1;
    }

    void Update()
    {

      //  Debug.Log(Input.mousePosition);

        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;

            Vector3 worldPosition = mousePos;
            worldPosition.z = -Camera.main.transform.position.z;
            worldPosition = Camera.main.ScreenToWorldPoint(worldPosition);
            print(worldPosition);
            Vector3 currentPosition = worldPosition;
            Vector3 adjustedPosition = new Vector3(currentPosition.x, restPosition.y, restPosition.z);
            transform.position = adjustedPosition;
        }
    }
    private void OnDrawGizmos()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 worldPosition = mousePos;
        worldPosition.z = 8;
        worldPosition = Camera.main.ScreenToWorldPoint(worldPosition);
        Gizmos.DrawSphere(worldPosition,.5f);
    }
}