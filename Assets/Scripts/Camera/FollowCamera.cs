using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float movementSpeed;

    private void LateUpdate()
    {
        Vector3 desiredPosition = objectToFollow.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, movementSpeed * Time.deltaTime);
    }

    public void ChangeTarget(GameObject newTarget)
    {
        objectToFollow = newTarget;
    }
}