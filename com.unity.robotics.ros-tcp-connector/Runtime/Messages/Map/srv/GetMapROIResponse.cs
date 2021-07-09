//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Map
{
    [Serializable]
    public class GetMapROIResponse : Message
    {
        public const string k_RosMessageName = "map_msgs/GetMapROI";

        public Nav.OccupancyGridMsg sub_map;

        public GetMapROIResponse()
        {
            this.sub_map = new Nav.OccupancyGridMsg();
        }

        public GetMapROIResponse(Nav.OccupancyGridMsg sub_map)
        {
            this.sub_map = sub_map;
        }

        public static GetMapROIResponse Deserialize(MessageDeserializer deserializer) => new GetMapROIResponse(deserializer);

        private GetMapROIResponse(MessageDeserializer deserializer)
        {
            this.sub_map = Nav.OccupancyGridMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.sub_map);
        }

        public override string ToString()
        {
            return "GetMapROIResponse: " +
            "\nsub_map: " + sub_map.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
