
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Colliders;

namespace StrategyRTS.GameObjects
{
    public class GameObject
    {
		protected BaseCollider collider;
		public BaseCollider Collider
		{
			get
			{
				return collider;
			}
		}

		protected Rectangle? sourseRentangle;

		protected Texture2D texture;
		public Texture2D Texture
		{
			get { return texture; }
		}

		protected bool isTexture;
		public bool IsTexture
		{
			get => isTexture;
		}

		protected Vector2 lastMove;
		public Vector2 LastMove
		{
			get { return lastMove; }
		}

		protected Vector2 position;
		public Vector2 Position
		{
			get
			{
				return position;
			}
		}

		protected Vector2 velocity;

		protected Vector2 origin;

		protected Vector2 scale;
		public Vector2 Scale
		{
			get
			{
				return scale;
			}
			set
			{
				scale = value;
			}
		}

		protected float angle;
		public float Angle
		{
			get { return angle; }
		}

		protected float rotationVelocity;

		public bool HasCollider
		{
			get
			{
				return collider != null;
			}
		}

		private int collisionIndex;

		public GameObject()
        {
			DefaultSetting();
		}
        public GameObject(Texture2D texture) : this()
        {
            this.texture = texture;
        }

		public void DefaultSetting()
		{
			position = new Vector2(0);
			sourseRentangle = null;
			angle = 0;
			origin = new Vector2(0);
			scale = new Vector2(1);
			isTexture = true;
		}
		public void NullTexture()
		{
			isTexture = false;
		}
		public void SetPosition(Vector2 position)
		{
			this.position = position;
		}
		public void AddCollider<T>(int collisionIndex = 0) where T : BaseCollider, new()
		{
			collider = new T();
			collider.SetMaster(this);
			this.collisionIndex = collisionIndex;
		}
		public void UndoMove()
		{
			position -= lastMove;
			lastMove = Vector2.Zero;
		}
		public void Move(Vector2 delta)
        {
            position += delta;
			lastMove = delta;
		}
        
		public virtual void Update(GameTime gameTime) 
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourseRentangle, Color.White, angle, origin, scale, SpriteEffects.None, 1);
        }
    }
}
