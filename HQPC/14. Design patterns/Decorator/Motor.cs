namespace Decorator
{
    using System;

    public class Motor : Vehicle
    {
        public Motor(int saddlebagsVolume, int consumption)
            : base(2, consumption)
        {
            this.SaddleBagsVolume = saddlebagsVolume;
        }

        public int SaddleBagsVolume { get; set; }

        public override void MoveForward()
        {
            Console.WriteLine("The motor moved forward");
        }

        public override void MoveBackward()
        {
            Console.WriteLine("The motor moved backward");
        }

        public override string Show()
        {
            var baseRes = base.Show();
            return baseRes + string.Format("--from Motor: saddlebags volume: {0} ", this.SaddleBagsVolume);
        }
    }
}
