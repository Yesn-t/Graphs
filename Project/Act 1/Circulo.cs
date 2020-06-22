/*
 * Created by SharpDevelop.
 * User: EndUser
 * Date: 10/09/2018
 * Time: 11:07 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace Act_1
{
	/// <summary>
	/// Description of Circulo.
	/// </summary>
	public class Circulo
	{
		Point Centro;
		// disable once FieldCanBeMadeReadOnly.Local
		int Id;
		int Radio;
		
		public Circulo(int X, int Y, int Radio, int Id)
		{
			Centro = new Point(X, Y);
			this.Radio = Radio;
			this.Id = Id;
		}
		
		public int GetRadio()
		{
			return Radio;
		}
		
		public int GetX()
		{
			return Centro.X;
		}
		
		public int GetY()
		{
			return Centro.Y;
		}
		
		public int GetID()
		{
			return Id;
		}
		
		public override string ToString()
		{
			return string.Format(" {0} --->  X: {1}    Y: {2}    R: {3}", Id, Centro.X, Centro.Y, Radio);
		}

		
	}
}
