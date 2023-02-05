using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graping : MonoBehaviour
{
    Collider Col;
    Vector3 Zero;
    Quaternion RZero;
    Vector3 TruePosition;

    [SerializeField]bool ClearFlag;
    bool OnGame;

    void Start()
    {
        OnGame = true;
        Col = GetComponent<Collider>();
        Zero = transform.position;
        RZero = transform.rotation;
        TruePosition = new Vector3(-1.2f,0.2f,0.5f);
    }

    private void OnMouseDown()
    {
        if (!OnGame) return;
        transform.rotation = Quaternion.Euler(-90,0,0);
    }

    void OnMouseDrag()
    {
        if (!OnGame) return;
        Col.enabled = false;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = new Vector3(hit.point.x, hit.point.y+0.1f, hit.point.z);
        }

        float distanse = Vector3.Distance(transform.position,TruePosition);

        if(distanse < 1)
        {
            transform.position = TruePosition;
        }
    }

    void OnMouseUp()
    {
        if (!OnGame) return;
        Col.enabled = true;

        if (!ClearFlag)
        {
            transform.position = Zero;
            transform.rotation = RZero;

        }

        if (ClearFlag)
        {
            if (transform.position != TruePosition)
            {
                transform.position = Zero;
                transform.rotation = RZero;

            }
            
            if(transform.position == TruePosition)
            {
                Debug.Log("CLEAR");
                transform.localScale = new Vector3(50, 50, 50);
                OnGame = false;
            }
        }


    }
}
