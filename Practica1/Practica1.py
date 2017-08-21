__author__ = "Jose"
__date__ = "$Ago 6, 2017 11:41:07 AM$"
import json, requests, graphviz, os
class Nodo:
	def __init__(self):
		self.ip = None
		self.carnet= 0
		self.estado=None
		self.siguiente=None
		
	
class Lista:

	def __init__(self):
		self.raiz = Nodo()
		
	def insertar(self,nodo):
		if self.raiz.ip == None :
			self.raiz = nodo
		else :
			aux = self.raiz
			while True :
				if aux.ip == nodo.ip:
					aux.carnet= nodo.carnet
					aux.estado= nodo. estado
					break;
				if aux.siguiente == None:
					aux.siguiente = nodo
					break 
				else :
					if aux.ip == nodo.ip:
						aux.carnet= nodo.carnet
						aux.estado= nodo. estado
					aux = aux.siguiente
	
	def consultar(self):
		aux = self.raiz
		if aux.ip == None:
			print "Lista vacia"
		else :
			print aux.ip
			print aux.carnet
			print aux.estado
			while aux.siguiente != None:
				aux = aux.siguiente
				print aux.ip
				print aux.carnet
				print aux.estado
	
	def getCarnet(self, ip):
		aux= self.raiz
		while aux != None:
			
			if aux.ip==ip:
					
				return aux.carnet
				break
			else:
				aux= aux.siguiente
	def getIp(self):
		aux= self.raiz
		cadena=""
		while aux!= None:
			cadena+="$"+aux.ip 
			aux= aux.siguiente
		return cadena		

	
	def eliminar(self, ipeliminar):
		aux = self.raiz
		aux2 = self.raiz
		if aux.ip == None:
			print "No hay elementos que se puedan eliminar"
		else:
			elemento = ipeliminar
			if aux.nombre == elemento :
				if aux.siguiente == None:
					self.raiz = Nodo()
				else :
					self.raiz = aux.siguiente
			else:
				t = True
				while aux.siguiente != None and t:
					aux = aux.siguiente
					if aux.ip == elemento :
						aux2.siguiente = aux.siguiente
						aux = None
						t = False
						break
					aux2 = aux2.siguiente
				if t==True:
					print "Nombre no encontrado"
			
class Cola:

	def __init__(self):
		self.cola = []
		self.size = -1
	def isempty(self):
		return len(self.cola) == 0
	def push(self, operacion, ip,postorden):
		self.cola += [operacion+"$"+ip+"$"+postorden]
		self.size += 1
		print self.size
	def popcola(self):
		if self.isempty():
			print("La cola esta vacia")
		else:
			i=0
			while (i<self.size):
				self.cola[i] = self.cola[i+1]
				i=i+1
			
			self.cola.pop()
			self.size -=1
			
	def printcola(self):
		n = self.size-1
		while n>-1:
			print(self.cola[n])
			n-=1
	def NextInCola(self):
		
		n = self.size
		return self.cola[0] +"$"+str(n)	
	
	def reporte(self):

		i=self.size
		verificar= False
		
		grafico="digraph A {\n"
		while (i!=0 and i!=-1):
			verificar= True
			a=i-1
			cadena= self.cola[i]
			cadena1= self.cola[a]

			cadena= cadena.strip()
			cadena1= cadena1.strip()

			cadena= cadena.replace('\t', '')
			cadena= cadena.replace('\r', '')
			cadena= cadena.replace('\n', '')

			cadena1= cadena1.replace('\t', '')
			cadena1= cadena1.replace('\r', '')
			cadena1= cadena1.replace('\n', '')

			cadena= cadena.split("$")
			cadena1= cadena1.split("$")

			grafico+= '"'+cadena[1]+": "+cadena[0]+'"'+"->"+ '"'+cadena1[1]+": "+cadena1[0]+'"'+"\n"
			
		
			
			i=i-1
		if i==0 and verificar==False:
			cadena= self.cola[i]
			cadena= cadena.strip()
			

			cadena= cadena.replace('\t', '')
			cadena= cadena.replace('\r', '')
			cadena= cadena.replace('\n', '')

			cadena= cadena.split("$")

			grafico+= '"'+cadena[1]+": "+cadena[0]+'"'
		if i==-1:
			
			grafico+= '"'+"Null"+'"'			
		grafico+="}"
		archivo= open('grafo1.dot','w')	
		archivo= open('grafo1.dot','a')
		archivo.write(grafico)
		archivo.close()
		os.system('dot grafo1.dot -o grafo1.png -Tpng -Grankdir=LR')


		os.startfile('grafo1.png')	

		
				

