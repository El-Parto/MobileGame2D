using System;

using UnityEngine;

namespace NullFrameworkException
{
    public static class RunnableUtils
    {
        /// <summary>
        /// Attempts to retrieve the runnable behaviour from the passed gameObject or its children.
        /// </summary>
        /// <param name="_runnable">The reference the runnable will be set to.</param>
        /// <param name="_optional">Whether or not the runnable is optional</param>
        /// <param name="_from">The gameObject we are attempting to get a runnable from.</param>
        public static bool Validate<TRunnable>(ref TRunnable _runnable, GameObject _from, bool _optional) 
            where TRunnable : IRunnable
        {
            // If the passed Runnable is already set, return true
            if(_runnable != null)
            {
                return true;
            }
            
            // If the passed runnable isn't set, attempt to get it from the passed GameObject
            if(_runnable == null)
            {
                _runnable = _from.GetComponent<TRunnable>();

                // We successfully retrieved the component, so return true
                if(_runnable != null)
                {
                    return true;
                }
            }
            
            // If the passed runnable isn't set, attempt to get it from the passed GameObject's children
            if(_runnable == null)
            {
                _runnable = _from.GetComponentInChildren<TRunnable>();

                // We successfully retrieved the component, so return true
                if(_runnable != null)
                {
                    return true;
                }
            }

            if(!_optional)
            {
                // The second parameter of Unity's debug.log is the object associated with the LogMessage
                Debug.LogException(new NullReferenceException($"Component {typeof(TRunnable).Name} is not present in the hierarchy of gameObject {_from.name}."), _from);
            }

            return false;
        }

        /// <summary>
        /// Attempts to validate then setup the IRunnable, returning whether or not it succeeded.
        /// </summary>
        /// <param name="_runnable">The runnable being setup.</param>
        /// <param name="_from">The gameObject the runnable is attached to.</param>
        /// <param name="_optional">Whether or not the runnable is optional</param>
        /// <param name="_params">Any additional information the Runnable's setup function needs.</param>
        public static bool Setup<TRunnable>(ref TRunnable _runnable, GameObject _from, bool _optional, params object[] _params)
            where TRunnable : IRunnable
        {
            // Validate the component, if we can, set it up and return true
            if(Validate(ref _runnable, _from, _optional))
            {
                _runnable.Setup(_params);
                return true;
            }

            // We failed to validate the component, so return false
            return false;
        }

        /// <summary>
        /// Attempts to validate the runnable and if successful, run it using the information provided.
        /// </summary>
        /// <param name="_runnable">The runnable being run.</param>
        /// <param name="_from">The gameObject the runnable is attached to.</param>
        /// <param name="_optional">Whether or not the runnable is optional</param>
        /// <param name="_params">Any additional information the Runnable's run function needs.</param>
        public static void Run<TRunnable>(ref TRunnable _runnable, GameObject _from, bool _optional, params object[] _params) 
            where TRunnable : IRunnable
        {
            // Validate the component in case we didn't do it earlier
            if(Validate(ref _runnable, _from, _optional))
            {
                _runnable.Run(_params);
            }
        }
    }
}