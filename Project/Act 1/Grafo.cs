/*
 * Created by SharpDevelop.
 * User: EndUser
 * Date: 10/09/2018
 * Time: 11:07 p. m.
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
	/// Description of Grafo.
	/// </summary>
	/// 
	
	// ----------------------------> Clase Grafo <-----------------------------------
	public class Grafo
	{
		// disable once FieldCanBeMadeReadOnly.Local
		List<Vertice> listaVertices;

		public Grafo(List<Circulo> listaCirculos)
		{
			listaVertices = new List<Vertice>();
			
			foreach (Circulo auxCirculo in listaCirculos) {
				// disable once SuggestUseVarKeywordEvident
				Vertice nuevoVertice = new Vertice(auxCirculo);
				listaVertices.Add(nuevoVertice);
			}
			
		}
		
		public List<Vertice> GetListaVertices()
		{
			return listaVertices; // lista de vertices
		}
		
		public Vertice GetVerticeI(int i)
		{
			return listaVertices[i];
		}
		
		public void SolutionTravelWidth(List<int> Recorrido, int Origen)
		{
			Recorrido.Clear();
			int Actual;
			Queue <int> Cola = new Queue<int>();
			List <int> Visitados = new List<int>();
			
			List<int> Camino1 = new List<int>();
			List<int> Camino2 = new List<int>();
			
			Cola.Enqueue(Origen);
			
			while (Cola.Count > 0) {
				
				Actual = Cola.Peek();
				Cola.Dequeue();
				
				if (VertexVisited(Visitados, Actual)) {
					if (Recorrido.Count > 1) {
						WayWidth(Camino1,Origen,Recorrido[Recorrido.Count-1]);
						WayWidth(Camino2,Origen,Actual);
						removeDuplicateWidth(Camino1,Camino2);
						Recorrido.AddRange(Camino1);
						Recorrido.AddRange(Camino2);
						Recorrido.Add(Actual);
						Visitados.Add(Actual);
					}
					else{
						Recorrido.Add(Actual);
						Visitados.Add(Actual);	
					}
					
					foreach (Arista Sig in listaVertices[Actual].GetListaAristas()) {
						if (VertexVisited(Visitados, Sig.GetDestino().GetOrigen().GetID())) {
							Cola.Enqueue(Sig.GetDestino().GetOrigen().GetID());
						}
					}
				}
				Camino1.Clear();
				Camino2.Clear();
			}
		} // -------------------------- RECORRIDOS AMPLITUD Y PROFUNDIDAD
		
		public void SolutionTravelDepth(List<int> Recorrido, int Origen)
		{
			int Actual;
			Stack <int> Camino = new Stack<int>();
			Stack <int> Pila = new Stack<int>();
			List <int> Visitados = new List<int>();
			
			Pila.Push(Origen);
			
			while (Pila.Count > 0) {
				
				Actual = Pila.Peek();
				Pila.Pop();
				
				if (VertexVisited(Visitados, Actual)) {
					if (Actual != Origen) {
						if (listaVertices[Recorrido[Recorrido.Count - 1]].findArista(Actual)) { // Si el vertice anterior tiene a actual como arista a actual
							Recorrido.Add(Actual);
							Visitados.Add(Actual);
							Camino.Push(Actual);
						} else {
							addMissingTravelDepth(Recorrido, Actual, Camino);
							Recorrido.Add(Actual);
							Visitados.Add(Actual);
							Camino.Push(Actual);
						}
					} else {
						Recorrido.Add(Actual);
						Visitados.Add(Actual);
						Camino.Push(Actual);
					}
					
					foreach (Arista Sig in listaVertices[Actual].GetListaAristas()) {
						if (VertexVisited(Visitados, Sig.GetDestino().GetOrigen().GetID())) {
							Pila.Push(Sig.GetDestino().GetOrigen().GetID());
						}
					}
				}
			}
		}
		
		public void TravelDepth(List<int> Recorrido, int Origen)
		{
			int Actual;
			Stack <int> Pila = new Stack<int>();
			List <int> Visitados = new List<int>();
			
			Pila.Push(Origen);
			
			while (Pila.Count > 0) {
				
				Actual = Pila.Peek();
				Pila.Pop();
				
				if (VertexVisited(Visitados, Actual)) {
					Recorrido.Add(Actual);
					Visitados.Add(Actual);
					
					foreach (Arista Sig in listaVertices[Actual].GetListaAristas()) {
						if (VertexVisited(Visitados, Sig.GetDestino().GetOrigen().GetID())) {
							Pila.Push(Sig.GetDestino().GetOrigen().GetID());
						}
					}
				}
			}
		}
		
		public void TravelWidth(List<int> Recorrido, int Origen)
		{
			int Actual;
			Queue <int> Cola = new Queue<int>();
			List <int> Visitados = new List<int>();
			
			Cola.Enqueue(Origen);
			
			while (Cola.Count > 0) {
				
				Actual = Cola.Peek();
				Cola.Dequeue();
				
				if (VertexVisited(Visitados, Actual)) {
					Recorrido.Add(Actual);
					Visitados.Add(Actual);
					
					foreach (Arista Sig in listaVertices[Actual].GetListaAristas()) {
						
						if (VertexVisited(Visitados, Sig.GetDestino().GetOrigen().GetID())) {
							Cola.Enqueue(Sig.GetDestino().GetOrigen().GetID());
						}
						
					}
				}
			}
		}
		
		void addMissingTravelDepth(List<int> Recorrido, int Missing, Stack<int> Pila)
		{
			int Actual;
			Pila.Pop();
			while (true) {
				Actual = Pila.Peek();
				//MessageBox.Show(Actual.ToString());
				Recorrido.Add(Actual);
				if (listaVertices[Actual].findArista(Missing)) {
					break;
				} else {
					Pila.Pop();
				}
			}
		}
		
		void WayWidth(List<int> Recorrido, int Origen, int Destino)
		{
			Stack <int> StackOrigen = new Stack<int>();
			Stack <int> StackDestino = new Stack<int>(); // Inicializar pilas de origen-destino
			
			Queue <int> Cola = new Queue<int>();
			List <int> Visitados = new List<int>();
			
			int Actual;
			
			Boolean Fin = false;
			
			Cola.Enqueue(Origen);
			
			while (Cola.Count > 0) {
				
				Actual = Cola.Peek();
				Cola.Dequeue();
				
				if (VertexVisited(Visitados, Actual)) {
					
					Visitados.Add(Actual);
					
					foreach (Arista Sig in listaVertices[Actual].GetListaAristas()) {
						if (VertexVisited(Visitados, Sig.GetDestino().GetOrigen().GetID())) {
							
							Cola.Enqueue(Sig.GetDestino().GetOrigen().GetID());
							//MessageBox.Show("Origen: " + listaVertices[Actual].GetOrigen().GetID() + "   Destino: " + Sig.GetDestino().GetOrigen().GetID());
							StackOrigen.Push(listaVertices[Actual].GetOrigen().GetID());
							StackDestino.Push(Sig.GetDestino().GetOrigen().GetID());
				
							if (Sig.GetDestino().GetOrigen().GetID() == Destino && Origen != Destino) {
								GeneratePathWidth(Recorrido, StackOrigen, StackDestino);
								Fin = true;
								break;
							}
						}
					}
					
					if(Fin){
						break;
					}
				}
			}
		}
		
		void GeneratePathWidth(List<int> Recorrido, Stack<int>StackOrigen, Stack<int>StackDestino)
		{
			int Destino;

			Destino = StackDestino.Peek(); //destino de conviete en el destino actual

			while (StackDestino.Count > 0 && StackOrigen.Count > 0) {

				Recorrido.Add(Destino);

				while ((StackDestino.Count > 0 && StackOrigen.Count > 0) && Destino != StackDestino.Peek()) { //Mientras la pila no este vacia, destino de la pila y destino actual sean diferentes
					StackDestino.Pop();     // desapilar un elemento
					StackOrigen.Pop();
				}
				
				if (StackDestino.Count > 0 && StackOrigen.Count > 0) { //si la pila no esta vacia
					Destino = StackOrigen.Peek();   // destino actual es igual al tope de la pila origen
				}

			}
		}
		
		void removeDuplicateWidth(List<int> Camino1, List<int> Camino2)
		{
			for (int i = 0; i < Camino1.Count; i++) {
				for (int j = 0; j < Camino2.Count; j++) {
					if (Camino1[i] == Camino2[j]) {
						if((i+1) < Camino1.Count){
							Camino1.RemoveRange( (i+1), Camino1.Count - (i+1));
						}
						Camino2.RemoveRange(j, Camino2.Count - j);
					}
				}
			}
			Camino1.RemoveRange(0,1);
			Camino2.RemoveRange(0,1);
			Camino2.Reverse();
		}
		
		Boolean VertexVisited(List<int> Visitados, int Actual)
		{
			Boolean Continuar;
			Continuar = true;
			foreach (int i  in Visitados) {
				if (i == Actual) {
					Continuar = false;
					break;
				}
			}
			return Continuar;
		}
		
		public void Kruskal(List<Arista> KRUSKAL){
			Arista Actual = new Arista();
			int indOrg, indDes;						 // e_1, e_2
			
			List<Arista> Candidatos = new List<Arista>(); // C
			CreateListOfCandidates (Candidatos);			 // Inicializar lista de candidatos
			SortAscToDec(Candidatos);                //Sort Candidatos
			
			List<List<int>> Arbol = new List<List<int>>(); // CC
			InitializeTree(Arbol);       			 // inicializa n componentes conexos, cada componente conexo tiene un vertice diferente
			
			while(Candidatos.Count > 0){ 			 // Mientras tenga aristas
				
				Actual = Candidatos[0];  			 // La arista de menor peso
				Candidatos.RemoveRange(0,1);
				indOrg = PosicionOfVertex(Actual.GetOrigen().GetOrigen().GetID(), Arbol);
				indDes = PosicionOfVertex(Actual.GetDestino().GetOrigen().GetID(), Arbol);
				if(indOrg != indDes){
					Arbol[indOrg].AddRange(Arbol[indDes]);
					Arbol.RemoveRange(indDes,1);
					KRUSKAL.Add(Actual);
				}
			}
		} // -------------------------- PRIM Y KRUSKAL 
		
		public void Prim(List<Arista> PRIM,int Origen){
			int nVertices = 1, newOrigen;
			List<Arista> Candidatos = new List<Arista>(); 	// C
			
			CreateListOfCandidates (Candidatos);			// Inicializar lista de candidatos
			SortAscToDec(Candidatos);                		//Sort Candidatos
			
			List<string> Visitados = new List<string>();
			List<string> Arbol = new List<string>(); 		// S = Solucion
			Visitados.Add(Origen.ToString());
			Arbol.Add(Origen.ToString());
			
			while(nVertices < listaVertices.Count){ 		// Mientras tenga aristas
				Arista Actual = new Arista();
				Actual = Outgoing(Candidatos,Arbol);
				if(Actual == null){
					newOrigen = NewOrigin(Visitados);
					Arbol.Add(newOrigen.ToString());
					Visitados.Add(newOrigen.ToString());
					nVertices++;					
				}else{
					PRIM.Add(Actual);
					if(Find(Arbol,Actual.GetOrigen().GetOrigen().GetID())){
						newOrigen = Actual.GetDestino().GetOrigen().GetID();
						Arbol.Add(newOrigen.ToString());
						Visitados.Add(newOrigen.ToString());
					}else{
						newOrigen = Actual.GetOrigen().GetOrigen().GetID();
						Arbol.Add(newOrigen.ToString());
						Visitados.Add(newOrigen.ToString());
					}
					nVertices++;
				}
			}
		}
		
		Arista Outgoing(List<Arista> Candidatos, List<string> Arbol){
			Arista Aux = new Arista();
			for(int i=0; i<Candidatos.Count; i++){
				Aux = Candidatos[i];
				if(Find(Arbol,Aux.GetOrigen().GetOrigen().GetID())){
					if(!Find(Arbol,Aux.GetDestino().GetOrigen().GetID())){
						Candidatos.RemoveAt(i);
						return Aux;
					}
				}
				if(Find(Arbol,Aux.GetDestino().GetOrigen().GetID())){
					if(!Find(Arbol,Aux.GetOrigen().GetOrigen().GetID())){
						Candidatos.RemoveAt(i);
						return Aux;
					}
				}
			}
			return null;
		}
		
		Boolean Find(List<string> Arbol, int Origen){
			Boolean Existe = false;
			int ToInt;
			for(int i=0; i<Arbol.Count; i++){
				ToInt = Int32.Parse(Arbol[i]);
				if(ToInt == Origen){
					Existe = true;
				}
			}
			return Existe;
		}
		
		int NewOrigin(List<string> Visitados){
			int Origen = -1, ToInt;
			Boolean Existe;
			for(int i=0; i<listaVertices.Count; i++){
				Existe = true;
				for(int j=0; j<Visitados.Count; j++){
					ToInt = Int32.Parse(Visitados[j]);
					if(i == ToInt){
						Existe = false;
					}
				}
				if(Existe){
					Origen=i;
					break;
				}
			}
			return Origen;
		}
		
		int PosicionOfVertex(int B,List<List<int>> CC){
			int Pos = 0;
			Boolean Existe;
			for(int i=0; i<CC.Count; i++){
				Existe = false;
				for(int j=0; j<CC[i].Count; j++){
					if(B == CC[i][j]){
						Existe=true;
						break;
					}					
				}
				if(Existe){
					Pos=i;
					break;
				}
			}
			return Pos;
		}
		
		void InitializeTree(List<List<int>> CC){
			List<int> Aux;
			for(int i=0; i<listaVertices.Count; i++){
				Aux = new List<int>();
				Aux.Add(i);
				CC.Add(Aux);
			}
		}
		
		void CreateListOfCandidates(List<Arista> Candidatos){
			foreach(Vertice i in listaVertices){
				foreach(Arista j in i.GetListaAristas()){
					if(ThereIsAnEdge(Candidatos,j)){
						Candidatos.Add(j);
					}
				}
			}
		}
		
		Boolean ThereIsAnEdge(List<Arista> Candidatos,Arista Nueva){
			Boolean continuar;
			continuar  = true;
			foreach(Arista Actual in Candidatos){
				if((Actual.GetOrigen() == Nueva.GetDestino()) &&
				   (Actual.GetDestino()== Nueva.GetOrigen())){
					continuar = false;
					break;
				}
			}
			return continuar;
		}
		
		void SortAscToDec(List<Arista> Candidatos){
			Arista Aux = new Arista();
			for(int i=0; i<Candidatos.Count; i++){
				for(int j=i; j<Candidatos.Count; j++){
					if(Candidatos[i].GetDistancia() > Candidatos[j].GetDistancia() ){
						Aux = Candidatos[j];
						Candidatos[j] = Candidatos[i];
						Candidatos[i] = Aux;
					}
				}
			}
		}
		
		public Boolean SolucionProbable(int Origen, int Destino){
            Stack<int> StackOrigen = new Stack<int>();
            Stack<int> StackDestino = new Stack<int>(); // Inicializar pilas de origen-destino

            Queue<int> Cola = new Queue<int>();
            List<int> Visitados = new List<int>();

            int Actual;

            Cola.Enqueue(Origen);

            while (Cola.Count > 0)
            {

                Actual = Cola.Peek();
                Cola.Dequeue();

                if (VertexVisited(Visitados, Actual))
                {

                    Visitados.Add(Actual);

                    foreach (Arista Sig in listaVertices[Actual].GetListaAristas())
                    {
                        if (VertexVisited(Visitados, Sig.GetDestino().GetOrigen().GetID()))
                        {

                            Cola.Enqueue(Sig.GetDestino().GetOrigen().GetID());
                            StackOrigen.Push(listaVertices[Actual].GetOrigen().GetID());
                            StackDestino.Push(Sig.GetDestino().GetOrigen().GetID());

                            if (Sig.GetDestino().GetOrigen().GetID() == Destino && Origen != Destino)
                            {
                             
                                return true;
                            }
                        }
                    }
               
                }
            }

            return false;
		} // --------------------- Dijkstra
		
		public void SolutionDijkstra(List<int> Recorrido, int Origen, int Destino){
			Dijkstra Actual = new Dijkstra();
			List<Dijkstra> Candidatos = new List<Dijkstra>();
			
			inicializaDijkstra(Candidatos,Origen);
			while(!ItsSolutionDijkstra(Candidatos,Destino)){
				Actual = SeleccionDefinitivo(Candidatos);
				Actualiza(Candidatos,Actual);
			}
			
			Recorrido.Add(Candidatos[Destino].GetOrigen());
			
			for(int i = Destino; ;){
				if(Candidatos[i].GetProcedente() != -1){
					i = Candidatos[i].GetProcedente();
				}else{
					break;
				}
				Recorrido.Add(Candidatos[i].GetOrigen());
			}
			
			Recorrido.Reverse();
		}
		
		void inicializaDijkstra(List<Dijkstra> Candidatos,int Origen){
			Dijkstra Candidato;
			foreach(Vertice V in listaVertices){
				Candidato = new Dijkstra(V.GetOrigen().GetID(),-1,double.PositiveInfinity);
				Candidatos.Add(Candidato);
			}
			Candidatos[Origen].SetPeso(0);
		}
		
		Boolean ItsSolutionDijkstra(List<Dijkstra> Candidatos, int Destino){
			if(Candidatos[Destino].GetDefinitivo()){
				return true;
			}
			return false;
		}
		
		Dijkstra SeleccionDefinitivo(List<Dijkstra> Candidatos){
			Dijkstra Seleccion = new Dijkstra(-1,-1,double.PositiveInfinity);
			foreach(Dijkstra D in Candidatos){
				if(!D.GetDefinitivo()){
					if(D.GetPeso() < Seleccion.GetPeso()){
						Seleccion = D;
					}
				}
			}
			
			Candidatos[Seleccion.GetOrigen()].ChangeDefinitivo();
			return Seleccion;
		}
		
		void Actualiza(List<Dijkstra> Candidatos,Dijkstra Actual){
			Dijkstra Aux = new Dijkstra();
			foreach(Arista A in listaVertices[Actual.GetOrigen()].GetListaAristas()){
				Aux = Candidatos[A.GetDestino().GetOrigen().GetID()];
				if(Aux.GetPeso() > (Actual.GetPeso() + A.GetDistancia())){
					Aux.SetPeso(Actual.GetPeso() + A.GetDistancia());
					Aux.SetProvcedente(Actual.GetOrigen());
				}
			}
				
		}
	}
	
	// ----------------------------> Clase Vertice <-----------------------------------
	public class Vertice
	{
		List<Arista> listaAristas;
		Circulo Origen;
		
		public Vertice(Circulo Origen)
		{
			listaAristas = new List<Arista>();
			this.Origen = Origen;
		}
		
		public Vertice()
		{
			
		}
		
		public void SetListaAristas(List<Arista> listaAristas)
		{
			this.listaAristas = listaAristas;
		}
		
		public List<Arista> GetListaAristas()
		{
			return listaAristas; //lista de aristas
		}
		
		public Arista GetAristaI(int i)
		{
			return listaAristas[i];
		}
		
		public Circulo GetOrigen()
		{
			return Origen;
		}
		
		public int getPositionAristaToFind(int destinationName)
		{
			int i;
			Arista Act;
			//MessageBox.Show("Tamaño de listaAristas: " + listaAristas.Count);
			for (i = 0; i < listaAristas.Count; i++) {
				Act = listaAristas[i];
				if (Act.GetDestino().GetOrigen().GetID() == destinationName) {
					break;
				}
			}
			return i;
		}
		
		public Boolean findArista(int nameArista)
		{
			Boolean Continuar;
			Continuar = false;
			Arista Act;
			for (int i = 0; i < listaAristas.Count; i++) {
				Act = listaAristas[i];
				if (Act.GetDestino().GetOrigen().GetID() == nameArista) {
					Continuar = true;
					break;
				}
			}
			return Continuar;
		}
	}
	
	// ----------------------------> Clase Arista <-----------------------------------
	public class Arista
	{
		// disable once FieldCanBeMadeReadOnly.Local
		int Distancia;
		Vertice Origen;
		Vertice Destino;
		List<Point> listaPixel;
		
		public Arista(int Distancia, Vertice Destino, Vertice Origen,List<Point> listaPixel)
		{
			this.Distancia = Distancia;
			this.listaPixel = new List<Point>(listaPixel);
			this.Origen = Origen;
			this.Destino = Destino;
		}
		
		public Arista(int Distancia, Vertice Destino, List<Point> listaPixel)
		{
			this.Distancia = Distancia;
			this.listaPixel = new List<Point>(listaPixel);
			this.Destino = Destino;
		}
		
		public Arista()
		{
			
		}
		
		public void SetListaPixeles(List<Point> listaPixel)
		{
			this.listaPixel = listaPixel;
		}
		
		public Point GetListaPixelI(int i)
		{
			return listaPixel[i];
		}
		
		public Vertice GetDestino()
		{
			return Destino;
		}
		
		public Vertice GetOrigen(){
			return Origen;
		}
		
		public int GetDistancia()
		{
			return Distancia;
			
		}
		
		public List<Point> GetListaPixel()
		{
			return listaPixel;
		}
		
		public override string ToString()
		{
			return string.Format("O:{0}   D:{1}   -> {2}", Origen.GetOrigen().GetID(), Destino.GetOrigen().GetID(), Distancia);
		}

	}
	
}
