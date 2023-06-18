[System.Serializable]
public sealed class CounterZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Single orderTime;
    public System.Single probDoubleMoney;
    public System.Single initalProbDoubleMoney;
    public System.Int32 visualIndex;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public CounterZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         orderTime = (System.Single)typeof(Counter).GetField("orderTime", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         probDoubleMoney = (System.Single)typeof(Counter).GetField("probDoubleMoney", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         initalProbDoubleMoney = (System.Single)typeof(Counter).GetField("initalProbDoubleMoney", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         visualIndex = (System.Int32)typeof(QueueFlow).GetField("visualIndex", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(Counter).GetField("orderTime", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, orderTime);
         typeof(Counter).GetField("probDoubleMoney", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, probDoubleMoney);
         typeof(Counter).GetField("initalProbDoubleMoney", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, initalProbDoubleMoney);
         typeof(QueueFlow).GetField("visualIndex", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, visualIndex);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}