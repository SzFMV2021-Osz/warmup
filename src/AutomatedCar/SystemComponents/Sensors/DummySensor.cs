using AutomatedCar.Models;
using AutomatedCar.SystemComponents.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedCar.SystemComponents
{
    public class DummySensor : SystemComponent
    {
        private DummyPacket packet;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.packet = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.packet;
        }

        public override void Process()
        {
            var circle = World.Instance.WorldObjects.ElementAt(0);
            var controlledCar = World.Instance.ControlledCar;

            int dX = Math.Abs(circle.X - controlledCar.X);
            int dY = Math.Abs(circle.Y - controlledCar.Y);

            this.packet.DistanceX = dX;
            this.packet.DistanceY = dY;

            // this.virtualFunctionBus.DummyPacket = this.packet;
        }
    }
}
