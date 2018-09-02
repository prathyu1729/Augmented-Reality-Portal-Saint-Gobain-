using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class portalmanager: MonoBehaviour {
    public GameObject cam;
    public GameObject Sponza;
    private Material[] sponzamaterial;
	// Use this for initialization
	void Start () {
        sponzamaterial = Sponza.GetComponent<Renderer>().sharedMaterials;
		
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider collider)
    {
        Vector3 campositioninportalspace = transform.InverseTransformPoint(cam.transform.position);
        if(campositioninportalspace.y<0.5f)
        {
            for (int i = 0; i < sponzamaterial.Length; i++)
                sponzamaterial[i].SetInt("_StencilComp", (int)CompareFunction.Always);
        }


        else
        {
            for (int i = 0; i < sponzamaterial.Length; i++)
                sponzamaterial[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
        }


	}
}
