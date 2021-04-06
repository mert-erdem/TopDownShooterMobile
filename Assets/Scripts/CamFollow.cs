using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerT;
    private Vector3 lookDir; Vector3 newPos;
    private float smoothness=0.1f;

    void Start()
    {
        lookDir = transform.position - playerT.position;
    }

    void FixedUpdate()
    {
        if(playerT!=null)
        {
            newPos = playerT.position + lookDir;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
        }       
    }
}
