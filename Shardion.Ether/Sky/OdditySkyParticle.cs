using Microsoft.Xna.Framework;


namespace VsOddity.Sky
{
    public struct OdditySkyParticle
    {
        public Vector2 Position { get; set; }
        public float Speed { get; set; }
        public float Scale { get; set; }

        public OdditySkyParticle(Vector2 position, float speed, float scale)
        {
            Position = position;
            Speed = speed;
            Scale = scale;
        }
    }
}
