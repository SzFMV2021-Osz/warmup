// <copyright file="DummySensor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AutomatedCar.SystemComponents
{
    using System;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    /// <summary>This is a dummy sensor for demonstrating the codebase.
    /// It calculates distance per coordinate between the controlled car and the dummy Circle object.</summary>
    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class.
        /// </summary>
        /// <param name="virtualFunctionBus">Injected virtual function bus.</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        /// <summary>
        /// Process method for calculating distance.
        /// </summary>
        public override void Process()
        {
            Circle circle = (Circle)World.Instance.WorldObjects[0];
            AutomatedCar currentCar = World.Instance.ControlledCar;

            int diffX = Math.Abs(circle.X - currentCar.X);
            int diffY = Math.Abs(circle.Y - currentCar.Y);

            this.dummyPacket.DistanceX = diffX;
            this.dummyPacket.DistanceY = diffY;
        }
    }
}