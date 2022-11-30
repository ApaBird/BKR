using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour
{
    [SerializeField] private float distan = 0.5f;
    private List<GameObject> link = new List<GameObject>();
    private RaycastHit2D[] rays = new RaycastHit2D[4];

    public GameObject GetLink(GameObject component)
    {
        if (component.GetComponent<Component>())
        {
            link.Add(component);
            return this.gameObject;
        }
        else
            return null;
    } 

    public void ChekLink()
    {
        rays[0] = Physics2D.Raycast(this.transform.position + Vector3.up, Vector2.up, distan);
        rays[1] = Physics2D.Raycast(this.transform.position + Vector3.down, Vector2.down, distan);
        rays[2] = Physics2D.Raycast(this.transform.position + Vector3.right, Vector2.right, distan);
        rays[3] = Physics2D.Raycast(this.transform.position + Vector3.left, Vector2.left, distan);

        foreach (RaycastHit2D i in rays)
        {
           if (i.collider != null && i.collider.GetComponent<Component>())
            {
                link.Add(i.collider.GetComponent<Component>().GetLink(this.gameObject));
                if (Mathf.Abs(i.transform.position.x - this.transform.position.x) < 0.5)
                    if (i.transform.position.y - this.transform.position.y < 0)
                        this.transform.position = new Vector2(i.transform.position.x, i.transform.position.y + 1);
                    else
                        this.transform.position = new Vector2(i.transform.position.x, i.transform.position.y - 1);
                else
                    if (i.transform.position.x - this.transform.position.x < 0)
                        this.transform.position = new Vector2(i.transform.position.x + 1, i.transform.position.y);
                    else
                        this.transform.position = new Vector2(i.transform.position.x - 1, i.transform.position.y);
            }

        }
    }
}
