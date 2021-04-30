﻿using RosMessageTypes.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerPoseWithCovarianceStamped : BasicVisualizer<MPoseWithCovarianceStamped>
{
    [SerializeField]
    float m_Size = 0.1f;
    [SerializeField]
    [Tooltip("If ticked, draw the axis lines for Unity coordinates. Otherwise, draw the axis lines for ROS coordinates (FLU).")]
    bool m_DrawUnityAxes;

    public override void Draw(BasicDrawing drawing, MPoseWithCovarianceStamped message, MessageMetadata meta)
    {
        message.pose.pose.Draw<FLU>(drawing, m_Size, m_DrawUnityAxes);
    }

    public override Action CreateGUI(MPoseWithCovarianceStamped message, MessageMetadata meta, BasicDrawing drawing) => () =>
    {
        message.header.GUI();
        message.pose.pose.GUI();
        MessageVisualizations.GUIGrid(message.pose.covariance, 6);
    };
}
