EXEC sp_RENAME 'ReciboCafePergamino.ProductorManual' , 'EsProductorManual', 'COLUMN'


alter table libros
  add autor varchar(20) not null default 'Desconocido'