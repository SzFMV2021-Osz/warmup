namespace AutomatedCar.SystemComponents.Sensors
{
    using Models;
    using Packets;
    using System;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }

        public override void Process()
        {
            Circle circle = (Circle)World.Instance.WorldObjects[0];
            AutomatedCar car = World.Instance.ControlledCar;
            int dX = Math.Abs(circle.X - car.X);
            int dY = Math.Abs(circle.Y - car.Y);
            dummyPacket.DistanceX = dX;
            dummyPacket.DistanceY = dY;
            virtualFunctionBus.DummyPacket = dummyPacket;
        }
    }
}