class Pila:
	

	def __init__(self):

		self.items=[]
		self.top=0
	

	def esPilaVacia(self):
		return self.items == []
	def apilar(self,dato):
		self.items.append(dato)
		self.top+=1
	def desapilar(self):
		
			self.top-=1
			return self.items.pop()
			
	def PilaSize(self):
		
		return self.top

class NodoEnlazado:
	def __init__(self,ip,carnet,inorden,postorden,resultado):
		self.siguiente=None
		self.anterior=None
		self.ip=ip
		self.carnet=carnet
		self.inorden=inorden
		self.postorden=postorden
		self.resultado= resultado
	
class ListaDoblementeEnlazada:
	def __init__(self):
		self.cabeza= None
		self.cola=None
	def isemptry(self):
		if self.cabeza==None:
			return True
		else:
			return False	
	def InsertarPrimero(self, nodo):
		temporal= nodo
		if self.isemptry()==True:
			self.cabeza= temporal
			self.cola=temporal
		else:
			temporal.siguiente= self.cabeza
			self.cabeza.anterior=temporal
			self.cabeza=temporal
	def PrintFromCabeza(self):
		temporal=self.cabeza
		cadena=""
		while temporal!=None:
			cadena += temporal.ip + "$"+temporal.carnet+"$"+temporal.inorden+"$"+ temporal.postorden+"$" +temporal.resultado+"@"
			temporal = temporal.siguiente
		return cadena	
	def PrintFromCola(self):
		temporal= self.cola
		cadena=""
		while temporal!= None:
			cadena += temporal.ip + "$"+temporal.carnet+"$"+temporal.inorden+"$"+ temporal.postorden+"$" +temporal.resultado+"@"
			temporal = temporal.anterior
		return cadena	

class Conversion:
	def __init__(self):

		
		
		
		
		self.pila=[]
		self.EP=[]
		self.tope=0

	

	

	def push(self,dato):
		self.tope+=1
		self.pila.append(dato)
		

	def pop(self):
		self.tope-=1
		return self.pila.pop()

	def infijo(self,dato):
		dato= dato.replace("@",'')
		
		if(dato=="^"):
			prioridadop=3
			return prioridadop
		elif(dato=="*"):
			prioridadop=2
			return prioridadop
		elif(dato=="/"):
			prioridadop=2
			return prioridadop
		elif(dato=="+"):
			prioridadop=1
			return prioridadop
		elif(dato=="-"):
			prioridadop=1
			return prioridadop
		else:

			return 0
		

	def pripila(self,dato):

		dato= dato.replace("@",'')
		
		if(dato=="*"):
			prioridadop=2
			return prioridadop
		elif(dato=="/"):
			prioridadop=2
			return prioridadop
			
		elif(dato=="+"):
			prioridadop=1
			return prioridadop
		elif(dato=="-"):
			prioridadop=1
			return prioridadop
		else:
			return 4	
		
	def ConversionAPostFija(self,operacion):
		EI=list(operacion)

		cadenapostorden=""
		for i in range(len(EI)):
			
			if EI[i].isdigit() :
				cadenapostorden+= str(EI[i])
				
				
			if(EI[i]=='+' or EI[i]=='-' or EI[i]=='*' or EI[i]=='/' or EI[i]=='^' or EI[i]=='('):
									  #EI es diferente a ')'
				if (self.pila):
					dato = self.pop()
					
					while (self.pila and self.infijo(dato) >= self.pripila(EI[i]) ):

						cadenapostorden += str(dato) 
						dato = self.pop()
					self.push(dato)
					self.push("@"+EI[i])
					cadenapostorden+="@"
				else:
					self.push("@"+EI[i])
					cadenapostorden+="@"
			if (EI[i] == ')'):
				if (self.pila):
					dato= self.pop()
					
					while (self.pila and dato != "@("):
						cadenapostorden +=str(dato)
						dato = self.pop()
						 
		while self.pila:
			cadenapostorden += str(self.pop()) 							
		return cadenapostorden	
			  
				
					
		 
			
							

