using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    [SerializeField] GameObject cursorObject;
    [SerializeField] GameObject objectToPlace;
    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] Camera cam;
    [SerializeField] GameObject car;
    [SerializeField] bool useCursor =true;

    [SerializeField] GameObject itemPrefab;
    [SerializeField] float spawnRadius;
    [SerializeField] int nbItems;


    // Start is called before the first frame update
    void Start()
    {
        cursorObject.SetActive(useCursor);
    }

    // Update is called once per frame
    void Update()
    {
        if (useCursor) UpdateCursor();

        
    }

    private void UpdateCursor()
    {
        Vector2 screenPosition = cam.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if(hits.Count >0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            useCursor = false;
            Debug.Log("haah");
            car.SetActive(true);
            car.transform.position = transform.position;
            car.transform.rotation = transform.rotation;

            for(int i = 0; i<nbItems; i++)
            {
                GameObject.Instantiate(itemPrefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), transform.position.y, Random.Range(-spawnRadius, spawnRadius)), transform.rotation);
            }
            //GameObject.Instantiate(objectToPlace, transform.position, transform.rotation);
        }
    }
}
