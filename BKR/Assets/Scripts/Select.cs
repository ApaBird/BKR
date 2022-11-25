using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    private List<GameObject> selectedObject = new List<GameObject>();
    [SerializeField] private Camera camera;

    public void selectCamera(Camera c) => this.camera = c;

    void Update()
    {
        Vector3 mousePosition = camera.ScreenPointToRay(Input.mousePosition).GetPoint(camera.transform.position.z);
        this.transform.localScale = new Vector3( mousePosition.x - this.transform.position.x, this.transform.position.y - mousePosition.y, 0);
    }

    public List<GameObject> GetListObject() => selectedObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Component>())
            selectedObject.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < selectedObject.Count; i++)
            if (selectedObject[i] == collision.gameObject)
            {
                selectedObject.RemoveAt(i);
                break;
            }

    }
}
