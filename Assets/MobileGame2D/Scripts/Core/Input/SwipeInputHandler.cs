using System.Collections.Generic;

using UnityEngine;

namespace NullFrameworkException.Mobile.InputHandling
{
	public class SwipeInputHandler : RunnableBehaviour
	{
		/// <summary>
		/// Contains all the information about this specific swipe, such as points along the swipe
		/// </summary>
		public class Swipe
		{
			/// <summary>
			/// The list of points along the swipe, added to each frame.
			/// </summary>
			public readonly List<Vector2> positions = new List<Vector2>();
			/// <summary>
			/// The position the swipe started from.
			/// </summary>
			public readonly Vector2 initialPosition;
			/// <summary>
			/// The finger id associated with this swipe.
			/// </summary>
			public readonly int fingerId;

			public Swipe(Vector2 _initialPosition, int _fingerId)
			{
				initialPosition = _initialPosition;
				fingerId = _fingerId;
				positions.Add(_initialPosition);
			}
		}

		/// <summary>
		/// The count of how many swipes are in progress.
		/// </summary>
		public int SwipeCount => swipes.Count;

		// Contains all the swipes currently being processed, each key is the corresponding fingerId
		private Dictionary<int, Swipe> swipes = new Dictionary<int, Swipe>();

		/// <summary>
		/// Attempts to retrieve the relevant swipe information relating to the passed ID.
		/// </summary>
		/// <param name="_index">The fingerID we are attempting to get the swipe for.</param>
		/// <returns>The corresponding swipe if it exists, otherwise null.</returns>
		public Swipe GetSwipe(int _index)
		{
			swipes.TryGetValue(_index, out Swipe swipe);
			return swipe;
		}

		protected override void OnSetup(params object[] _params) { }

		protected override void OnRun(params object[] _params)
		{
			if(Input.touchCount > 0)
			{
				// Loop through all touches being processed by Unity
				foreach(Touch touch in Input.touches)
				{
					if(touch.phase == TouchPhase.Began)
					{
						// This is the first frame this touch is detected, so put it in the dictionary
						// as a swipe
						swipes.Add(touch.fingerId, new Swipe(touch.position, touch.fingerId));
					}
					else if(touch.phase == TouchPhase.Moved && swipes.TryGetValue(touch.fingerId, out Swipe swipe))
					{
						// This touch moved so add the position to the swipe
						swipe.positions.Add(touch.position);
					}
					else if((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && swipes.TryGetValue(touch.fingerId, out swipe))
					{
						// The swipe has ended so remove it from the dictionary
						swipes.Remove(swipe.fingerId);
					}
				}
			}
		}
	}
}