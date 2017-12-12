# AndroidUnityBuildAutomation
A Unity Editor script that streamlines android builds on unity. Can also be used with Jenkins Server

You have to set up the variables below, residing at the top of the script

```
//appplication name 
static string APP_NAME = "";
//the path that your build is to reside
>static string BUILD_PATH = "";
//Enviroment variable that points to the android SDK
static string ANDROID_SDK = "";
//the path to the keystore in order to sign the .apk
static string KEYSTORE_PATH = "";
//password for the KEYSTORE
static string KEYSTORE_PASS = "";
//the alias of the key 
static string KEY_ALIAS = "";
//and its password
static string KEY_ALIAS_PASS = "";
```
You will have a "Quality Of Life"/Build/Android on your browser menus that you can click for a quick android build. 

# Jenkins + Unity3d Plugin 
It seems to me that you need a Unity Pro seat in order to properly use this feature. Didnt manage to get it working on a non-free build yet. 
On the Unity3d Plugin you provide the following command line arguments:
```
>-batchmode -quiet -nographics -executeMethod AutoBuild.BuildAndroidDevelopemnt (-logfile "PATH/TO/LOG/FIlE")

```
