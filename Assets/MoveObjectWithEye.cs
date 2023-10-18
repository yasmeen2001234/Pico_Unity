using Tobii.G2OM;
using UnityEngine;

public class MoveObjectWithGaze : MonoBehaviour
{
    public float movementSpeed = 2f;

    private Transform _objectToMove;

    private void Start()
    {
        _objectToMove = transform;
    }
    /*
    private void Update()
    {
        // Check if the object has gaze focus using Tobii G2OM.
        if (G2OM_FocusHandler.HasFocus(this))
        {
            // Move the object based on gaze data.
            Vector3 newPosition = _objectToMove.position;
            newPosition.x += G2OM_FocusHandler.FocusedObject.PositionOnGazePoint.x * movementSpeed * Time.deltaTime;
            _objectToMove.position = newPosition;
        }
    }

    public void G2OM_OnGazeFocusChanged(bool hasFocus)
    {
        // This method is called when the object receives or loses gaze focus.
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        throw new System.NotImplementedException();
    }
    */
}
