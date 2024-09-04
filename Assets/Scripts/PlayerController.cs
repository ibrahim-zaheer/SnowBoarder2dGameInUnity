using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount  = 1f;
    Rigidbody2D rgb2d;
    SurfaceEffector2D surfaceEffector;

    bool canMove = true;

    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            rotationController();
            Booster();
        }
     
    }

    public void DisableControls()
    {
        canMove = false;
    }

void  Booster()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            surfaceEffector.speed = boostSpeed;
        }
        else
        {
            surfaceEffector.speed = baseSpeed;
        }
    }

    void rotationController()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgb2d.AddTorque(torqueAmount);
        }
        else
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rgb2d.AddTorque(-torqueAmount);
        }
    }
}
