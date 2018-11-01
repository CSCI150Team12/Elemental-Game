using UnityEngine;
using System.Collections;

public class HingeJointTarget : MonoBehaviour
{

    private HingeJoint hj;
    private Transform target;
    private float maxTwist = 90;
    private float minTwist = -90;
    public bool debug = false;
    public bool ignoreCharacterJointAxis = false;
    public Transform targetGO;
    public Rigidbody connectedBody;
    public float springAmount = 1000;
    [Tooltip("Only use one of these values at a time. Toggle invert if the rotation is backwards.")]
    public bool x, y, z, invert;

    void Start()
    {
        targetGO = GameObject.Find("Wizard").transform;
        target = FindGranchild(targetGO);
        hj = gameObject.AddComponent<HingeJoint>();
        if (connectedBody == null)
        {
            connectedBody = transform.parent.GetComponent<Rigidbody>();
            CharacterJoint cj = GetComponent<CharacterJoint>();
            if (cj)
            {
                connectedBody = cj.connectedBody;
                //maxTwist = -cj.highTwistLimit.limit;
                //minTwist = -cj.lowTwistLimit.limit;
                if (!ignoreCharacterJointAxis)
                {
                    x = cj.axis.x != 0;
                    y = cj.axis.y != 0;
                    z = cj.axis.z != 0;
                }
                Destroy(cj);  
            }
        }
        hj.connectedBody = connectedBody;
        hj.axis = new Vector3(x ? 1 : 0, y ? 1 : 0, z ? 1 : 0);
        hj.useLimits = true;
        hj.useSpring = true;
        hj.limits = new JointLimits
        {
            max = maxTwist,
            min = minTwist
        };
        hj.spring = new JointSpring
        {
            spring = springAmount
        };
    }

    void Update()
    {
        if (hj != null)
        {
            if (x)
            {
                JointSpring js;
                js = hj.spring;
                js.targetPosition = target.transform.localEulerAngles.x;
                if (js.targetPosition > 180)
                    js.targetPosition = js.targetPosition - 360;
                if (invert)
                    js.targetPosition = js.targetPosition * -1;

                js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

                hj.spring = js;
            }
            else if (y)
            {
                JointSpring js;
                js = hj.spring;
                js.targetPosition = target.transform.localEulerAngles.y;
                if (debug)
                {
                    print(target.transform.localEulerAngles);
                }
                if (js.targetPosition > 180)
                    js.targetPosition = js.targetPosition - 360;
                if (invert)
                    js.targetPosition = js.targetPosition * -1;

                js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

                hj.spring = js;
            }
            else if (z)
            {
                JointSpring js;
                js = hj.spring;
                js.targetPosition = target.transform.localEulerAngles.z;
                if (js.targetPosition > 180)
                    js.targetPosition = js.targetPosition - 360;
                if (invert)
                    js.targetPosition = js.targetPosition * -1;

                js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5);

                hj.spring = js;
            }
        }
    }

    Transform FindGranchild(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.name == transform.name)
            {
                return child;
            }
            Transform granchild = FindGranchild(child);
            if (granchild != null)
            {
                return granchild;
            }
            
        }
        return null;
    }
}