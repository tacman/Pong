using UnityEditor;
using UnityEngine;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

// Output the build size or a failure depending on BuildPlayer.

namespace Editor
{
    public class BuildScript : MonoBehaviour
    {
        [MenuItem("Build/Build WebGL")]
        public static void BuildWebGL()
        {
            Debug.Log("Starting build...");
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
            buildPlayerOptions.locationPathName = "Builds/newBuild";
            buildPlayerOptions.target = BuildTarget.WebGL;
            buildPlayerOptions.options = BuildOptions.None;
            Debug.Log(JsonUtility.ToJson(buildPlayerOptions.target));
            return;

            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;
            
            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            }
            
            if (summary.result == BuildResult.Failed)
            {
                Debug.Log("Build failed " + JsonUtility.ToJson(summary));
            }
        }
    }    
}
