# SAT Recruitment

El objetivo de esta prueba es refactorizar el código de este proyecto.
Se puede realizar cualquier cambio que considere necesario en el código y en los test.

## Requisitos

- Todos los test deben pasar.
- El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
- El código resultante debe ser mantenible y extensible.

## Cambios realizados

- Se cambio la estructura (ahora el proyecto cuenta con el proyecto principal y proyectos de dependencia, esto facilita el mantenimiento del código).
- Se mantuvo el endpoint para que siga funcionando los proyectos asociados.
- Se optimizo el código para un mejor funcionamiento.
- Se agrego código correspondiente a la escritura del usuario en archivo.
- Se preparo el código para el funcionamiento con docker.
- Se ajustaron los test para funcionar con el nuevo código.
- Se agregaron nuevos test.
- Se agregaron Github Actions para probar el build del código y probar los cambios en el dockerfile.

## Posibles futuros cambios

- Agregar un nuevo endpoint para obtener un objeto y no pasar los datos por parámetro.
- Utilizar una base de datos para mantener los usuarios.
- Utilizar herramientas de métricas.
- Utilizar herramientas para verificar el estado de la aplicación (health)

## Division de la arquitectura del proyecto

primero se dividió el proyecto en la aplicación (src) y en los test (test) para organizar todo.

SRC

- Api: es la parte donde se exponen los endpoint y no debería tener lógica.
- Application: es la parte donde se expone la lógica general y se devuelve el resultado correspondiente.
- Domain: es la parte donde solo tenemos estructuras de datos y sin nada de lógica.
- Infrastructure: es la parte donde se tiene la lógica mas contundente y especifica, generalmente estas se encuentran en servicios.

Todos estos proyectos tienen sus dependencias y los servicios son pasados a traves de inyección de dependencia.

## Créditos

- Mariano Damian Abadie [LinkedIn](https://www.linkedin.com/in/mariano-damian-abadie/)
