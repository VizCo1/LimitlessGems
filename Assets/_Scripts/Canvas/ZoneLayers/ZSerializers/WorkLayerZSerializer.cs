[System.Serializable]
public sealed class WorkLayerZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 mUpgradeTarget;
    public System.String unlockCost;
    public System.String majorUpgradeCost;
    public System.Int32 requiredSpots;
    public System.Boolean canMajorUpgrade;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public WorkLayerZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         mUpgradeTarget = (System.Int32)typeof(SpecialZoneLayer).GetField("mUpgradeTarget").GetValue(instance);
         unlockCost = (System.String)typeof(SpecialZoneLayer).GetField("unlockCost", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         majorUpgradeCost = (System.String)typeof(SpecialZoneLayer).GetField("majorUpgradeCost", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         requiredSpots = (System.Int32)typeof(SpecialZoneLayer).GetField("requiredSpots", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         canMajorUpgrade = (System.Boolean)typeof(SpecialZoneLayer).GetField("canMajorUpgrade", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(SpecialZoneLayer).GetField("mUpgradeTarget").SetValue(component, mUpgradeTarget);
         typeof(SpecialZoneLayer).GetField("unlockCost", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, unlockCost);
         typeof(SpecialZoneLayer).GetField("majorUpgradeCost", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, majorUpgradeCost);
         typeof(SpecialZoneLayer).GetField("requiredSpots", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, requiredSpots);
         typeof(SpecialZoneLayer).GetField("canMajorUpgrade", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, canMajorUpgrade);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}