
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StrategyRTS.GameObjects;

namespace StrategyRTS.UserInterface
{
	public class UIControlBase : GameObject
	{
		protected MouseState previousState;
		protected MouseState currentState;
		protected SpriteFont font;
		protected string text;
		protected Vector2 textPosition;
		protected Color color;
		protected void DrawString(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(font, text, textPosition, color = Color.White);
		}
	}
}
/*Наиболее распространённые элементы интерфейса: Кнопка, Ссылка, Иконка, Вкладка, 
 * Чекбокс, Радиокнопка, Переключатель, Выпадающий список, Ползунок, Поле ввода, 
 * Таблицы, Меню.*/