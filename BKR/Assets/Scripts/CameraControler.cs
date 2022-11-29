using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] float speedZoom = 0.1f;
    [SerializeField] float maxZoom = 10;
    [SerializeField] float minZoom = 1;
    [SerializeField] float maxHeight = 10;
    [SerializeField] float maxWidth = 10;
    [SerializeField] GameObject selecter;
    [SerializeField] private List <GameObject> target = new List<GameObject>();
    private Camera camera;
    private Vector2 positionMouse;
    private GameObject nowSelect;
    private int mainTarget;


    public void SelectTarget(GameObject t)
    {
        target.Add(t);
    }

    public void TakeOffTarget(GameObject t)
    {
        for (int i = 0; i < target.Count; i++)
            if (target[i] == t)
            {
                target.RemoveAt(i);
                break;
            }
    }

    void Start()
    {
        camera = this.GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 cameraSee = camera.ScreenPointToRay(Input.mousePosition).GetPoint(Mathf.Abs(this.transform.position.z));


        if (Input.mouseScrollDelta.y > 0.0f && camera.orthographicSize > minZoom)
        {
            camera.orthographicSize -= speedZoom;
        }
        else if (Input.mouseScrollDelta.y < 0.0f && camera.orthographicSize < maxZoom)
        {
            camera.orthographicSize += speedZoom;
        }

        if (Input.GetKey(KeyCode.Mouse2))
        {
            float deltaX = 0, deltaY = 0;
            if (Mathf.Abs(positionMouse.x - Input.mousePosition.x) > 0)
            {
                deltaX = positionMouse.x - Input.mousePosition.x ;
            }
            if (Mathf.Abs(positionMouse.y - Input.mousePosition.y) > 0)
            {
                deltaY = positionMouse.y - Input.mousePosition.y;
            }

            if (Mathf.Abs(deltaX + deltaY) > 0)
            {
                this.transform.position += new Vector3(deltaX/100, deltaY/100, 0);

                if (Mathf.Abs(this.transform.position.x) > maxWidth)
                    if (this.transform.position.x > 0)
                        this.transform.position = new Vector3(maxWidth, this.transform.position.y, this.transform.position.z);
                    else
                        this.transform.position = new Vector3(-maxWidth, this.transform.position.y, this.transform.position.z);

                if (Mathf.Abs(this.transform.position.y) > maxHeight)
                    if (this.transform.position.y > 0)
                        this.transform.position = new Vector3(this.transform.position.x, maxHeight, this.transform.position.z);
                    else
                        this.transform.position = new Vector3(this.transform.position.x, -maxHeight, this.transform.position.z);
            }
        }
        positionMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (target.Count == 0)
            {
                nowSelect = Instantiate(selecter, new Vector3(cameraSee.x, cameraSee.y, 0), Quaternion.identity);
                nowSelect.GetComponent<Select>().selectCamera(this.GetComponent<Camera>());
            }
            else
            {
                foreach (GameObject i in target)
                    i.GetComponent<Component>().Unselect();
                target = new List<GameObject>();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && nowSelect != null)
        {
            GameObject[] x = nowSelect.GetComponent<Select>().GetObjects();
            Destroy(nowSelect);
            foreach (GameObject i in x)
            {
                target.Add(i);
                i.GetComponent<Component>().Select();
            }

            nowSelect = null;
            mainTarget = 0;
            float mn = Vector2.Distance(target[mainTarget].transform.position, cameraSee);
            for (int i = 0; i < target.Count; i++)
                if (mn > Vector2.Distance(target[i].transform.position, cameraSee))
                {
                    mn = Vector2.Distance(target[i].transform.position, cameraSee);
                    mainTarget = i;
                }
        }

        if (target.Count != 0) {
            foreach (GameObject i in target)
                i.transform.position += new Vector3(cameraSee.x - target[mainTarget].transform.position.x, cameraSee.y - target[mainTarget].transform.position.y, 0);
        }

    }
}
