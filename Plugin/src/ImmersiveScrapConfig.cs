
using System.Collections.Generic;
using System.Reflection;
using BepInEx.Configuration;

namespace ImmersiveScrap.Configs {
    public class ImmersiveScrapConfig {
        public static ConfigEntry<int> ConfigVanillaSpawnWeight { get; private set; }
        public static ConfigEntry<int> ConfigCustomSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigAlcoholSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigAnvilSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigBaseballSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigBeercanSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigBrickSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigBrokenEngineSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigBucketSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigCanPaintSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigCanteenSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigCarBatterySpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigClampSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigClockSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigFanSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigFancyPaintingSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigFireAxeSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigFireExtingSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigFireHydrantSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigFoodCanSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigGameboySpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigGarbageSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigHammerSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigJerryCanSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigKeyboardSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigLanternSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigLibraryLampSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigPlantSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigPliersSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigPlungerSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigRetroToySpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigScrewdriverSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigSinkSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigSocketSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigSqueakyToySpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigSuitcaseSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigToasterSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigToolboxSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigTophatSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigTrafficConeSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigVentSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigWateringCanSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigWheelSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigWineBottleSpawnWeight { get; private set; }
        public static ConfigEntry<string> ConfigWrenchSpawnWeight { get; private set; }
        public ImmersiveScrapConfig(ConfigFile configFile) {
            ConfigAlcoholSpawnWeight = configFile.Bind("Scrap Options",
                                                "Alcohol | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for alcohol scrap on moons");
            ConfigAnvilSpawnWeight = configFile.Bind("Scrap Options",
                                                "Anvil | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for anvil scrap on moons");
            ConfigBaseballSpawnWeight = configFile.Bind("Scrap Options",
                                                "Baseball | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for baseball scrap on moons");
            ConfigBeercanSpawnWeight = configFile.Bind("Scrap Options",
                                                "Beercan | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for beer can scrap on moons");
            ConfigBrickSpawnWeight = configFile.Bind("Scrap Options",
                                                "Brick | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for brick scrap on moons");
            ConfigCanteenSpawnWeight = configFile.Bind("Scrap Options",
                                                "Canteen | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for canteen scrap on moons");
            ConfigCarBatterySpawnWeight = configFile.Bind("Scrap Options",
                                                "CarBattery | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for car battery scrap on moons");
            ConfigFireAxeSpawnWeight = configFile.Bind("Scrap Options",
                                                "FireAxe | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for fire axe scrap on moons");
            ConfigFireExtingSpawnWeight = configFile.Bind("Scrap Options",
                                                "FireExtinguisher | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for fire extinguisher scrap on moons");
            ConfigFireHydrantSpawnWeight = configFile.Bind("Scrap Options",
                                                "FireHydrant | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for fire hydrant scrap on moons");
            ConfigFoodCanSpawnWeight = configFile.Bind("Scrap Options",
                                                "FoodCan | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for food can scrap on moons");
            ConfigLibraryLampSpawnWeight = configFile.Bind("Scrap Options",
                                                "LibraryLamp | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for library lamp scrap on moons");
            ConfigPlantSpawnWeight = configFile.Bind("Scrap Options",
                                                "Plant | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for plant scrap on moons");
            ConfigPliersSpawnWeight = configFile.Bind("Scrap Options",
                                                "Pliers | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for pliers scrap on moons");
            ConfigPlungerSpawnWeight = configFile.Bind("Scrap Options",
                                                "Plunger | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for plunger scrap on moons");
            ConfigTrafficConeSpawnWeight = configFile.Bind("Scrap Options",
                                                "TrafficCone | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for traffic cone scrap on moons");
            ConfigWateringCanSpawnWeight = configFile.Bind("Scrap Options",
                                                "WateringCan | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for watering can scrap on moons");
            ConfigWrenchSpawnWeight = configFile.Bind("Scrap Options",
                                                "Wrench | SpawnWeight",
                                                "Vanilla:20, Custom:20",
                                                "Configurable Spawn Weight of Scrap for wrench scrap on moons");
            ConfigBrokenEngineSpawnWeight = configFile.Bind("Scrap Options",
                                                            "BrokenEngine | SpawnWeight",
                                                            "Vanilla:20, Custom:20", 
                                                            "Configurable Spawn Weight of Scrap for broken engine scrap on moons");
            ConfigBucketSpawnWeight = configFile.Bind("Scrap Options", 
                                                    "Bucket | SpawnWeight", 
                                                    "Vanilla:20, Custom:20", 
                                                    "Configurable Spawn Weight of Scrap for bucket scrap on moons");
            ConfigCanPaintSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "CanPaint | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for can of paint scrap on moons");
            ConfigClampSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Clamp | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for clamp scrap on moons");
            ConfigClockSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Clock | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for clock scrap on moons");
            ConfigFanSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Fan | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for fan scrap on moons");
            ConfigFancyPaintingSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "FancyPainting | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for fancy painting scrap on moons");
            ConfigGarbageSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Garbage | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for garbage scrap on moons");
            ConfigGameboySpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Gameboy | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for Gameboy scrap on moons");
            ConfigHammerSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Hammer | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for hammer scrap on moons");
            ConfigJerryCanSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "JerryCan | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for jerry can scrap on moons");
            ConfigKeyboardSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Keyboard | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for keyboard scrap on moons");
            ConfigLanternSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Lantern | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for lantern scrap on moons");
            ConfigRetroToySpawnWeight = configFile.Bind("Scrap Options", 
                                                        "RetroToy | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for retro toy scrap on moons");
            ConfigScrewdriverSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Screwdriver | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for screwdriver scrap on moons");
            ConfigSinkSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Sink | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for sink scrap on moons");
            ConfigSocketSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Socket | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for socket scrap on moons");
            ConfigSqueakyToySpawnWeight = configFile.Bind("Scrap Options", 
                                                        "SqueakyToy | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for squeaky toy scrap on moons");
            ConfigSuitcaseSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Suitcase | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for suitcase scrap on moons");
            ConfigToasterSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Toaster | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for toaster scrap on moons");
            ConfigToolboxSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Toolbox | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for toolbox scrap on moons");
            ConfigTophatSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Tophat | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for top hat scrap on moons");
            ConfigVentSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Vent | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for vent scrap on moons");
            ConfigWheelSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "Wheel | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for wheel scrap on moons");
            ConfigWineBottleSpawnWeight = configFile.Bind("Scrap Options", 
                                                        "WineBottle | SpawnWeight", 
                                                        "Vanilla:20, Custom:20", 
                                                        "Configurable Spawn Weight of Scrap for wine bottle scrap on moons");

            ClearUnusedEntries(configFile);
            Plugin.Logger.LogInfo("Setting up config for ImmersiveScrap plugin...");
        }
        private void ClearUnusedEntries(ConfigFile configFile) {
            // Normally, old unused config entries don't get removed, so we do it with this piece of code. Credit to Kittenji.
            PropertyInfo orphanedEntriesProp = configFile.GetType().GetProperty("OrphanedEntries", BindingFlags.NonPublic | BindingFlags.Instance);
            var orphanedEntries = (Dictionary<ConfigDefinition, string>)orphanedEntriesProp.GetValue(configFile, null);
            orphanedEntries.Clear(); // Clear orphaned entries (Unbinded/Abandoned entries)
            configFile.Save(); // Save the config file to save these changes
        }
    }
}