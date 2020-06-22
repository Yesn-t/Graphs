/*
 * Created by SharpDevelop.
 * User: EndUser
 * Date: 23/08/2018
 * Time: 01:27 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Act_1
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Boolean cargoImagen, analizoImagen;
		string ruta;
		List<Circulo> Lista_Circulos;
		Bitmap bmpImagen,bmpRespaldo,bmpCentros,bmpStatic;
		Grafo grafo;
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			cargoImagen = false;
			groupBoxACT1.Visible = false;
			groupBoxACT2.Visible = false;
			groupBoxACT3.Visible = false;
			groupBoxACT4.Visible = false;
			groupBoxACT5.Visible = false;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ButtonCARGAClick(object sender, EventArgs e)
		{
			try {
				openFileDialog1.ShowDialog();
				ruta = openFileDialog1.FileName;
				pictureBox1.BackgroundImage = Image.FromFile(ruta);
				cargoImagen = true;
				analizoImagen = false;
				clearVisualElements();
			} catch (Exception) {
				cargoImagen = false;
				analizoImagen = false;
				clearVisualElements();
				MessageBox.Show("No se cargo Imagen");
			}
		}
		
		void clearVisualElements(){
			// ACT 1
			listBoxCENTROS.DataSource = null;
			// ACT 2
			treeViewGRAFO.Nodes.Clear();
			// ACT 3
			// ACT 4
			KruskalListBox.DataSource = null;
			PrimListBox.DataSource = null;
			PrimLabel.Text = "";
			KruskalLabel.Text = "";
			PrimNumericUpDown.Value = 0;
			// ACT 5
			
		}
		
		void ButtonCALCULARClick(object sender, EventArgs e)
		{
			try {
				if(cargoImagen){
					analizoImagen = true;
					
					clearVisualElements();
					
					Lista_Circulos = new List<Circulo>();

					bmpImagen = new Bitmap(ruta);
					bmpCentros = new Bitmap(ruta);
					bmpStatic = new Bitmap(ruta);

					Manejo_Imagen Tratamiento = new Manejo_Imagen(bmpCentros);

					Draw Linea = new Draw();
					
					Tratamiento.AnalisisDeImagen(Lista_Circulos, bmpCentros);	// Analisis del Bitmap
					
					pictureBox1.BackgroundImage = bmpStatic;                   	// Imagen como fondo de Picturebox
					
					grafo = new Grafo(Lista_Circulos);                         	// ACT 2 -5
					Tratamiento.GenerarGrafo(grafo, bmpImagen);                	// ACT 2 - 5
					Linea.DrawNumeroVertice(Lista_Circulos, bmpCentros);        // ACT 1 - 5
					Linea.DrawNumeroVertice(Lista_Circulos, bmpImagen);        	// ACT 1 - 5
					bmpRespaldo = new Bitmap(bmpImagen);
					MessageBox.Show("Listo para usarse");
				}else{
					MessageBox.Show("No Hay Imagen");
				}
			} catch (Exception) {
				analizoImagen = false;
				MessageBox.Show("Error...");
			}
		}
		
		void GenerarTreeView(Grafo Original)
		{
			foreach (Vertice TempVertice in Original.GetListaVertices()) { // Vista en arbol del grafo, generacion de treeView
				
				List <Arista> ListaAristas = TempVertice.GetListaAristas();   // Lista que contiene la direccion de la lista de aristas que tiene el vertice
				TreeNode[] array = new TreeNode[ListaAristas.Count];         // Nueva lista de tamaño igual a la cantidad de aristas del vertice
				
				int i = 0;
				
				foreach (Arista TempArista in ListaAristas) {  // For para asignar hijos en el vertice del treeView Nodo
					TreeNode subNode = new TreeNode(TempArista.GetOrigen().GetOrigen().GetID() +
					                                ":" + TempArista.GetDestino().GetOrigen().GetID() +
					                                " --> D: " + TempArista.GetDistancia());
					array[i] = subNode;
					i++;
				}
				
				TreeNode Node = new TreeNode(TempVertice.GetOrigen().GetID() + " --> Adyacentes: " + TempVertice.GetListaAristas().Count(), array); // Asignacion de padre a hijos
				treeViewGRAFO.Nodes.Add(Node);  // Agregar a la vista en treeView
				
			}
		} // ACT 2
		
		void PuntosCercanosButtonClick(object sender, EventArgs e)
		{
			Manejo_Imagen Tratamiento = new Manejo_Imagen(bmpImagen);
			if(!Tratamiento.ParVertices(grafo, bmpImagen)){
				MessageBox.Show("No existen Vertices con Aristas...");
			}
			pictureBox1.Refresh();
		} // ACT 2
		
		void Camino4VerticesButtonClick(object sender, EventArgs e)
		{
			Manejo_Imagen Tratamiento = new Manejo_Imagen(bmpImagen);
			if(!Tratamiento.CaminoAristas(grafo, bmpImagen)){
				MessageBox.Show("No existen Camino de 4 Verrtices y 3 Aristas...");
			}
			pictureBox1.Refresh();
		} // ACT 2
		
		void InsertParticulabuttonClick(object sender, EventArgs e)
		{
			if( (presaNumericUpDown.Value >= 0 && presaNumericUpDown.Value < grafo.GetListaVertices().Count) ||
			   (depredadorNumericUpDown.Value >= 0 && depredadorNumericUpDown.Value < grafo.GetListaVertices().Count) ){
				int R;
				Random Rand = new Random();
				Draw DrawParticulas = new Draw();
				List<int> Inicios = new List<int>();
				// Generar lista de presas y depredadores
				List<Presa> ListaPresas = new List<Presa>();
				for (int i = 0; i < (int)presaNumericUpDown.Value; i++) {
					
					do {
						R = Rand.Next(0, grafo.GetListaVertices().Count);
					} while(Inicios.Contains(R));
					Inicios.Add(R);
					
					Presa P = new Presa(R);
					grafo.SolutionTravelDepth(P.getSolucion(), R);
					ListaPresas.Add(P);
				}
				
				Inicios.Clear();
				List<Depredador> ListaDepredadores = new List<Depredador>();
				for (int i = 0; i < (int)depredadorNumericUpDown.Value; i++) {
					
					do {
						R = Rand.Next(0, grafo.GetListaVertices().Count);
					} while(Inicios.Contains(R));
					Inicios.Add(R);
					
					Depredador D = new Depredador(R);
					grafo.SolutionTravelWidth(D.getSolucion(), R);
					ListaDepredadores.Add(D);
				}
				
				DrawParticulas.EncourageParticle(ListaPresas, ListaDepredadores, bmpImagen, grafo, pictureBox1);
			}else{
				MessageBox.Show("Numero de Presas o Depredadores Incorrecto...");
			}
			
		} // ACT 3
		
		void RecorridoProfundidadButtonClick(object sender, EventArgs e)
		{
			List<int> Recorrido;
			Recorrido = new List<int>();
			string texto;
			texto = "";
			
			grafo.TravelDepth(Recorrido, (int)inicioRecorrido.Value);
			
			for (int j = 0; j < Recorrido.Count; j++) {
				int i = Recorrido[j];
				if (j == 0) {
					texto += i.ToString(	);
				} else if (j > 0) {
					texto += " -> " + i;
				}
			}
			
			labelRecorrido.Text = texto;
			
		} // ACT 3
		
		void RecorridoAnchuraButtonClick(object sender, EventArgs e)
		{
			List<int> Recorrido;
			Recorrido = new List<int>();
			string texto;
			texto = "";
			
			grafo.TravelWidth(Recorrido, (int)inicioRecorrido.Value);
			
			for (int j = 0; j < Recorrido.Count; j++) {
				int i = Recorrido[j];
				if (j == 0) {
					texto += i.ToString();
				} else if (j > 0) {
					texto += " -> " + i;
				}
			}
			
			labelRecorrido.Text = texto;
			
		} // ACT 3
		
		void KruskalButtonClick(object sender, EventArgs e)
		{
			Draw Line = new Draw();
			int Ponderacion = 0;
			List<Arista> KRUSKAL = new List<Arista>();
			grafo.Kruskal(KRUSKAL);
			
			foreach (Arista Aux in KRUSKAL) {
				Line.DrawListaPixeles(Aux.GetListaPixel(), bmpImagen, Color.Red);
				Ponderacion += Aux.GetDistancia();
			}
			KruskalListBox.DataSource = KRUSKAL;
			KruskalLabel.Text = Ponderacion.ToString();
			pictureBox1.BackgroundImage = bmpImagen;
			pictureBox1.Refresh();
		} // ACT 4
		
		void PrimButtonClick(object sender, EventArgs e)
		{
			if(PrimNumericUpDown.Value >= 0 && PrimNumericUpDown.Value < grafo.GetListaVertices().Count){
				Draw Line = new Draw();
				int Ponderacion = 0;
				List<Arista> PRIM = new List<Arista>();
				grafo.Prim(PRIM, (int)PrimNumericUpDown.Value);
				
				foreach (Arista Aux in PRIM) {
					Line.DrawListaPixeles(Aux.GetListaPixel(), bmpImagen, Color.BlueViolet);
					Ponderacion += Aux.GetDistancia();
				}
				PrimListBox.DataSource = PRIM;
				PrimLabel.Text = Ponderacion.ToString();
				pictureBox1.BackgroundImage = bmpImagen;
				pictureBox1.Refresh();
			}else{
				MessageBox.Show("Inicio incorrecto");
			}
		} // ACT 4
		
		void AnimarDijButtonClick(object sender, EventArgs e)
		{
			if((DestinoDijNumericUpDown.Value >= 0 && DestinoDijNumericUpDown.Value < grafo.GetListaVertices().Count) &&
			   (OrigenDijNumericUpDown.Value >= 0 && OrigenDijNumericUpDown.Value < grafo.GetListaVertices().Count)){
				int R, newOrigen;
				int NO, ND;
				Random Rand = new Random();
				Draw DrawParticulas = new Draw();
				List<int> Inicios = new List<int>();
				
				ND = (int)DestinoDijNumericUpDown.Value;
				NO = (int)OrigenDijNumericUpDown.Value;
				
				// Generar lista de presas y depredadores
				if (ND != NO) {
					if (/*true*/grafo.SolucionProbable(NO, ND)) {
						List<Presa> ListaPresas = new List<Presa>();  // Agregar Validacion (Menor a numero de vertices)
						Presa P = new Presa((int)OrigenDijNumericUpDown.Value);
						grafo.SolutionDijkstra(P.getSolucion(), (int)OrigenDijNumericUpDown.Value, (int)DestinoDijNumericUpDown.Value);
						ListaPresas.Add(P);
						
						Inicios.Clear();
						List<Depredador> ListaDepredadores = new List<Depredador>();
						for (int i = 0; i < (int)DepredadorDijnumericUpDown.Value; i++) {
							
							do {
								R = Rand.Next(0, grafo.GetListaVertices().Count);
							} while(Inicios.Contains(R));
							Inicios.Add(R);
							
							Depredador D = new Depredador(R);
							grafo.SolutionTravelWidth(D.getSolucion(), R);
							ListaDepredadores.Add(D);
						}
						
						newOrigen = ListaPresas[0].getSolucion()[ListaPresas[0].getSolucion().Count - 1];
						
						if (DrawParticulas.ParticleDijstra(ListaPresas, ListaDepredadores, bmpImagen, grafo, pictureBox1)) {
							OrigenDijNumericUpDown.Value = newOrigen;
							DestinoDijNumericUpDown.Value = 0;
						}
					} else {
						MessageBox.Show("No Existe solucion!!!");
					}
					pictureBox1.Refresh();
				} else {
					MessageBox.Show("Origen y Destino Iguales!!!");
				}
			}else{
				MessageBox.Show("Origen o Destino Incorrecto");
			}
		}  // ACT 5
		
		void ACT1Click(object sender, EventArgs e)
		{
			if(analizoImagen){
				groupBoxACT1.Visible = true;
				groupBoxACT2.Visible = false;
				groupBoxACT3.Visible = false;
				groupBoxACT4.Visible = false;
				groupBoxACT5.Visible = false;
				listBoxCENTROS.DataSource = Lista_Circulos;
				pictureBox1.BackgroundImage = bmpCentros;
			}else{
				MessageBox.Show("No se analizo una imagen");
			}
		}
		
		void ACT2Click(object sender, EventArgs e)
		{
			if(analizoImagen){
				groupBoxACT1.Visible = false;
				groupBoxACT2.Visible = true;
				groupBoxACT3.Visible = false;
				groupBoxACT4.Visible = false;
				groupBoxACT5.Visible = false;
				bmpImagen = new Bitmap(bmpRespaldo);
				pictureBox1.BackgroundImage = bmpImagen;
				clearVisualElements();
				GenerarTreeView(grafo);
			}else{
				MessageBox.Show("No se analizo una imagen");
			}
		}
		
		void ACT3Click(object sender, EventArgs e)
		{
			if(analizoImagen){
				groupBoxACT1.Visible = false;
				groupBoxACT2.Visible = false;
				groupBoxACT3.Visible = true;
				groupBoxACT4.Visible = false;
				groupBoxACT5.Visible = false;
				bmpImagen = new Bitmap(bmpRespaldo);
				pictureBox1.BackgroundImage = bmpImagen;
			}else{
				MessageBox.Show("No se analizo una imagen");
			}
		}
		
		void ACT4Click(object sender, EventArgs e)
		{
			if(analizoImagen && grafo.GetListaVertices().Count > 1){
				groupBoxACT1.Visible = false;
				groupBoxACT2.Visible = false;
				groupBoxACT3.Visible = false;
				groupBoxACT4.Visible = true;
				groupBoxACT5.Visible = false;
				bmpImagen = new Bitmap(bmpRespaldo);
				pictureBox1.BackgroundImage = bmpImagen;
				clearVisualElements();
			}else{
				MessageBox.Show("No se analizo una imagen");
			}
		}
		
		void ACT5Click(object sender, EventArgs e)
		{
			if(analizoImagen){
				groupBoxACT1.Visible = false;
				groupBoxACT2.Visible = false;
				groupBoxACT3.Visible = false;
				groupBoxACT4.Visible = false;
				groupBoxACT5.Visible = true;
				bmpImagen = new Bitmap(bmpRespaldo);
				pictureBox1.BackgroundImage = bmpImagen;
			}else{
				MessageBox.Show("No se analizo una imagen");
			}
		}
		
	}
}