class ConsolaDeEjecucion: 
	
	 def calculadora_polaca(self,elementos):
		cadenaconsola=""
		p=Pila()
		elementos = elementos.strip()
		
		elementos= elementos.split("@")
		for elemento in elementos:
			
		  if elemento!='':

		  

			 
			 try:
				numero = float(elemento)
				p.apilar(numero)
				cadenaconsola += "_Push "+ str(numero)
			 except ValueError:
					if elemento not in "+-*/ %" or len(elemento) != 1:
						raise ValueError("Operando invalido "+ str(elemento))
					try:
						 
						 a1 = p.desapilar()
						 cadenaconsola += "_Pop "+str(a1)
						 a2 = p.desapilar()
						 cadenaconsola += "_Pop "+str(a2)
					except ValueError:     
						 cadenaconsola += "\Error pila faltan operandos"
						 raise ValueError("Faltan operandos")
					resultado=0     
					if elemento=="+": 
 
				
						 resultado = a2 + a1
						 cadenaconsola += "_" + str(a2) +"+"+ str(a1)+"="+str(resultado)
					elif elemento == "-":     
					  
				
						 resultado = a2 - a1
						 cadenaconsola += "_"+ str(a2) +"-"+ str(a1)+"="+str(resultado)
					elif elemento == "*":     
				
						 resultado = a2 * a1
						 cadenaconsola += "_"+ str(a2) +"*"+ str(a1)+"="+str(resultado)
					elif elemento == "/":     
				
						 resultado = a2 / a1
						 cadenaconsola += "_"+str(a2) +"/"+ str(a1)+"="+str(resultado)
					elif elemento == "%":     
			   
						 resultado = a2 % a1
						 cadenaconsola += +"_"+ str(a2) +"%"+ str(a1)+"="+str(resultado)
					#print "Push ", resultado  
					p.apilar(resultado)
					cadenaconsola += "_Push "+str(resultado) 
		res=0
		if p.PilaSize()==1:
			res=p.desapilar()
		return cadenaconsola +"$"+ str(res)
						
			 
	 
					
			   
from flask import Flask, request, render_template
from werkzeug.datastructures import OrderedMultiDict, ImmutableOrderedMultiDict

app = Flask("Web Service")
lista = Lista()
cola = Cola()
resolver = ConsolaDeEjecucion()
convertir = Conversion()
listaenlazada= ListaDoblementeEnlazada()
pila= Pila()
@app.route('/mensaje',methods=['POST']) 
def h4():
	
	ip= request.environ['REMOTE_ADDR']
	oper = request.form['inorden']
	
	cola.push(oper,ip,convertir.ConversionAPostFija(oper))
	
	return "true"

@app.route('/guardarip',methods=['POST']) 
def h():
	carnet= request.form['carnet']
	ip= request.form['ip']
	estado = request.form['estado']
	
	nodo = Nodo()
	nodo.ip= ip
	nodo.carnet= carnet
	nodo.estado= estado

	lista.insertar(nodo)
	lista.consultar()

	return "True" 
@app.route('/respuesta',methods=['POST']) 
def h7():
	
	ip= request.environ['REMOTE_ADDR']
	carnet = lista.getCarnet(ip)
	inorden= request.form['inorden']
	postorden= request.form['postorden']
	resultado= request.form['resultado']
	nodo= NodoEnlazado(ip,carnet,inorden,postorden,resultado)
	
	listaenlazada.InsertarPrimero(nodo)
	cola.popcola()

	

	return "true" 

@app.route('/conectado', methods= ['GET'])
def h1():
	return "201212644"

@app.route('/ListaRespuestaReciente', methods= ['GET'])
def h9():
	cadena= listaenlazada.PrintFromCabeza()
	return cadena
@app.route('/ListaRespuestaUltimo', methods= ['GET'])
def h10():
	cadena= listaenlazada.PrintFromCola()
	
	return cadena	

@app.route('/ActualizarCola', methods= ['GET'])
def h5():
	datos= cola.NextInCola()
	datos= datos.split("$")
	
	carnet = lista.getCarnet(datos[1].strip())
	
	resultados= resolver.calculadora_polaca(datos[2])
	

   
	return cola.NextInCola()+"$"+str(carnet)+"$"+resultados
@app.route('/Reporte', methods= ['GET'])
def h12():
	cola.reporte()
	
	return "True"
@app.route('/GetIp', methods= ['GET'])
def h13():
	print lista.getIp()
	
	return lista.getIp()		



@app.route('/hola') 
def he():
	return "hola Mundo"

if __name__ == "__main__":
  app.run(debug=True, host='192.168.1.5')					

