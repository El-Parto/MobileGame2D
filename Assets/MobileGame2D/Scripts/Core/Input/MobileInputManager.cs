using UnityEngine;

namespace NullFrameworkException.Mobile.InputHandling
{
    public class MobileInputManager : MonoSingleton<MobileInputManager>
    {
        public JoystickInputHandler joystick;
        public SwipeInputHandler swiping;
        //public GyroInputHandler gyroscope;

        /// <summary> Attempt to get the data about the gyroscope this frame </summary>
        //public static GyroInputHandler.GyroscopeState GetGyroscopeState() 
         //   => Instance.gyroscope != null ? Instance.gyroscope.gyroscopeState : new GyroInputHandler.GyroscopeState();
        
        /// <summary> Attempt to get the axis of the joystick attached to the system. </summary>
        public static Vector2 GetJoystickAxis() => Instance.joystick != null ? Instance.joystick.Axis : Vector2.zero;

        // Start is called before the first frame update
        private void Start()
        {
            RunnableUtils.Setup(ref joystick, gameObject, true, this);
            RunnableUtils.Setup(ref swiping, gameObject, true);
            //RunnableUtils.Setup(ref gyroscope, gameObject, true);
        }

        // Update is called once per frame
        private void Update()
        {
            RunnableUtils.Run(ref joystick, gameObject, true);
            RunnableUtils.Run(ref swiping, gameObject, true);
            //RunnableUtils.Run(ref gyroscope, gameObject, true);
        }
    }
}