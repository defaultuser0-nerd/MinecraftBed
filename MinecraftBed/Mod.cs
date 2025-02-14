using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;

namespace MinecraftBed
{
	[BepInPlugin(ModInfo.GUID, ModInfo.Name, ModInfo.Version)]
	public class MinecraftBed : BaseUnityPlugin
	{
        public static AssetBundle bundle;
        public static GameObject bed;
        public static string parentName = "bed";
        public void Start()
	{
            GorillaTagger.OnPlayerSpawned(init);
	}
 
	void init()
	{
            bundle = LoadAssetBundle("MinecraftBed.bed");
            bed = Instantiate(bundle.LoadAsset<GameObject>(parentName));

            var stumpbed = bed.transform.GetChild(0);
            stumpbed.SetParent(GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").transform);
            stumpbed.position = new Vector3(-68.675f, 11.169f, -83.747f); 

            var virtualbed = bed.transform.GetChild(0);
            virtualbed.SetParent(GameObject.Find("Environment Objects/LocalObjects_Prefab/VirtualStump_CustomMapLobby").transform);
            virtualbed.position = new Vector3(0.0711f, -11.304f, -1.9899f);
            virtualbed.rotation = Quaternion.Euler(0f, 269.8199f, 0f);
            virtualbed.localScale = new Vector3(0.5401f, 0.5074f, 0.5401f);
        }
	
        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
