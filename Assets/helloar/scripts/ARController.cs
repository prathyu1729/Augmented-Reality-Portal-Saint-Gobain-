using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using UnityEngine.UI;
#if UNITY_EDITOR
using input = GoogleARCore.InstantPreviewInput;
#endif


public class ARController : MonoBehaviour
{
    private List<DetectedPlane> m_NewTrackedPlanes = new List<DetectedPlane>();
    public GameObject gridprefab;
    public GameObject portal;
    public GameObject cam;
    public Text messagebox;
   // public Material material;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Session.Status != SessionStatus.Tracking)
            return;

        Session.GetTrackables<DetectedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);

        for (int i = 0; i < m_NewTrackedPlanes.Count; i++)
        {
            GameObject grid = Instantiate(gridprefab, Vector3.zero, Quaternion.identity);
            grid.GetComponent<VisualiserGrid>().Initialize(m_NewTrackedPlanes[i]);

        }


        Touch touch;
        if (Input.touchCount < 1 || (touch =Input.GetTouch(0)).phase != TouchPhase.Began)
            return;

         TrackableHit hit;

        if(Frame.Raycast(touch.position.x,touch.position.y,TrackableHitFlags.PlaneWithinPolygon,out hit))
         {
            //portal.SetActive(false);

            /* portal.SetActive(true);
             Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);
             portal.transform.position = hit.Pose.position;
             portal.transform.rotation = hit.Pose.rotation;
             Vector3 camposition = cam.transform.position;
             camposition.y = hit.Pose.position.y;
             portal.transform.LookAt(camposition,portal.transform.up);
             portal.transform.parent = anchor.transform;*/
            GL.Begin(GL.LINES);
           // material.SetPass(0);
           // GL.Color(material.color);
            GL.Vertex(new Vector3(0, 0, 0));
            GL.Vertex(new Vector3(1, 1, 1));
            GL.End();
            messagebox.text = Vector3.Distance(new Vector3(0, 0, 0), new Vector3(1, 1, 1)).ToString();
         }

        /*if (Input.touchCount==2)
        {
            Debug.Log("ITS COMING HOME");
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            TrackableHit hit1;
            TrackableHit hit2;
            if (Frame.Raycast(touch1.position.x, touch1.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit1)&& Frame.Raycast(touch2.position.x, touch2.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit2))
            {
                
                GL.Begin(GL.LINES);
                //material.SetPass(0);
               /// GL.Color(material.color);
                GL.Vertex(hit1.Pose.position);
                GL.Vertex(hit2.Pose.position);
                GL.End();
                messagebox.text = Vector3.Distance(hit1.Pose.position, hit2.Pose.position).ToString();


            }

        }*/


        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("ITS COMING HOME");
            GL.Begin(GL.LINES);
            GL.Vertex(new Vector3(0,0,0));
            GL.Vertex(new Vector3(1,1,1));
            GL.End();
            messagebox.text = Vector3.Distance(new Vector3(0, 0, 0), new Vector3(1, 1, 1)).ToString();
        }





	}
}
