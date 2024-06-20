
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
			set { texture = value; }
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

		protected Vector2 tempPosition;
		public Vector2 TempPosition
		{
			get
			{
				return tempPosition;
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

		protected bool hasMovement;
		public bool HasMovement
		{
			get { return hasMovement; }
			set { hasMovement = value; }
		}

		private int collisionIndex;
		public int CollisionIndex
		{
			get { return collisionIndex; }
			set { collisionIndex = value; }
		}

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
		public void SetTempPosition(Vector2 tempPosition)
		{
			this.tempPosition = tempPosition;
		}
		public void SetPosition(Vector2 position)
		{
			this.position = position;
		}
		public void SetVelocity(Vector2 velocity)
		{
			this.velocity = velocity;
		}
		public void AddCollider<T>(int collisionIndex = 0) where T : BaseCollider, new()
		{
			collider = new T();
			collider.SetMaster(this);
			this.collisionIndex = collisionIndex;
		}
		public void UndoMove()
		{
			position -= lastMove + velocity;
			lastMove = Vector2.Zero;
		}
		public void Move(Vector2 delta)
        {
            position += delta;
			lastMove = delta;
			hasMovement = (delta.X != 0 || delta.Y != 0);
		}
		public virtual void Update(GameTime gameTime) 
        {
			position += velocity;
			
		}
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourseRentangle, Color.White, angle, origin, scale, SpriteEffects.None, 1);
        }
    }
}
