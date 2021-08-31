using UnityEngine;

namespace NullFrameworkException
{
    public sealed class SceneFieldAttribute : PropertyAttribute
    {
        /// <summary> Converts a full filepath to a SceneManager friendly one for scene loading. </summary>
        /// <param name="_path">The full file path to be converted.</param>
        public static string LoadableName(string _path)
        {
            // The pieces of the path we are looking to ignore
            string start = "Assets/";
            string end = ".unity";
            
            // Test if the path contains 'start' data, if so, remove it
            if(_path.StartsWith(start))
                _path = _path.Substring(start.Length);
            
            // Test if the path contains 'end' data, if so, remove it
            if(_path.EndsWith(end))
                // ReSharper disable once StringLastIndexOfIsCultureSpecific.1
                _path = _path.Substring(0, _path.LastIndexOf(end));

            // Return the newly edited path
            return _path;
        }

        /// <summary> Takes a local folder path and converts it into an asset path. </summary>
        /// <param name="_path"> The local path. </param>
        public static string ToAssetPath(string _path) => $"Assets/{_path}.unity";
    }
}