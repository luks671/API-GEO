# API-GEO
Rabbit --> la finalidad del proyecto es consumir del exchange los registros ya procesados y actualizar la base con las coordenadas y estado.
           Es totalmente independiente del resto de los proyectos, posee su propia capa de mapeamiento de datos. No se reutilizo el proyecto
           Persistencia porque no es recomendable compartir el contexto entre subprocesos.

Persistencia --> Realiza el mapeamiento de datos que utilizara la Api Geo

Entity --> Contiene las entidades de la BD

API GEO --> Proyecto con los endpoint de creación y consulta
