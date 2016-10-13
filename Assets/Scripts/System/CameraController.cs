using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Transform [] playerToFollow;
    private int cursor = 0, nextPOI=1, lastPOI=0;
    public float offset, limit, increment;
    float playersDistance, lastPlayerDistance, duration, elapsed, startZoom, endZoom;
    public Parallax[] parallaxElements;
    Camera mainCamera;
    public PointsOfInterest [] pointsOfInterest;
    bool zooming;

    [System.Serializable]
    public struct PointsOfInterest
    {
       public float position, size, zoomSpeed;

    }

    [System.Serializable]
    public struct Parallax
    {

        public float parallaxSpeed;
        public Transform parallaxElement;
    }



    void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Use this for initialization
    void Start () {
        
        playerToFollow = new Transform[2];

        PlayerController[] players = GameObject.FindObjectsOfType<PlayerController>();
        for (int i =0; i<players.Length; i++)
        {
            playerToFollow[i] = players[i].gameObject.transform;
        }
        playersDistance = (playerToFollow[0].position.x + playerToFollow[1].position.x)/2;
        lastPlayerDistance = playersDistance;

    }

    // Update is called once per frame
    void Update() {
        //CameraCheck();
        POICheck();
        playersDistance = (playerToFollow[0].position.x + playerToFollow[1].position.x) / 2;
        if (playersDistance != lastPlayerDistance)
        {
            CalculateParallax(playersDistance - lastPlayerDistance);
        }
        lastPlayerDistance = playersDistance;

        transform.position = new Vector3(playersDistance - offset, transform.position.y, transform.position.z);
        if (offset > limit)
            offset += increment;

        if (zooming)
        {
            elapsed += Time.deltaTime / duration;
            mainCamera.orthographicSize = Mathf.Lerp(startZoom, endZoom, elapsed);
            //this next line i'm not sure of, I'm not familiar with CameraMovement.ypos
            //Camera.main.GetComponent<CameraMovement>().ypos = Mathf.Lerp(ypos1, ypos2, elapsed);


            if (elapsed > 1.0f)
            {
                zooming = false;
            }
        }
    }

    void POICheck()
    {
        if (transform.position.x > pointsOfInterest[nextPOI].position)
        {
            CameraSizeLerping(pointsOfInterest[nextPOI].size, pointsOfInterest[nextPOI].zoomSpeed);
            lastPOI = nextPOI;
            nextPOI++;
        }
        else if (transform.position.x<pointsOfInterest[lastPOI].position)
        {
            nextPOI = lastPOI;
            lastPOI--;
            CameraSizeLerping(pointsOfInterest[lastPOI].size, pointsOfInterest[lastPOI].zoomSpeed);
     
        }
    }

 
    void CameraSizeLerping(float size, float speed)
    {

        zooming = true;
        startZoom = mainCamera.orthographicSize;
        endZoom = size;
        elapsed = 0;
        duration = speed;
    }

    void CalculateParallax(float difference)
    {
        for (int k=0; k<parallaxElements.Length; k++)
        {
            Transform par = parallaxElements[k].parallaxElement;
            float speed = parallaxElements[k].parallaxSpeed;
            par.position = new Vector3(par.position.x - difference * speed, par.position.y, par.position.z);
        }
    }

   

    //void CameraCheck()
    //{
    //    float max = playerToFollow[cursor].position.x;
    //    for (int i=0; i < playerToFollow.Length; i++)
    //    {
    //        if (playerToFollow[i].position.x > playerToFollow[cursor].position.x)
    //            cursor = i;
    //    }
    //}
}
