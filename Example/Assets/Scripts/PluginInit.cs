using System.Linq;
using UnityEngine;
 
public class GetAndroidPluginData : MonoBehaviour
{
    private string path;
    private string getUrl;
    private string brandDevice;
    private string simDevice;

    public void Start()
    {
        
        if(path == null)
        {
            LoadFire();
        }
        //else
        //{
        ////return path;
        //}
    }

    public void ReturnSIMSerialNumber()
    {
        AndroidJavaClass jcUnityPlayer =
          new AndroidJavaClass( "com.unity3d.player.UnityPlayer" );
    
        AndroidJavaObject joUnityActivity =
          jcUnityPlayer.GetStatic<AndroidJavaObject>( "currentActivity" );
    
        AndroidJavaObject joAndroidPluginAccess =
          new AndroidJavaObject( "com.Test.myandroidplugin.AndroidPluginAccess" );
    
        simDevice = joAndroidPluginAccess.Call<string>( "ReturnSIMSerialNumber", joUnityActivity );
    }

    public void LoadFire()
    {
        getUrl = "0";
        if( getUrl == null || SystemInfo.deviceModel.Contains("google") || simDevice == null)
        {
            
        }
        else
        {

        }
    }
}