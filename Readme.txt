Las instruccione spara correr la api son muy sencillas, clone el proyecto, abra visual studio y abra el proyecto en cuestion , solo dele click en el boton verde en la parte superior central de su pantalla, seleccionado http o https
estos on los endpoints y los body con los que se recomienda probar :


NOTAS IMPORTANTES :

RECUERDE QUE AL MOMENTO DE PROBAR LA API EN SU PC DEBE CAMBIARLE EL VALOR AL CONNECTION STRING , POR LOS DATOS DE SU USUARIO Y CONTRASEÑA EN CASO DE REQUERIR
RECUERDE QUE ESTO FUE PROBADO EN LOCALHOST, ESPECIFICAMENTE EL PUERTO 5118, DEBERA CAMBIAR LOS ENDPOINTS EN POSTAMN SI LO ESTA CORRIENDO EN OTRO PUERTO



Creacion de clientes:

tipo endpoint: Post
Endpoint :http://localhost:5118/api/clientes
Body: 
{
  "nombre": "Brayan",
  "email": "Brayan@gmail.com"
}


productos con filtros:

tipo endpoint: GET
Endpoint: http://localhost:5118/api/productos?precioinicial=2000&preciofinal=50000&minimum_stock=1
Nota: las querys, son opcionales, si no se coloca ninguna ejemplo(http://localhost:5118/api/productos) se pondran unos valores por defecto, precio inicial 0, peecio final 1000000000 y cantidad minima 0, por tanto se pueden usar los 3 querys o unicamente de a uno o de a 2


Actualizacion de precio y de estock de productos :

Tipo endpoint : PUT
Endpoint :http://localhost:5118/api/productos/7 (aca donde esta el 7 va el numero del producto)
Body:
{
  "precio": 50000,
  "stock": 10
}



Traer pedidos detalladamente:

tipo endpoint: GET
Endpoint: http://localhost:5118/api/pedidos/1 (aca va el id del pedido a consultar)



DDL BASE DE DATOS SQL SERVER CON DATOS DE PRUEBA (Se recomienda que al crear la bd ud mismo asigne algunos valores de prueba para que lo testee todo correctamente )


Create database PruebaBF;

use PruebaBF;

Create table Clientes(
id int identity primary key,
Nombre varchar(100),
Email varchar(100),
FechaCreacion datetime default Current_Timestamp
)

Create table Productos(
id int identity primary key,
Nombre varchar(100),
Precio decimal,
Stock int,
FechaCreacion datetime default Current_Timestamp
);

Create table Pedidos(
id int identity primary key,
ClientId int,
FechaPedido  datetime,
Total decimal
Foreign key (ClientId) references Clientes(id)
);

create table PedidoProductos(
PedidoId int,
ProductoId int,
Cantidad int,
Foreign key (PedidoId) references Pedidos(id),
Foreign key (ProductoId) references Productos(id)
);


insert into Clientes(Nombre,Email,FechaCreacion) values('Brayan','BrayanFigueroajerez@gmail.com',CURRENT_TIMESTAMP); 
insert into Productos(Nombre,Precio,Stock) values ('Pan bimbo',5000,40);
insert into Productos(Nombre,Precio,Stock) values ('Pan la rosita',2000,10);
insert into Pedidos(ClientId,FechaPedido,Total) values (1,CURRENT_TIMESTAMP,50000)
insert into PedidoProductos(PedidoId,ProductoId,Cantidad) values (1,1,10);





