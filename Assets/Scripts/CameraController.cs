using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //Keeps the camera at a maximum distance from the player, always looking down at the same angle
        //And only ever moving forward on the track, never back
        if((transform.position.z - player.transform.position.z) < offset.z)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            Vector3 newPos = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, transform.position.z);
            transform.position = newPos;
        }
    }
}