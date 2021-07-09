//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.MoveBase
{
    [Serializable]
    public class MoveBaseResult : Message
    {
        public const string k_RosMessageName = "move_base_msgs/MoveBase";


        public MoveBaseResult()
        {
        }
        public static MoveBaseResult Deserialize(MessageDeserializer deserializer) => new MoveBaseResult(deserializer);

        private MoveBaseResult(MessageDeserializer deserializer)
        {
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
        }

        public override string ToString()
        {
            return "MoveBaseResult: ";
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
