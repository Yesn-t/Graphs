/*
 * Created by SharpDevelop.
 * User: EndUser
 * Date: 28/11/2018
 * Time: 10:12 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Act_1
{
	/// <summary>
	/// Description of Dijkstra.
	/// </summary>
	public class Dijkstra
	{
		int Origen;
		int Procedente;
		double Peso;
		Boolean Definitivo;
		
		public Dijkstra(){
			
		}
		
		public Dijkstra(int Origen, int Procedente, double Peso){
			this.Origen = Origen;
			this.Procedente = Procedente;
			this.Peso = Peso;
			Definitivo = false;
		}
		
		public int GetOrigen(){
			return Origen;
		}
		
		public int GetProcedente(){
			return Procedente;
		}
		
		public double GetPeso(){
			return Peso;
		}
		
		public Boolean GetDefinitivo(){
			return Definitivo;
		}
		
		public void SetProvcedente(int Procedente){
			this.Procedente = Procedente;
		}
		
		public void SetPeso(double Peso){
			this.Peso = Peso;
		}
		
		public void ChangeDefinitivo(){
			Definitivo = true;
		}
	}
}
