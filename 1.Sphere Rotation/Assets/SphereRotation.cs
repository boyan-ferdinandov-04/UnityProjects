using UnityEngine;

public class SphereRotation : MonoBehaviour
{
    public GameObject otherSphere; // The other sphere
    public GameObject pivotPoint; // The pivot point
    public Vector3 rotationAxis = new Vector3(0, 1, 0);
    public float rotationSpeed = 30f; 
    public float collisionDistance = 1f; 

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = RotateAroundPivotMatrix(this.gameObject, pivotPoint.transform.position, rotationAxis, rotationSpeed * Time.deltaTime);

        UpdateSphereTransform(this.gameObject, newPos);
        DetectCollision();
    }

    Vector3 RotateAroundPivotMatrix(GameObject sphere, Vector3 pivot, Vector3 rotationAxis, float angle)
    {
        
        Vector3 currentPosition = sphere.transform.localToWorldMatrix.GetColumn(3);
        Vector3 relativePosition = currentPosition - pivot;

        Quaternion rotation = Quaternion.AngleAxis(angle, rotationAxis);

        Vector3 rotatedPosition = rotation * relativePosition;
        return pivot + rotatedPosition;
    }

    void UpdateSphereTransform(GameObject sphere, Vector3 newPosition)
    {
        Matrix4x4 currentMatrix = sphere.transform.localToWorldMatrix;
        // Creating a new matrix with the updated position
        currentMatrix.SetColumn(3, new Vector4(newPosition.x, newPosition.y, newPosition.z, 1));
        WorkaroundSetMatrix4x4(sphere.transform, currentMatrix);
    }

    void WorkaroundSetMatrix4x4(Transform sphereTransform, Matrix4x4 newMatrix)
    {
        // Modifying the transform based on the new matrix
        sphereTransform.localPosition = newMatrix.GetColumn(3);
        sphereTransform.localScale = new Vector3(newMatrix.GetColumn(0).magnitude, newMatrix.GetColumn(1).magnitude, newMatrix.GetColumn(2).magnitude);
        sphereTransform.localRotation = Quaternion.LookRotation(newMatrix.GetColumn(2), newMatrix.GetColumn(1));
    }

    void DetectCollision()
    {
        // Calculating the distance between this sphere and the other sphere
        float distance = Vector3.Distance(this.transform.position, otherSphere.transform.position);

        if (distance < collisionDistance)
        {
            Debug.Log("Collision Detected!");
        }
    }
}
