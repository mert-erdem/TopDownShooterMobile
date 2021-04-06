using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    //CoreMovement
    Rigidbody fizik;
    float horizontal, vertical; 
    Vector3 horizontalVector, verticalVector, velocityVector
        , horizontalDir=new Vector3(1,0,0), verticalDir=new Vector3(0,0,1);

    [Range(1,10)]
    public int speed = 2; 
    [SerializeField]
    private Camera cam;


    [Range(1, 30)]
    public int mouseSensivity = 20;
    public static Quaternion lookDir;

    //joystick;
    [SerializeField]
    private Joystick joystickLeft, joystickRigth;

    void Start()
    {
        fizik = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CoreMovement();
        CoreRotation();
    }

    private void CoreMovement()
    {
        horizontal = joystickLeft.Horizontal;
        vertical = joystickLeft.Vertical;

        horizontalVector = horizontal * horizontalDir;
        verticalVector = vertical * verticalDir;

        velocityVector = (horizontalVector + verticalVector);

        fizik.velocity = velocityVector * speed;
    }

    private void CoreRotation()
    {
        Vector3 input = joystickRigth.Direction;

        if(joystickRigth.Direction!=Vector2.zero)//to prevent locking player's rotation when joystick's direction become to it's origin
        {
            input.z = input.y;
            input.y = 0;

            lookDir = Quaternion.LookRotation(input);
            transform.rotation = lookDir;
        }
        
    }

    //Game over statement;
    private void OnDestroy()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }

    
}
