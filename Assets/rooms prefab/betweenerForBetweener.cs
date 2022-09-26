using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betweenerForBetweener : MonoBehaviour
{
    public Vector3 cameraPosition;
    public Vector3 playerPosition;
    public GameObject[] roomsToCreate;
    private GameObject parentRoom;
    private new Camera camera;

    private string betweenerName;
    void Start()
    {
        camera = Camera.main.GetComponent<Camera>();
        parentRoom = GetComponent<GameObject>();
    }
    private void OnCollisionEnter2D(Collision2D betweener)
    {
        if (betweener.gameObject.tag == "Player")
        {
            newRoomCreator();
            betweener.transform.position += playerPosition;
            camera.transform.position += cameraPosition;
            Destroy(transform.parent.gameObject);
        }
    }
    private void newRoomCreator()
    {
        Instantiate(roomsToCreate[Random.Range(0, 3)], new Vector3 (camera.transform.position.x, camera.transform.position.y, 0) + cameraPosition, camera.transform.rotation);
    }
}
