using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looting : MonoBehaviour
{
    private Transform TargetLooting;

    public void SetTargetLooting(Transform TargetLooting)
    {
        this.TargetLooting = TargetLooting;
    }

	void Update()
    {
        if(TargetLooting != null && this.transform.position.x == TargetLooting.transform.position.x)
        {
            TargetLooting.GetComponent<Loot>().IssuindLoots();

            Destroy(TargetLooting.gameObject);
        }   
    }
}
