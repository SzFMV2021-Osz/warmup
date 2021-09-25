namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus bus) 
            : base(bus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            Circle circle = (Circle)World.Instance.WorldObjects[0];
            AutomatedCar controlledCar = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = Math.Abs(controlledCar.X - circle.X);
            this.dummyPacket.DistanceY = Math.Abs(controlledCar.Y - circle.Y);
        }
    }
}
