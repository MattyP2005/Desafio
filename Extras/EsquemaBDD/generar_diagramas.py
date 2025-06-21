from graphviz import Digraph

dot = Digraph(comment='Esquema BDD')

# Tablas
dot.node('Conductor', 'Conductor\nId (PK)\nNombre\nLicencia\nFecVencimiento')
dot.node('Camion', 'Camion\nId (PK)\nMarca\nModelo\nAño\nPlaca\nKilometraje\nConductorId (FK)')
dot.node('Taller', 'Taller\nId (PK)\nNombre\nCiudad\nCapacidadMaxima')
dot.node('Mantenimiento', 'Mantenimiento\nId (PK)\nCamionId (FK)\nTallerId (FK)\nFecha\nTipo')
dot.node('SensorLog', 'SensorLog\nId (PK)\nCamionId (FK)\nKilometraje\nEstado\nFechaHora')
dot.node('Alerta', 'AlertaMantenimiento\nId (PK)\nCamionId (FK)\nFecha\nMensaje\nEsCritica')

# Relaciones
dot.edge('Camion', 'Conductor', label='FK')
dot.edge('Mantenimiento', 'Camion', label='FK')
dot.edge('Mantenimiento', 'Taller', label='FK')
dot.edge('SensorLog', 'Camion', label='FK')
dot.edge('Alerta', 'Camion', label='FK')

# Generar imagen
dot.render('esquema_bdd', format='png', cleanup=True)
print("✅ Imagen generada: esquema_bdd.png")