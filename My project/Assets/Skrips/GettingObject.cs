using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class GettingObject : MonoBehaviour
{
    static internal RaycastHit2D hit;

    void Update()
    {
        StartHit();
    }

    private RaycastHit2D StartHit()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(!EventSystem.current.IsPointerOverGameObject())
            {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				hit = Physics2D.GetRayIntersection(ray);
			}
        }

        return hit;
    }
}
