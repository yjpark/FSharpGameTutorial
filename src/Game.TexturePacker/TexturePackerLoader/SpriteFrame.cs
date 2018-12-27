namespace TexturePackerLoader
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class SpriteFrame
    {
        public SpriteFrame(Texture2D texture, Rectangle sourceRect, Vector2 size, Vector2 pivotPoint, bool isRotated)
        {
            this.Texture = texture;
            this.SourceRectangle = sourceRect;
            this.Size = size;
            this.Origin = isRotated ? new Vector2(sourceRect.Width * (1 - pivotPoint.Y), sourceRect.Height * pivotPoint.X)
                                    : new Vector2(sourceRect.Width * pivotPoint.X, sourceRect.Height * pivotPoint.Y);
            this.IsRotated = isRotated;
        }

        public Texture2D Texture { get; private set; }

        public Rectangle SourceRectangle { get; private set; }

        public Vector2 Size { get; private set; }

        public bool IsRotated { get; private set; }

        public Vector2 Origin { get; private set; }
    }
}
