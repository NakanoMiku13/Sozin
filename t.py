import random
import json

# Listas de nombres y apellidos
first_names = [
    "Carlos", "Lucia", "Jorge", "Ana", "Miguel", "Sofia", "Manuel", "Carmen",
    "Pedro", "Isabel", "Raul", "Laura", "Luis", "Jose", "Maria", "Juan", 
    "Marta", "Antonio", "Paula", "Francisco", "Elena", "David", "Patricia",
    "Ricardo", "Sandra", "Fernando", "Lorena", "Enrique", "Silvia", "Alberto"
]

last_names = [
    "Garcia", "Fernandez", "Perez", "Lopez", "Rodriguez", "Gonzalez", "Diaz",
    "Hernandez", "Martinez", "Romero", "Sanchez", "Ruiz", "Castro", "Vargas",
    "Ortega", "Ramos", "Cruz", "Ortiz", "Medina", "Vega", "Marquez", "Guerrero",
    "Mendoza", "Soto", "Reyes", "Flores", "Rojas", "Cabrera", "Suarez", "Torres"
]

types = [
    "Sargento de Policia", "Teninente de Bombero", "Bombero", "Recluta Bombero", 
    "Capitan Bombero", "Jefe de batallon", "Teninente de Policia", "Oficial de Policia",
    "Paramedico Jefe", "Paramedico", "Recluta Paramedico", "Guarda bosques", "Jefe Guarda Bosques"
]

schedules = ["Matutino", "Mixto", "Vespertino"]

data = []
import requests
# Generar 10 entradas por cada tipo
for type in types:
    for _ in range(1000):
        first_name = random.choice(first_names)
        last_name = random.choice(last_names)
        full_name = f"{first_name} {last_name}"
        
        entry = {
            "Name": full_name,
            "Latitude": random.uniform(-90, 90),
            "Longitude": random.uniform(-180, 180),
            "Schedule": random.choice(schedules),
            "Available": True,
            "Type": type,
            "Operative": random.choice([True, False])
        }
        req = requests.post('http://localhost:5004/v1/Set/Personal', json=entry)
        print(req.status_code, entry)

# Imprimir el JSON generado
