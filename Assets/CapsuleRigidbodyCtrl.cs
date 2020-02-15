using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleRigidbodyCtrl : MonoBehaviour
{
    public Transform mCenterObj;
    private Rigidbody mRigidboyComponent;


    // Start is called before the first frame update
    void Start()
    {
        mRigidboyComponent = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 crossValue = Vector3.Cross(mCenterObj.up, transform.up).normalized;
        Vector3 northDirect = Vector3.Cross(mCenterObj.up, crossValue).normalized;
        Debug.DrawLine(transform.position, transform.position+northDirect * 10, Color.red);
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * 0.03f);
        transform.Rotate(Vector3.up * horizontal );
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        mRigidboyComponent.AddForceAtPosition(-transform.up * 500, mCenterObj.position,ForceMode.Force);
    }
}
