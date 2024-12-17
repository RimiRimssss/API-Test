using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;
    private LineRenderer lineRenderer;

    void Start()
    {
        // Get the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Set the positions of the line
        lineRenderer.SetPosition(0, objectOne.transform.position);
        lineRenderer.SetPosition(1, objectTwo.transform.position);
        lineRenderer.SetPosition(2, objectThree.transform.position);

        // Check if there's an obstruction between objectOne and objectTwo
        if (Physics.Linecast(objectOne.transform.position, objectTwo.transform.position))
        {
            // Logic for when there's an obstruction
        }
    }
}
