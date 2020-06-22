/*
 * Created by SharpDevelop.
 * User: EndUser
 * Date: 04/10/2018
 * Time: 01:40 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Act_1
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Particula{
		
		int indiceOrigen;
		int indiceArista;
		int indicePosicion;
		List<int> Solucion;
		
		public Particula(){
		}
		
		public Particula(int indiceOrigen){
			indiceArista = 0;
			indicePosicion = 0;
			this.indiceOrigen = indiceOrigen;
			Solucion = new List<int>();
		}
		
		//METODOS DE ACTUALIZACION DE ATRIBUTOS
		
		public void setIndiceArista(int indiceArista){
			this.indiceArista = indiceArista;
		}
		
		//METODOS DE OBTENCION DE ATRIBUTOS
		
		public int getIndiceOrigen(){
			return indiceOrigen;
		}
		
		public int getIndiceArista(){
			return indiceArista;
		}
		
		public int getIndicePosicion(){
			return indicePosicion;
		}
		
		public List<int> getSolucion(){
			return Solucion;
		}
		
		public int getNextIdToSolution(){
			return Solucion[0];
		}
		
		//METODOS DE ...
		
		public void newOrigen(){
			indiceOrigen = Solucion[0];
			Solucion.RemoveRange(0, 1);
		}
		
		public void Reset(){
			indicePosicion = 0;
		}
		
		public void SiguientePunto()
		{
			indicePosicion ++; //Cambiar Por 20
		}
	}

	public class Presa : Particula
	{
		public Presa() : base(){
			
		}
		public Presa(int indiceOrigen) : base(indiceOrigen)
		{

		}
	}

	public class Depredador : Particula {
		
		int Color;
		
		public Depredador() : base()
		{

		}
		public Depredador(int indiceOrigen) : base (indiceOrigen){
			Color = 0;
		}
		
		public void Eat(){
			
			Color += 60;
			
		}
		
		public int getColor(){
			return Color;
		}
		
	}

}

