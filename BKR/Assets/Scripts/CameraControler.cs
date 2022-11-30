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
    private List <GameObject> target = new List<GameObject>();
    private Camera camera;
    private Vector2 positionMouse;
    private GameObject nowSelect;
    
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
            /*Debug.Log(cameraSee);
            nowSelect = Instantiate(selecter, new Vector3(cameraSee.x, cameraSee.y, 0), Quaternion.identity);
            nowSelect.GetComponent<Select>().selectCamera(this.GetComponent<Camera>());*/
            if (target.Count == 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(camera.ScreenToWorldPoint(Input.mousePosition).x, camera.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
                if (hit.collider != null && hit.collider.GetComponent<Component>())
                    SelectTarget(hit.collider.gameObject);
            }
            else
            {
                foreach (GameObject i in target)
                    i.GetComponent<Component>().ChekLink();
                target = new List<GameObject>();
            }
        }

        /*if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            target = nowSelect.GetComponent<Select>().GetListObject();
            Destroy(nowSelect);
        }*/
        
        if (target.Count != 0)
            foreach (GameObject i in target)
                i.transform.position += new Vector3(cameraSee.x - i.transform.position.x, cameraSee.y - i.transform.position.y, 0);

    }
}
