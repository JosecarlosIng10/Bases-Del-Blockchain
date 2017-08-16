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
	def push(self, operacion, ip):
		self.cola += [operacion+"/"+ip]
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
		return self.cola[n] +"/"+str(n)		

						


from flask import Flask, request, render_template
from werkzeug.datastructures import OrderedMultiDict, ImmutableOrderedMultiDict

app = Flask("Web Service")
lista = Lista()
cola = Cola()

@app.route('/mensaje',methods=['POST']) 
def h4():
	f= request.get_data()
	datos= f.replace("[","")
	datos=datos.replace("]","")
	datos= datos.split(",")
	cola.push(datos[1],datos[0])
	cola.printcola()
	return "True"

@app.route('/guardarip',methods=['POST']) 
def h():
	f = request.get_data()
	datos= f.replace("[","")
	datos=datos.replace("]","")
	datos= datos.split(",")
	nodo = Nodo()
	nodo.ip= datos[0]
	nodo.carnet= datos[1]
	nodo.estado= datos[2]
	lista.insertar(nodo)
	lista.consultar()
	

	return "True" 

@app.route('/conectado', methods= ['GET'])
def h1():
	return "201212644"
@app.route('/ActualizarCola', methods= ['GET'])
def h5():
	datos= cola.NextInCola()
	datos= datos.split("/")
	
	carnet = lista.getCarnet(datos[1].strip())
	
   
	return cola.NextInCola()+"/"+str(carnet)

@app.route('/dashboard', methods= ['POST'])
def h2():
	f = str(request.form)

	return ala.printListaPrimeroUltimo()


@app.route('/hola') 
def he():
	return "hola Mundo"

if __name__ == "__main__":
  app.run(debug=True, host='192.168.1.5')					

