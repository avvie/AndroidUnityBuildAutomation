using UnityEditor;
using System.Collections.Generic;
using System;
using UnityEngine;

class AutoBuild {
        static string[] SCENES = FindEnabledEditorScenes();
 
        static string APP_NAME = "";
        static string BUILD_PATH = "";
        static string ANDROID_SDK = "";
        static string KEYSTORE_PATH = "";
        static string KEYSTORE_PASS = "";
        static string KEY_ALIAS = "";
        static string KEY_ALIAS_PASS = "";
        static string TARGET_DIR = BUILD_PATH+ APP_NAME + "\\";
		
        [MenuItem("Quality Of Life/Build/ Android")]
        public static void BuildAndroidDevelopemnt(){
            PlayerSettings.Android.keystoreName = KEYSTORE_PATH;
            PlayerSettings.Android.keystorePass = KEYSTORE_PASS;
            PlayerSettings.Android.keyaliasName = KEY_ALIAS;
            PlayerSettings.Android.keyaliasPass = KEY_ALIAS_PASS;
   
            EditorPrefs.SetString("AndroidSdkRoot", Environment.GetEnvironmentVariable(ANDROID_SDK));

            PlayerSettings.Android.bundleVersionCode = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; 

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = SCENES;
            buildPlayerOptions.locationPathName = TARGET_DIR + "AndroidBuild";
            buildPlayerOptions.target = BuildTarget.Android;
            buildPlayerOptions.options = BuildOptions.AllowDebugging;
            Debug.Log(BuildPipeline.BuildPlayer(buildPlayerOptions));
        }
        private static string[] FindEnabledEditorScenes() {
            List<string> EditorScenes = new List<string>();
            foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
                if (!scene.enabled) continue;
                EditorScenes.Add(scene.path);
            }
            return EditorScenes.ToArray();
        }
 
        static void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
        {
                EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
                string res = BuildPipeline.BuildPlayer(scenes,target_dir,build_target,build_options);
                if (res.Length > 0) {
                        throw new Exception("BuildPlayer failure: " + res);
                }
        }
}