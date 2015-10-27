using UnityEngine;
using System.Collections;

namespace Control
{
	public interface IClickable
	{
		void OnSelected();
		void OnReleased();
	}

	public class Manager : MonoBehaviour {
		public float _perspectiveZoomSpeed = 0.1f;        // The rate of change of the field of view in perspective mode.
		public float _orthoZoomSpeed = 0.1f;        // The rate of change of the orthographic size in orthographic mode.
		public IClickable _touched { get; private set; }
		
		void Update()
		{
			// If there are two touches on the device...
			// Pinch to zoom
			if (Input.touchCount == 2) {
				// Store both touches.
				Touch touchZero = Input.GetTouch (0);
				Touch touchOne = Input.GetTouch (1);
				
				// Find the position in the previous frame of each touch.
				Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
				Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
				
				// Find the magnitude of the vector (the distance) between the touches in each frame.
				float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
				
				// Find the difference in the distances between each frame.
				float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
				// If the camera is orthographic...
				if (Camera.main.orthographic) {
					// ... change the orthographic size based on the change in distance between the touches.
					Camera.main.orthographicSize += deltaMagnitudeDiff * _orthoZoomSpeed;
					
					// Make sure the orthographic size never drops below zero.
					Camera.main.orthographicSize = Mathf.Max (GetComponent<Camera> ().orthographicSize, 5f);
				} else {
					// Otherwise change the field of view based on the change in distance between the touches.
					Camera.main.fieldOfView += deltaMagnitudeDiff * _perspectiveZoomSpeed;
					
					// Clamp the field of view to make sure it's between 0 and 180.
					Camera.main.fieldOfView = Mathf.Clamp (Camera.main.fieldOfView, 5f, 150f);
				}
			}
			else if (Input.touchCount == 1)
			{
				// Object Select Touch
				Touch touchZero = Input.GetTouch(0);
				Vector2 pos = touchZero.position;
				
				if (touchZero.phase == TouchPhase.Ended)
				{
					if (_touched != null)
					{
						_touched.OnReleased();
					}
					Ray ray = Camera.main.ScreenPointToRay (pos);
					RaycastHit hit = new RaycastHit(); 
					if(Physics.Raycast(ray, out hit)){
						_touched = hit.collider.GetComponent(typeof(IClickable)) as IClickable;
						if (_touched != null)
						{
							_touched.OnSelected();
						}
					}
				}
			}
		}
	}

}

