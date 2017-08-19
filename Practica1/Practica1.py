__author__ = "Jose"
__date__ = "$Ago 6, 2017 11:41:07 AM$"
import json, requests
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
			print ip
			if aux.ip==ip:
					
				return aux.carnet
				break
			else:
				aux= aux.siguiente
				

	
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
		self.size = 0
	def isempty(self):
		return len(self.cola) == 0
	def push(self, operacion, ip,postorden):
		self.cola += [operacion+"$"+ip+"$"+postorden]
		self.size += 1
	def pop(self):
		if self.isempty():
			print("La cola esta vacia")
		else:
			self.cola = [self.cola[i] for i in range(1,self.size())]
			self.size -=1
	def printcola(self):
		n = self.size-1
		while n>-1:
			print(self.cola[n])
			n-=1
	def NextInCola(self):
		n = self.size-1
		return self.cola[n] +"$"+str(n)		

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
		print str(self.top)
		return self.top

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
		if(dato=='^'):
			prioridadop=3
			return prioridadop
		elif(dato=='*'):
			prioridadop=2
			return prioridadop
		elif(dato=='/'):
			prioridadop=2
			return prioridadop
		elif(dato=='+'):
			prioridadop=1
			return prioridadop
		elif(dato=='-'):
			prioridadop=1
			return prioridadop
		else:
			return 0
		

	def pripila(self,dato):
		
		if(dato=='*'):
			prioridadop=2
			return prioridadop
		elif(dato=='/'):
			prioridadop=2
			return prioridadop
			
		elif(dato=='+'):
			prioridadop=1
			return prioridadop
		elif(dato=='-'):
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
					self.push(EI[i])
				else:
					self.push(EI[i])
			if (EI[i] == ')'):
				if (self.pila):
					dato= self.pop()
					while (self.pila and dato != '('):
						cadenapostorden += str(dato) 
						dato = self.pop()
						 
		while self.pila:
			cadenapostorden += str(self.pop()) 								
		return cadenapostorden	
			  
				
					
		 
			
							

class ConsolaDeEjecucion: 
	
	 def calculadora_polaca(self,elementos):
	 	cadenaconsola=""
		p=Pila()
		for elemento in elementos:

			 
			 try:
				numero = int(elemento)
				p.apilar(numero)
				cadenaconsola += "_Push "+ str(numero)
			 except ValueError:
					if elemento not in "+-*/ %" or len(elemento) != 1:
						raise ValueError("Operando invalido "+ elemento)
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

@app.route('/mensaje',methods=['POST']) 
def h4():
	ip= request.environ['REMOTE_ADDR']
	oper = request.form['inorden']
	
	cola.push(oper,ip,convertir.ConversionAPostFija(oper))
	
	return "True"

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

@app.route('/conectado', methods= ['GET'])
def h1():
	return "201212644"
@app.route('/ActualizarCola', methods= ['GET'])
def h5():
	datos= cola.NextInCola()
	datos= datos.split("$")
	
	carnet = lista.getCarnet(datos[1].strip())
	
	resultados= resolver.calculadora_polaca(datos[2])
	

   
	return cola.NextInCola()+"$"+str(carnet)+"$"+resultados

@app.route('/dashboard', methods= ['POST'])
def h2():
	f = str(request.form)

	return ala.printListaPrimeroUltimo()


@app.route('/hola') 
def he():
	return "hola Mundo"

if __name__ == "__main__":
  app.run(debug=True, host='192.168.1.5')					

