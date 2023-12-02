using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class Builder
{
    public static void Build()
    {
        var args = System.Environment.GetCommandLineArgs();
        for(var i=0;i<args.Length;i++)
        {
            Debug.Log($"{i}:{args[i]}");
        }

        var option = new BuildPlayerOptions();
        option.target = BuildTarget.StandaloneWindows64;
        //ビルドシーンのパスを配列で指定
        option.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        //ビルドプラットフォーム名のフォルダに入れないと上手くいかない
        option.locationPathName = "build/StandaloneWindows64/Sample.exe";
        var result = BuildPipeline.BuildPlayer(option);
        if (result.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("BUILD SUCCEED");
            Debug.Log(result.summary.outputPath);
            Debug.Log($"{result.summary.totalSize:N}bytes");
            Debug.Log($"{result.summary.totalTime.TotalSeconds}seconds");
        }
        else
        {
            Debug.LogError("BUILD FAILED");
        }

        EditorApplication.Exit(result.summary.result == BuildResult.Succeeded ? 0 : 1);
    }
}
