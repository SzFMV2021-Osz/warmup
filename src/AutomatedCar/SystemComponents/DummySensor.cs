using System;
using AutomatedCar.Models;
using AutomatedCar.SystemComponents.Packets;

namespace AutomatedCar.SystemComponents
{
    /// <summary>
    /// Sensor for calculating the egocar - circle distance.
    /// </summary>
    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        /// <summary>
        /// Initializes new instance of <see cref="DummySensor"/>.
        /// </summary>
        /// <param name="virtualFunctionBus">dummyPacket reference.</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        /// <summary>
        /// Egocar - circle distance calculation.
        /// </summary>
        public override void Process()
        {
            AutomatedCar car = World.Instance.ControlledCar;
            Circle circle = (Circle)World.Instance.WorldObjects[0];

            this.dummyPacket.DistanceX = Math.Abs(car.X - circle.X);
            this.dummyPacket.DistanceY = Math.Abs(car.Y - circle.Y);
        }
    }
}
