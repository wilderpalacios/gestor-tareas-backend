# 📌 Gestor de Tareas - Backend  

Este es el **backend** del sistema de gestión de tareas, desarrollado con **.NET 8**. Proporciona una API RESTful para administrar tareas, incluyendo operaciones CRUD y actualización de estados.  

## 🚀 Tecnologías Utilizadas  

- **.NET 9**  
- **Entity Framework Core** (con base de datos en memoria)  
- **CORS** habilitado para comunicación con el frontend  
- **JSON Patch** para actualización parcial de tareas  

## 📦 Requisitos Previos  

Antes de ejecutar el proyecto, asegúrate de tener instalado:  

- **.NET 9 SDK**  
- **Postman** (opcional, para probar la API manualmente)  

## 🛠️ Instalación y Ejecución  

### 1️⃣ Clonar el repositorio  

```sh
git clone https://github.com/tuusuario/gestor-tareas-backend.git  
cd gestor-tareas-backend  
```


### 2️⃣ Restaurar dependencias
```sh
dotnet restore 
```


### 3️⃣ Ejecutar la API
```sh
dotnet run 
```


#### 📌 **Nota**: La API se ejecutará en [http://localhost:5047](http://localhost:5047).


## 📑 Endpoints Principales  


| Método | Endpoint               | Parámetros        | Descripción                                     |
|--------|------------------------|-------------------|-------------------------------------------------|
| GET    | `/api/tasks`           | `?status`         | Obtiene todas las tareas o filtra por estado.   |
| GET    | `/api/tasks/{id}`      | `id` (número)     | Obtiene una tarea por su ID.                    |
| POST   | `/api/tasks`           | `title`, `status` | Crea una nueva tarea.                           |
| PATCH  | `/api/tasks/{id}`      | `id` (número), `status` | Actualiza el estado de la tarea.          |
| DELETE | `/api/tasks/{id}`      | `id` (número)     | Elimina una tarea.                              |


### Ejecutar pruebas
```sh
dotnet test
```

## 📌 Consideraciones Finales  

- No se usa una base de datos persistente, las tareas se almacenan en memoria.  
- Para restablecer los datos, basta con reiniciar la API.  
- Se puede modificar `launchSettings.json` para cambiar el puerto si es necesario.  

## 📄 Licencia  

Proyecto de código abierto bajo la licencia **MIT**.  

