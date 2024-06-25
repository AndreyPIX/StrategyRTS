
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StrategyRTS.GameObjects;
using System.Drawing;

namespace StrategyRTS.UserInterface
{
	public class UIControlBase : GameObject
	{
		protected MouseState previousState;
		protected MouseState currentState;
		protected SpriteFont font;
		public void SetFont(SpriteFont font)
		{
			this.font = font;
		}
	}
}
/*Наиболее распространённые элементы интерфейса: Кнопка, Ссылка, Иконка, Вкладка, 
 * Чекбокс, Радиокнопка, Переключатель, Выпадающий список, Ползунок, Поле ввода, 
 * Таблицы, Меню.*/