namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DummySensor : SystemComponent
    {
        DummyPacket dummyPacket { get; } = new DummyPacket();

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            AutomatedCar automatedCar = World.Instance.ControlledCar;
            Circle circle = World.Instance.WorldObjects
                .OfType<Circle>()
                .First();

            this.dummyPacket.DistanceX = Math.Abs(automatedCar.X - circle.X);
            this.dummyPacket.DistanceY = Math.Abs(automatedCar.Y - circle.Y);
        }
    }
}
