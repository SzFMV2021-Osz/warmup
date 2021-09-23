// <copyright file="DummySensor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Linq;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    /// <summary>
    /// Dummy Sensor class. This is used to calculate the distance between the car and the circle object.
    /// </summary>
    public class DummySensor : SystemComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class.
        /// </summary>
        /// <param name="vfb">VirtualFunctionBus.</param>
        public DummySensor(VirtualFunctionBus vfb)
            : base(vfb)
        {
            this.DummyPacket = new DummyPacket();
            vfb.DummyPacket = this.DummyPacket;
        }

        /// <summary>
        /// Gets dummy packet to hold the x, y values.
        /// </summary>
        public DummyPacket DummyPacket { get; private set; }

        /// <summary>
        /// Process to determine how far the Circle world object is.
        /// </summary>
        public override void Process()
        {
            var circleObject = World.Instance.WorldObjects.FirstOrDefault(x => x.GetType() == typeof(Circle));
            var carObject = World.Instance.ControlledCar;

            this.DummyPacket.DistanceX = Math.Abs(circleObject.X - carObject.X);
            this.DummyPacket.DistanceY = Math.Abs(circleObject.Y - carObject.Y);
        }
    }
}