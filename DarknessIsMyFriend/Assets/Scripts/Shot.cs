using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject dragIndicatorObj;
    private Vector3 dragIndicatorOrigPos;
    private Vector3 shotInitPos;

    private Rigidbody rb;

    private Vector3 dragBeginPos;
    private Vector3 dragEndPos;

    private Vector3 dragVec;

    private bool draggingShot = false;

    [SerializeField] private float maxDragDistance = 70.0f;
    [SerializeField] private float maxShotForce = 3000.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dragIndicatorOrigPos = dragIndicatorObj.transform.position;
        shotInitPos = transform.position;
        FreezePosition(true);
    }

    void Update(){
        if(draggingShot){
            CalcDragPower();
            IndicateDragPower();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = shotInitPos;
            rb.velocity = Vector3.zero;
            FreezePosition(true);
        }
    }

    private void CalcDragPower(){
        dragEndPos = Input.mousePosition;
        float xForce = -(dragEndPos.x - dragBeginPos.x);
        float zForce = -(dragEndPos.y - dragBeginPos.y); // Don't question it ~Jannes
        dragVec = new Vector3(xForce, 0, zForce);

        dragVec = Vector3.ClampMagnitude(dragVec, maxDragDistance);

        dragVec = new Vector3(dragVec.x/maxDragDistance, 0, dragVec.z/maxDragDistance);
    }

    private void IndicateDragPower(){
        dragIndicatorObj.transform.position = new Vector3(dragVec.x * 10, 0, dragVec.z * 10);;
    }

    public void BeginDragShot(){
        Debug.Log("Begin Drag");
        dragBeginPos = Input.mousePosition;
        draggingShot = true;
    }

    public void EndDragShot(){
        Debug.Log("End Drag");
        GottaShootMyShot();
        draggingShot = false;
    }

    private void GetDragEndPos(){
    }

    private void GottaShootMyShot(){
        FreezePosition(false);
        dragVec = new Vector3(dragVec.x * maxShotForce, 0, dragVec.z * maxShotForce);
        Debug.Log(dragVec);
        rb.AddForce(dragVec);
        ResetIndicatorPosition();
    }

    private void ResetIndicatorPosition(){
        dragIndicatorObj.transform.position = dragIndicatorOrigPos;
    }

    private void FreezePosition(bool on){
        if(on){
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }else {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}
