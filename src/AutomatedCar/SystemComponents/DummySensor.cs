namespace AutomatedCar.SystemComponents
{
    using Models;
    using Packets;
    using System;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }

        /// <summary>
        /// Process method to calculate the distance x and y.
        /// </summary>
        public override void Process()
        {
            AutomatedCar car = World.Instance.ControlledCar;
            Circle circle = (Circle)World.Instance.WorldObjects[0];

            this.dummyPacket.DistanceX = Math.Abs(circle.X - car.X);
            this.dummyPacket.DistanceY = Math.Abs(circle.Y - car.Y);
        }
    }
}
