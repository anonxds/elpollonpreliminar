create table usuarios
(
usuario varchar(30),
contraseña varchar(30),
rol varchar(30),
)
select * from usuarios
insert into usuarios values('alexis','1234','administrador');
drop table usuarios;
select usuario,contraseña,rol from usuarios where usuario='alexis';
delete usuarios where usuario='alexis' and rol!='administrador';

create table clientes(
id int primary key identity(1,1),
cliente varchar(30),
descripcion varchar(30),
coste int,
)
insert into clientes values('cesar','algo vendido',2);
select * from clientes;
drop table clientes;

create table ventas(
id int primary key identity(1,1),
TipoDePollo varchar(30),
Coste int,
Extras varchar(30),
FechadeVenta varchar(30),
)
TRUNCATE table ventas; 
insert into ventas values('asado',20,'algo','28');
select * from ventas;

create table almacen(
id int primary key identity(1,1),
TipoDePollo varchar(30),
cantidaddepollo int,
tortillas varchar(30),
chiles varchar(30),
)
insert into almacen values('asado',20,'maiz','toreados');


-----------------------------------------------
create table componentes(
id int primary key identity(1,1),
pantalla varchar(30),
pantallacost int,
pantallacant int,
memoria int,
memcosto int,
memcant int,
almacenamiento int,
almacosto int,
almacant int,
camara int,
camcosto int,
camcant int,
accesorio varchar(30),
acccosto int,
acccant int,
)
insert into componentes values('9 pulgadas',100,10,12,20,25,120,40,5,48,50,10,'Audifonos',20,18);
insert into componentes values('6 pulgadas',50,5,8,15,25,64,30,5,28,40,10,'Nada',0,0);
insert into componentes values('4 pulgadas',35,8,6,10,10,32,20,3,18,30,5,'Case',15,8);
insert into componentes values('14 pulgadas',20,5,8,1,14,30,58,58,5,12,55,'dfgh',12,5);

update componentes set memcant=(memcant-1) where id =2;

delete componentes where id=4;
update componentes set memoria=1,memcosto=2,almacenamiento=3,almacosto=4,camara=5,camcosto=6,accesorio='algo',acccosto=8 where id =4;
select * from componentes

DBCC CHECKIDENT ('componentes', RESEED,1)
TRUNCATE TABLE ventas;
select pantallacost from componentes where pantalla='14 pulg'

declare @max int
select @max=max([Id])from componentes
if @max IS NULL   
  SET @max = 0
DBCC CHECKIDENT ('componentes', RESEED,@max);

declare @max int select @max=ISNULL(max([Id]),0) 
from componentes; DBCC CHECKIDENT (componentes, RESEED, @max );

DELETE FROM componentes
DBCC CHECKIDENT ('componentes', RESEED, 0)

drop table componentes;
select memoria from componentes where memoria = 6

create table suscriptores(
correo varchar(50)
)
insert into suscriptores values('aleksxo08@gmail.com')
insert into suscriptores values('alexis.chavez17@tectijuana.edu.mx')
drop table suscriptores
delete suscriptores where correo='aleksxo08@gmail.com';
select * from suscriptores;