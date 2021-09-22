namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Linq;

    public class DummySensor : SystemComponent
    {
        public DummySensor(VirtualFunctionBus vfb) : base(vfb)
        {
            this.DummyPacket = new DummyPacket();
            vfb.DummyPacket = this.DummyPacket;
        }

        public DummyPacket DummyPacket { get; private set; }

        public override void Process()
        {
            var circleObject = World.Instance.WorldObjects.FirstOrDefault(x => x.GetType() == typeof(Circle));
            var carObject = World.Instance.ControlledCar;

            DummyPacket.DistanceX = Math.Abs(circleObject.X - carObject.X);
            DummyPacket.DistanceY = Math.Abs(circleObject.Y - carObject.Y);
        }
    }
}
