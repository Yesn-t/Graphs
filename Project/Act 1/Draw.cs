/*
 * Created by SharpDevelop.
 * User: EndUser
 * Date: 19/09/2018
 * Time: 09:49 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Act_1
{
	/// <summary>
	/// Description of Draw.
	/// </summary>
	public class Draw
	{
		public Draw()
		{
			// Color Purple genera contraste en YellowGreen
		}
		
		public void DrawX(double X0, double X1, double Y0, double Pendiente, Bitmap bmpOriginal)
		{
			double posicion;
			for (int i = (int)X0; i < X1; i++) {
				posicion = Y0 + Pendiente * ((i - X0));
				bmpOriginal.SetPixel(i, (int)Math.Ceiling(posicion), Color.YellowGreen);
				
			}
		}
		
		public void DrawY(double Y0, double Y1, double X0, double Pendiente, Bitmap bmpOriginal)
		{
			double posicion;
			for (int i = (int)Y0; i < Y1; i++) {
				posicion = ((i - Y0) / Pendiente) + X0;
				bmpOriginal.SetPixel((int)Math.Ceiling(posicion), i, Color.YellowGreen);
				
			}
		}
		
		public void DrawNumeroVertice(List<Circulo> centros, Bitmap Original)
		{
			Graphics letra = Graphics.FromImage(Original);
			
			foreach (Circulo Actual in centros) {
				
				Font drawFont = new Font("Arial", 24);
				SolidBrush drawBrush = new SolidBrush(Color.Red);
				letra.DrawString(Actual.GetID().ToString(), drawFont, drawBrush, Actual.GetX(), Actual.GetY());
				
			}
		}
		
		public Bitmap DrawCirculo(int Sup_Y, int Inf_Y, int Der_X, int Izq_X, Bitmap Original, Color Relleno)  //Funcion para colorear un circulo
		{
			
			float win = (Der_X - Izq_X) + 10;
			float hei = (Inf_Y - Sup_Y) + 10;
			
			Graphics Circle = Graphics.FromImage(Original);
			Brush randomBrush = new SolidBrush(Relleno);
			
			Circle.FillEllipse(randomBrush, Izq_X - 5, Sup_Y - 5, win, hei);
			
			return Original;
		}
		
		public void DrawCirculoConRadio(int X, int Y, int Radio, Bitmap Original, Color Relleno)  //Funcion para colorear un circulo
		{
			int Diametro = Radio * 2;
			X = X - Radio;
			Y = Y - Radio;
			
			Graphics Circle = Graphics.FromImage(Original);
			Brush randomBrush = new SolidBrush(Relleno);
			
			Circle.FillEllipse(randomBrush, X - 1, Y - 1, Diametro + 2, Diametro + 2);
		}
		
		public void DrawListaPixeles(List<Point> listaPuntos, Bitmap Original, Color Desing)
		{
			
			foreach (Point Punto in listaPuntos) {
				Original.SetPixel(Punto.X, Punto.Y, Desing);
			}
			
		}
		
		public void EncourageParticle(List<Presa> ListaPresas, List<Depredador> ListaDepredadores, Bitmap ImgOriginal, Grafo g, PictureBox Back)
		{
			PictureBox Pic = Back;
			List<Point> CentroPresas = new List<Point>();
			List<Point> CentroDepredadores = new List<Point>();
			Bitmap Tranparent = new Bitmap(ImgOriginal.Width, ImgOriginal.Height);
			Graphics Dibujo = Graphics.FromImage(Tranparent);
			Brush BrochaP = new SolidBrush(Color.Magenta);
			Brush BrochaD;
			Color ColorDepredador = new Color();
			int pintar = 0;


			Presa p = new Presa();
			Depredador d = new Depredador();
			Point Centro;
			
			Pic.Image = Tranparent;
			
			const int Radio = 20;
			int X, Y;

			for (int i = 0; i < ListaPresas.Count; i++) {
				p = ListaPresas[i];
				p.newOrigen();
				p.setIndiceArista(g.GetVerticeI(p.getIndiceOrigen()).getPositionAristaToFind(p.getNextIdToSolution()));
				Centro = new Point(0, 0);
				CentroPresas.Add(Centro);
			}
			
			for (int i = 0; i < ListaDepredadores.Count; i++) {
				d = ListaDepredadores[i];
				d.newOrigen();
				d.setIndiceArista(g.GetVerticeI(d.getIndiceOrigen()).getPositionAristaToFind(d.getNextIdToSolution()));
				Centro = new Point(0, 0);
				CentroDepredadores.Add(Centro);
			}

			while (ListaPresas.Count > 0 || ListaDepredadores.Count > 0) {

				if (pintar == 20) {
					Dibujo.Clear(Color.Transparent); // Color de Bitmap Front para Particulas
				}
				for (int i = 0; i < ListaPresas.Count; i++) { // Movimineto de Una Presas
					p = ListaPresas[i];
					if (p.getIndicePosicion() >= g.GetVerticeI(p.getIndiceOrigen()).GetAristaI(p.getIndiceArista()).GetListaPixel().Count) {
						if (p.getSolucion().Count > 1) {
							p.Reset();
							p.newOrigen();
							p.setIndiceArista(g.GetVerticeI(p.getIndiceOrigen()).getPositionAristaToFind(p.getNextIdToSolution()));
						} else {
							ListaPresas.RemoveRange(i, 1);
							CentroPresas.RemoveRange(i, 1);
						}
					} else {
						X = g.GetVerticeI(p.getIndiceOrigen()).GetAristaI(p.getIndiceArista()).GetListaPixelI(p.getIndicePosicion()).X;
						Y = g.GetVerticeI(p.getIndiceOrigen()).GetAristaI(p.getIndiceArista()).GetListaPixelI(p.getIndicePosicion()).Y;
						if (pintar == 20) {
							Dibujo.FillEllipse(BrochaP, X - Radio, Y - Radio, Radio * 2, Radio * 2);
						}
						Centro = new Point(X, Y);
						CentroPresas[i] = Centro;
						p.SiguientePunto();
					}
				}

				eliminarPresa(ListaPresas, ListaDepredadores, CentroDepredadores, CentroPresas);

				for (int i = 0; i < ListaDepredadores.Count; i++) { // Movimineto de Depredadoras
					d = ListaDepredadores[i];
					if (d.getIndicePosicion() >= g.GetVerticeI(d.getIndiceOrigen()).GetAristaI(d.getIndiceArista()).GetListaPixel().Count) {
						if (d.getSolucion().Count > 1) {
							d.Reset();
							d.newOrigen();
							d.setIndiceArista(g.GetVerticeI(d.getIndiceOrigen()).getPositionAristaToFind(d.getNextIdToSolution()));
						} else {
							ListaDepredadores.RemoveRange(i, 1);
						}
					} else {
						X = g.GetVerticeI(d.getIndiceOrigen()).GetAristaI(d.getIndiceArista()).GetListaPixelI(d.getIndicePosicion()).X;
						Y = g.GetVerticeI(d.getIndiceOrigen()).GetAristaI(d.getIndiceArista()).GetListaPixelI(d.getIndicePosicion()).Y;
						d = ListaDepredadores[i];

						ColorDepredador = newColor(ColorDepredador, d);
						BrochaD = new SolidBrush(ColorDepredador);
						if (pintar == 20) {
							Dibujo.FillEllipse(BrochaD, X - Radio, Y - Radio, Radio * 2, Radio * 2);
						}

						Centro = new Point(X, Y);
						CentroDepredadores[i] = Centro;
						d.SiguientePunto();
					}
				}

				eliminarPresa(ListaPresas, ListaDepredadores, CentroDepredadores, CentroPresas);

				if (pintar == 20) {
					Pic.Refresh(); // Actualizacion de Bitmap con Nuevas posiciones de particulas
					pintar = 0;
				}
				pintar++;
			}
			Dibujo.Clear(Color.Transparent);
		}

		void eliminarPresa(List<Presa> ListaPresas, List<Depredador> ListaDepredadores, List<Point> CentroDepredadores, List<Point> CentroPresas)
		{
            for (int i = 0; i < CentroDepredadores.Count; i++)
            {
                for (int j = 0; j < CentroPresas.Count; j++)
                {
                    if (CentroDepredadores[i] == CentroPresas[j])
                    {
                        MessageBox.Show("Ya se MURIO!!!!!!!");
                        CentroPresas.RemoveRange(j, 1);
                        if (j < ListaPresas.Count)
                        {
                            ListaPresas.RemoveRange(j, 1);
                        }
                        ListaDepredadores[i].Eat();
                    }
                }
            }
		}

		Color newColor(Color ColorDepredador, Depredador d)
		{
			int R;
			R = d.getColor();
			if (R < 256) {
				ColorDepredador = Color.FromArgb(255, R, 255, 0);
			} else if (R < 511) {
				R -= 255;
				ColorDepredador = Color.FromArgb(255, 0, R, 255);
			} else {
				R -= 511;
				ColorDepredador = Color.FromArgb(255, 255, 0, R);
			}
			return ColorDepredador;
		}

		public Boolean ParticleDijstra(List<Presa> ListaPresas, List<Depredador> ListaDepredadores, Bitmap ImgOriginal, Grafo g, PictureBox Back)
		{
			Boolean Vive = false;
			PictureBox Pic = Back;
			List<Point> CentroPresas = new List<Point>();
			List<Point> CentroDepredadores = new List<Point>();
			Bitmap Tranparent = new Bitmap(ImgOriginal.Width, ImgOriginal.Height);
			Graphics Dibujo = Graphics.FromImage(Tranparent);
			Brush BrochaP = new SolidBrush(Color.Magenta);
			Brush BrochaD;
			Color ColorDepredador = new Color();
			int pintar = 0;


			Presa p = new Presa();
			Depredador d = new Depredador();
			Point Centro;
			
			Pic.Image = Tranparent;
			
			const int Radio = 20;
			int X, Y;

			for (int i = 0; i < ListaPresas.Count; i++) {
				p = ListaPresas[i];
				p.newOrigen();
				p.setIndiceArista(g.GetVerticeI(p.getIndiceOrigen()).getPositionAristaToFind(p.getNextIdToSolution()));
				Centro = new Point(0, 0);
				CentroPresas.Add(Centro);
			}
			
			for (int i = 0; i < ListaDepredadores.Count; i++) {
				d = ListaDepredadores[i];
				d.newOrigen();
				d.setIndiceArista(g.GetVerticeI(d.getIndiceOrigen()).getPositionAristaToFind(d.getNextIdToSolution()));
				Centro = new Point(0, 0);
				CentroDepredadores.Add(Centro);
			}

			while (ListaPresas.Count > 0 || ListaDepredadores.Count > 0) {
				if (pintar == 10) {
					Dibujo.Clear(Color.Transparent);
				}
				
				for (int i = 0; i < ListaPresas.Count; i++) { // Movimineto de Una Presas
					p = ListaPresas[i];
					if (p.getIndicePosicion() >= g.GetVerticeI(p.getIndiceOrigen()).GetAristaI(p.getIndiceArista()).GetListaPixel().Count) {
						if (p.getSolucion().Count > 1) {
							p.Reset();
							p.newOrigen();
							p.setIndiceArista(g.GetVerticeI(p.getIndiceOrigen()).getPositionAristaToFind(p.getNextIdToSolution()));
						} else {
							ListaPresas.RemoveRange(i, 1);
							CentroPresas.RemoveRange(i, 1);
							Vive = true;
						}
					} else {
						X = g.GetVerticeI(p.getIndiceOrigen()).GetAristaI(p.getIndiceArista()).GetListaPixelI(p.getIndicePosicion()).X;
						Y = g.GetVerticeI(p.getIndiceOrigen()).GetAristaI(p.getIndiceArista()).GetListaPixelI(p.getIndicePosicion()).Y;
						if (pintar == 10) {
							Dibujo.FillEllipse(BrochaP, X - Radio, Y - Radio, Radio * 2, Radio * 2);
						}
						Centro = new Point(X, Y);
						CentroPresas[i] = Centro;
						p.SiguientePunto();
					}
				}

				eliminarPresa(ListaPresas, ListaDepredadores, CentroDepredadores, CentroPresas);

				for (int i = 0; i < ListaDepredadores.Count; i++) { // Movimineto de Depredadoras
					d = ListaDepredadores[i];
					if (d.getIndicePosicion() >= g.GetVerticeI(d.getIndiceOrigen()).GetAristaI(d.getIndiceArista()).GetListaPixel().Count) {
						if (d.getSolucion().Count > 1) {
							d.Reset();
							d.newOrigen();
							d.setIndiceArista(g.GetVerticeI(d.getIndiceOrigen()).getPositionAristaToFind(d.getNextIdToSolution()));
						} else {
							g.SolutionTravelWidth(ListaDepredadores[i].getSolucion(),ListaDepredadores[i].getSolucion()[0]);
						}
					} else {
						X = g.GetVerticeI(d.getIndiceOrigen()).GetAristaI(d.getIndiceArista()).GetListaPixelI(d.getIndicePosicion()).X;
						Y = g.GetVerticeI(d.getIndiceOrigen()).GetAristaI(d.getIndiceArista()).GetListaPixelI(d.getIndicePosicion()).Y;
						d = ListaDepredadores[i];

						ColorDepredador = newColor(ColorDepredador, d);
						BrochaD = new SolidBrush(ColorDepredador);
						if (pintar == 10) {
							Dibujo.FillEllipse(BrochaD, X - Radio, Y - Radio, Radio * 2, Radio * 2);
						}

						Centro = new Point(X, Y);
						CentroDepredadores[i] = Centro;
						d.SiguientePunto();
					}
				}

				eliminarPresa(ListaPresas, ListaDepredadores, CentroDepredadores, CentroPresas);

				if (pintar == 10) {
					Pic.Refresh(); // Actualizacion de Bitmap con Nuevas posiciones de particulas
					pintar = 0;
				}
				pintar++;
				if(ListaPresas.Count < 1){
					break;
				}
			}
			
			Dibujo.Clear(Color.Transparent);
			return Vive;
		}
	}
}
