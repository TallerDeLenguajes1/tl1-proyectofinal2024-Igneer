# Colosseum RPG
## Sobre el juego
Luego de que te sucede un accidente, reencarnas en otro mundo...
No sabes cómo fue que paso pero tienes que sobrevivir en el coliseo en el que te encuentras, teniendo que luchar contra enemigos de distintas razas que se encuentran en tu misma situacion. Buena suerte en tu aventura.
## Estructura del Juego
El juego se encuentra estructurado mediante una estructura de dato que se denomina Pila, gracias a ella, la ejecucion del juego se basa en ir apilando y desapilando los distintos estados. Cada estado hereda de la clase Estados, el metodo Update() y lo sobreescribe con lo correspondiente a cada uno. Se puede guardar una partida en curso, como consultar todos los personajes que sobrevivieron y pasaron al Hall de la Fama mediante archivos JSON.
## Cómo jugar
1. Necesitas clonar el repositorio, que lo puedes hacer con el siguiente comando: 
```sh
git clone https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-Igneer.git
```
2. Vé a la ruta donde clonaste el repositorio:
```sh
cd rutaDondeEstaElRepositorio
```
3. Y listo, solo queda ejecutarlo y disfrutar:
```sh
dotnet run
```
## Requisitos
- .NET Core SDK 8.0 o superior
## API  
Se utilizo D&D 5e SRD API para poder mostrar la raza de los enemigos que van surgiendo durante la aventura. Si quieres saber mas sobre la API, puedes visitar el siguiente enlace: https://5e-bits.github.io/docs/.
