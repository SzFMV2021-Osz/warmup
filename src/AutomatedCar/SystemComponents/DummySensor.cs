namespace AutomatedCar.SystemComponents
{
    using System;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    /// <summary>
    /// A sensor that calculates the distance between the egocar and the Circle object.
    /// </summary>
    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class.
        /// </summary>
        /// <param name="virtualFunctionBus">Stores the reference of the dummyPacket.</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        /// <summary>
        /// Calculates the distance between the egocar and the circle.
        /// </summary>
        public override void Process()
        {
            AutomatedCar egoCar = World.Instance.ControlledCar;
            Circle circle = (Circle)World.Instance.WorldObjects[0];

            this.dummyPacket.DistanceX = Math.Abs(egoCar.X - circle.X);
            this.dummyPacket.DistanceY = Math.Abs(egoCar.Y - circle.Y);
        }
    }
}
