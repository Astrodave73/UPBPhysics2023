using UnityEngine;

public class CatapultController: MonoBehaviour
{
    public float catapultForce = 10f; // Adjust the force as needed
    public Transform releasePoint;    // The point where the object will be released

    private SpringJoint springJoint;

    private void Start()
    {
        // Get the SpringJoint component
        springJoint = GetComponent<SpringJoint>();
        // Disable the SpringJoint initially
        springJoint.spring = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Change the key as needed
        {
            // Enable the SpringJoint and apply the force
            springJoint.spring = catapultForce;
            springJoint.connectedAnchor = releasePoint.localPosition;
        }
    }
}