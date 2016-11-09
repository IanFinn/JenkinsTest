using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
using System.Collections.Generic;

public class BuildEditor

{

    static string[] sceneName = FindEnabledEditorScenes();
    [MenuItem("Build/window(x86)")]
    static void PreformWindowx86Build()
    {
        string targetDir = "Build/Window(x86)/" + PlayerSettings.productName + ".exe";
        GenericBuild(targetDir, BuildTarget.StandaloneWindows, BuildOptions.None);
    }
    static void GenericBuild(string targerDir, BuildTarget buildTarget,
                                        BuildOptions buildOptions)
    {
        //swith the platfrom to target plafrom
        EditorUserBuildSettings.SwitchActiveBuildTarget(buildTarget);
        //preform the build
       string result =  BuildPipeline.BuildPlayer(sceneName, targerDir, buildTarget, buildOptions);
        if (result.Length > 0)
        {
            //sotre error message
            string error = "Build Falilure: " + result;
            //print error to tuniy
            Debug.LogError(error);
            //print errot to console
            System.Console.WriteLine(error);
        }
    }
    static string[] FindEnabledEditorScenes()
    {
        List<string> editorScenes = new List<string>();
        //loop trhough all the scenes in the build settings
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            //check if the current scene is enable
            if (scene.enabled)
            {
                //add it to the list
                editorScenes.Add(scene.path);
            }
        }

        return editorScenes.ToArray();
    }

}
#endif
