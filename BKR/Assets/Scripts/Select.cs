using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] private List<GameObject> selectedObject = new List<GameObject>();
    [SerializeField] private Camera camera;

    public void selectCamera(Camera c) => this.camera = c;

    void Update()
    {
        Vector3 mousePosition = camera.ScreenPointToRay(Input.mousePosition).GetPoint(camera.transform.position.z);
        float sizeX = 0.1f;
        float sizeY = 0.1f;
        if (Mathf.Abs(mousePosition.x - this.transform.position.x) > 0.1)
            sizeX = mousePosition.x - this.transform.position.x;
        if (Mathf.Abs(mousePosition.y - this.transform.position.y) > 0.1)
            sizeY = mousePosition.y - this.transform.position.y;
        this.transform.localScale = new Vector3( sizeX, sizeY, 0);
    }

    public GameObject[] GetObjects()
    {
        if (selectedObject.Count > 0)
        {
            GameObject[] x = new GameObject[selectedObject.Count];
            for (int i = 0; i < selectedObject.Count; i++)
                x[i] = selectedObject[i];
            return x;
        }
        else
            return new GameObject[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Component>())
        {
            if (collision.GetComponent<Outline>())
                collision.GetComponent<Outline>().OutlineOn();
            selectedObject.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < selectedObject.Count; i++)
            if (selectedObject[i] == collision.gameObject)
            {
                selectedObject[i].GetComponent<Component>().Unselect();
                selectedObject.RemoveAt(i);
                break;
            }

    }
}
