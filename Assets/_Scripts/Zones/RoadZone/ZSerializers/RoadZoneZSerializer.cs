[System.Serializable]
public sealed class RoadZoneZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 ActiveSpots;
    public CarQueue carQueue;
    public ParkingZone parkingZone;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public RoadZoneZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         ActiveSpots = (System.Int32)typeof(Zone).GetField("ActiveSpots").GetValue(instance);
         carQueue = (CarQueue)typeof(RoadZone).GetField("carQueue", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         parkingZone = (ParkingZone)typeof(RoadZone).GetField("parkingZone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(Zone).GetField("ActiveSpots").SetValue(component, ActiveSpots);
         typeof(RoadZone).GetField("carQueue", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, carQueue);
         typeof(RoadZone).GetField("parkingZone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, parkingZone);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}