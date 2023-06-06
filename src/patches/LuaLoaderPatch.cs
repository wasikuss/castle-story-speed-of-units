using System.IO;
using Brix.Lua;
using HarmonyLib;
using MoonSharp.Interpreter;
using UnityEngine;

namespace CastleStory_SpeedOfUnits
{
    [HarmonyPatch(typeof(LuaLoader), nameof(LuaLoader.LoadUserKeyBindingLuaFile))]
    public class LuaLoaderPatch
    { 
        static FileSystemWatcher watcher;
        static void Prefix()
        {
            LoadSpeedOfUnitsConfig();

            watcher = new FileSystemWatcher("Info/Lua/modconf");
            watcher.Filter = "speed_of_units.lua";
            watcher.Changed += (object sender, FileSystemEventArgs e) => {
                Debug.Log("Reloading speed up units config.");
                LoadSpeedOfUnitsConfig();
            };
            watcher.EnableRaisingEvents = true;
        }

        static void LoadSpeedOfUnitsConfig() {
            Script script;
			DynValue result = LuaLoader.Load(out script, "modconf/speed_of_units.lua");
            SpeedOfUnits.Instance.Start(Config.Config.Parse(result.Table));
            Script.Kill(ref script);
        }
    }
}
