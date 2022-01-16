using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistic : MonoBehaviour
{
    public Transform SpawnTransform;
    public Transform TargetTransform;

    public float AngleInDegrees;

    float g = Physics.gravity.y;

    public GameObject bullet;

    public float testAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTransform.localEulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);
        //SpawnTransform.rotation = Quaternion.

        Vector3 fromTo = TargetTransform.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        testAngle = Vector3.Angle(transform.position, TargetTransform.position);



        if(testAngle < 90 && (testAngle + AngleInDegrees) > 90)
        {
            AngleInDegrees = testAngle + (90 - testAngle) / 3;
        }
        else if(testAngle > 90 && (testAngle - AngleInDegrees) < 90)
        {
            AngleInDegrees = 180 - testAngle + (testAngle - 90) / 3;
        }
        else
        {
            AngleInDegrees = 45;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shot(fromTo,fromToXZ);
        }

    }

    public void Shot(Vector3 fromTo, Vector3 fromToXZ)
    {

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float angleInRadians = AngleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        Debug.Log("Znam: " + (y - Mathf.Tan(angleInRadians) * x));
        Debug.Log(v);

        GameObject newBullet = Instantiate(bullet, SpawnTransform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnTransform.forward * v;
        
    }
}
