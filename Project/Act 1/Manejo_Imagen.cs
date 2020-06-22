/*
 * Created by SharpDevelop.
 * User: EndUser
 * Date: 10/09/2018
 * Time: 11:10 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Act_1
{
	/// <summary>
	/// Description of Manejo_Imagen.
	/// </summary>
	public class Manejo_Imagen
	{
		Bitmap bmpImagen;
		Bitmap bmpCopiaAristas;
		
		public Manejo_Imagen(Bitmap Original) // Constuctor -> El genera una copia
		{
			bmpImagen = new Bitmap(Original);
		}
		
		public void AnalisisDeImagen(List<Circulo> ListaCirculos, Bitmap Original)
		{
			Draw Relleno = new Draw();
			int Numero_Circulo = -1;
			float Y_Inicio_5P,
			Y_Fin_5P,
			X_Inicio_5P,
			X_Fin_5P;
			
			for (int i = 0; i < bmpImagen.Height; i++) {            // Height = alto       i = y
				for (int j = 0; j < bmpImagen.Width; j++) {         // Width  = ancho      j = x
					
					Color Color_Actual = bmpImagen.GetPixel(j, i);  // Pixel actual
					
					if ((Color_Actual.R == 0 && Color_Actual.G == 0 && Color_Actual.B == 0) && Color_Actual.A == 255) {
						
						Numero_Circulo++;
						
						int Y_Inicio = i,
						Y_Final = i,
						X_Izq = j,
						X_Der = j,
						Y_Medio, X_Medio, radio;
						
						for (; Y_Final < bmpImagen.Height; Y_Final++) {   // Movieminto de Y hacia abajo
							Color_Actual = bmpImagen.GetPixel(j, Y_Final);
							if (!(Color_Actual.R == 0 && Color_Actual.G == 0 && Color_Actual.B == 0) || Color_Actual.A != 255) {
								break;
							}
						}
						
						Y_Medio = (Y_Final + Y_Inicio) / 2; // Calculo de Y medio
						
						for (; X_Izq >= 0; X_Izq--) {              // Movimiento de X hacia la izquierda
							Color_Actual = bmpImagen.GetPixel(X_Izq, Y_Medio);
							if (!(Color_Actual.R == 0 && Color_Actual.G == 0 && Color_Actual.B == 0) || Color_Actual.A != 255) {
								break;
							}
						}
						
						for (; X_Der < bmpImagen.Width; X_Der++) { // Movimiento de X hacia la derecha
							Color_Actual = bmpImagen.GetPixel(X_Der, Y_Medio);
							if (!(Color_Actual.R == 0 && Color_Actual.G == 0 && Color_Actual.B == 0) || Color_Actual.A != 255) {
								break;
							}
						}
						
						
						X_Medio = (X_Der + X_Izq) / 2;  // Calculo de X medio
						
						radio = X_Der - X_Medio;  // Calculo de radio
						
						// Calculo del 5% del diametro para dibujar el centro
						Y_Inicio_5P = Y_Medio - ((Y_Medio - Y_Inicio) / 10);
						Y_Fin_5P = Y_Medio + ((Y_Medio - Y_Inicio) / 10);
						X_Inicio_5P = X_Medio - ((X_Medio - X_Izq) / 10);
						X_Fin_5P = X_Medio + ((X_Medio - X_Izq) / 10);
						
						bmpImagen = Relleno.DrawCirculo(Y_Inicio, Y_Final, X_Der, X_Izq, bmpImagen, Color.Cyan);                                     // Colorear el circulo
						Original = Relleno.DrawCirculo(Y_Inicio, Y_Final, X_Der, X_Izq, Original, Color.Cyan);
						//Original = Relleno.DrawCirculo((int)Y_Inicio_5P, (int)Y_Fin_5P, (int)X_Inicio_5P, (int)X_Fin_5P, Original, Color.Yellow);
						//bmpImagen = Relleno.DrawCirculo((int)Y_Inicio_5P, (int)Y_Fin_5P, (int)X_Inicio_5P, (int)X_Fin_5P, bmpImagen, Color.Yellow);  // Colorear el centro
						
						//pictureBox1.Image = bmpImagen;       // Actualizacion del PictureBox
						
						Circulo Circulo_Actual = new Circulo(X_Medio, Y_Medio, radio, Numero_Circulo);  // Punto que contiene el centro del circulo
						
						ListaCirculos.Add(Circulo_Actual);                    // Adicion del punto a una lista
						
					}
				}
			}
		}
		
		public void GenerarGrafo(Grafo originalGrafo, Bitmap bmpOriginal)
		{
			bmpCopiaAristas = new Bitmap(bmpOriginal); // Copia de bitmap para analisis de aristas
			Draw linea = new Draw();
			Boolean Pintar;
			double Pendiente, posicion, RadioOrigen, RadioDestino;
			double Y0, Y1, X0, X1;
            double DistanciaEU;


            foreach (Vertice AuxVerticeOrigen in originalGrafo.GetListaVertices()) {
				List<Arista> Adyacentes = new List<Arista>(); // Lista para insertar en Vertice origen
				
				foreach (Vertice AuxVerticeDestino in originalGrafo.GetListaVertices()) {
					List<Point> Pixeles = new List<Point>();
					
					if (AuxVerticeOrigen.GetOrigen() != AuxVerticeDestino.GetOrigen()) {
						
						Y0 = AuxVerticeOrigen.GetOrigen().GetY();                   // Y vertice origen
						X0 = AuxVerticeOrigen.GetOrigen().GetX();                   // X vertice origen
						Y1 = AuxVerticeDestino.GetOrigen().GetY();                  // Y vertice destino
						X1 = AuxVerticeDestino.GetOrigen().GetX();                  // X vertice destino
						RadioOrigen = AuxVerticeOrigen.GetOrigen().GetRadio() + 4;   // Radio del circulo A
						RadioDestino = AuxVerticeDestino.GetOrigen().GetRadio() + 4; // Radio del circulo B
						Pendiente = (Y1 - Y0) / (X1 - X0);                           // Calculo de pendiente
						
						if ((-1 < Pendiente) && (Pendiente < 1)) { // ************** If para dibujo en los cuadrates de X
							if (X1 > X0) {
								
								RadioDestino = X1 - RadioDestino;
								Pintar = true;
								
								for (int i = (int)X0; i < X1; i++) {
									
									posicion = Y0 + Pendiente * ((i - X0));       // Calculo de posicion de Y
									Point P_Actual = new Point(i, (int)posicion); // Creacion del punto
									Pixeles.Add(P_Actual);                        // Inclusion de punto en la lista de puntos
									
									if (((i - X0) > RadioOrigen) && (i < RadioDestino)) { // If para tomar en cuenta el espacio entre A y B
										Pintar = ExisteObstruccionEnX(i, (int)posicion);
										if (!Pintar)
											break;
									}
								}
								if (Pintar) {
                                    DistanciaEU = Math.Pow((AuxVerticeDestino.GetOrigen().GetX() - AuxVerticeOrigen.GetOrigen().GetX()), 2) + Math.Pow((AuxVerticeDestino.GetOrigen().GetY() - AuxVerticeOrigen.GetOrigen().GetY()), 2);
                                    DistanciaEU = Math.Sqrt(DistanciaEU);
                                    Arista Aux = new Arista((int)DistanciaEU, AuxVerticeDestino, AuxVerticeOrigen, Pixeles);
                                    Adyacentes.Add(Aux);
									linea.DrawX(X0, X1, Y0, Pendiente, bmpOriginal); // Se dibujan aristas sobre la imagen original
								}
								Pixeles.Clear();                                              //limpieza de los pixeles para nueva arista
								
							} else {                                                          // Recta Destino < Origen    X(Izquierda)
								
								RadioOrigen = X0 - RadioOrigen;
								RadioDestino = X1 + RadioDestino;
								Pintar = true;
								
								for (int i = (int)X0; i > X1; i--) {
									
									posicion = Y0 + Pendiente * ((i - X0));       // Calculo de posicion de Y
									Point P_Actual = new Point(i, (int)posicion); // Creacion del punto
									Pixeles.Add(P_Actual);                        // Inclusion de punto en la lista de puntos
									
									if ((i < RadioOrigen) && (i > RadioDestino)) { // If para tomar en cuenta el espacio entre A y B
										Pintar = ExisteObstruccionEnX(i, (int)posicion);
										if (!Pintar)
											break;
									}
								}
								
								if (Pintar) {
                                    DistanciaEU = Math.Pow((AuxVerticeDestino.GetOrigen().GetX() - AuxVerticeOrigen.GetOrigen().GetX()), 2) + Math.Pow((AuxVerticeDestino.GetOrigen().GetY() - AuxVerticeOrigen.GetOrigen().GetY()), 2);
                                    DistanciaEU = Math.Sqrt(DistanciaEU);
                                    Arista Aux = new Arista((int)DistanciaEU, AuxVerticeDestino, AuxVerticeOrigen, Pixeles);
                                    Adyacentes.Add(Aux);
								}
								Pixeles.Clear();                                              // limpieza de los pixeles para nueva arista
							}
							
						} else { // ********************************************************* Else para dibujo en los cuadrantes de Y
							
							if (Y1 > Y0) {
								
								RadioDestino = Y1 - RadioDestino;
								Pintar = true;
								
								for (int i = (int)Y0; i < Y1; i++) {
									
									posicion = ((i - Y0) / Pendiente) + X0;       // Calculo de posicion X
									Point P_Actual = new Point((int)posicion, i); // Creacion del punto
									Pixeles.Add(P_Actual);                        // Inclusion de punto en la lista de puntos
									
									if (((i - Y0) > RadioOrigen) && (i < RadioDestino)) { // If para tomar en cuenta el espacio entre A y B
										Pintar = ExisteObstruccionEnY((int)posicion, i);
										if (!Pintar)
											break;
									}
								}
								if (Pintar) {
                                    DistanciaEU = Math.Pow((AuxVerticeDestino.GetOrigen().GetX() - AuxVerticeOrigen.GetOrigen().GetX()), 2) + Math.Pow((AuxVerticeDestino.GetOrigen().GetY() - AuxVerticeOrigen.GetOrigen().GetY()), 2);
                                    DistanciaEU = Math.Sqrt(DistanciaEU);
                                    Arista Aux = new Arista((int)DistanciaEU, AuxVerticeDestino, AuxVerticeOrigen, Pixeles);
                                    Adyacentes.Add(Aux);
									linea.DrawY(Y0, Y1, X0, Pendiente, bmpOriginal); // Se dibujan aristas sobre la imagen original
								}
								Pixeles.Clear();                                             // limpieza de los pixeles para nueva arista
								
							} else {                                                         // Recta Destino < Origen    Y(Abajo)
								
								RadioOrigen = Y0 - RadioOrigen;
								RadioDestino = Y1 + RadioDestino;
								Pintar = true;
								
								for (int i = (int)Y0; i > Y1; i--) {
									  
									posicion = ((i - Y0) / Pendiente) + X0;  // Calculo de posicion X
									Point P_Actual = new Point((int)posicion, i);  // Creacion del punto
									Pixeles.Add(P_Actual);                         // Inclusion de punto en la lista de puntos
									
									if ((i < RadioOrigen) && (i > RadioDestino)) { // If para tomar en cuenta el espacio entre A y B
										Pintar = ExisteObstruccionEnY((int)posicion, i);
										if (!Pintar)
											break;
									}
								}
								if (Pintar) {
                                    DistanciaEU = Math.Pow((AuxVerticeDestino.GetOrigen().GetX() - AuxVerticeOrigen.GetOrigen().GetX()),2) + Math.Pow((AuxVerticeDestino.GetOrigen().GetY() - AuxVerticeOrigen.GetOrigen().GetY()),2);
                                    DistanciaEU = Math.Sqrt(DistanciaEU);
									Arista Aux = new Arista((int)DistanciaEU, AuxVerticeDestino, AuxVerticeOrigen, Pixeles);
									Adyacentes.Add(Aux);
								}
								Pixeles.Clear();    // limpieza de los pixeles para nueva arista
							}
						}
					}
				}
				AuxVerticeOrigen.SetListaAristas(Adyacentes); // Inclusion de aristas a un vertice
			}
		}
		
		public Boolean ParVertices(Grafo originalGrafo, Bitmap bmpOriginal)
		{
			
			int Distancia = 0; 
			Boolean Primero = true;
			Circulo[] Par = new Circulo[2];
			Draw drawPar = new Draw();
			
			foreach (Vertice AuxVertice in originalGrafo.GetListaVertices()) {
				
				foreach (Arista AuxArista in AuxVertice.GetListaAristas()) {
					
					if (AuxVertice != AuxArista.GetDestino()) {
						if (Primero) {
							Distancia = AuxArista.GetDistancia();
							Par[0] = AuxVertice.GetOrigen();
							Par[1] = AuxArista.GetDestino().GetOrigen();
							Primero = false;
						} else if (Distancia > AuxArista.GetDistancia()) {
							Distancia = AuxArista.GetDistancia();
							Par[0] = AuxVertice.GetOrigen();
							Par[1] = AuxArista.GetDestino().GetOrigen();
						}
					}
					
				}
				
			}
			if (Distancia > 0) {
				drawPar.DrawCirculoConRadio(Par[0].GetX(), Par[0].GetY(), Par[0].GetRadio(), bmpOriginal, Color.Coral);
				drawPar.DrawCirculoConRadio(Par[1].GetX(), Par[1].GetY(), Par[1].GetRadio(), bmpOriginal, Color.Coral);
			} else {
				return false;
			}
			return true;
		}
		
		public Boolean CaminoAristas(Grafo originalGrafo, Bitmap bmpOriginal)
		{
			int Distancia = 0;                      // Distancia final del camino
			int AuxDistancia = 0;                   // Nueva distancia para comparacion
			bool Primero = true; 		            // Bandera de primera iteracion
			Vertice[] AuxPuntos = new Vertice[4];	// Lista para compracion de Vertices
			Arista[] Camino = new Arista[3];        // Lista final de Aristas
			Arista[] AuxCamino = new Arista[3];     // Lista para comparacion de Aristas
			Draw drawPuntos = new Draw();
			
			foreach (Vertice AuxVertice in originalGrafo.GetListaVertices()) {
				AuxPuntos[0] = AuxVertice;
				
				foreach (Arista AuxArista_1 in AuxVertice.GetListaAristas()) {
					AuxPuntos[1] = AuxArista_1.GetDestino();
					AuxCamino[0] = AuxArista_1;
					AuxDistancia += AuxArista_1.GetDistancia();
					
					foreach (Arista AuxArista_2 in AuxArista_1.GetDestino().GetListaAristas()) {
						if (AuxArista_2.GetDestino() != AuxPuntos[0]) {
								
							AuxPuntos[2] = AuxArista_2.GetDestino();
							AuxCamino[1] = AuxArista_2;
							AuxDistancia += AuxArista_2.GetDistancia();
						
							foreach (Arista AuxArista_3 in AuxArista_2.GetDestino().GetListaAristas()) {
								if (AuxArista_3.GetDestino() != AuxPuntos[0] && AuxArista_3.GetDestino() != AuxPuntos[1]) {
									
									AuxPuntos[3] = AuxArista_3.GetDestino();
									AuxCamino[2] = AuxArista_3;
									AuxDistancia += AuxArista_3.GetDistancia();
							
									if (Primero) {
										Camino[0] = new Arista(AuxCamino[0].GetDistancia(), AuxCamino[0].GetDestino(), AuxCamino[0].GetListaPixel());
										Camino[1] = new Arista(AuxCamino[1].GetDistancia(), AuxCamino[1].GetDestino(), AuxCamino[1].GetListaPixel());
										Camino[2] = new Arista(AuxCamino[2].GetDistancia(), AuxCamino[2].GetDestino(), AuxCamino[2].GetListaPixel());
										Distancia = AuxDistancia;
										Primero = false;
									} else if (Distancia > AuxDistancia) {
										Camino[0] = new Arista(AuxCamino[0].GetDistancia(), AuxCamino[0].GetDestino(), AuxCamino[0].GetListaPixel());
										Camino[1] = new Arista(AuxCamino[1].GetDistancia(), AuxCamino[1].GetDestino(), AuxCamino[1].GetListaPixel());
										Camino[2] = new Arista(AuxCamino[2].GetDistancia(), AuxCamino[2].GetDestino(), AuxCamino[2].GetListaPixel());
										Distancia = AuxDistancia;
									}
							
									AuxPuntos[3] = null;
									AuxCamino[2] = null;
									AuxDistancia -= AuxArista_3.GetDistancia();
								}
							}
						
							AuxPuntos[2] = null;
							AuxCamino[1] = null;
							AuxDistancia -= AuxArista_2.GetDistancia();
						}
					}
					AuxPuntos[1] = null;
					AuxCamino[0] = null;
					AuxDistancia -= AuxArista_1.GetDistancia();
				}
				AuxPuntos[0] = null;
			}
			
			if (Distancia > 0) {
				drawPuntos.DrawListaPixeles(Camino[0].GetListaPixel(), bmpOriginal,Color.Cyan);
				drawPuntos.DrawListaPixeles(Camino[1].GetListaPixel(), bmpOriginal,Color.Cyan);
				drawPuntos.DrawListaPixeles(Camino[2].GetListaPixel(), bmpOriginal,Color.Cyan);
			} else {
				return false;
			}
			return true;
		}
		
		Boolean ExisteObstruccionEnX(int X, int Y)
		{
			Boolean salir = true;
			Color pixel = new Color();
			pixel = bmpCopiaAristas.GetPixel(X, Y); // Se analizan las obstrucciones con una copia sin aristas de la imagen original
			if (pixel.R != 255 || pixel.G != 255 || pixel.B != 255) {
				salir = false;
			}
			pixel = bmpCopiaAristas.GetPixel(X, Y + 1); // Se analizan las obstrucciones con una copia sin aristas de la imagen original
			if (pixel.R != 255 || pixel.G != 255 || pixel.B != 255) {
				salir = false;
			}
			pixel = bmpCopiaAristas.GetPixel(X, Y - 1); // Se analizan las obstrucciones con una copia sin aristas de la imagen original
			if (pixel.R != 255 || pixel.G != 255 || pixel.B != 255) {
				salir = false;
			}
			return salir;
		}
		
		Boolean ExisteObstruccionEnY(int X, int Y)
		{
			Boolean salir = true;
			Color pixel = new Color();
			pixel = bmpCopiaAristas.GetPixel(X, Y); // Se analizan las obstrucciones con una copia sin aristas de la imagen original
			if (pixel.R != 255 || pixel.G != 255 || pixel.B != 255) {
				salir = false;
			}
			pixel = bmpCopiaAristas.GetPixel(X + 1, Y); // Se analizan las obstrucciones con una copia sin aristas de la imagen original
			if (pixel.R != 255 || pixel.G != 255 || pixel.B != 255) {
				salir = false;
			}
			pixel = bmpCopiaAristas.GetPixel(X - 1, Y); // Se analizan las obstrucciones con una copia sin aristas de la imagen original
			if (pixel.R != 255 || pixel.G != 255 || pixel.B != 255) {
				salir = false;
			}
			return salir;
		}
	}
}
