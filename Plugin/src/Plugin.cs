using System.Reflection;
using UnityEngine;
using BepInEx;
using BepInEx.Logging;
using ImmersiveScrap.Configs;
using ImmersiveScrap.Keybinds;
using LethalLevelLoader;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ImmersiveScrap;
[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency(LethalLib.Plugin.ModGUID)] 
[BepInDependency("com.rune580.LethalCompanyInputUtils", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency(LethalLevelLoader.Plugin.ModGUID, BepInDependency.DependencyFlags.HardDependency)]
public class Plugin : BaseUnityPlugin {
    internal static new ManualLogSource Logger;
    public static GameObject explosionPrefab;
    public static ImmersiveScrapConfig ModConfig { get; private set; } // prevent from accidently overriding the config
    internal static IngameKeybinds InputActionsInstance;

    private void Awake() {
        Logger = base.Logger;
        // This should be ran before Network Prefabs are registered.
        // Register Keybinds
        InputActionsInstance = new IngameKeybinds();
        ModConfig = new ImmersiveScrapConfig(this.Config); // Create the config with the file from here.
        AssetBundleLoader.AddOnExtendedModLoadedListener(OnExtendedModRegistered, "XuXiaolan");
        AssetBundleLoader.AddOnLethalBundleLoadedListener(OnLethalBundleLoaded, "immersivescrapassets.lethalbundle");

        InitializeNetworkBehaviours();
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
    internal static void OnExtendedModRegistered(ExtendedMod extendedMod) {
        if (extendedMod == null) return;

        foreach (ExtendedItem item in extendedMod.ExtendedItems) {
            // This assumes the config values are appropriately initialized in ImmersiveScrapConfig.
            string configValue = GetConfigValueForItem(item.Item.itemName);
            if (string.IsNullOrEmpty(configValue)) continue;
            List<StringWithRarity> planetNames = ConfigParsing(configValue);
            item.LevelMatchingProperties.levelTags.AddRange(planetNames);
            Logger.LogInfo($"Updated matching properties for {item.Item}.");
        }
    }
    internal static void OnLethalBundleLoaded(AssetBundle assetBundle) {
        if (assetBundle == null) return;
    }
    private static string GetConfigValueForItem(string itemName) {
        switch (itemName) {
            case "Alcohol Flask":
                return ImmersiveScrapConfig.ConfigAlcoholSpawnWeight.Value;
            case "Anvil":
                return ImmersiveScrapConfig.ConfigAnvilSpawnWeight.Value;
            case "Baseball bat":
                return ImmersiveScrapConfig.ConfigBaseballSpawnWeight.Value;
            case "Beer can":
                return ImmersiveScrapConfig.ConfigBeercanSpawnWeight.Value;
            case "Brick":
                return ImmersiveScrapConfig.ConfigBrickSpawnWeight.Value;
            case "Broken engine":
                return ImmersiveScrapConfig.ConfigBrokenEngineSpawnWeight.Value;
            case "Bucket":
                return ImmersiveScrapConfig.ConfigBucketSpawnWeight.Value;
            case "Can paint":
                return ImmersiveScrapConfig.ConfigCanPaintSpawnWeight.Value;
            case "Canteen":
                return ImmersiveScrapConfig.ConfigCanteenSpawnWeight.Value;
            case "Car battery":
                return ImmersiveScrapConfig.ConfigCarBatterySpawnWeight.Value;
            case "Clamp":
                return ImmersiveScrapConfig.ConfigClampSpawnWeight.Value;
            case "Clock":
                return ImmersiveScrapConfig.ConfigClockSpawnWeight.Value;
            case "Fan":
                return ImmersiveScrapConfig.ConfigFanSpawnWeight.Value;
            case "Fancy Painting":
                return ImmersiveScrapConfig.ConfigFancyPaintingSpawnWeight.Value;
            case "Fireaxe":
                return ImmersiveScrapConfig.ConfigFireAxeSpawnWeight.Value;
            case "Fire extinguisher":
                return ImmersiveScrapConfig.ConfigFireExtingSpawnWeight.Value;
            case "Fire hydrant":
                return ImmersiveScrapConfig.ConfigFireHydrantSpawnWeight.Value;
            case "Food can":
                return ImmersiveScrapConfig.ConfigFoodCanSpawnWeight.Value;
            case "Gameboy":
                return ImmersiveScrapConfig.ConfigGameboySpawnWeight.Value;
            case "Garbage":
                return ImmersiveScrapConfig.ConfigGarbageSpawnWeight.Value;
            case "Hammer":
                return ImmersiveScrapConfig.ConfigHammerSpawnWeight.Value;
            case "Jerrycan":
                return ImmersiveScrapConfig.ConfigJerryCanSpawnWeight.Value;
            case "Keyboard":
                return ImmersiveScrapConfig.ConfigKeyboardSpawnWeight.Value;
            case "Lantern":
                return ImmersiveScrapConfig.ConfigLanternSpawnWeight.Value;
            case "Library lamp":
                return ImmersiveScrapConfig.ConfigLibraryLampSpawnWeight.Value;
            case "Plant":
                return ImmersiveScrapConfig.ConfigPlantSpawnWeight.Value;
            case "Pliers":
                return ImmersiveScrapConfig.ConfigPliersSpawnWeight.Value;
            case "Plunger":
                return ImmersiveScrapConfig.ConfigPlungerSpawnWeight.Value;
            case "Retro Toy":
                return ImmersiveScrapConfig.ConfigRetroToySpawnWeight.Value;
            case "Screwdriver":
                return ImmersiveScrapConfig.ConfigScrewdriverSpawnWeight.Value;
            case "Sink":
                return ImmersiveScrapConfig.ConfigSinkSpawnWeight.Value;
            case "Socket Wrench":
                return ImmersiveScrapConfig.ConfigSocketSpawnWeight.Value;
            case "Squeaky toy":
                return ImmersiveScrapConfig.ConfigSqueakyToySpawnWeight.Value;
            case "Suitcase":
                return ImmersiveScrapConfig.ConfigSuitcaseSpawnWeight.Value;
            case "Toaster":
                return ImmersiveScrapConfig.ConfigToasterSpawnWeight.Value;
            case "Toolbox":
                return ImmersiveScrapConfig.ConfigToolboxSpawnWeight.Value;
            case "Top hat":
                return ImmersiveScrapConfig.ConfigTophatSpawnWeight.Value;
            case "Traffic cone":
                return ImmersiveScrapConfig.ConfigTrafficConeSpawnWeight.Value;
            case "Vent":
                return ImmersiveScrapConfig.ConfigVentSpawnWeight.Value;
            case "Watering Can":
                return ImmersiveScrapConfig.ConfigWateringCanSpawnWeight.Value;
            case "Wheel":
                return ImmersiveScrapConfig.ConfigWheelSpawnWeight.Value;
            case "Wine bottle":
                return ImmersiveScrapConfig.ConfigWineBottleSpawnWeight.Value;
            case "Wrench":
                return ImmersiveScrapConfig.ConfigWrenchSpawnWeight.Value;
            default:
                Logger.LogInfo($"No configuration found for item type: {itemName}");
                return null;
        }
    }
    private static List<StringWithRarity> ConfigParsing(string configMoonRarity) {
        List<StringWithRarity> spawnRates = new List<StringWithRarity>();

        foreach (string entry in configMoonRarity.Split(ConfigHelper.indexSeperator).Select(s => s.Trim())) {
            string[] entryParts = entry.Split(ConfigHelper.keyPairSeperator);
            if (entryParts.Length != 2) {
                continue;
            }

            string name = entryParts[0];
            if (int.TryParse(entryParts[1], out int spawnrate)) {
                spawnRates.Add(new StringWithRarity(name, spawnrate));
                Plugin.Logger.LogInfo($"Registered spawn rate for {name} to {spawnrate}");
            }
        }
        return spawnRates;
    }
    private void InitializeNetworkBehaviours() {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (var type in types)
        {
            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                if (attributes.Length > 0)
                {
                    method.Invoke(null, null);
                }
            }
        }
    }
}